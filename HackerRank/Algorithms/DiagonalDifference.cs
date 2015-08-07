using System;

namespace HackerRank.Algorithms
{
    /// <summary>
    /// Diagonal Difference Challenge
    /// Description: Calculate the absolute difference of the sums of the diagonals in a square matrix
    /// Problem Statement: https://www.hackerrank.com/challenges/diagonal-difference
    /// </summary>
    class DiagonalDifference
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int left = 0;
            int right = 0;

            // Since we only care about the diagonals we don't need to store the matrix at all
            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine().Split(' ');
                left += int.Parse(row[i]);
                right += int.Parse(row[(n - 1) - i]);
            }

            Console.WriteLine(Math.Abs(left - right));
        }
    }
}