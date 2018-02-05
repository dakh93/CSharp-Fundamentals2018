using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _07.LegoBlocks
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var firstMatrix = new int[n][];
            var secondMatrix = new int[n][];

            MatrixFill(n, firstMatrix, secondMatrix);

            bool fitsPerfect = CheckMatrixFitting(firstMatrix, secondMatrix, n);

            if (fitsPerfect)
            {
                PrintGluedMatrix(firstMatrix, secondMatrix, n);
            }
            else
            {
                PrintTotalMatrixCells(firstMatrix, secondMatrix, n);
            }

        }

        private static void PrintTotalMatrixCells(int[][] firstMatrix, int[][] secondMatrix, int n)
        {
            var counter = 0;
            for (int row = 0; row < n; row++)
            {
                counter += firstMatrix[row].Length + secondMatrix[row].Length;
            }
            Console.WriteLine($"The total number of cells is: {counter}");
        }

        private static void PrintGluedMatrix(int[][] firstMatrix, int[][] secondMatrix, int n)
        {
            

            for (int row = 0; row < n ; row++)
            {
                var firstColLenght = firstMatrix[row].Length;
                var secondColLenght = secondMatrix[row].Length;

                //PRINT FIRST PART
                var firstArray = firstMatrix[row].ToArray();
                var secondArray = secondMatrix[row].ToArray().Reverse();
                Console.Write("[");
                Console.Write(String.Join(", ",firstArray));
                Console.Write(", ");
                Console.Write(String.Join(", ", secondArray));
                Console.WriteLine("]");
            }
        }

        private static bool CheckMatrixFitting(int[][] firstMatrix, int[][] secondMatrix, int n)
        {
            var fitLenght = firstMatrix[0].Length + secondMatrix[0].Length;
            bool isEqual = true;
            for (int rows = 1; rows <  n ; rows++)
            {
                var currLenght = firstMatrix[rows].Length + secondMatrix[rows].Length;
                if (fitLenght != currLenght)
                {
                    isEqual = false;
                }

                if (!isEqual)
                {
                    break;
                }
            }
            return isEqual;

        }


        private static void MatrixFill(int n, int[][] firstMatrix, int[][] secondMatrix)
        {
            for (int row = 0; row < n * 2; row++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                if (row < n)
                {
                    firstMatrix[row] = new int[input.Count];
                    for (int col = 0; col < firstMatrix[row].Length; col++)
                    {
                        firstMatrix[row][col] = input[col];
                    }
                }
                else
                {
                    var rowIndex = row % n;
                        secondMatrix[rowIndex] = new int[input.Count];
                        for (int colIndex = 0; colIndex < input.Count; colIndex++)
                        {
                            secondMatrix[rowIndex][colIndex] = input[colIndex];
                        }
                    
                }
            }
        }
    }
}
