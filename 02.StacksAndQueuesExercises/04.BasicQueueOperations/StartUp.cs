using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BasicQueueOperations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int[] input =
                Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int[] numbers =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();


            for (int i = 0; i < input[0]; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < input[1]; i++)
            {
                queue.Dequeue();
            }

            Console.WriteLine(
                queue.Count == 0 ? "0" : queue.Contains(input[2]) ? "true" : $"{queue.Min()}");
        }
    }
}
