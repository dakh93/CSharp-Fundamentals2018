using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PridicateForNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int lenghtAllowed = int.Parse(Console.ReadLine());

            var names =
                Console.ReadLine()
                    .Split(' ')
                    .ToList();

            Func<List<string>, int, List<string>> filteredNames = FilterNamesByLength;
            PrintFilterNames(filteredNames(names, lenghtAllowed));
        }

        private static void PrintFilterNames(List<string> filteredNames)
        {
            foreach (string name in filteredNames)
            {
                Console.WriteLine(name);
            }
        }

        private static List<string> FilterNamesByLength(List<string> names, int lengthAllowed)
        {
            var filteredNames = new List<string>();

            foreach (string name in names)
            {
                if (name.Length <= lengthAllowed)
                {
                    filteredNames.Add(name);
                }
            }

            return filteredNames;
        }
    }
}
