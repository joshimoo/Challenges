using System;
using System.IO;

namespace CodeEval.LongestWord
{
    /// <summary>
    /// Longest Word Challenge
    /// Difficulty: Easy
    /// Description: Find the Longest Word in a sentence
    /// Problem Statement: https://www.codeeval.com/open_challenges/111/
    /// </summary>
    class LongestWord
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
                Console.WriteLine(FindLongestWord(line));
            }
        }

        static string FindLongestWord(string sentence)
        {
            string longestWord = String.Empty;
            string[] words = sentence.Split(' ');

            foreach (string word in words)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }

            return longestWord;
        }

    }
}
