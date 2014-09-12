using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;

namespace CodeEval.MultiplyLists
{
    /// <summary>
    /// Multiply qLists Challenge
    /// Difficulty: Easy
    /// Description: multiply elements from two lists that have the same index
    /// Problem Statement: https://www.codeeval.com/open_challenges/113/
    /// </summary>
    class MultiplyLists
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                // Trim the Whitespace around the edges, so we don't have to worry about emtpy elements.
                string[] split = line.Split('|');
                int[] left = split[0].Trim().Split(' ').Select(int.Parse).ToArray();
                int[] right = split[1].Trim().Split(' ').Select(int.Parse).ToArray();
                Debug.Assert(left.Length == right.Length, "The 2 passed arrays have different element counts");

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < left.Length; i++) { sb.AppendFormat("{0} ", left[i] * right[i]); }

                Console.WriteLine(sb.ToString(0, sb.Length - 1));
            }
        }
    }
}
