using System;

namespace CodeEval.OddNumbers
{
    /// <summary>
    /// Odd Numbers Challenge
    /// Difficulty: Easy
    /// Description: Print the odd numbers from 1 to 99
    /// Problem Statement: https://www.codeeval.com/open_challenges/25/
    /// </summary>
    class OddNumbers
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            // No input in this challenge
            for (int i = 1; i <= 99; i += 2)
            {
                Console.WriteLine(i);
            }
        }

    }
}
