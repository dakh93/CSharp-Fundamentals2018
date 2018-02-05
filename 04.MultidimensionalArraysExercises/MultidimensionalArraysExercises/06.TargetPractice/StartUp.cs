using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06.TargetPractice
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            string snake = Console.ReadLine();

            int rows = sizeMatrix[0];
            int cols = sizeMatrix[1];

            var matrix = new char[rows][];
            
            FillMatrix(rows, cols, matrix, snake);

            var shotParams = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            RemoveDamagedAreas(shotParams, matrix, rows, cols);
            DropDown(matrix, rows, cols);
            PrintMatrix(matrix, rows, cols);
        }

        private static void DropDown(char[][] matrix, int rows, int cols)
        {
            
            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                List<char> currCol = new List<char>();
                for (int rowIndex = 0; rowIndex < rows; rowIndex++)
                {
                    if (matrix[rowIndex][colIndex] != ' ')
                    {
                        currCol.Add(matrix[rowIndex][colIndex]);
                    }
                }

                var spaces = rows - currCol.Count;
                if (spaces == 0)
                {
                    continue;
                    
                }

                for (int i = 0; i < spaces; i++)
                {
                    matrix[i][colIndex] = ' ';
                }
                for (int rowIndex = 0 + spaces, cnt = 0; rowIndex < rows; rowIndex++, cnt++)
                {
                    matrix[rowIndex][colIndex] =currCol[cnt] ;
                }
            }
        }

        private static void PrintMatrix(char[][] matrix, int rows, int cols)
        {
            for (int row = 0; row <rows ; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void RemoveDamagedAreas(int[] shotParams, char[][] matrix, int rows, int cols)
        {
            var impactRow = shotParams[0];
            var impactCol = shotParams[1];
            var shotRadius = shotParams[2];


            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    if ((colIndex - impactCol) * (colIndex - impactCol) + 
                        (rowIndex - impactRow) * (rowIndex - impactRow) <= shotRadius * shotRadius)
                    {
                        matrix[rowIndex][colIndex] = ' ';
                    }
                }
            }


        }

        private static void FillMatrix(int rows, int cols, char[][] matrix, string snake)
        {
            var cnt = 0;
            bool changeDirection = false;
            for (int rowIndex = rows - 1; rowIndex >= 0; rowIndex--)
            {
                matrix[rowIndex] = new char[cols];
                if (!changeDirection)
                {
                    for (int colIndex = cols - 1; colIndex >= 0; colIndex--)
                    {
                        if (cnt > snake.Length - 1)
                        {
                            cnt = 0;
                        }

                        matrix[rowIndex][colIndex] = snake[cnt];
                        cnt++;
                    }
                    changeDirection = true;
                }
                else
                {
                    for (int colIndex = 0; colIndex < cols; colIndex++)
                    {
                        if (cnt > snake.Length - 1)
                        {
                            cnt = 0;
                        }

                        matrix[rowIndex][colIndex] = snake[cnt];
                        cnt++;
                    }
                    changeDirection = false;
                }
            }

        }
    }
}
