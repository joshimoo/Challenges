using System;
using System.Linq;

namespace HackerRank.Algorithms.Warmup
{
    /// <summary>
    /// A Very Big Sum Challenge
    /// Description: Sum Big Numbers
    /// Problem Statement: https://www.hackerrank.com/challenges/a-very-big-sum
    /// </summary>
    class AVeryBigSum
    {
        public static void Main(string[] args)
        {
            int count = Convert.ToInt32(Console.ReadLine());
            long sum = Console.ReadLine().Split(' ').Sum(s => long.Parse(s));
            Console.WriteLine(sum);
        }
    }
}