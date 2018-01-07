using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MathPotato
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var queue = new Queue<string>(input.Split(' '));
            int number = int.Parse(Console.ReadLine());

            int cnt = 0;

            while (queue.Count > 1)
            {
                cnt++;
                for (int i = 0; i < number - 1; i++)
                {
                    string reminder = queue.Dequeue();
                    queue.Enqueue(reminder);
                }
                if (!IsPrime(cnt))
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                else
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        public static bool IsPrime(int cnt)
        {
            if ((cnt & 1) == 0)
            {
                if (cnt == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            for (int i = 3; (i * i) <= cnt; i += 2)
            {
                if ((cnt % i) == 0)
                {
                    return false;
                }
            }
            return cnt != 1;
        }
    }
    
}


