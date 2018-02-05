using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GroupNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input =
                Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            List<int> zero = new List<int>();
            List<int> one = new List<int>();
            List<int> two = new List<int>();
            foreach (var number in input)
            {
                if (Math.Abs(number % 3) == 0)
                {
                    zero.Add(number);
                }
                if (Math.Abs(number % 3) == 1)
                {
                    one.Add(number);
                }
                if (Math.Abs(number % 3) == 2)
                {
                    two.Add(number);
                }
            }

            Console.WriteLine(String.Join(" ", zero));
            Console.WriteLine(String.Join(" ", one));
            Console.WriteLine(String.Join(" ", two));
        }
    }
}
