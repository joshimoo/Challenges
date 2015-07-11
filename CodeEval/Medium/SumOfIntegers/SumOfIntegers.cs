using System;
using System.IO;

namespace CodeEval.SumOfIntegers
{
    /// <summary>
    /// Sum of integers Challenge
    /// Difficulty: Medium
    /// Description: Find the maximum Sum 
    /// Problem Statement: https://www.codeeval.com/open_challenges/17/
    /// </summary>
    class SumOfIntegers
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                var nums = Array.ConvertAll(line.Split(','), int.Parse);
                Console.WriteLine(MaxSum(nums));
            }
        }


        /// <summary>
        /// Return the maximum sum in an array
        /// </summary>
        static int MaxSum(int[] nums)
        {
            // Exit early if we don't have any numbers
            if (nums.Length <= 0) { return 0; }

            // Kadane's Algorithm: O(n)
            // Modified to work on negative arrays
            // Possible Underflow if nums[i] + nums[i+1] < int.MinValue;
            // Possible Overflow if nums[i] + nums[i+1] > int.MaxValue;
            int maxSoFar = nums[0];
            int maxEndingHere = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
        }
    }
}
