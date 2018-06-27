using System.Windows.Forms;
namespace NHP.RandomFilePicker
{
    partial class frmMaincs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaincs));
            this.txtSourceAndDestination = new System.Windows.Forms.TextBox();
            this.btnRandomPick = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblProgressOf = new System.Windows.Forms.Label();
            this.txtProgressMax = new System.Windows.Forms.TextBox();
            this.txtProgressCurrent = new System.Windows.Forms.TextBox();
            this.pgbMain = new System.Windows.Forms.ProgressBar();
            this.txtLastFile = new System.Windows.Forms.TextBox();
            this.txtMoveCount = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.txtMoveDone = new System.Windows.Forms.TextBox();
            this.txtMoveError = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRandomStrategy = new System.Windows.Forms.ComboBox();
            this.txtRoundRobin = new System.Windows.Forms.TextBox();
            this.btnSpecialMovie = new System.Windows.Forms.Button();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.txtSpecialMove = new System.Windows.Forms.TextBox();
            this.txtDeleteAway = new System.Windows.Forms.TextBox();
            this.btnDeleteAway = new System.Windows.Forms.Button();
            this.txtSpecialMoveCredits = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.chkMinimize = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtSourceAndDestination
            // 
            this.txtSourceAndDestination.Location = new System.Drawing.Point(12, 12);
            this.txtSourceAndDestination.Multiline = true;
            this.txtSourceAndDestination.Name = "txtSourceAndDestination";
            this.txtSourceAndDestination.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSourceAndDestination.Size = new System.Drawing.Size(609, 83);
            this.txtSourceAndDestination.TabIndex = 0;
            this.txtSourceAndDestination.Text = "Y:\\Download\\uTorrent\\Completed\tY:\\NotProtected\tY:\\NoDelete\tY:\\DeleteAway";
            // 
            // btnRandomPick
            // 
            this.btnRandomPick.Location = new System.Drawing.Point(12, 129);
            this.btnRandomPick.Name = "btnRandomPick";
            this.btnRandomPick.Size = new System.Drawing.Size(609, 80);
            this.btnRandomPick.TabIndex = 2;
            this.btnRandomPick.Text = "Random Pick";
            this.btnRandomPick.UseVisualStyleBackColor = true;
            this.btnRandomPick.Click += new System.EventHandler(this.btnRandomPick_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(522, 213);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblProgressOf
            // 
            this.lblProgressOf.AutoSize = true;
            this.lblProgressOf.Location = new System.Drawing.Point(530, 296);
            this.lblProgressOf.Name = "lblProgressOf";
            this.lblProgressOf.Size = new System.Drawing.Size(18, 13);
            this.lblProgressOf.TabIndex = 55;
            this.lblProgressOf.Text = "Of";
            // 
            // txtProgressMax
            // 
            this.txtProgressMax.Location = new System.Drawing.Point(554, 295);
            this.txtProgressMax.Name = "txtProgressMax";
            this.txtProgressMax.Size = new System.Drawing.Size(67, 20);
            this.txtProgressMax.TabIndex = 54;
            this.txtProgressMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProgressCurrent
            // 
            this.txtProgressCurrent.Location = new System.Drawing.Point(434, 293);
            this.txtProgressCurrent.Name = "txtProgressCurrent";
            this.txtProgressCurrent.Size = new System.Drawing.Size(90, 20);
            this.txtProgressCurrent.TabIndex = 53;
            this.txtProgressCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pgbMain
            // 
            this.pgbMain.Location = new System.Drawing.Point(12, 290);
            this.pgbMain.Name = "pgbMain";
            this.pgbMain.Size = new System.Drawing.Size(416, 26);
            this.pgbMain.TabIndex = 52;
            // 
            // txtLastFile
            // 
            this.txtLastFile.Location = new System.Drawing.Point(12, 328);
            this.txtLastFile.Name = "txtLastFile";
            this.txtLastFile.Size = new System.Drawing.Size(536, 20);
            this.txtLastFile.TabIndex = 56;
            // 
            // txtMoveCount
            // 
            this.txtMoveCount.Location = new System.Drawing.Point(87, 103);
            this.txtMoveCount.Name = "txtMoveCount";
            this.txtMoveCount.Size = new System.Drawing.Size(31, 20);
            this.txtMoveCount.TabIndex = 58;
            this.txtMoveCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(446, 213);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(75, 23);
            this.btnTransfer.TabIndex = 59;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // txtMoveDone
            // 
            this.txtMoveDone.Location = new System.Drawing.Point(196, 103);
            this.txtMoveDone.Name = "txtMoveDone";
            this.txtMoveDone.Size = new System.Drawing.Size(31, 20);
            this.txtMoveDone.TabIndex = 60;
            this.txtMoveDone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMoveError
            // 
            this.txtMoveError.Location = new System.Drawing.Point(301, 103);
            this.txtMoveError.Name = "txtMoveError";
            this.txtMoveError.Size = new System.Drawing.Size(31, 20);
            this.txtMoveError.TabIndex = 61;
            this.txtMoveError.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Move Queue:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Move Done:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Move Error:";
            // 
            // cmbRandomStrategy
            // 
            this.cmbRandomStrategy.FormattingEnabled = true;
            this.cmbRandomStrategy.Location = new System.Drawing.Point(338, 101);
            this.cmbRandomStrategy.Name = "cmbRandomStrategy";
            this.cmbRandomStrategy.Size = new System.Drawing.Size(121, 21);
            this.cmbRandomStrategy.TabIndex = 65;
            // 
            // txtRoundRobin
            // 
            this.txtRoundRobin.Location = new System.Drawing.Point(472, 102);
            this.txtRoundRobin.Name = "txtRoundRobin";
            this.txtRoundRobin.Size = new System.Drawing.Size(37, 20);
            this.txtRoundRobin.TabIndex = 66;
            this.txtRoundRobin.Text = "5";
            this.txtRoundRobin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSpecialMovie
            // 
            this.btnSpecialMovie.Location = new System.Drawing.Point(220, 214);
            this.btnSpecialMovie.Name = "btnSpecialMovie";
            this.btnSpecialMovie.Size = new System.Drawing.Size(100, 23);
            this.btnSpecialMovie.TabIndex = 68;
            this.btnSpecialMovie.Text = "Special Move";
            this.btnSpecialMovie.UseVisualStyleBackColor = true;
            this.btnSpecialMovie.Click += new System.EventHandler(this.btnSpecialMovie_Click);
            // 
            // txtFileSize
            // 
            this.txtFileSize.Location = new System.Drawing.Point(554, 328);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.Size = new System.Drawing.Size(67, 20);
            this.txtFileSize.TabIndex = 54;
            this.txtFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSpecialMove
            // 
            this.txtSpecialMove.Location = new System.Drawing.Point(12, 216);
            this.txtSpecialMove.Name = "txtSpecialMove";
            this.txtSpecialMove.Size = new System.Drawing.Size(202, 20);
            this.txtSpecialMove.TabIndex = 69;
            // 
            // txtDeleteAway
            // 
            this.txtDeleteAway.Location = new System.Drawing.Point(12, 242);
            this.txtDeleteAway.Name = "txtDeleteAway";
            this.txtDeleteAway.Size = new System.Drawing.Size(202, 20);
            this.txtDeleteAway.TabIndex = 70;
            // 
            // btnDeleteAway
            // 
            this.btnDeleteAway.Location = new System.Drawing.Point(220, 239);
            this.btnDeleteAway.Name = "btnDeleteAway";
            this.btnDeleteAway.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteAway.TabIndex = 71;
            this.btnDeleteAway.Text = "Delete Away";
            this.btnDeleteAway.UseVisualStyleBackColor = true;
            this.btnDeleteAway.Click += new System.EventHandler(this.btnDeleteAway_Click);
            // 
            // txtSpecialMoveCredits
            // 
            this.txtSpecialMoveCredits.Location = new System.Drawing.Point(326, 215);
            this.txtSpecialMoveCredits.Name = "txtSpecialMoveCredits";
            this.txtSpecialMoveCredits.Size = new System.Drawing.Size(81, 20);
            this.txtSpecialMoveCredits.TabIndex = 72;
            this.txtSpecialMoveCredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 354);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(609, 83);
            this.txtLog.TabIndex = 73;
            // 
            // chkMinimize
            // 
            this.chkMinimize.AutoSize = true;
            this.chkMinimize.Checked = true;
            this.chkMinimize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMinimize.Location = new System.Drawing.Point(531, 103);
            this.chkMinimize.Name = "chkMinimize";
            this.chkMinimize.Size = new System.Drawing.Size(66, 17);
            this.chkMinimize.TabIndex = 74;
            this.chkMinimize.Text = "Minimize";
            this.chkMinimize.UseVisualStyleBackColor = true;
            // 
            // frmMaincs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 442);
            this.Controls.Add(this.chkMinimize);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtSpecialMoveCredits);
            this.Controls.Add(this.btnDeleteAway);
            this.Controls.Add(this.txtDeleteAway);
            this.Controls.Add(this.txtSpecialMove);
            this.Controls.Add(this.btnSpecialMovie);
            this.Controls.Add(this.txtRoundRobin);
            this.Controls.Add(this.cmbRandomStrategy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMoveError);
            this.Controls.Add(this.txtMoveDone);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.txtMoveCount);
            this.Controls.Add(this.txtLastFile);
            this.Controls.Add(this.lblProgressOf);
            this.Controls.Add(this.txtFileSize);
            this.Controls.Add(this.txtProgressMax);
            this.Controls.Add(this.txtProgressCurrent);
            this.Controls.Add(this.pgbMain);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRandomPick);
            this.Controls.Add(this.txtSourceAndDestination);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMaincs";
            this.Text = "frmMaincs";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMaincs_Unload);
            this.Load += new System.EventHandler(this.frmMaincs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourceAndDestination;
        private System.Windows.Forms.Button btnRandomPick;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblProgressOf;
        private System.Windows.Forms.TextBox txtProgressMax;
        private System.Windows.Forms.TextBox txtProgressCurrent;
        private System.Windows.Forms.ProgressBar pgbMain;
        private System.Windows.Forms.TextBox txtLastFile;
        private System.Windows.Forms.TextBox txtMoveCount;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox txtMoveDone;
        private System.Windows.Forms.TextBox txtMoveError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRandomStrategy;
        private System.Windows.Forms.TextBox txtRoundRobin;
        private System.Windows.Forms.Button btnSpecialMovie;
        private System.Windows.Forms.TextBox txtFileSize;
        private TextBox txtSpecialMove;
        private TextBox txtDeleteAway;
        private Button btnDeleteAway;
        private TextBox txtSpecialMoveCredits;
        private TextBox txtLog;
        private CheckBox chkMinimize;
    }
}