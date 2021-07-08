using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileExercises
{
    public class FileService
    {
        public static void CreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
        }
    }
}
