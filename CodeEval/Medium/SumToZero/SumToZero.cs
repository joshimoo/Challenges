using System;
using System.IO;

namespace CodeEval.SumToZero
{
    /// <summary>
    /// Sum to Zero Challenge
    /// Difficulty: Medium
    /// Description: Count the numbers of ways in which the sum of 4 elements in the input result in zero. 
    /// Problem Statement: https://www.codeeval.com/open_challenges/81/
    /// </summary>
    class SumToZero
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                var numbers = Array.ConvertAll(line.Split(','), int.Parse);
            }
        }

    }
}
