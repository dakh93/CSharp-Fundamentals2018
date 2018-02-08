using System;
using System.IO;

namespace _02.LineNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var stream = new StreamReader("text.txt"))
            {
                using (var output = new StreamWriter("output.txt"))
                {
                    var lineCount = File.ReadAllLines("text.txt").Length;
                    for (int line = 1; line <= lineCount; line++)
                    {
                        var lineContent = stream.ReadLine();

                        output.WriteLine($"Line {line}: {lineContent}");
                    }
                   
                    
                }
            }
        }
    }
}
