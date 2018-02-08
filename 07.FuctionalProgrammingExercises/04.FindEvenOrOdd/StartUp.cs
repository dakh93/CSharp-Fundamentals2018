using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvenOrOdd
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var range =
                Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
          

            var typeNums = Console.ReadLine();

            Func<int[], string, List<int>> filteredNums = FilteredNums;

            var result = filteredNums(range, typeNums);

            PrintResult(result);

        }

        private static void PrintResult(List<int> result)
        {
            Console.WriteLine(String.Join(" ", result));
        }

        private static List<int> FilteredNums(int[] range, string commandType)
        {
            var start = range[0];
            var end = range[1];
            var filtered = new List<int>();
            if (commandType == "even")
            {
                for (int i = start; i <= end; i++)
                {
                    if (i % 2 == 0)
                    {
                        filtered.Add(i);
                    }
                }
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    if (i % 2 != 0)
                    {
                        filtered.Add(i);
                    }
                }
            }
            return filtered;
        }
    }
}
