using System;
using System.Diagnostics;

namespace HackerRank.SherlockAndArray
{
    /// <summary>
    /// Sherlock and Array Challenge
    /// Description: Find Element where the sum of elements on its left is equal to the sum of elements on its right
    /// Problem Statement: https://www.hackerrank.com/challenges/sherlock-and-array
    /// </summary>
    class SherlockAndArray
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine().Trim();
            int t = int.Parse(line);
            Debug.Assert(t >= 1 && t <= 10);
            for (var i = 0; i < t; i++)
            {
                line = Console.ReadLine().Trim();
                int numberOfEntries = int.Parse(line);
                Debug.Assert(numberOfEntries >= 1 && numberOfEntries <= 100000);

                line = Console.ReadLine().Trim();
                var split = line.Split(' ');
                Debug.Assert(split.Length == numberOfEntries);

                //int[] entries = Array.ConvertAll(split, element => int.Parse(element));
                int[] entries = new int[numberOfEntries];
                int[] precalc = new int[numberOfEntries];

                // Since I have todo the precalc I can do the conversion per element at the same time
                for (int j = 0; j < numberOfEntries; j++)
                {
                    entries[j] = int.Parse(split[j]);
                    precalc[j] = (j > 0 ? precalc[j - 1] : 0) + entries[j];
                    Debug.Assert(entries[j] >= 1 && entries[j] <= 20000);
                }

                // Check for possible match left-sum == right-sum
                Console.WriteLine(ContainsDevider(entries, precalc) ? "YES" : "NO");
            }
        }

        static bool ContainsDevider(int[] entries, int[] precalc)
        {
            int n = entries.Length;

            // n == 1 -> true
            // n == 2 -> false
            if (n == 1) { return true; }
            if (n == 2) { return false; }

            for (int i = 1; i < n; i++)
            {
                // Check for possible match left-sum == right-sum where i is devider
                if (precalc[i - 1] == (precalc[n - 1] - precalc[i])) { return true; }
            }

            return false;
        }
    }
}
