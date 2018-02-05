using System;

namespace _04.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            
            long[][] triangle = new long[height][];
            for (int currHeight = 0; currHeight < height; currHeight++)
            {
                triangle[currHeight] = new long[currHeight + 1];
                triangle[currHeight][0] = 1;
                triangle[currHeight][currHeight] = 1;

                if (currHeight >= 2)
                {
                    for (int widthCnt = 1; widthCnt < currHeight; widthCnt++)
                    {
                        triangle[currHeight][widthCnt] =
                            triangle[currHeight - 1][widthCnt] +
                            triangle[currHeight - 1][widthCnt - 1];
                    }
                }
            }

            for (int rows = 0; rows < triangle.Length; rows++)
            {
                for (int cols = 0; cols < triangle[rows].Length; cols++)
                {
                    Console.Write(triangle[rows][cols] + " ");
                }
                Console.WriteLine();
            }

           
        }
    }
}
