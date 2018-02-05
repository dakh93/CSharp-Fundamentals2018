using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var fibonacciNums = new Stack<long>();

            fibonacciNums.Push(0);
            fibonacciNums.Push(1);

            for (int i = 0; i < n - 1; i++)
            {
                var firstNum = fibonacciNums.Pop();
                var secondNum = fibonacciNums.Peek();

                var result = firstNum + secondNum;

                fibonacciNums.Push(firstNum);
                fibonacciNums.Push(result);
            }

            Console.WriteLine(fibonacciNums.Peek());
        }
    }
}
