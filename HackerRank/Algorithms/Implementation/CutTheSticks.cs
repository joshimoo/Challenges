using System;
using System.Linq;

namespace HackerRank.Algorithms.Warmup
{
    /// <summary>
    /// Cut The Sticks Challenge
    /// Description: Cut the sticks till there are no more left
    /// Problem Statement: https://www.hackerrank.com/challenges/cut-the-sticks
    /// </summary>
    class CutTheSticks
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var sticks = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int sum = 0;

            // The Linq is nice, but unfortunatly I need to iterate multiple times
            // A completly different approach is to sort, descending than you can select at the end
            // and remove all elements smaller-equal 0 by lowering the list count
            // That way the list to iterate gets smaller each iteration
            while ((n = sticks.Count(x => (x - sum) > 0)) > 0)
            {
                sum += sticks.Where(x => (x - sum) > 0).DefaultIfEmpty(sum).Min(x => x - sum);
                Console.WriteLine(n);
            }
        }


    }
}