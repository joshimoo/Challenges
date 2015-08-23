using System;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Make It Anagram Challenge
    /// Description: Find the Amount of Deletions, to turn a string into an anagram
    /// Problem Statement: https://www.hackerrank.com/challenges/make-it-anagram
    /// </summary>
    class MakeItAnagram
    {
        public static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            Console.WriteLine(DeletionCount(a, b));
        }

        static int DeletionCount(string a, string b)
        {
            // Input will only contain a-z
            int alphabetCount = 'z' - 'a' + 1;
            char[] left = new char[alphabetCount];
            char[] right = new char[alphabetCount];

            foreach (var c in a) { left[c - 'a']++; }
            foreach (var c in b) { right[c - 'a']++; }

            int sum = 0;
            for (int i = 0; i < alphabetCount; i++)
            {
                int dif = Math.Abs(left[i] - right[i]);
                if (dif > 0) { sum += dif; }
            }


            return sum;
        }

    }
}