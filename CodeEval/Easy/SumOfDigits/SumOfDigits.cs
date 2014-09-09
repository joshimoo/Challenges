using System;
using System.IO;

namespace CodeEval.SumOfDigits
{
    /// <summary>
    /// Sum of Digits Challenge
    /// Difficulty: Easy
    /// Description: Given a positive integer, find the sum of its constituent digits
    /// Problem Statement: https://www.codeeval.com/open_challenges/21/
    /// </summary>
    class SumOfDigits
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
                int sum = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    // Instead of using the asci code 48 use '0' this works because in most charset the numbers are all behind each other from 0 to 9
                    int digit = line[i] - '0';
                    sum += digit;
                }

                Console.WriteLine(sum);
            }
        }

    }
}
