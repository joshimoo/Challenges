using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeEval.DecimalToBinary
{
    /// <summary>
    /// Decimal To Binary Challenge
    /// Difficulty: Medium
    /// Description: Convert number to binary
    /// Problem Statement: https://www.codeeval.com/open_challenges/27/
    /// </summary>
    class DecimalToBinary
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
                if (!String.IsNullOrEmpty(line))
                {
                    int number = int.Parse(line);
                    Console.WriteLine(IntegerToBinary(number));
                }
            }
        }

        /// <summary>
        /// Quick and Dirty implementation
        /// Not optimized at all, and I feel like the Stack and StringBuilder business sucks.
        /// TODO: Rewrite this in a cleaner and more optimized fashion.
        /// </summary>
        static string IntegerToBinary(int number)
        {
            // Exit early
            if (number == 0) { return "0"; }

            var stack = new Stack<int>();
            while (number > 0)
            {
                int remainder = number % 2;
                number = number / 2;
                stack.Push(remainder);
            }

            var sb = new StringBuilder(stack.Count);
            while (stack.Count > 0) { sb.Append(stack.Pop()); }

            return sb.ToString();
        }
    }
}
