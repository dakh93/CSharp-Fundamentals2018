using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Func<string, string> names =
                s => s;
            var input =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var strings = input.Select(names);

            foreach (var s in strings)
            {
                Console.WriteLine($"Sir {s}");
            }
        }
    }
}
