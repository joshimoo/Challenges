using System;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Alternating Characters Challenge
    /// Description: Evaluate whether a string is funny
    /// Problem Statement: https://www.hackerrank.com/challenges/funny-string
    /// </summary>
    class FunnyString
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                string s = Console.ReadLine();
                Console.WriteLine(IsFunny(s) ? "Funny" : "Not Funny");
            }
        }

        /// <summary>
        /// The string S is funny if the condition |s[i] - s[i - 1]| == |r[i] - r[i - 1]| is true for each i from 1 to N-1
        /// Whereby r is the reverse of s
        /// </summary>
        static bool IsFunny(string s)
        {
            int last = s.Length - 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (Math.Abs(s[i] - s[i - 1]) != Math.Abs(s[last - i] - s[last - i + 1])) { return false; }
            }

            return true;
        }
    }
}