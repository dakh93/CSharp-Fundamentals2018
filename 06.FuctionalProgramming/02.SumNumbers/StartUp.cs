using System;
using System.Linq;

namespace _02.SumNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input =
                Console.ReadLine()
                    .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var numsCount = input.Length;
            var sum = input.Sum();

            Console.WriteLine(numsCount);
            Console.WriteLine(sum);
        }
    }
}
