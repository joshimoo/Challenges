using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CodeEval.FirstNonRepeatedCharacter
{
    /// <summary>
    /// First Non-Repeated Character Challenge
    /// Difficulty: Medium
    /// Description: Find the first non repeated character in a string
    /// Problem Statement: https://www.codeeval.com/open_challenges/12/
    /// </summary>
    class FirstNonRepeatedCharacter
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
                Console.WriteLine(FindFirstNonRepeatedCharacter(line));
            }
        }

        /// <summary>
        /// Returns the first non repeated character
        /// Uses a Dictionary to keep track of char counts
        /// </summary>
        static char FindFirstNonRepeatedCharacter(string line)
        {
            var counts = new Dictionary<char, int>();

            // Index all Characters
            foreach (char c in line)
            {
                if (!counts.ContainsKey(c)) { counts.Add(c, 1); }
                else { counts[c]++; }
            }

            // Find the first non repeated Character
            // This uses the fact that the enumerator for the dict is in adding order, unless you remove elements from the dict.
            // NOTE: A more guaranteed approach is to iterate trough the input again and exit once the char count == 1
            return (from kvp in counts where kvp.Value == 1 select kvp.Key).FirstOrDefault();
        }

    }
}
