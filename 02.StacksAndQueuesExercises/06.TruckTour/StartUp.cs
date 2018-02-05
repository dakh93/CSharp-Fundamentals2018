using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TruckTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int pumpsNum = int.Parse(Console.ReadLine());

            var pumps = new Queue<int[]>();
            for (int i = 0; i < pumpsNum; i++)
            {
                var currPump = 
                    Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse).ToArray();
                pumps.Enqueue(currPump);
            }

            int smallestIndex = 0;
            for (int currentStart = 0; currentStart < pumpsNum - 1; currentStart++)
            {
                int fuel = 0;
                bool isSolution = true;

                for (int pumpsPassed = 0; pumpsPassed < pumpsNum - 1; pumpsPassed++)
                {
                    int[] currentPump = pumps.Dequeue();

                    int fuelAdd = currentPump[0];
                    int toNextPump = currentPump[1];

                    pumps.Enqueue(currentPump);

                    fuel += fuelAdd - toNextPump;

                    if (fuel <0)
                    {
                        currentStart += pumpsPassed;
                        isSolution = false;
                        break;
                    }
                }
                if (isSolution)
                {
                    Console.WriteLine(currentStart);
                    Environment.Exit(0);
                }
            }

        }
    }
}
