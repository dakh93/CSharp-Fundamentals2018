using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseNumWithStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> nums = new Stack<int>();
            
            Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(strNum => nums.Push(int.Parse(strNum)));

            Console.WriteLine(string.Join(" ", nums));

        }
    }
}
