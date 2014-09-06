using System;
using System.IO;

namespace CodeEval.LongestLines
{
    /// <summary>
    /// Longest Lines Challenge
    /// Difficulty: Medium
    /// Description: find the 'N' longest lines and return them from longest to smallest.
    /// Problem Statement: https://www.codeeval.com/open_challenges/2/
    /// </summary>
    class LongestLines
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// Possible Optimization: Implement a Cycle buffer that keeps track of the n longest lines, and sort that at the end.
        /// That way we only need to store and sort n lines.
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(args[0]);
            int n = int.Parse(lines[0]);
            Comparison<string> lengthDescending = (x, y) => x.Length > y.Length ? -1 : x.Length < y.Length ? 1 : 0;
            Array.Sort(lines, lengthDescending);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }

    }
}
