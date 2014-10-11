using System;
using System.IO;
using System.Text;

namespace CodeEval.HappyNumbers
{
    /// <summary>
    /// Happy Numbers Challenge
    /// Difficulty: Easy
    /// Description: Evaluate wether the number is a happy number
    /// Problem Statement: https://www.codeeval.com/open_challenges/39/
    /// </summary>
    class HappyNumbers
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
                // NOTE: Normally you would need TODO: cycle finding
                // Instead I will just do a bruteforce approach
                // I will assume that any iterations > 1000 will be inside of a cycle
                int number = int.Parse(line);
                bool happyNumber = false;
                int i = 1000;
                while (!happyNumber && i-- > 0)
                {
                    // Is this a happy Number
                    number = SquareDigits(number);
                    if (number == 1) { happyNumber = true; }
                }

                Console.WriteLine(happyNumber ? 1 : 0);
            }
        }

        /// <summary>
        /// Returns the sum of each digit squared
        /// </summary>
        static int SquareDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                int digit = number % 10;
                number = number / 10;
                sum += digit * digit;
            }

            return sum;
        }

    }
}
