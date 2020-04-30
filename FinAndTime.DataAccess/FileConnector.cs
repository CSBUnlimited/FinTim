using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAndTime.DataAccess
{
    public static class FileConnector
    {
        private static object _lockObject = new object();

        public static void WriteListOfLines(string path, IEnumerable<string> content)
        {
            lock (_lockObject)
            {
                System.IO.File.WriteAllLines(path, content);
            }
        }

        public static void CheckFolder(string path)
        {
            lock (_lockObject)
            {
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
            }
        }

        public static string CombineFolderAndFilePath(string folderPath, string filePath)
        {
            return System.IO.Path.Combine(folderPath, filePath);
        }
    }
}
