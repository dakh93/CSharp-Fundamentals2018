using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _08.RadioactiveMutantVampireBunnies
{
    class StartUp
    {
        private static int playerRow = 0;
        private static int playerCol = 0;
        static void Main(string[] args)
        {
            var size =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var rows = size[0];
            var cols = size[1];
            var matrix = new char[rows][];
            
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[rowIndex] = new char[cols];
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (input[colIndex].Equals('P'))
                    {
                        playerRow = rowIndex;
                        playerCol = colIndex;
                    }
                    matrix[rowIndex][colIndex] = input[colIndex];
                }
            }

            var command = Console.ReadLine().ToCharArray();

            for (int moves = 0; moves < command.Length; moves++)
            {
                var currMove = command[moves];
                MovingToDirection(currMove, matrix, rows, cols);
                BunnyMultiply(matrix, playerCol, playerRow, rows, cols);

            }


        }

        private static void BunnyMultiply(char[][] matrix, int playerCol, int playerRow, int rows, int cols)
        {
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == 'B')
                    {
                        if (colIndex > 0 )
                        {
                            matrix[rowIndex][colIndex - 1] = 'B';
                        }
                        if (colIndex < cols - 1)
                        {
                            matrix[rowIndex][colIndex + 1] = 'B';
                        }
                        if (rowIndex > 0)
                        {
                            matrix[rowIndex - 1][colIndex] = 'B';
                        }
                        if (rowIndex < rows - 1)
                        {
                            matrix[rowIndex + 1][colIndex] = 'B';
                        }
                    }
                }
            }
        }

        private static void MovingToDirection(char currMove, char[][] matrix, int rows, int cols)
        {
            try
            {

                if (currMove == 'L')
                {
                    var temp = matrix[playerRow][playerCol];
                    matrix[playerRow][playerCol] = '.';
                    matrix[playerRow][playerCol - 1] = temp;
                    playerCol--;
                }
                if (currMove == 'R')
                {
                    var temp = matrix[playerRow][playerCol];
                    matrix[playerRow][playerCol] = '.';
                    matrix[playerRow][playerCol + 1] = temp;
                    playerCol++;
                }
                if (currMove == 'U')
                {
                    var temp = matrix[playerRow][playerCol];
                    matrix[playerRow][playerCol] = '.';
                    matrix[playerRow - 1][playerCol] = temp;
                    playerRow--;
                }
                if (currMove == 'D')
                {
                    var temp = matrix[playerRow][playerCol];
                    matrix[playerRow][playerCol] = '.';
                    matrix[playerRow + 1][playerCol] = temp;
                    playerRow++;
                }
            }
            catch (IndexOutOfRangeException)
            {
                PrintMatrix(rows, cols, matrix);
                Console.WriteLine($"won: {playerRow} {playerCol}");
                Environment.Exit(0);
                
            }

        }

        private static void PrintMatrix(int rows, int cols, char[][] matrix)
        {
                for (int rowIndex = 0; rowIndex < rows; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < cols; colIndex++)
                    {
                        Console.Write(matrix[rowIndex][colIndex]);
                        
                    }
                    Console.WriteLine();
                }

        }
    }
}
