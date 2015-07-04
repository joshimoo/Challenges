using System;
using System.IO;
using System.Text;

namespace CodeEval.StringsAndArrows
{
    /// <summary>
    /// Strings And Arrows Challenge
    /// Difficulty: Easy
    /// Description: Return the occurences of 2 specific patterns in the search string
    /// Problem Statement: https://www.codeeval.com/open_challenges/203/
    /// </summary>
    class StringsAndArrows
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            // Parameters for the String Searching Algorithms
            char[] alphabet = new char[] { '>', '-', '<' };
            string[] patterns = new string[] { ">>-->", "<--<<" };

            foreach (var line in File.ReadLines(args[0]))
            {
                Console.WriteLine(
                    NaiveStringSearch(line, patterns[0]) + 
                    NaiveStringSearch(line, patterns[1])
                );
            }
        }

        public static int NaiveStringSearch(string text, string pattern)
        {
            int count = 0;

            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                int j;
                for (j = 0; j < pattern.Length; j++)
                {
                    if (text[i + j] != pattern[j]) { break; }
                }

                if (j == pattern.Length) { count++; }
            }

            return count;
        }
    }
}
