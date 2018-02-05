using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Console.WriteLine(fibonacci(n));
            
        }
        
        static Dictionary<long, long> memoization = new Dictionary<long, long>();

        public static long fibonacci(long n)
        {
            if (n <= 1)
            {
                return n;
            }
            long result = 0;
            if (memoization.TryGetValue(n , out result))
            {
                return result;
            }
            else
            {
                var unSavedCase =  fibonacci(n - 1) + fibonacci(n - 2);
                memoization.Add(n, unSavedCase);
                return unSavedCase;
            }
        }
    }
}
