using System;
using System.IO;
using System.Text;

namespace CodeEval.StepwiseWord
{
    /// <summary>
    /// Stepwise Word Challenge
    /// Difficulty: Easy
    /// Description: Find the largest word and present it in steps
    /// Problem Statement: https://www.codeeval.com/open_challenges/202/
    /// </summary>
    class StepwiseWord
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {

                StringBuilder sb = new StringBuilder();
                var words = line.Split(' ');
                string largestWord = String.Empty;

                // Find Largest Word
                foreach (var word in words)
                {
                    if (word.Length > largestWord.Length) { largestWord = word;}
                }

                // Print Largest Word Stepwise
                for (int i = 0; i < largestWord.Length; i++)
                {
                    sb.AppendFormat("{0}{1} ", new String('*', i), largestWord[i]);
                }
                
                // Remove last space
                Console.WriteLine(sb.ToString(0, sb.Length - 1));
            }
        }

    }
}
