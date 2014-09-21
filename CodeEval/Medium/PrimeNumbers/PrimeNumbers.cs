using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeEval.PrimeNumbers
{
    /// <summary>
    /// Prime Numbers Challenge
    /// Difficulty: Medium
    /// Description: Print out the prime numbers less than a given number N
    /// Problem Statement: https://www.codeeval.com/open_challenges/46/
    /// </summary>
    class PrimeNumbers
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                uint n = uint.Parse(line);
                CalculatePrimesDynamic(n);

                // Output the primes less then n
                var sb = new StringBuilder(primes.Count * 2);
                foreach (var prime in primes)
                {
                    if (prime < n) { sb.AppendFormat("{0},", prime); }
                    else { break; }
                }

                Console.WriteLine(sb.ToString(0, sb.Length - 1));
            }
        }


        /// <summary>
        /// Simple Trial Division Algorithm, that calculates the primes upto and including n
        /// Uses a Dynamic Programming approach, since we are going to have to calculate multiple prime sequences we can reuse the prior results
        /// </summary>
        static List<uint> primes = new List<uint>() { 2, 3 };
        static void CalculatePrimesDynamic(uint n)
        {
            // Only test the odd numbers since all others are dividable by 2.
            // Start with the last prior calculated Prime number
            for (uint i = primes[primes.Count - 1]; i <= n; i += 2)
            {
                bool isPrime = true;
                int upperLimit = (int)Math.Sqrt(i);

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
        }


    }
}
