using System;
using System.Linq;

namespace _04.MaximumSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] matrixSize =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int rowSize = matrixSize[0];
            int colSize = matrixSize[1];

            var matrix = new int[rowSize, colSize];
            for (int i = 0; i < rowSize; i++)
            {
                var input =
                    Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                for (int j = 0; j < colSize; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int bestSum = 0;
            int rowIndex = 0;
            int colIndex = 0;
            for (int rows = 0; rows < rowSize - 2; rows++)
            {
                int tempSum = 0;
                for (int cols = 0; cols < colSize - 2; cols++)
                {
                    var first =
                        matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows, cols + 2];
                    var second =
                        matrix[rows + 1, cols] + matrix[rows + 1, cols + 1] + matrix[rows + 1, cols + 2];
                    var third =
                        matrix[rows + 2, cols] + matrix[rows + 2, cols + 1] + matrix[rows + 2, cols + 2];

                    tempSum = first + second + third;

                    if (tempSum > bestSum)
                    {
                        bestSum = tempSum;
                        rowIndex = rows;
                        colIndex = cols;
                    }
                }
            }

            Console.WriteLine($"Sum = {bestSum}");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[rowIndex + i,colIndex + j] + " ");

                }
                Console.WriteLine();
            }

        }
    }
}
