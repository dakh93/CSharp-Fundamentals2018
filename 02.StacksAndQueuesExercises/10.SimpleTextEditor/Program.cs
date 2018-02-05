using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            text.Append("");
            var memory = new Stack<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                string command = input[0];
                string argument = String.Empty;
                if (input.Length > 1)
                {
                    argument = input[1];
                }

                if (command == "1")
                {
                    memory.Push(text.ToString());
                    text.Append(argument);

                }
                else if (command == "2")
                {
                
                    memory.Push(text.ToString());
                    var elementsToErase = Math.Min(text.Length, int.Parse(argument));
                    var startIndex = text.Length - elementsToErase;
                    text.Remove(startIndex, elementsToErase);

                }
                else if (command == "3")
                {
                    var elementIndex = int.Parse(argument);
                    Console.WriteLine(text.ToString()[elementIndex - 1]);
                }
                else
                {
                    text.Clear();
                    text.Append(memory.Pop());
                }
            }
        }
    }
}
