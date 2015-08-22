using System;
using System.Numerics;

namespace HackerRank.Algorithms.Warmup
{
    /// <summary>
    /// Extra Long Factorials Challenge
    /// Description: Calculate huge factorials > ulong
    /// Problem Statement: https://www.hackerrank.com/challenges/extra-long-factorials
    /// </summary>
    class ExtraLongFactorials
    {
        public static void Main(string[] args)
        {
            // Naive Algorithm, for faster algorithms have a look at prime factorization based ones.
            // http://www.luschny.de/math/factorial/conclusions.html
            int n = Convert.ToInt32(Console.ReadLine());
            BigInteger sum = 1;
            for (int i = 1; i <= n; i++) { sum *= i; }
            Console.WriteLine(sum);
        }
    }
}