using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var nums =
                Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

            Func<int[], int> minNum = Minimum;

            Console.WriteLine(minNum(nums));
        }

        private static int Minimum(int[] nums)
        {
            var tempMin = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < tempMin)
                {
                    tempMin = nums[i];
                }
            }
            return tempMin;
        }
    }
}
