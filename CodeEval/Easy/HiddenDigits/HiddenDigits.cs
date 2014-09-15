using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeEval.HiddenDigits
{
    /// <summary>
    /// Hidden Digits Challenge
    /// Difficulty: Easy
    /// Description: Find all Digits inside of a sentence including hidden digits
    /// Problem Statement: https://www.codeeval.com/open_challenges/122/
    /// </summary>
    class HiddenDigits
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
                Console.WriteLine(FindAllDigits(line));
            }
        }

        /// <summary>
        /// Maps the Characters to their numeric representation
        /// </summary>
        static readonly Dictionary<char, int> digitValues = new Dictionary<char, int>()
        {
            {'0', 0}, {'1', 1}, {'2', 2}, {'3', 3}, {'4', 4}, {'5', 5}, {'6', 6}, {'7', 7},{'8', 8}, {'9', 9}, 
            {'a', 0}, {'b', 1}, {'c', 2}, {'d', 3}, {'e', 4}, {'f', 5}, {'g', 6}, {'h', 7}, {'i', 8}, {'j', 9}
        };

        /// <summary>
        /// Find all digits inside of a sentence, including hidden Digits 
        /// Could also do asci arithmetic magic, but this is much nicer code =)
        /// </summary>
        static string FindAllDigits(string sentence)
        {
            var sb = new StringBuilder();
            foreach (var c in sentence)
            {
                if (digitValues.ContainsKey(c)) { sb.Append(digitValues[c]); }
            }

            return sb.Length > 0 ? sb.ToString() : "NONE";
        }

    }
}
