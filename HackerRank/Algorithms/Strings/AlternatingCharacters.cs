using System;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Alternating Characters Challenge
    /// Description: Find the Minimum Amount of deletions so the string is a collection of alternating characters
    /// Problem Statement: https://www.hackerrank.com/challenges/alternating-characters
    /// </summary>
    class AlternatingCharacters
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                string s = Console.ReadLine();
                Console.WriteLine(MinimumDeletionCount(s));
            }
        }

        static int MinimumDeletionCount(string s)
        {
            int deletions = 0;
            char prev = Char.MinValue;
            foreach (var c in s)
            {
                if (c != prev) { prev = c; }
                else { deletions++; }
            }

            return deletions;
        }
    }
}