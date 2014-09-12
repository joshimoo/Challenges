using System;
using System.Diagnostics;
using System.IO;

namespace CodeEval.PenultimateWord
{
    /// <summary>
    /// Penultimate Word Challenge
    /// Difficulty: Easy
    /// Description: find the next-to-last word in a string.
    /// Problem Statement: https://www.codeeval.com/open_challenges/92/
    /// </summary>
    class PenultimateWord
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
                string[] split = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Debug.Assert(split.Length > 1);
                string nextToLastWord = split[split.Length - 2];
                Console.WriteLine(nextToLastWord);
            }
        }
    }
}
