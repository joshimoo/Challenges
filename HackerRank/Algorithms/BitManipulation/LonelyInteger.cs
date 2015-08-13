using System;
using System.Linq;

namespace HackerRank.Algorithms.BitManipulation
{
    /// <summary>
    /// Lonely Integer
    /// Description: Find the Single Integer that does not have a duplicate
    /// Problem Statement: https://www.hackerrank.com/challenges/lonely-integer
    /// </summary>
    class LonelyInteger
    {
        public static void Main(string[] args)
        {
            int count = Convert.ToInt32(Console.ReadLine());
            var nums = Console.ReadLine().Split(' ');
            int lonelyInteger = nums.Select(int.Parse).Aggregate((acc, val) => acc ^ val);
            Console.WriteLine(lonelyInteger);
        }
    }
}