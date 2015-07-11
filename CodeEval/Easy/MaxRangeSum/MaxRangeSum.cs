using System;
using System.IO;

namespace CodeEval.MaxRangeSum
{
    /// <summary>
    /// Max Range Sum Challenge
    /// Difficulty: Easy
    /// Description: Solve the maximum subarray problem for period p
    /// Problem Statement: https://www.codeeval.com/open_challenges/186/
    /// </summary>
    class MaxRangeSum
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                // Format "n; x0 x1 x2 x3"
                var split = line.Split(';');
                int days = int.Parse(split[0]);
                var nums = Array.ConvertAll(split[1].Split(' '), int.Parse);
                Console.WriteLine(MaxSumForPeriod(nums, days));
            }
        }

        /// <summary>
        /// Return the maximum sum in an array
        /// </summary>
        static int MaxSum(int[] nums)
        {
            // Kadane's Algorithm: O(n)
            int maxSoFar = 0;
            int maxEndingHere = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                maxEndingHere = Math.Max(0, maxEndingHere + nums[i]);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
        }

        /// <summary>
        /// Returns the maximum sum in an array for period
        /// Uses a moving window for the cumulative sum O(n)
        /// </summary>
        static int MaxSumForPeriod(int[] nums, int period)
        {
            // Cumulative Sum for the period (days)
            // Doubly LinkedList makes it nicer but one can also use the index nums[i - period] instead
            int sumForPeriod = 0;
            int maxSumForPeriod = 0;

            // Exit early, if period is longer then our data count
            if (period > nums.Length) { return 0; }
            for (int i = 0; i < period; i++)
            {
                sumForPeriod += nums[i];
                maxSumForPeriod = sumForPeriod;
            }

            // our replacement starts with period, before it's just sum to period
            for (int i = period; i < nums.Length; i++)
            {
                int first = i - period;
                sumForPeriod -= nums[first];
                sumForPeriod += nums[i];
                maxSumForPeriod = Math.Max(maxSumForPeriod, sumForPeriod);
            }

            // remove this if you need negative sums
            return Math.Max(0, maxSumForPeriod);
        }
    }
}
