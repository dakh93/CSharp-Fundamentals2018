using System;
using System.Linq;

namespace _13.TriFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            var names =
                Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            for (int i = 0; i < names.Length; i++)
            {
                var currentName = names[i].ToCharArray();
                var sum = 0;
                for (int j = 0; j < currentName.Length; j++)
                {
                    sum += currentName[j];
                }

                if (sum >= num)
                {
                    Console.WriteLine(currentName);
                    return;
                }
            }
        }
    }
}
