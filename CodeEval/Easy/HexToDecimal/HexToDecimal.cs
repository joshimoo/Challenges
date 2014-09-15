using System;
using System.Collections.Generic;
using System.IO;

namespace CodeEval.HexToDecimal
{
    /// <summary>
    /// Hex to Decimal Challenge
    /// Difficulty: Easy
    /// Description: Convert a Hex Number (no 0x prefix) to a decimal
    /// Problem Statement: https://www.codeeval.com/open_challenges/67/
    /// </summary>
    class HexToDecimal
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
                Console.WriteLine(HexNumberToDecimal(line));
            }
        }

        /// <summary>
        /// Maps the Hex Characters to their numeric representation
        /// </summary>
        static readonly Dictionary<char, int> hexValues = new Dictionary<char, int>()
        {
            {'0', 0}, {'1', 1}, {'2', 2}, {'3', 3}, {'4', 4}, {'5', 5}, {'6', 6}, {'7', 7},{'8', 8}, {'9', 9}, 
            {'a', 10}, {'b', 11}, {'c', 12}, {'d', 13}, {'e', 14}, {'f', 15}
        };

        /// <summary>
        /// Converts a Hex number (base 16) to an int (base 10)
        /// NOTE: Could easily changed the method to handle other bases
        /// </summary>
        static int HexNumberToDecimal(string hexNumber)
        {
            int number = 0;
            const int hexBase = 16;
            for (int i = hexNumber.Length - 1; i >= 0; i--)
            {
                int quotient = hexValues[hexNumber[i]];
                int exponent = (hexNumber.Length - 1) - i;
                number += (int)(quotient * Math.Pow(hexBase, exponent));
            }

            return number;
        }

    }
}
