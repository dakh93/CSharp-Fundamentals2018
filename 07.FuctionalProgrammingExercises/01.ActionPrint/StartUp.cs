using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ActionPrint
{
    class StartUp
    {
        static void Main(string[] args)
        {

            Func<string, string> names =
                s => s;
            var input =
                Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var strings = input.Select(names);

            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }

        }
    }
}
