using System;
using System.IO;

namespace CodeEval.ArmstrongNumbers
{
    /// <summary>
    /// Armstrong Numbers Challenge
    /// Difficulty: Easy
    /// Description: An Armstrong number is an n-digit number that is equal to the sum of the n'th powers of its digits
    /// Problem Statement: https://www.codeeval.com/open_challenges/82/
    /// </summary>
    class ArmstrongNumbers
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
                int target = int.Parse(line);
                int n = line.Length;
                int num = target;
                int sum = 0;

                // one digit number is always an armstrong number since x^1 = x
                while (num != 0)
                {
                    int digit = num % 10;
                    sum += (int)Math.Pow(digit, n);
                    num = num / 10;
                }

                Console.WriteLine(sum == target ? "True" : "False");
            }
        }

    }
}
