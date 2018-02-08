using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _05.FilterByAge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var people = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var input =
                    Console.ReadLine()
                        .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                var CurrPerson = input[0];
                var currAge = int.Parse(input[1]);

                people[CurrPerson] = currAge;
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine().Split(' ');

            if (format.Length > 1)
            {

                var filtered = PrintAccordingFormat(condition, age, format, people);

                foreach (var person in filtered)
                {
                    Console.WriteLine($"{person.Key} - {person.Value}");
                }
            }
            else
            {
                var filtered = new List<string>(); 
                if (format[0] == "name")
                {

                    filtered =
                        PrintAccordingFormat(condition, age, format, people).Keys.ToList();

                }
                else if (format[0] == "age")
                {
                    filtered =
                        PrintAccordingFormat(condition, age, format, people)
                        .Values.Select(x => x.ToString()).ToList();
                }

                foreach (var current in filtered)
                {
                    Console.WriteLine(current);
                }
            }
        }

        private static Dictionary<string,int> PrintAccordingFormat(string condition,
            int age, 
            string[] format,
            Dictionary<string, int> people)
        {
            var filtered = new Dictionary<string, int>();
            if (condition == "older")
            {
                 filtered = people.Where(x => x.Value >= age).ToDictionary(x => x.Key, y => y.Value); 
            }
            else if (condition == "younger")
            {
                filtered = people.Where(x => x.Value < age).ToDictionary(x => x.Key, y => y.Value);
            }

            return filtered;
        }

    }
}
