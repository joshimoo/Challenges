using System;
using System.Text;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Manasa And Stones Challenge
    /// Description: Find all permutations for a* + b* for n
    /// Problem Statement: https://www.hackerrank.com/challenges/manasa-and-stones
    /// </summary>
    class ManasaAndStones
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(CalculateUniqueSums(n, a, b));
            }
        }


        /// <summary>
        /// No need to calculate the series, I just need to calculate the permutations of the sum
        /// Since we only care about the unique end sums, position of terms does not matter.
        /// One Benefit of this is that we don't need a set since we only calculate the unique ones
        /// Also we don't need to sort the results, as long as a < b
        /// Example
        /// 0,1,2
        /// 0,1,3
        /// 0,2,3 (Duplicate no need to calculate)
        /// 0,2,4
        /// </summary>
        static string CalculateUniqueSums(int n, int a, int b)
        {
            if (b == a)
            {
                // If the two terms are identical, there is only 1 possible sum
                return (a * (n - 1)).ToString();
            }
            if (b < a)
            {
                // Make sure a is smaller then b, that way we don't need to sort the results later :)
                int tmp = a;
                a = b;
                b = tmp;
            }

            var sb = new StringBuilder();
            for (int j = 0; j < n; j++)
            {
                sb.Append(a * (n - 1 - j) + b * j).Append(' ');
            }

            return sb.ToString(0, sb.Length - 1);
        }

    }
}