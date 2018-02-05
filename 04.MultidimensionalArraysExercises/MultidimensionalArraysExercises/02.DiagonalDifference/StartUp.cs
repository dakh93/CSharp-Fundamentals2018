using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize,matrixSize];

            for (int rows = 0; rows < matrixSize; rows++)
            {
                int[] input = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int cols = 0; cols < matrixSize; cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }

            int leftDiagonalSum = 0;
            int rightDiagonalSum = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                leftDiagonalSum += matrix[i, i];
                rightDiagonalSum += matrix[i, matrixSize - 1 - i];
            }

            var difference = Math.Abs(leftDiagonalSum - rightDiagonalSum);

            Console.WriteLine(difference);

        }
    }
}
