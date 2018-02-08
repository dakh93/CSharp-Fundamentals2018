using System;
using System.Linq;

namespace _04.AddVAT
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input =
                Console.ReadLine()
                    .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

            
            for (int cnt = 0; cnt < input.Length; cnt++)
            {
                var currPrice = input[cnt];
                var currVATadded = currPrice + (currPrice * 20) / 100;
                Console.WriteLine($"{currVATadded:f2}");
            }
        }
    }
}
