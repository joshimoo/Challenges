using System;
using System.IO;

namespace CodeEval.Lowercase
{
    /// <summary>
    /// Lowercase Challenge
    /// Difficulty: Easy
    /// Description: Print the english(asci) text in Lowercase formatting
    /// Problem Statement: https://www.codeeval.com/open_challenges/20/
    /// </summary>
    class Lowercase
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
                char[] output = new char[line.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];

                    // The case flag, is bit 6 (n^5 = 32) in asci
                    // upper case: bit 6 = 0
                    // lower case: bit 6 = 1
                    if (c >= 'A' && c <= 'Z') { c = (char)(c | 32); }
                    output[i] = c;
                }

                Console.WriteLine(new string(output));
            }
        }

    }
}
