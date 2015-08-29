using System;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Two Strings Challenge
    /// Description: Find if there is a common substring for two Strings
    /// Problem Statement: https://www.hackerrank.com/challenges/two-strings
    /// </summary>
    class TwoStrings
    {
        public static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                uint a = ReadAlphabet();
                uint b = ReadAlphabet();

                Console.WriteLine((a & b) > 0 ? "YES" : "NO");
            }
        }


        /// <summary>
        /// Reads a line from Console and stores the used characters in an uints bit
        /// Only processes lower case a-z
        /// </summary>
        static uint ReadAlphabet()
        {
            int c;
            uint alphabet = 0;
            while ((c = Console.Read()) != -1)
            {
                if (c >= 'a' && c <= 'z') { alphabet = (alphabet | (uint)(1 << c - 'a')); }
                else if (c == '\n') { break; }
            }

            return alphabet;
        }

    }
}