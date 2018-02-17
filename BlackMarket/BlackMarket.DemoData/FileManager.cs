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
        private static long maximumFileSize = 40000; // measure unit is bytes
        private static int i = 1;
        private const string rootDirPath = @"c:\DemoData";
        private static string PL_NAME = "Bitfinex";
        private static object obj;
        static FileManager()
        {
            if (Directory.Exists(rootDirPath))
            {
                string[] filePaths = Directory.GetFiles(rootDirPath);
                foreach (string filePath in filePaths)
                {
                    File.Delete(filePath);
                }
            }
            else
            {
                Directory.CreateDirectory(rootDirPath);
            }
            obj = new Object();
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
                return String.Format("{0}_log_{1}",PL_NAME,i.ToString());
            }
        }

        internal static void AppendResponse(TickerResponse response)
        {
            if (response == null)
            {
                return;
            }
            lock (obj)
            {
                if (File.Exists(FilePath) && new FileInfo(FilePath).Length > maximumFileSize)
                {
                    // move to the next file
                    i++;
                }

                try
                {
                    using (StreamWriter w = File.AppendText(FilePath))
                    {
                        Console.WriteLine(String.Format("Response: {0}", response.jsonResponse));
                        Console.WriteLine(String.Format("Appending response to log file {0}",FileName));

                        w.WriteLine(response.jsonResponse);
                    }
                }
                catch (IOException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

    }
}
