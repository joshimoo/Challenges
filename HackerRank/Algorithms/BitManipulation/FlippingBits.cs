using System;

namespace HackerRank.Algorithms.BitManipulation
{
    /// <summary>
    /// Flipping Bits
    /// Description: Flip all the Bits in an Unsigned Integer
    /// Problem Statement: https://www.hackerrank.com/challenges/flipping-bits
    /// </summary>
    class FlippingBits
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int t = 0; t < testCount; t++)
            {
                uint val = Convert.ToUInt32(Console.ReadLine());
                Console.WriteLine(val ^ uint.MaxValue);
            }
        }
    }
}