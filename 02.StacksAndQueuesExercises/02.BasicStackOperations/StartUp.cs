using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BasicStackOperations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int elementsToPush = int.Parse(input[0]);
            int elementsToPop = int.Parse(input[1]);
            int existingElementInStack = int.Parse(input[2]);


            int[] numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < elementsToPush && i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < elementsToPop && i < numbers.Length; i++)
            {
                stack.Pop();
            }

            Console.WriteLine(
                stack.Count == 0 ? "0" : stack.Contains(existingElementInStack) ? "true" :
                $"{stack.Min()}");

        }
    }
}
