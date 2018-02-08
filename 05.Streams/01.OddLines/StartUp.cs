using System;
using System.IO;

namespace _01.OddLines
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var stream = new StreamReader("text.txt"))
            {
                var line = stream.ReadLine();
                var cnt = 0;
                while (line !=null)
                {
                    if (cnt % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    cnt++;
                    line = stream.ReadLine();
                }
            }
        }
    }
}
