using System;
using System.IO;
using System.Text;

namespace CodeEval.Pangrams
{
    /// <summary>
    /// Pangrams Challenge
    /// Difficulty: Medium
    /// Description: take a sentence, and return all the letters it is missing
    /// Problem Statement: https://www.codeeval.com/open_challenges/37/
    /// </summary>
    class Pangrams
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
                // No need for dictionary, this should be just as fast, a dictionary makes the code easier to read tough.
                int[] letterCounts = new int[26];

                // Index all Characters
                for (int i = 0; i < line.Length; i++)
                {
                    // The case flag, is bit 6 (n^5 = 32) in asci lower case: bit 6 = 1
                    char c = (char)(line[i] | 32);
                    if (c >= 'a' && c <= 'z') { letterCounts[c - 'a']++; }
                }

                // Find all letter which are not included
                var sb = new StringBuilder();
                for (int i = 0; i < letterCounts.Length; i++)
                {
                    if (letterCounts[i] == 0) { sb.Append((char)('a' + i)); }
                }

                Console.WriteLine(sb.Length > 0 ? sb.ToString() : "NULL");
            }
        }
    }
}
