using System;
using System.Diagnostics;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Chocolate Feast Challenge
    /// Description: Calculate the amount of Chocolates Bill will get
    /// Problem Statement: https://www.hackerrank.com/challenges/chocolate-feast
    /// </summary>
    class ChocolateFeast
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                var split = Console.ReadLine().Split(' ');
                int money = Convert.ToInt32(split[0]);
                int cost = Convert.ToInt32(split[1]);
                int trade = Convert.ToInt32(split[2]);

                Console.WriteLine(CalculateChocolates(money, cost, trade));
            }
        }

        /// <summary>
        /// Calculate the amount of Chocolates Bill will get.
        /// Whereby, it will continuosly trade the maximum, while the newly acquired still allow to trade
        /// To make sure that this will end, the tradecost needs to be higher then 1
        /// </summary>
        static int CalculateChocolates(int money, int buyCost, int tradeCost)
        {
            Debug.Assert(tradeCost >= 2);
            int bought = money / buyCost;
            int traded = bought / tradeCost;
            int leftOver = (bought % tradeCost) + traded;
            int total = bought + traded;

            // Can we trade more chocolates?
            while (leftOver >= tradeCost)
            {
                traded = leftOver / tradeCost;
                leftOver = (leftOver % tradeCost) + traded;
                total = total + traded;
            }

            return total;
        }
    }
}