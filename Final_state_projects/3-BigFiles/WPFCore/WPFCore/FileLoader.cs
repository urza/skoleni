using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPFCore
{
    class FileLoader
    {
        public static IEnumerable<string> LoadAllFiles(CancellationToken cancelToken)
        {
            string dir = @"C:\PROJECTS\IctPro\CNET2-STUDENTI-GIT\3-BigFiles\data";
            DirectoryInfo di = new DirectoryInfo(dir);
            var files = di.EnumerateFiles("*.txt");

            List<string> result = new List<string>();

            foreach (var file in files)
            {
                System.IO.StreamReader open = new System.IO.StreamReader(file.FullName);

                string word;
                Task.Delay(500).Wait();

                while ((word = open.ReadLine()) != null)
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        return result;
                    }
                    result.Add(word);
                }
            }

            return result;
        }
    }
}
