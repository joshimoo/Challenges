using System;
using System.Diagnostics;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Find Digits Challenge
    /// Description: You are given a number N, you need to print the number of positions where digits exactly divides N
    /// Problem Statement: https://www.hackerrank.com/challenges/find-digits
    /// </summary>
    class FindDigits
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine().Trim();
            int t = int.Parse(line);
            Debug.Assert(t >= 1 && t <= 15);
            for (var i = 0; i < t; i++)
            {
                line = Console.ReadLine().Trim();
                int n = int.Parse(line);
                Debug.Assert(n > 0 && n < 10000000000);
                Console.WriteLine(CalculateDigits(n));
            }
        }

        static int CalculateDigits(int n)
        {
            int sum = 0;
            int number = n;
            while (number != 0)
            {
                int digit = number % 10;
                number = number / 10;

                // can n be devided by this digit evenly?
                if (digit != 0 && n % digit == 0) { sum++; }
            }

            return sum;
        }
    }
}
