using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int endPoint = int.Parse(Console.ReadLine());

            int[] divisors =
                Console.ReadLine()
                    .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            Func<int[], int, List<int>> isDivisibleOfArrayNums = CheckIfDivisible;

            Console.WriteLine(String.Join(" ",isDivisibleOfArrayNums(divisors, endPoint) ));
        }

        private static List<int> CheckIfDivisible(int[] divisors, int endPoint)
        {
            var divisible = new List<int>();

            for (int i = 1; i <= endPoint; i++)
            {
                var currNum = i;
                var lamp = 0;

                for (int j = 0; j < divisors.Length; j++)
                {
                    var currDivisor = divisors[j];
                    if (currNum % currDivisor == 0)
                    {
                        lamp++;
                    }
                }
                if (lamp == divisors.Length)
                {
                    divisible.Add(currNum);
                }
            }

            return divisible;
        }
    }
}
