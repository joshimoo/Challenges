using System;
using System.IO;

namespace CodeEval.EvenNumbers
{
    /// <summary>
    /// Even Numbers Challenge
    /// Difficulty: Easy
    /// Description: Determine if a Number is even/odd
    /// Problem Statement: https://www.codeeval.com/open_challenges/100/
    /// </summary>
    class EvenNumbers
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            int[] numbers = Array.ConvertAll(File.ReadAllLines(args[0]), int.Parse);
            foreach (var num in numbers)
            {
                // Print 1 if the number is even or 0 if the number is odd. 
                int rem = num % 2;
                const int even = 1;
                const int odd = 0;
                Console.WriteLine(rem == 0 ? even : odd);
            }
        }
    }
}
