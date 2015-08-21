using System;

namespace HackerRank.Algorithms.DynamicProgramming
{
    /// <summary>
    /// The Maximum Subarray Challenge
    /// Description: Find the best contiguous and non-contiguous Maximum Subarray
    /// Problem Statement: https://www.hackerrank.com/challenges/maxsubarray
    /// </summary>
    class TheMaximumSubarray
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                var nums = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                // Since we start with elem[0], we will get the maximum Value in case we only have negative numbers
                int currentSum = nums[0];
                int bestSum = nums[0];
                int nonContiguousSum = nums[0];

                for (int j = 1; j < nums.Length; j++)
                {
                    int x = nums[j];

                    // non-contiguous: -1, -3, 2, -4, 5
                    nonContiguousSum = Math.Max(nonContiguousSum, Math.Max(x, nonContiguousSum + x));

                    // contiguous
                    currentSum = Math.Max(x, currentSum + x);
                    bestSum = Math.Max(bestSum, currentSum);
                }

                Console.WriteLine("{0} {1}", bestSum, nonContiguousSum);
            }
        }
    }
}