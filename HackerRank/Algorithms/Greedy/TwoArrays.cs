using System;

namespace HackerRank.Algorithms.Greedy
{
    /// <summary>
    /// Two Arrays Challenge
    /// Description: Evaluate whether a permutation exists where a[i] + b[i] >= k for all i
    /// Problem Statement: https://www.hackerrank.com/challenges/two-arrays
    /// </summary>
    class TwoArrays
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int t = 0; t < testCount; t++)
            {
                var split = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(split[0]);
                int target = Convert.ToInt32(split[1]);

                var left = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var right = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                Console.WriteLine(PermutationExists(left, right, target) ? "YES" : "NO");
            }
        }

        static bool PermutationExists(int[] a, int[] b, int k)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Swap(b, i, FindMinIndex(b, i, k - a[i]));
                if (a[i] + b[i] < k) { return false; }
            }

            return true;
        }

        static int FindMinIndex(int[] b, int startIndex, int target)
        {
            int minIndex = startIndex;
            int minValue = int.MaxValue;
            for (int j = startIndex; j < b.Length; j++)
            {
                // Find Minimum that is >= target
                if (b[j] >= target && b[j] < minValue)
                {
                    minIndex = j;
                    minValue = b[j];
                }
            }

            return minIndex;
        }

        static void Swap<T>(T[] data, int i, int j)
        {
            T tmp = data[i];
            data[i] = data[j];
            data[j] = tmp;
        }

    }
}