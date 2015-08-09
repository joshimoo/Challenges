using System;

namespace HackerRank.Algorithms
{
    /// <summary>
    /// Utopian Tree Challenge
    /// Description: Calculate the height after n growth cycles
    /// Problem Statement: https://www.hackerrank.com/challenges/utopian-tree
    /// </summary>
    class UtopianTree
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(RecursiveSolution(n));
            }
        }


        /// <summary>
        /// Integer Sequence: https://oeis.org/A075427
        /// a(0) = 1; a(n) = if n is even then a(n-1)+1 else 2*a(n-1).
        /// </summary>
        static long RecursiveSolution(int n)
        {
            // Base Case a(0)
            if (n == 0) { return 1; }
            else if (n % 2 == 0) { return RecursiveSolution(n - 1) + 1; }
            else { return RecursiveSolution(n - 1) * 2; }
        }

        /// <summary>
        /// Integer Sequence: https://oeis.org/A075427
        /// a(0) = 1; a(n) = if n is even then a(n-1)+1 else 2*a(n-1).
        /// </summary>
        static long IterativeSolution(int n)
        {
            int height = 1;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0) { height *= 2; }
                else { height++; }
            }
            return height;
        }
    }
}