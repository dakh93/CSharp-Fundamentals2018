using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CustomComparator
{
    class StartUp
    {
        static void Main()
        {
            var numbers =
                Console.ReadLine()
                    .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            Func<List<int>, List<int>> sortNums = SortEvenOddNums;

            Console.WriteLine(String.Join(" ", sortNums(numbers)));
        }

        private static List<int> SortEvenOddNums(List<int> nums)
        {
            var evenSort = new List<int>();
            var oddSort = new List<int>();

            var sortedResult = new List<int>();
            foreach (var num in nums)
            {
                if (num % 2 == 0)
                {
                    evenSort.Add(num);
                }
                else
                {
                    oddSort.Add(num);
                }
            }

            evenSort.Sort();
            oddSort.Sort();
            foreach (var num in evenSort)
            {
                sortedResult.Add(num);
            }

            foreach (var num in oddSort)
            {
                sortedResult.Add(num);
            }

            return sortedResult;
        }
    }
}
