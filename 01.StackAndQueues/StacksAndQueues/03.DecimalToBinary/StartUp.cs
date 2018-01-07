using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DecimalToBinary
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            if (num == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (num > 0)
                {
                    int reminder = num % 2;
                    stack.Push(reminder);
                    num /= 2;
                }

                foreach (var element in stack)
                {
                    Console.Write(element);
                }
                Console.WriteLine();
            }
        }
    }
}
