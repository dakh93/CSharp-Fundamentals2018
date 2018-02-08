using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _08.FullDirectoryTraversal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var path = Console.ReadLine();

            
            string[] subDirectories = 
                Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

            var dict = new Dictionary<string, List<FileInfo>>();

            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;

                if (!dict.ContainsKey(extension))
                {
                    dict[extension] = new List<FileInfo>();
                }

                dict[extension].Add(fileInfo);
            }

            foreach (var subDirectory in subDirectories)
            {

                var subFiles = Directory.GetFiles(subDirectory);

                foreach (var file in subFiles)
                {
                    var fileInfo = new FileInfo(file);
                    var extension = fileInfo.Extension;

                    if (!dict.ContainsKey(extension))
                    {
                        dict[extension] = new List<FileInfo>();
                    }

                    dict[extension].Add(fileInfo);
                }
            }

            dict = dict.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullFileName = desktop + "/report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                foreach (var pair in dict)
                {
                    string extension = pair.Key;
                    writer.WriteLine(extension);

                    var fileInfos = pair.Value
                        .OrderByDescending(f => f.Length);

                    foreach (var fileinfo in fileInfos)
                    {
                        double fileSize = (double)fileinfo.Length / 1024;
                        writer.WriteLine($"--{fileinfo.Name} - {fileSize:f3}kb");
                    }
                }
            }

        }
    }
}
