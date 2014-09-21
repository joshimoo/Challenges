using System;
using System.Collections.Generic;

namespace CodeEval.PrimePalindrome
{
    /// <summary>
    /// Prime Palindrome Challenge
    /// Difficulty: Easy
    /// Description: determine the biggest prime palindrome under 1000
    /// Problem Statement: https://www.codeeval.com/open_challenges/3/
    /// </summary>
    class PrimePalindrome
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            // No input in this challenge
            int biggestPrimePalindrome = BiggestPrimePalindrome(1000);
            Console.WriteLine(biggestPrimePalindrome);
        }

        /// <summary>
        /// Simple Trial Division Algorithm
        /// </summary>
        static int BiggestPrimePalindrome(int n)
        {
            var primes = new List<int>(n) { 2 };

            // Only test the odd numbers since all others are dividable by 2.
            for (int i = 3; i <= n; i += 2)
            {
                bool isPrime = true;
                int upperLimit = (int)Math.Sqrt(i); // Upper Limit for the Prime Test

                // Check the current Number against the prime numbers that where calculated sofar
                // If it's not prime, it can be divided by one of the prime numbers
                for (int j = 0; primes[j] <= upperLimit; j++)
                {
                    if (i % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) { primes.Add(i); }
            }

            // NOTE: Checking the list backwards since that will reduce the required palindrome check count
            for (int i = primes.Count - 1; i >= 0; i--)
            {
                if (IsPalindrome(primes[i])) { return primes[i]; }
            }

            return -1;
        }


        /// <summary>
        /// Quick palindrome checking implementation
        /// </summary>
        static bool IsPalindrome<T>(T input)
        {
            string candidate = input.ToString();
            for (int i = 0; i < candidate.Length / 2; i++)
            {
                if (candidate[i] != candidate[candidate.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
