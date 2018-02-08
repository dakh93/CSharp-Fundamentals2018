using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    public class Person
    {
        public string Name { get; set; }
        public bool IsInList { get; set; }
    }
    public static class MyExtensions
    {
        public static List<Person> Remove(
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

        public static List<Person> DoubleFIlter(
            this List<Person> dict,
            Func<string, bool> checker)
        {
            List<Person> result = new List<Person>();

            foreach (var person in dict)
            {
                Person currP = new Person();
                if (checker(person.Name) && person.IsInList == true)
                {
                    currP.Name = person.Name;
                    currP.IsInList = true;

                    result.Add(currP);
                    result.Add(currP);

                }
                else if (person.IsInList == true)
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
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                List<Person> dict = new List<Person>();

                FillGuests(dict, invited);


                var data = Console.ReadLine().Split(' ').ToArray();
                while (data.Length > 1)
                {
                    string filterType = data[0];
                    string criteria = data[1];
                    string parameter = data[2];

                    if (filterType == "Remove")
                    {
                        switch (criteria)
                        {
                            case "StartsWith":
                                dict = dict.Remove(g => g.StartsWith(parameter));
                                break;
                            case "EndsWith":
                                dict = dict.Remove(g => g.EndsWith(parameter));
                                break;
                            case "Length":
                                dict = dict.Remove(g => g.Length == int.Parse(parameter));
                                break;
                           
                        }
                    }
                    else if (filterType == "Double")
                    {
                        switch (criteria)
                        {
                            case "StartsWith":
                                dict = dict.DoubleFIlter(g => g.StartsWith(parameter));
                                break;
                            case "EndsWith":
                                dict = dict.DoubleFIlter(g => g.EndsWith(parameter));
                                break;
                            case "Length":
                                dict = dict.DoubleFIlter(g => g.Length == int.Parse(parameter));
                                break;
                          
                        }
                    }

                    data = Console.ReadLine().Split(' ').ToArray();
                }


                var result = new List<string>();
                foreach (var person in dict)
                {
                    if (person.IsInList == true)
                    {
                        result.Add(person.Name);
                    }
                }


                if (result.Count > 0)
                {
                    Console.WriteLine(string.Join(", ", result) + " are going to the party!");
                }
                else
                {
                    Console.WriteLine("Nobody is going to the party!");
                }
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
