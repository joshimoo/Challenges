using System;
using System.IO;

namespace CodeEval.ReverseAndAdd
{
    /// <summary>
    /// Reverse And Add Challenge
    /// Difficulty: Medium
    /// Description: choose a number, reverse its digits and add it to the original. If the sum is not a palindrome, repeat this procedure
    /// Problem Statement: https://www.codeeval.com/open_challenges/45/
    /// </summary>
    class ReverseWords
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
                int i = 0;
                int sum = int.Parse(line);
                while (!IsPalindrome(sum) && i < 99)
                {
                    sum += Reverse(sum);
                    i++;
                }

                Console.WriteLine("{0} {1}", i, sum);
            }
        }

        /// <summary>
        /// Compares the Integer against itself by using the Fast Integer Reversal
        /// </summary>
        static bool IsPalindrome(int input) { return input == Reverse(input); }

        /// <summary>
        /// Fast Integer Reversal
        /// Works on positive / negative base 10 numbers
        /// </summary>
        static int Reverse(int number)
        {
            int reverse = 0;
            while (number != 0)
            {
                // This will get the number in the firsts place 256 % 10 = 6
                // then shifts the number downwards 256 / 10 = 25
                // then shifts the reverse upwards and adds the remainder at the appropriate place
                int remainder = number % 10;
                number = number / 10;
                reverse = reverse * 10 + remainder;
            }

            return reverse;
        }

    }
}
