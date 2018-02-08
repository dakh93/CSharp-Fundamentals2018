using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> results = new Dictionary<string, int>();
            using (var reader = new StreamReader("words.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    results[line] = 0;
                    line = reader.ReadLine();
                }
            }
            //COUNTING EQUAL WORDS
            using (var reader = new StreamReader("text.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    line = line.ToLower();
                    var currWords =
                        line
                            .Split(new char[] {' ', ',', '-', '!', '?', '.'}, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                    for (int word = 0; word < currWords.Length; word++)
                    {

                        if (results.ContainsKey(currWords[word]))
                        {
                            results[currWords[word]] += 1;
                        }
                    }
                    line = reader.ReadLine();
                }


            }

            using (var writer = new StreamWriter("result.txt"))
            {

                foreach (var word in results.OrderByDescending(key => key.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
