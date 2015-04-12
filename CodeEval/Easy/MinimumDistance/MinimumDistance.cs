using System;
using System.IO;
using System.Linq;

namespace CodeEval.MinimumDistance
{
    /// <summary>
    /// Minimum Distance Challenge
    /// Difficulty: Easy
    /// Find the sum of the minimal distance to reach all of alices friends. (optimal position)
    /// Problem Statement: https://www.codeeval.com/open_challenges/189/
    /// </summary>
    class MinimumDistance
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                // For O(n) implement Pivot Selection Algorithm
                int[] numbers = line.Split(' ').Skip(1).Select(int.Parse).OrderBy(x => x).ToArray();

                // median average
                int mid = numbers.Length / 2;
                int median = numbers.Length % 2 == 0 ? (numbers[mid] + numbers[mid - 1]) / 2 : numbers[mid];
                int minDistance = numbers.Sum(num => Math.Abs(num - median));

                Console.WriteLine(minDistance);
            }

        }

    }
}
