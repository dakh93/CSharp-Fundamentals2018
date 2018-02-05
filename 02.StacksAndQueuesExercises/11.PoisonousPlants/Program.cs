using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int plantNums = int.Parse(Console.ReadLine());

            List<long> plants = Console.ReadLine()
                .Split(' ').Select(long.Parse).ToList();

            int daysCnt = 0;
            while (true)
            {
                bool dead = false;

                var start = plants.Count;
                for (int j = start - 1 , i = start-2; j > 0; j-- , i--)
                {

                    if (plants[j] > plants[i])
                    {
                        plants.RemoveAt(j);
                        dead = true;
                    }
                }
                if (!dead)
                {
                    Console.WriteLine(daysCnt);
                    Environment.Exit(0);
                }
                daysCnt++;
            }
        }
    }
}
