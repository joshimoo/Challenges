using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeEval.ColumnNames
{
    /// <summary>
    /// Column Names Challenge
    /// Difficulty: Medium
    /// Description: Convert number to bijective base-26 system (A-Z no 0 char)
    /// Problem Statement: https://www.codeeval.com/open_challenges/197/
    /// </summary>
    class ColumnNames
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                if (!String.IsNullOrEmpty(line))
                {
                    int number = int.Parse(line);
                    Console.WriteLine(IntegerToBijectiveBase26(number));
                }
            }
        }

        /// <summary>
        /// The Excel Column Names use a Bijective base 26 system.
        /// A Bijective numeration is any numeral system in which every non-negative integer can be represented in exactly one way using a finite string of digits.
        /// Tldr. Does not contain a 0 quotient, since that would lead to multiple representations for each number (009 == 09 == 9, etc)
        /// </summary>
        static string IntegerToBijectiveBase26(int number)
        {
            var stack = new Stack<char>();
            while (number > 0)
            {
                // Transform Quotient into 0-25 Range
                number = number - 1;
                char c = (char)('A' + (number % 26));
                number = number / 26;
                stack.Push(c);
            }

            var sb = new StringBuilder(stack.Count);
            foreach (var c in stack) { sb.Append(c); }
            return sb.ToString();
        }


    }
}
