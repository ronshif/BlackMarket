using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackMarket.DemoData
{
    public static class FileManager
    {
        private static long maximumFileSize = 1500; // measure unit is bytes
        private static int i = 1;
        private const string rootDirPath = @"c:\Output";

        static FileManager()
        {
           Directory.CreateDirectory(rootDirPath);
        }

        private static string FilePath
        {
            get
            {
                return Path.Combine(rootDirPath + "\\", FileName);
            }
        }

        private static string FileName
        {
            get
            {
                return String.Format("log_{0}",i.ToString());
            }
        }

        public static void SaveLine(string line)
        {
            if(File.Exists(FilePath) && new FileInfo(FilePath).Length > maximumFileSize)
            {
                // move to the next file
                i++;
            }
            using (StreamWriter w = File.AppendText(FilePath))
            {
                w.WriteLine(line);
            }    
        }
    }
}
