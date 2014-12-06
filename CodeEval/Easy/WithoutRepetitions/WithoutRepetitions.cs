using System;
using System.IO;
using System.Text;

namespace CodeEval.WithoutRepetitions
{
    /// <summary>
    /// Without Repetitions Challenge
    /// Difficulty: Easy
    /// Description: Remove Sequentially repeating characters
    /// Problem Statement: https://www.codeeval.com/open_challenges/173/
    /// </summary>
    class WithoutRepetitions
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            //string[] lines = File.ReadAllLines(args[0]);
            // NOTE: Enumeration can start before all lines are read
            foreach (var line in File.ReadLines(args[0]))
            {
                // NOTE: For more performance, work on a lower level char[]
                var sb = new StringBuilder();
                char prev = '\0';
                foreach (char c in line)
                {
                    if (c != prev)
                    {
                        sb.Append(c);
                        prev = c;
                    }
                }

                Console.WriteLine(sb.ToString());
            }
        }

    }
}
