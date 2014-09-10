using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HackerRank.Algorithms.Warmup.GameOfThrones1
{
    /// <summary>
    /// Game of Thrones 1 Challenge
    /// Description: figure out if any anagram of the string can be a palindrome
    /// Problem Statement: https://www.hackerrank.com/challenges/game-of-thrones
    /// </summary>
    class GameOfThrones1
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine().Trim();
            Debug.Assert(line.Length >= 1 && line.Length <= 100000);
            Console.WriteLine(PossiblePalindrome(line) ? "YES" : "NO");
        }

        /// <summary>
        /// Complexity: O(n)
        /// </summary>
        static bool PossiblePalindrome(string line)
        {
            var charCounts = new Dictionary<char, int>();
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (!charCounts.ContainsKey(c)) { charCounts.Add(c, 0); }
                charCounts[c]++;
            }

            // an even length text can have at most 0 mismatches
            // an  odd length text can have at most 1 mismatches
            int mismatches = 0;
            int maxMismatches = line.Length % 2;
            foreach (var count in charCounts.Values)
            {
                if (count % 2 != 0)
                {
                    mismatches++;
                    if (mismatches > maxMismatches) { break; }
                }
            }

            return mismatches <= maxMismatches;
        }

    }
}
