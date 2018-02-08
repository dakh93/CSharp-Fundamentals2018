using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartiReservationFilterModule
{
    public class Person
    {
        public string Name { get; set; }
        public bool IsInList { get; set; }
    }
    public static class MyExtensions
    {
        public static List<Person> AddFilter(
            this List<Person> dict,
            Func<string, bool> checker)
        {
            List<Person> result = new List<Person>();

            foreach (var person in dict)
            {
                Person currP = new Person();
                if (checker(person.Name))
                {
                    currP.Name = person.Name;
                    currP.IsInList = false;

                    result.Add(currP);
                }
                else
                {
                    currP.Name = person.Name;
                    currP.IsInList = person.IsInList;

                    result.Add(currP);
                }
            }
            return result;
        }

        public static  List<Person> RemoveFilter(
            this List<Person> dict,
            Func<string, bool> checker)
        {
            List<Person> result = new List<Person>();

            foreach (var person in dict)
            {
                Person currP = new Person();
                if (checker(person.Name))
                {
                    currP.Name = person.Name;
                    currP.IsInList = true;

                    result.Add(currP);
                }
                else
                {
                    currP.Name = person.Name;
                    currP.IsInList = person.IsInList;

                    result.Add(currP);
                }
            }
            return result;
        }


        class StartUp
        {
            static void Main()
            {
                var invited =
                    Console.ReadLine()
                        .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                List<Person> dict = new List<Person>();

                FillGuests(dict, invited);


                var data = Console.ReadLine().Split(';').ToArray();
                while (data.Length > 1)
                {
                    string filterType = data[0];
                    string criteria = data[1];
                    string parameter = data[2];

                    if (filterType == "Add filter")
                    {
                        switch (criteria)
                        {
                            case "Starts with":
                                dict = dict.AddFilter(g => g.StartsWith(parameter));
                                break;
                            case "Ends with":
                                dict = dict.AddFilter(g => g.EndsWith(parameter));
                                break;
                            case "Length":
                                dict = dict.AddFilter(g => g.Length == int.Parse(parameter));
                                break;
                            case "Contains":
                                dict = dict.AddFilter(g => g.Contains(parameter));
                                break;
                        }
                    }
                    else if (filterType == "Remove filter")
                    {
                        switch (criteria)
                        {
                            case "Starts with":
                                dict = dict.RemoveFilter(g => g.StartsWith(parameter));
                                break;
                            case "Ends with":
                                dict = dict.RemoveFilter(g => g.EndsWith(parameter));
                                break;
                            case "Length":
                                dict = dict.RemoveFilter(g => g.Length == int.Parse(parameter));
                                break;
                            case "Contains":
                                dict = dict.RemoveFilter(g => g.Contains(parameter));
                                break;
                        }
                    }

                    data = Console.ReadLine().Split(';').ToArray();
                }


                var result =new List<string>();
                foreach (var person in dict)
                {
                    if (person.IsInList == true)
                    {
                        result.Add(person.Name);
                    }
                }

                Console.WriteLine(string.Join(" ", result));
            }

            private static void FillGuests(List<Person> dict, List<string> invited)
            {
                foreach (var person in invited)
                {
                    Person currentPerson = new Person();

                    currentPerson.Name = person;
                    currentPerson.IsInList = true;
                    
                    dict.Add(currentPerson);

                }
            }
        }
    }
}
