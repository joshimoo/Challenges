using System;
using System.Collections.Generic;

namespace CodeEval.SumOfPrimes
{
    /// <summary>
    /// Sum of Primes Challenge
    /// Difficulty: Easy
    /// Description: determine the sum of the first 1000 prime numbers.
    /// Problem Statement: https://www.codeeval.com/open_challenges/4/
    /// </summary>
    class SumOfPrimes
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            // No input in this challenge
            int sum = SumPrimes(1000);
            Console.WriteLine(sum);
        }

        /// <summary>
        /// Simple Trial Division Algorithm
        /// </summary>
        static int SumPrimes(int n)
        {
            var primes = new List<int>(n) { 2 };
            int sum = 2;

            // Only test the odd numbers since all others are dividable by 2.
            for (int i = 3; primes.Count < n; i += 2)
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

                if (isPrime)
                {
                    primes.Add(i);
                    sum += i;
                }
            }

            return sum;
        }

    }
}
