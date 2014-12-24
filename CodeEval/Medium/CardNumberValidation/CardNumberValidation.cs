using System;
using System.IO;
using System.Linq;

namespace CodeEval.CardNumberValidation
{
    /// <summary>
    /// Card Number Validation Challenge
    /// Difficulty: Medium
    /// Description: Validate an account number using Luhn Algorithm
    /// Problem Statement: https://www.codeeval.com/open_challenges/172/
    /// </summary>
    class CardNumberValidation
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                int numIndex = 0;
                int spaceCount = (line.Length / 4) - 1; // Card Numbers beetwen 12 - 19, spaces after 4 digits
                int[] numbers = new int[line.Length - spaceCount];

                // Convert to numbers
                foreach (char c in line)
                {
                    if (c >= '0' && c <= '9')
                    {
                        numbers[numIndex++] = c - '0';
                    }
                }

                // NOTE: this can be done in one iteration
                // Luhn Algorithm - skip the check digit
                for (int i = numbers.Length - 2; i >= 0; i -= 2)
                {
                    // Sum the digits
                    int num = numbers[i] * 2;
                    numbers[i] = (num % 10) + (num / 10);
                }

                // Sum all Numbers
                int sum = numbers.Sum();
                const int VALID = 1;
                const int INVALID = 0;
                Console.WriteLine(sum % 10 == 0 ? VALID : INVALID);
            }
        }

    }
}
