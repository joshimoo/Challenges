using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CodeEval.RomanNumerals
{
    /// <summary>
    /// Roman Numerals Challenge
    /// Difficulty: Easy
    /// Description: Convert an number to an roman numeral representation of that number
    /// Problem Statement: https://www.codeeval.com/open_challenges/106/
    /// </summary>
    class RomanNumerals
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                int number = int.Parse(line);
                Console.WriteLine(ConvertToRomanNumeral(number));
            }
        }

        // Our Value Range is from [1-3999]
        // The symbols I (capital i), V, X, L, C, D, and M represent the decimal values 1, 5, 10, 50, 100, 500 and 1000
        static readonly Dictionary<int, string> numbers = new Dictionary<int, string>()
        {
            {1, "I"}, {2, "II"}, {3, "III"}, {4, "IV"}, {5, "V"}, {6, "VI"}, {7, "VII"}, {8, "VIII"}, {9, "IX"}, 
            {10, "X"}, {20, "XX"}, {30, "XXX"}, {40, "XL"}, {50, "L"}, {60, "LX"}, {70, "LXX"}, {80, "LXXX"}, {90, "XC"}, 
            {100, "C"}, {200, "CC"}, {300, "CCC"}, {400, "CD"}, {500, "D"}, {600, "DC"},{700, "DCC"},{800, "DCCC"},{900, "CM"},
            {1000, "M"}, {2000, "MM"}, {3000, "MMM"}
        };

        static string ConvertToRomanNumeral(int num)
        {
            Debug.Assert(num > 0 && num < 3999);

            var stack = new Stack<string>();
            var sb = new StringBuilder();
            int multiplier = 1;

            // We go back to front since it's more simple and generic
            while (num > 0)
            {
                int quotient = num % 10;
                num = num / 10;

                // The Roman System does not have a value for 0
                // This check also makes sure to only process numbers inside of our range
                if (numbers.ContainsKey(quotient * multiplier)) { stack.Push(numbers[quotient * multiplier]); }
                multiplier = multiplier * 10;
            }

            // process stack lifo :)
            foreach (var s in stack) { sb.Append(s); }
            return sb.ToString();
        }

    }
}
