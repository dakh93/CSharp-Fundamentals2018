using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var divisor = int.Parse(Console.ReadLine());

            Func<List<int>, int, List<int>> nonDivisible = CheckForNonDivisible;

            Console.WriteLine(string.Join(" ",nonDivisible(numbers, divisor)));
        }

        private static List<int> CheckForNonDivisible(List<int> nums, int divisor)
        {
            var nonDivisible = new List<int>();

            for (int i = nums.Count - 1; i >= 0; i--)
            {
                var num = nums[i];
                
                if (num % divisor != 0)
                {
                    nonDivisible.Add(num);
                }
            }
            return nonDivisible;
        }
    }
}
