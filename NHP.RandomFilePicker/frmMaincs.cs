using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using OGB.General.Performance;

namespace NHP.RandomFilePicker
{
    
    public partial class frmMaincs : Form
    {
        class MoveFile
        {
            public String source;
            public String destination;
            public DateTime dateAdded;

            public MoveFile(String prmSource, String prmDestination)
            {
                source = prmSource;
                destination = prmDestination;
                dateAdded = DateTime.Now;
            }

        }
        Dictionary<string, string[]> dictSourceDestination = new Dictionary<string, string[]>();
        //Dictionary<string, clsFileStat> dictFiles = null;
        clsFileListManager FileListManager = null;
        string LastFile = String.Empty;
        Random Rand = new Random();
        List<MoveFile> lstMove = new List<MoveFile>();
        System.Threading.Thread thrMove;
        DateTime LastClick = DateTime.MaxValue;
        clsStatInfo StatInfo = new clsStatInfo();
        int TotalValue = 0;//TotalValueStart = 0;
        int RoundRobin = -1;
        double specialMoveCredits = Math.Pow(1024, 4);
        long currentFileSize = 0;

        public frmMaincs()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            thrMove = new System.Threading.Thread(new System.Threading.ThreadStart(Moving));
            thrMove.Start();
        }

        private void btnRandomPick_Click(object sender, EventArgs e)
        {
            ExecuteNext(true, true,"");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string LastFileTemp = LastFile;

            ExecuteNext(false, false,"");
            if (MessageBox.Show("Are you sure?", "Delete File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    System.IO.File.Delete(LastFileTemp);
                }
                catch (Exception)
                {}
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void ExecuteNext(bool prmMinimize, bool prmMoveFile, string prmDestination)
        {
            LastClick = DateTime.Now;

            int DaysSinceCreate;

            if (prmMinimize && chkMinimize.Checked)
            {
                this.WindowState = FormWindowState.Minimized;
                Application.DoEvents();
            }

            if (FileListManager == null)
            {
                dictSourceDestination = new Dictionary<string, string[]>();
                string[] Folders = OGB.General.Text.clsSegment.SplitRow(txtSourceAndDestination.Text);
                string Source, Destination, SpecialMove, DeleteAway;
                clsFileStat FileInfo = null;

                foreach (string Row in Folders)
                {
                    String[] rowSplit = Row.Split('\t');
                    SpecialMove = "";
                    DeleteAway = "";

                    Source = rowSplit[0];
                    Destination = rowSplit[1];
                    if (rowSplit.Length > 2)
                        SpecialMove = rowSplit[2];


                    if (rowSplit.Length > 3)
                        DeleteAway = rowSplit[3];

                    dictSourceDestination.Add(Source, new String[] { Destination, SpecialMove, DeleteAway });

                    saveLastConfig();
                }

                //dictFiles = new Dictionary<string, clsFileInfo>();
                FileListManager = new clsFileListManager();

                foreach (KeyValuePair<string, string[]> KeyValue in dictSourceDestination)
                {
                    if (System.IO.Directory.Exists(KeyValue.Key))
                    {
                        //foreach (string File in System.IO.Directory.GetFiles(KeyValue.Key,"*.*",SearchOption.AllDirectories))
                        foreach (string File in System.IO.Directory.GetFiles(KeyValue.Key))
                        {
                            FileListManager.Add(File);
                        }
                    }
                }

                //TotalValueStart = dictFiles.Count;
            }

            string FileNameNew = String.Empty;

            {
                int Temp;
                if (Int32.TryParse(txtRoundRobin.Text, out Temp) && Temp > 0)
                {
                    //First time
                    if (RoundRobin == -1)
                        RoundRobin = Temp;

                    if (RoundRobin == 0)
                    {
                        //Next in combo
                        if (cmbRandomStrategy.SelectedIndex + 1 < cmbRandomStrategy.Items.Count)
                            cmbRandomStrategy.SelectedIndex = cmbRandomStrategy.SelectedIndex + 1;
                        else
                            cmbRandomStrategy.SelectedIndex = 0;

                        Temp++;
                        RoundRobin = Temp;
                        txtRoundRobin.Text = Temp.ToString();
                    }

                    RoundRobin--;
                }
            }




            if (cmbRandomStrategy.Text == "Flat")
            {
                FileNameNew = PickAFileRandomFlat();
            }
            else if (cmbRandomStrategy.Text == "Size Big")
            {
                FileNameNew = FileListManager.PickLargestSize();
            }
            else if (cmbRandomStrategy.Text == "Size Small")
            {
                FileNameNew = FileListManager.PickSmallestSize();
            }
            else if (cmbRandomStrategy.Text == "Name")
            {
                FileNameNew = FileListManager.PickName();
            }
            else if (cmbRandomStrategy.Text == "Name Reverse")
            {
                FileNameNew = FileListManager.PickNameReverse();
            }
            //FileNameNew = PickAFileRandomWeight();


            Process p = new Process();
            ProcessStartInfo pi = new ProcessStartInfo();
            pi.UseShellExecute = true;
            pi.FileName = FileNameNew;
            p.StartInfo = pi;
            p.Start();

            if (prmMoveFile && String.IsNullOrEmpty(LastFile) == false)
            {
                String FileName = System.IO.Path.GetFileName(LastFile);
                string PathOnly = System.IO.Path.GetDirectoryName(LastFile);
                String NewPath = System.IO.Path.Combine(dictSourceDestination[PathOnly][0], FileName);

                //Provided with special Destination
                if (String.IsNullOrEmpty(prmDestination) == false)
                    NewPath = System.IO.Path.Combine(prmDestination, FileName);

                lock (lstMove)
                {
                    lstMove.Add(new MoveFile(LastFile, NewPath));
                }


            }

            //Handle last file
            {
                specialMoveCredits += currentFileSize / 10;
            }

            ProgressUpdate(0, FileListManager.StartCount, FileListManager.StartCount - FileListManager.dictFiles.Count, "");

            string parentPath = System.IO.Path.GetDirectoryName(FileNameNew);
            String[] pathInfo = dictSourceDestination[parentPath];
            LastFile = FileNameNew;
            txtLastFile.Text = LastFile;
            txtSpecialMove.Text = pathInfo[1];
            txtDeleteAway.Text = pathInfo[2];
            currentFileSize = new FileInfo(FileNameNew).Length;
            txtFileSize.Text = ((double)currentFileSize / 1024d / 1024d).ToString("#,0.00 MB");
            txtSpecialMoveCredits.Text = ((double)specialMoveCredits / 1024d / 1024d).ToString("#,0 MB");

            if (specialMoveCredits > currentFileSize)
                btnSpecialMovie.Enabled = true;
            else
                btnSpecialMovie.Enabled = false;
        }
        private void Moving()
        {
            while (1 == 1)
            {
                MoveFile moveFile;
                int movedThisLoop = 0;
                for (int i = lstMove.Count - 1; i >= 0; i--)
                {
                    moveFile = lstMove[i];
                    if (
                        (
                        //Same Drive
                        moveFile.source.Substring(0, 1) == moveFile.destination.Substring(0, 1) ||
                        //Last Click
                        DateTime.Now.Subtract(LastClick).TotalSeconds > 400 ||
                        //List Too Long
                        lstMove.Count > 200
                        )
                        //File is not locked
                        && DateTime.Now.Subtract(moveFile.dateAdded).TotalSeconds > 60
                        )
                    {
                        lock (lstMove)
                        {
                            lstMove.RemoveAt(i);
                            moveTheFile(moveFile);

                            movedThisLoop++;

                            moveFileStats();
                        }
                    }

                }

                if (movedThisLoop > 0)
                {
                    double totalMBMoved = totalBytesMoved / 1024 / 1024;
                    addLog("Total Moved: " + totalMBMoved.ToString("#,0") + " MB");
                }
                moveFileStats();

                System.Threading.Thread.Sleep(5000);
            }
        }
        private void moveFileStats()
        {
            txtMoveCount.Text = lstMove.Count.ToString("#,0");
            txtMoveDone.Text = StatInfo.GetINT("Move.Done").ToString();
            txtMoveError.Text = StatInfo.GetINT("Move.Error").ToString();
        }

        private long totalBytesMoved = 0;
        private void moveTheFile(MoveFile moveFile)
        {
            try
            {
                if (System.IO.File.Exists(moveFile.destination) == false)
                {
                    FileInfo fileInfo = new FileInfo(moveFile.source);
                    double MBSize = fileInfo.Length / 1024 / 1024;

                    addLog("Begin " + moveFile.source + " (" + MBSize.ToString("#,0") + " MB)");
                    DateTime startMove = DateTime.Now;
                    System.IO.File.Move(moveFile.source, moveFile.destination);
                    StatInfo.ValueInc("Move.Done");
                    TimeSpan moveTimestamp = DateTime.Now.Subtract(startMove);
                    addLog("Done " + moveFile.source + " (" + moveTimestamp.TotalSeconds.ToString("0") + " sec)");

                    totalBytesMoved += (long)fileInfo.Length;
                }
                else if ((new FileInfo(moveFile.destination)).Length == (new FileInfo(moveFile.source)).Length)
                {
                    System.IO.File.Delete(moveFile.destination);
                    System.IO.File.Move(moveFile.source, moveFile.destination);
                    StatInfo.ValueInc("Move.Done");
                }
                else
                {
                    StatInfo.ValueInc("Move.Exists");
                }
            }
            catch (Exception ex)
            {
                addLog("ERROR: moving '" + moveFile.source + "' GOT:" + ex.Message);
                StatInfo.ValueInc("Move.Error");
            }
        }

        private string PickAFileRandomFlat()
        {
            string Result = String.Empty;

            int NextValue = Rand.Next(0, FileListManager.dictFiles.Count);
            foreach (KeyValuePair<string, clsFileStat> KeyValue in FileListManager.dictFiles)
            {
                NextValue--;
                if (NextValue <= 0)
                {
                    Result = KeyValue.Key;
                    break;
                }
            }
            FileListManager.dictFiles.Remove(Result);

            return Result;
        }
   

        private DateTime ProgressUpdateLast = DateTime.MinValue;
        public void ProgressUpdate(int prmMin, int prmMax, int prmCurrent, string prmProcessName)
        {
            if (DateTime.Now.Subtract(ProgressUpdateLast).TotalSeconds > 1)
            {
                double Percent = ((double)prmCurrent / (double)prmMax) * 100;
                pgbMain.Minimum = prmMin;
                pgbMain.Maximum = prmMax;
                pgbMain.Value = prmCurrent;
                txtProgressCurrent.Text = prmCurrent.ToString("#,#") + " (" + Percent.ToString("#,0.00") + ")";
                txtProgressMax.Text = prmMax.ToString("#,#");
                ProgressUpdateLast = DateTime.Now;
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            LastClick = DateTime.MinValue;
        }

        private void btnSpecialMovie_Click(object sender, EventArgs e)
        {
            if (specialMoveCredits > currentFileSize)
            {
                specialMoveCredits -= currentFileSize;
                ExecuteNext(true, true, txtSpecialMove.Text);
            }
            else
            {
                btnRandomPick_Click(sender, e);
            }
        }

        private void frmMaincs_Unload(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnDeleteAway_Click(object sender, EventArgs e)
        {
            specialMoveCredits += (currentFileSize / 2); 
            ExecuteNext(true, true, txtDeleteAway.Text);
        }

        private void loadLastConfig()
        {
            txtSourceAndDestination.Text = System.IO.File.ReadAllText("txtSourceAndDestination");
        }
        private void saveLastConfig()
        {
            System.IO.File.WriteAllText("txtSourceAndDestination", txtSourceAndDestination.Text);
        }

        private void frmMaincs_Load(object sender, EventArgs e)
        {
            loadLastConfig();
            randomStrategyLoad();
        }

        private void randomStrategyLoad()
        {
            //String[] strategies = new String[]{"Flat","Size Big","Size Small","Name","Name Reverse"};
            //String[] strategies = new String[]{"Flat","Size Small"};
            String[] strategies = new String[] { "Size Big", "Size Small" };

            foreach(String strategy in strategies)
                cmbRandomStrategy.Items.Add(strategy);
        }

        public void addLog(String message)
        {
            txtLog.Text = DateTime.Now.ToString() + " " +  message + "\r\n" + txtLog.Text;
        }

    }


}
