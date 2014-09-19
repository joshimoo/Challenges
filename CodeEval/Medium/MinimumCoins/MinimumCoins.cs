using System;
using System.IO;
using System.Text;

namespace CodeEval.MinimumCoins
{
    /// <summary>
    /// Minimum Coins Challenge
    /// Difficulty: Medium
    /// Description: Calculate the minimum amount of coins required for a total
    /// Problem Statement: https://www.codeeval.com/open_challenges/74/
    /// </summary>
    class MinimumCoins
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                // This only works, when their is a coin with value 1
                int[] coins = new int[]{ 5, 3, 1 };
                int total = int.Parse(line);
                int count = 0;

                for (int i = 0; i < coins.Length; i++)
                {
                    count += total / coins[i];
                    total = total % coins[i];
                }

                Console.WriteLine(count);
            }
        }

    }
}
