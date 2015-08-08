using System;

namespace HackerRank.Algorithms
{
    /// <summary>
    /// Staircase Challenge
    /// Description: Print a Staircase of height n
    /// Problem Statement: https://www.hackerrank.com/challenges/staircase
    /// </summary>
    class Staircase
    {
        public static void Main(string[] args)
        {
            int height = Convert.ToInt32(Console.ReadLine());
            for (int i = height - 1; i >= 0; i--)
            {
                Console.WriteLine(new String(' ', i) + new String('#', height - i));
            }
        }
    }
}