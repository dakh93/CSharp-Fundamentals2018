using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input =
                Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            Queue<string>  uppercaseWords = new Queue<string>();
            foreach (var word in input)
            {
                if (char.IsUpper(word.First()))
                {
                    uppercaseWords.Enqueue(word);
                }
            }
            var cnt = uppercaseWords.Count;
            for (int i = 0; i < cnt; i++)
            {
                Console.WriteLine(uppercaseWords.Dequeue());
            }
        }
    }
}
