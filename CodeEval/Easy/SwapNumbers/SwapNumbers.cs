using System;
using System.IO;
using System.Text;

namespace CodeEval.SwapNumbers
{
    /// <summary>
    /// Swap Numbers Challenge
    /// Difficulty: Easy
    /// Description: Swap the First and Last Number of each Word
    /// Problem Statement: https://www.codeeval.com/open_challenges/196/
    /// </summary>
    class SwapNumbers
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                // For production to many allocations, but for quick and dirty it's okay :)
                var sb = new StringBuilder();
                foreach (string s in line.Split(' '))
                {
                    sb.Append(s[s.Length - 1]).Append(s, 1, s.Length - 2).Append(s[0]).Append(' ');
                }

                Console.WriteLine(sb.ToString(0, sb.Length - 1));
            }
        }

    }
}
