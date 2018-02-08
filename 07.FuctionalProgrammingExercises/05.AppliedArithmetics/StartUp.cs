using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputNums = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, string, List<int>> changeNumsValues = ChangeNumsValues;
            var command = Console.ReadLine();

            while (command != "end")
            {
                var result = changeNumsValues(inputNums, command);
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ",result));
                }

                    command = Console.ReadLine();
            }
        }

        private static List<int> ChangeNumsValues(List<int> inputNums, string command)
        {
            if (command == "add")
            {
                for (int i = 0; i < inputNums.Count; i++)
                {
                    inputNums[i]++;
                }
            }
            else if (command == "multiply")
            {
                for (int i = 0; i < inputNums.Count; i++)
                {
                    inputNums[i] *= 2;
                }
            }
            else if (command == "subtract")
            {
                for (int i = 0; i < inputNums.Count; i++)
                {
                    inputNums[i]--;
                }
            }
            return inputNums;
        }
    }
}
