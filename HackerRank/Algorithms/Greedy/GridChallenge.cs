using System;

namespace HackerRank.Algorithms.Greedy
{
    /// <summary>
    /// Grid Challenge Challenge
    /// Description: Evaluate whether a matrix can be lexicographically sorted
    /// Problem Statement: https://www.hackerrank.com/challenges/grid-challenge
    /// </summary>
    class GridChallenge
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int t = 0; t < testCount; t++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                var matrix = new char[n][];
                for (int y = 0; y < matrix.Length; y++)
                {
                    matrix[y] = Console.ReadLine().ToCharArray();
                    Array.Sort(matrix[y]);
                }

                Console.WriteLine(IsSorted(matrix, n) ? "YES" : "NO");
            }
        }

        static bool IsSorted(char[][] matrix, int n)
        {
            for (int col = 0; col < n; col++)
            {
                for (int row = 1; row < n; row++)
                {
                    if (matrix[row - 1][col] > matrix[row][col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}