﻿using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] {", "},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rows = input[0];
            var cols = input[1];

            var sum = 0;

            for (int i = 0; i < rows; i++)
            {

                    sum += Console.ReadLine()
                        .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray().Sum();
                    
                
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
