using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MaximumElement
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxNumbers = new Stack<int>();
            var maxValue = int.MinValue;

            for (int i = 0; i < inputLines; i++)
            {
                int[] currElements =
                    Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();


                if (currElements[0] == 1)
                {

                    int number = currElements[1];
                    stack.Push(number);

                    if (maxValue < number)
                    {
                        maxValue = number;
                        maxNumbers.Push(number);
                    }
                }
                else if (currElements[0] == 2)
                {
                    if (stack.Pop() == maxValue)
                    {
                        maxNumbers.Pop();
                        if (maxNumbers.Count != 0)
                        {
                            maxValue = maxNumbers.Peek();
                        }
                        else
                        {
                            maxValue = int.MinValue;
                        }
                    }
                }
                else if (currElements[0] == 3)
                {
                    Console.WriteLine(maxValue);

                }
                }
            }
        }
    }

