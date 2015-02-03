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
                Console.WriteLine(CountWaysRecursive(numbers));
            }
        }

        static int CountWaysRecursive(int[] numbers)
        {
            int counter = 0;
            for (int i = 0; i < numbers.Length; i++) { counter += Count(numbers, i, 4); }
            return counter;
        }

        static bool Sum(int[] numbers, int upperBound, int choicesLeft, int sum)
        {
            // Base cases
            if (choicesLeft == 0)
            {
                // no more choices, does the sum == 0
                return sum == 0;
            }
            else if (upperBound == 0)
            {
                // We still have choices, but no more candidates
                // return error state
                return false;
            }
            else
            {
                // Recurse downwards
                for (int i = upperBound - 1; i >= 0; i--)
                {
                    Sum(numbers, i, choicesLeft - 1, sum + numbers[i]);
                }
            }
        }

    }
}
