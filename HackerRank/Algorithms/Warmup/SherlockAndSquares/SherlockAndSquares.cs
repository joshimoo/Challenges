using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HackerRank.Algorithms.Warmup.SherlockAndSquares
{
    /// <summary>
    /// Sherlock and Squares Challenge
    /// Description: Given two integers A & B count the number of square integers between A and B (both inclusive)
    /// Problem Statement: https://www.hackerrank.com/challenges/sherlock-and-squares
    /// </summary>
    class SherlockAndSquares
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine().Trim();
            int t = int.Parse(line);
            Debug.Assert(t >= 1 && t <= 100);
            for (var i = 0; i < t; i++)
            {
                line = Console.ReadLine().Trim();
                var split = line.Split(' ');
                int a = int.Parse(split[0]);
                int b = int.Parse(split[1]);
                Debug.Assert(1 <= a && a <= b && b <= 1000000000);

                // create a list so we don't have to recalculate already calculated entries
                var calculatedSquares = new List<int>() { 0 };
                Console.WriteLine(CalculateSquares(a, b, calculatedSquares));
            }
        }

        static int CalculateSquares(int lowerBound, int upperBound, List<int> calculatedSquares)
        {
            int count = 0;

            // Start from the last calculated square and see if its inside the search area
            for (int i = calculatedSquares.Count; i * i <= upperBound; i++)
            {
                calculatedSquares.Add(i * i);
            }

            // Find all elements inside the search area
            // Alternativly Use BinarySearch to find the optimal starting index
            int startIndex = (int)Math.Ceiling(Math.Sqrt(lowerBound));
            for (int i = startIndex; i * i <= upperBound; i++)
            {
                count++;
            }

            return count;
        }

    }
}
