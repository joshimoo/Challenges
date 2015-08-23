using System;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Anagram Challenge
    /// Description: Find the Amount of swaps, to turn a string into an anagram
    /// Problem Statement: https://www.hackerrank.com/challenges/anagram
    /// </summary>
    class Anagram
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                string s = Console.ReadLine();
                Console.WriteLine(SwapCount(s));
            }
        }

        static int SwapCount(string s)
        {
            if (s.Length % 2 != 0) { return -1; }

            // Input will only contain a-z
            int alphabetCount = 'z' - 'a' + 1;
            char[] left = new char[alphabetCount];
            char[] right = new char[alphabetCount];

            int mid = s.Length / 2;
            for (int i = 0; i < mid; i++)
            {
                left[s[i] - 'a']++;
                right[s[mid + i] - 'a']++;
            }

            int sum = 0;
            for (int i = 0; i < alphabetCount; i++)
            {
                int dif = (left[i] - right[i]);
                if (dif > 0) { sum += dif; }
            }


            return sum;
        }

    }
}