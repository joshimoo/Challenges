using System;
using System.Linq;

namespace HackerRank.Algorithms
{
    /// <summary>
    /// Pangrams Challenge
    /// Description: Evaluate wether a string is a pangram (contains a-z atleast once)
    /// Problem Statement: https://www.hackerrank.com/challenges/pangrams
    /// </summary>
    class Pangrams
    {
        public static void Main(string[] args)
        {
            string msg = Console.ReadLine();
            Console.WriteLine(IsPangramBitField(msg) ? "pangram" : "not pangram");
        }

        /// <summary>
        /// Regular Pangram check with an alphabet counter
        /// </summary>
        static bool IsPangram(string msg)
        {
            var count = new short[26];
            foreach (char c in msg)
            {
                if (c >= 'a' && c <= 'z') { count[c - 'a']++; }
                else if (c >= 'A' && c <= 'Z') { count[c - 'A']++; }
            }

            // did each character appear atleast once
            return count.Where(val => val > 0).Count() == count.Length;
        }

        /// <summary>
        /// The Bit mapping is very fast, but more importantly
        /// it allows for a very performant early exit logic.
        /// Since to evaluate wheter it's a pangram it's just an equals check
        /// </summary>
        static bool IsPangramBitField(string msg)
        {
            int p = 0;
            foreach (char c in msg)
            {
                if (c >= 'a' && c <= 'z') { p |= 1 << (c - 'a'); }
                else if (c >= 'A' && c <= 'Z') { p |= 1 << (c - 'A'); ; }
            }

            // To be a pangram, bits [0-25] need to be high
            return p == ((1 << 26) - 1);
        }
    }
}