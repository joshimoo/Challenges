using System;
using System.Linq;

namespace HackerRank.Algorithms.Warmup
{
    /// <summary>
    /// Simple Array Sum Challenge
    /// Description: Sum an Array
    /// Problem Statement: https://www.hackerrank.com/challenges/simple-array-sum
    /// </summary>
    class SimpleArraySum
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int sum = Console.ReadLine().Split(' ').Sum(x => int.Parse(x));
            Console.WriteLine(sum);
        }
    }
}