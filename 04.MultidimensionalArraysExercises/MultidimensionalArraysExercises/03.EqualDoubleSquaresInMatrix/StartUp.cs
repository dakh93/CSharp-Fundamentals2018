using System;
using System.Linq;

namespace _03.EqualDoubleSquaresInMatrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] size =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int rowSize = size[0];
            int colSize = size[1];

            var matrix = new string[rowSize, colSize];
            for (int rows = 0; rows < rowSize; rows++)
            {
                var input =
                    Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    

                for (int cols = 0; cols < colSize; cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }

            int cntOfEquals = 0;
            for (int rows = 0; rows < rowSize - 1; rows++)
            {
                for (int cols = 0; cols < colSize - 1; cols++)
                {
                    var first = matrix[rows, cols];
                    var second = matrix[rows, cols + 1];
                    var third = matrix[rows + 1, cols];
                    var fourth = matrix[rows + 1, cols + 1];
                    if (first.Equals(second) && second.Equals(third) && third.Equals(fourth))
                    {
                        cntOfEquals++;
                    }
                }
            }

            Console.WriteLine(cntOfEquals);
        }
    }
}
