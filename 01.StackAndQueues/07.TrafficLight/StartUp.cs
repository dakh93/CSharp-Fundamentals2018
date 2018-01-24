using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.TrafficLight
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int carsPerGreen = int.Parse(Console.ReadLine());
            var queueOfCars = new Queue<string>();
            int totalPassedCars = 0;

            while (true)
            {
                string input = Console.ReadLine();


                if (input == "end")
                {
                    Console.WriteLine($"{totalPassedCars} cars passed the crossroads.");
                    return;
                }
                else if (input == "green")
                {
                    int carsToPass = 0;

                    if (carsPerGreen > queueOfCars.Count)
                    {
                        carsToPass = queueOfCars.Count;
                    }
                    else
                    {
                        carsToPass = carsPerGreen;
                    }
                    for (int i = 0; i < carsToPass; i++)
                    {
                        Console.WriteLine($"{queueOfCars.Dequeue()} passed!");
                        totalPassedCars++;
                        
                    }
                }
                else
                {
                    queueOfCars.Enqueue(input);
                }

            }
        }
    }
}
