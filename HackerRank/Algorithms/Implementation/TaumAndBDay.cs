using System;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Taum And B'Day Challenge
    /// Description: Calculate the cheapest price for the gifts
    /// Problem Statement: https://www.hackerrank.com/challenges/taum-and-bday
    /// </summary>
    class TaumAndBDay
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                var split = Console.ReadLine().Split(' ');
                ulong blackAmount = Convert.ToUInt64(split[0]);
                ulong whiteAmount = Convert.ToUInt64(split[1]);

                split = Console.ReadLine().Split(' ');
                ulong blackCost = Convert.ToUInt64(split[0]);
                ulong whiteCost = Convert.ToUInt64(split[1]);
                ulong transformCost = Convert.ToUInt64(split[2]);
                ulong minCost = blackAmount * Math.Min(blackCost, whiteCost + transformCost) +
                                whiteAmount * Math.Min(whiteCost, blackCost + transformCost);
                Console.WriteLine(minCost);
            }
        }

    }
}