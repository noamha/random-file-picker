using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NHP.RandomFilePicker
{
    public class clsFileStat
    {
        public FileInfo Info;

        public clsFileStat(FileInfo prmInfo)
        {
            Info = prmInfo;
        }
    }
    public class clsFileListManager
    {
        public Dictionary<string, clsFileStat> dictFiles = new Dictionary<string, clsFileStat>();
        public int StartCount = 0;

        public void Add(string prmFile)
        {
            FileInfo Info;
            clsFileStat FileStat;

            if (System.IO.Path.GetExtension(prmFile).Equals(".db") == false)
            {
                Info = new FileInfo(prmFile);
                FileStat = new clsFileStat(Info);
                dictFiles.Add(prmFile, FileStat);
            }
            StartCount = dictFiles.Count;
        }

        #region Service Function
        public string PickNameReverse()
        {
            string Result = String.Empty;

            string FileName = "";
            string FirstFilename = "";

            foreach (KeyValuePair<string, clsFileStat> KeyValue in dictFiles)
            {
                FileName = System.IO.Path.GetFileName(KeyValue.Key);
                if (FileName.CompareTo(FirstFilename) == 1 ||
                    String.IsNullOrEmpty(FirstFilename))
                {
                    FirstFilename = FileName;
                    Result = KeyValue.Key;
                }
            }
            dictFiles.Remove(Result);

            return Result;
        }
        public string PickName()
        {
            string Result = String.Empty;
            
            string FileName = "";
            string FirstFilename = "";

            foreach (KeyValuePair<string, clsFileStat> KeyValue in dictFiles)
            {
                FileName = System.IO.Path.GetFileName(KeyValue.Key);
                if (FileName.CompareTo(FirstFilename) == -1 ||
                    String.IsNullOrEmpty(FirstFilename))
                {
                    FirstFilename = FileName;
                    Result = KeyValue.Key;
                }
            }
            dictFiles.Remove(Result);

            return Result;
        }
        public string PickSmallestSize()
        {
            string Result = String.Empty;

            long MinValue = -1;
            clsFileStat FileStat;

            foreach (KeyValuePair<string, clsFileStat> KeyValue in dictFiles)
            {
                FileStat = KeyValue.Value;
                if (FileStat.Info.Length < MinValue || MinValue == -1)
                {
                    MinValue = FileStat.Info.Length;
                    Result = KeyValue.Key;
                }
            }
            dictFiles.Remove(Result);

            return Result;
        }
        public string PickLargestSize()
        {
            string Result = String.Empty;

            long MaxValue = 0;
            clsFileStat FileStat;

            foreach (KeyValuePair<string, clsFileStat> KeyValue in dictFiles)
            {
                FileStat = KeyValue.Value;
                if (FileStat.Info.Length > MaxValue)
                {
                    MaxValue = FileStat.Info.Length;
                    Result = KeyValue.Key;
                }
            }
            dictFiles.Remove(Result);

            return Result;
        }
        #endregion

        #region Properties

        #endregion
    }
}
