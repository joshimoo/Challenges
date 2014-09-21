using System;
using System.Collections.Generic;
using System.IO;

namespace CodeEval.CountingPrimes
{
    /// <summary>
    /// Counting Primes Challenge
    /// Difficulty: Medium
    /// Description: Count the Primes beetwen N and M
    /// Problem Statement: https://www.codeeval.com/open_challenges/63/
    /// </summary>
    class CountingPrimes
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
                var split = line.Split(',');
                uint n = uint.Parse(split[0]);
                uint m = uint.Parse(split[1]);

                // Calculate Primes upto and including M
                CalculatePrimesDynamic(m);
                int sum = CountPrimes(n, m);
                Console.WriteLine(sum);
            }
        }

        static int CountPrimes(uint n, uint m)
        {
            int leftIndex = BinarySearch.FindIndex(primes, n, BinarySearch.FindType.EqualOrMore);
            int rightIndex = BinarySearch.FindIndex(primes, m, BinarySearch.FindType.EqualOrLess);
            int sum = (rightIndex - leftIndex) + 1;

            return sum;
        }

        /// <summary>
        /// Contains all the prime numbers that where calculated so far
        /// Make sure that it atleast has an uneven prime as a last element
        /// </summary>
        static List<uint> primes = new List<uint>() { 2, 3, 5, 7, 11 };

        /// <summary>
        /// Simple Trial Division Algorithm, that calculates the primes upto and including n
        /// Uses a Dynamic Programming approach, since we are going to have to calculate multiple prime sequences we can reuse the prior results
        /// </summary>
        static void CalculatePrimesDynamic(uint n)
        {
            // Only test the odd numbers since all others are dividable by 2.
            // Start with the last prior calculated Prime number + 2
            for (uint i = primes[primes.Count - 1] + 2; i <= n; i += 2)
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


        static class BinarySearch
        {
            /// <summary>
            /// Defines the Find Behaviour for the Binary Search
            /// </summary>
            internal enum FindType { EqualOrMinusOne, EqualOrLess, EqualOrMore };

            /// <summary>
            /// Binary Search O(Log(n))
            /// Depending on the passed FindType it will either return the element or the closest index to the element
            /// </summary>
            internal static int FindIndex<T>(IList<T> data, T element, FindType findType = FindType.EqualOrMinusOne) { return FindIndex(data, element, Comparer<T>.Default, findType); }
            internal static int FindIndex<T>(IList<T> data, T element, Comparer<T> comparer, FindType findType)
            {
                // Exit early if the element couldn't possibly be in the data
                if (data.Count < 1) { return -1; }
                else if (comparer.Compare(element, data[0]) < 0) { return findType == FindType.EqualOrMore ? 0 : -1; }
                else if (comparer.Compare(element, data[data.Count - 1]) > 0) { return findType == FindType.EqualOrLess ? data.Count - 1 : -1; }

                // Test Run: data=[2, 3, 5, 7, 11, 13], element=9,6
                // Run 0: min=0, max=5, mid=2
                // Run 1: min=3, max=5, mid=4
                // Run 2: min=3, max=3, mid=3
                // Exit9 : min=4, max=3, mid=3
                // Exit6 : min=3, max=2, mid=3
                int minIndex = 0;
                int maxIndex = data.Count - 1;

                while (minIndex <= maxIndex)
                {
                    int midIndex = (minIndex + maxIndex) / 2;
                    int c = comparer.Compare(element, data[midIndex]);

                    if (c == 0) { return midIndex; } // Found
                    else if (c > 0) { minIndex = midIndex + 1; } // Right Side
                    else if (c < 0) { maxIndex = midIndex - 1; } // Left Side
                }

                // Did not find the Item
                switch (findType)
                {
                    case FindType.EqualOrLess:
                    return maxIndex;

                    case FindType.EqualOrMore:
                    return minIndex;

                    case FindType.EqualOrMinusOne:
                    default:
                    return -1;
                }
            }
        }


    }
}
