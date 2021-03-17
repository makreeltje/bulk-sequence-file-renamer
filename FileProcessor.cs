using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace bulk_sequence_file_renamer
{
    public class FileProcessor
    {
        public void FindFile(string directory, string subDirectories, string fileNamePrefix, string totalDigits)
        {
            FileInfo[] files = null;
            DirectoryInfo info = new DirectoryInfo(directory);
            string fmt = "";

            for (int j = 0; j < Convert.ToInt32(totalDigits); j++)
            {
                fmt += "0";
            }

            string formatString = " {0,15:" + fmt + "}";

            if (subDirectories == "y")
            {
                //Find files in given directory and sub-directories (excluding path name)
                files = info.GetFiles("*", SearchOption.AllDirectories).OrderBy(p => p.CreationTime).ToArray();
            }
            else
            {
                // Find files in given directory (excluding path name)
                files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
            }

            int i = 1;
            foreach (FileInfo file in files)
            {
                Console.WriteLine("Changing " + file.Name + " to " + fileNamePrefix + i.ToString().PadLeft(Convert.ToInt32(totalDigits), '0') + file.Extension);
                file.MoveTo(file.Directory + "\\" + fileNamePrefix + i.ToString().PadLeft(Convert.ToInt32(totalDigits), '0') + file.Extension);
                i++;
            }
        }
    }
}