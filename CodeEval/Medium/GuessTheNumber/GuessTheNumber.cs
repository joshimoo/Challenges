using System;
using System.IO;

namespace CodeEval.GuessTheNumber
{
    /// <summary>
    /// Guess the number Challenge
    /// Difficulty: Medium
    /// Description: Guess the number in O(log2(n))
    /// Problem Statement: https://www.codeeval.com/open_challenges/170/
    /// </summary>
    class GuessTheNumber
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                var split = line.Split(' ');
                int lowerBound = 0;
                int upperBound = int.Parse(split[0]);
                int mid = 0;

                // Skip the first input, since it's the upperbound number
                for (int i = 1; i < split.Length; i++)
                {
                    mid = lowerBound + (upperBound - lowerBound + 1) / 2;
                    if (split[i] == "Lower") { upperBound = mid - 1; }
                    else if (split[i] == "Higher") { lowerBound = mid + 1; }
                }

                Console.WriteLine(mid);
            }
        }

    }
}
