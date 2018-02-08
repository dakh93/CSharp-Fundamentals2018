using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Inferno
{
    public class Gems
    {
        public int number { get; set; }
        public bool isExluded { get; set; }
    }


    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            

            List<Gems> gems = new List<Gems>();
            FillGems(numbers, gems);    

            string[] input = Console.ReadLine().Split(';').ToArray();

            while (input.Length > 1)
            {
                string command = input[0];
                string filter = input[1];
                int parameter = int.Parse(input[2]);

                if (command == "Exclude")
                {
                    string[] side = filter.Split(' ');
                    switch (filter)
                    {
                        case "Sum Left":

                            gems = Exclude(gems, side, parameter);
                            break;
                        case "Sum Right":
                            gems = Exclude(gems, side, parameter);
                            break;
                        case "Sum Left Right":
                            gems = Exclude(gems, side, parameter);
                            break;
                    }
                }
                else if (command == "Reverse")
                {
                    string[] side = filter.Split(' ');
                    switch (filter)
                    {
                        case "Sum Left":

                            gems = Reverse(gems, side, parameter);
                            break;
                        case "Sum Right":
                            gems = Reverse(gems, side, parameter);
                            break;
                        case "Sum Left Right":
                            gems = Reverse(gems, side, parameter);
                            break;
                    }
                }


                input = Console.ReadLine().Split(';').ToArray();
            }

            PrintResult(gems);
        }

        private static List<Gems> Reverse(List<Gems> gems, string[] side, int param)
        {


            var currList = new List<Gems>();
            if (side[1] == "Left" && side.Length == 2)
            {
                FirstGem(currList);

                for (int i = 1; i < gems.Count - 1; i++)
                {
                    Gems currentGem = new Gems();
                    if (gems[i].number + gems[i - 1].number == param)
                    {
                        currentGem.number = gems[i].number;
                        currentGem.isExluded = false;

                    }
                    else
                    {
                        currentGem.number = gems[i].number;
                        currentGem.isExluded = gems[i].isExluded;
                    }
                    currList.Add(currentGem);
                }
                LastGem(currList);
                return currList;
            }
            else if (side[1] == "Right" && side.Length == 2)
            {
                FirstGem(currList);
                for (int i = 1; i < gems.Count - 1; i++)
                {
                    Gems currentGem = new Gems();
                    if (gems[i].number + gems[i + 1].number == param)
                    {
                        currentGem.number = gems[i].number;
                        currentGem.isExluded = false;

                    }
                    else
                    {
                        currentGem.number = gems[i].number;
                        currentGem.isExluded = gems[i].isExluded;
                    }
                    currList.Add(currentGem);
                }
                LastGem(currList);
                return currList;
            }
            else
            {
                FirstGem(currList);
                for (int i = 1; i < gems.Count - 1; i++)
                {
                    var toLeft = gems[i - 1].number;
                    var ToRight = gems[i + 1].number;
                    var currGem = gems[i].number;
                    Gems currentGem = new Gems();
                    if (toLeft + currGem + ToRight == param)
                    {
                        currentGem.number = gems[i].number;
                        currentGem.isExluded = false;

                    }
                    else
                    {
                        currentGem.number = gems[i].number;
                        currentGem.isExluded = gems[i].isExluded;
                    }
                    currList.Add(currentGem);
                }
                LastGem(currList);
                return currList;
            }
            
        }

        private static void PrintResult(List<Gems> gems)
        {
            List<int> result = new List<int>();

            for (int i = 1; i < gems.Count - 1; i++)
            {
                if (!gems[i].isExluded)
                {
                    result.Add(gems[i].number);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }

        private static List<Gems> Exclude(List<Gems> gems, string[] side, int param)
        {
            
            var currList = new List<Gems>();
            if (side[1] == "Left" && side.Length == 2)
            {
                FirstGem(currList);
              
                for (int i = 1; i < gems.Count - 1; i++)
                {
                    Gems currentGem = new Gems();
                    if (gems[i].number + gems[i - 1].number != param)
                    {
                        currentGem.number = gems[i].number;
                        currentGem.isExluded = gems[i].isExluded;

                    }
                    else
                    {
                        currentGem.number = gems[i].number;
                        currentGem.isExluded = true;
                    }
                    currList.Add(currentGem);
                }
                LastGem(currList);
                return currList;
            }
            else if (side[1] == "Right" && side.Length == 2)
            {
                FirstGem(currList);
                for (int i = 1; i < gems.Count - 1; i++)
                {
                    Gems currentGem = new Gems();
                    if (gems[i].number + gems[i + 1].number != param)
                    {
                        currentGem.number = gems[i].number;
                        currentGem.isExluded = gems[i].isExluded;

                    }
                    else
                    {
                        currentGem.number = gems[i].number;
                        currentGem.isExluded = true;
                    }
                    currList.Add(currentGem);
                }
                LastGem(currList);
                return currList;
            }
            else
            {
                FirstGem(currList);
                for (int i = 1; i < gems.Count - 1; i++)
                {
                    var toLeft =gems[i - 1].number;
                    var ToRight = gems[i + 1].number;
                    var currGem = gems[i].number;
                    Gems currentGem = new Gems();
                    if (toLeft + currGem + ToRight != param)
                    {
                        currentGem.number = gems[i].number;
                        currentGem.isExluded = gems[i].isExluded;

                    }
                    else
                    {
                        currentGem.number = gems[i].number;
                        currentGem.isExluded = true;
                    }
                        currList.Add(currentGem);
                }
                LastGem(currList);
                return currList ;
            }
        }

        private static void LastGem(List<Gems> currList)
        {
            Gems last = new Gems();
            last.number = 0;
            last.isExluded = false;
            currList.Add(last);
        }

        private static void FirstGem(List<Gems> currList)
        {
            Gems first = new Gems();
            first.number = 0;
            first.isExluded = false;
            currList.Add(first);
        }

        private static void FillGems(int[] numbers, List<Gems> gems)
        {
            Gems first = new Gems();
            first.number = 0;
            first.isExluded = false;
            gems.Add(first);

            foreach (var gem in numbers)
            {
                Gems currGem = new Gems();

                currGem.number = gem;
                currGem.isExluded = false;

                gems.Add(currGem);


            }
            Gems last = new Gems();
            first.number = 0;
            first.isExluded = false;
            gems.Add(last);

        }
    }
}
