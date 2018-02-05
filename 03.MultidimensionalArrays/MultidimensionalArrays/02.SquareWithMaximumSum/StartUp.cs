using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SquareWithMaximumSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input =
                Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int rows = input.First();
            int cols = input.Last();

            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] currRow =
                    Console.ReadLine()
                        .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                matrix[i] = new int[currRow.Length];
                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = currRow[j];
                }
            }

            int bestSum = 0;
            int colIndex = 0;
            int rowIndex = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    var tempSum = 0;

                    int first = matrix[i][j];
                    int second = matrix[i][j + 1];
                    int third = matrix[i + 1][j];
                    int fourth = matrix[i + 1][j + 1];
                    tempSum = first + second + third + fourth;

                    if (tempSum > bestSum)
                    {
                        bestSum = tempSum;
                        rowIndex = i;
                        colIndex = j;
                    }
                }
            }

            Console.Write(matrix[rowIndex][colIndex] + " ");
            Console.WriteLine(matrix[rowIndex][colIndex + 1]);
            Console.Write(matrix[rowIndex + 1][colIndex] + " ");
            Console.WriteLine(matrix[rowIndex + 1][colIndex + 1]);
            Console.WriteLine(bestSum);
        }
    }
}
