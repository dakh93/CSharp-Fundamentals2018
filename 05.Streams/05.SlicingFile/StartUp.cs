using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace _05.SlicingFile
{
    class StartUp
    {
        private const int bufferSize = 4096;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string sourceFile = "../resources/sliceMe.mp4";
            string destination = "";

            var files = new List<string>();
            var zippedFiles = new List<string>();

            Slice(sourceFile, destination, n, files);

            Assemble(files, destination);

            Zip(sourceFile, destination, n, files, zippedFiles);

            DeZip(files, destination, zippedFiles);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts, List<string> files)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.')+ 1);
                long pieceSize =(long)Math.Ceiling((double) reader.Length / parts);
                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;  
                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    string currentPart = destinationDirectory + $"Part-{i}.{extension}";
                    files.Add($"Part-{i}.{extension}");
                    using (var writer = new FileStream(currentPart, FileMode.Create))
                    {
                        byte[] buffer = new byte[bufferSize];

                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPieceSize += bufferSize;
                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files.First().Substring(files.First().LastIndexOf('.') + 1);

            if (destinationDirectory == String.Empty)
            {
                destinationDirectory = "./";
            }
            if (!destinationDirectory.EndsWith("/") )
            {
                destinationDirectory += "/";
            }

            string assebledFile = $"{destinationDirectory}Assembled.{extension}";

            using (FileStream writer = new FileStream(assebledFile, FileMode.Create))
            {
                byte[] buffer = new byte[bufferSize];
                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }

        static void Zip(string sourceFile, string destinationDirectory, int parts, List<string> files, List<string> zippedFiles)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);
                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;
                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    string currentPart = destinationDirectory + $"Part-{i}.{extension}.gz";
                    zippedFiles.Add($"Part-{i}.{extension}.gz");
                    using (var writer = new GZipStream(new FileStream(currentPart, FileMode.Create), CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[bufferSize];

                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPieceSize += bufferSize;
                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void DeZip(List<string> files, string destinationDirectory, List<string> zippedFiles)
        {
            string extension = files.First().Substring(files.First().LastIndexOf('.') + 1);

            if (destinationDirectory == String.Empty)
            {
                destinationDirectory = "./";
            }
            if (!destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }

            string assebledFile = $"{destinationDirectory}AssembledDecompressed.{extension}";

            using (var writer = new FileStream(assebledFile, FileMode.Create))
            {
                byte[] buffer = new byte[bufferSize];
                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }

    }
}
