using System;
using System.IO;

namespace CodeEval.MultiplesOfANumber
{
    /// <summary>
    /// Multiples of a Number Challenge
    /// Difficulty: Easy
    /// Description: print out the smallest multiple of n which is greater than or equal to x. Do not use division or modulo operator
    /// Problem Statement: https://www.codeeval.com/open_challenges/18/
    /// </summary>
    class MultiplesOfANumber
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
                string[] split = line.Split(',');
                int target = int.Parse(split[0]);
                int n = int.Parse(split[1]);
                int sum = n;

                while (sum < target) { sum += n; }
                Console.WriteLine(sum);
            }
        }
    }
}
