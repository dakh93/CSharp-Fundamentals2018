using System;
using System.Linq;

namespace _01.MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input =
                Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int rows = input[0];
            int cols = input[1];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[,] matrix = new string[rows,cols];

            for (int i = 0; i < rows; i++)
            {
               
                for (int middle = 0; middle < cols; middle++)
                {
                    matrix[i, middle] =
                        alphabet[i].ToString() + alphabet[middle + i].ToString() + alphabet[i].ToString();
                }
                
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(String.Join(" ",matrix[i,j]));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
