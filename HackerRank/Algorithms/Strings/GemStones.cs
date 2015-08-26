using System;

namespace HackerRank.Algorithms.Strings
{
    /// <summary>
    /// Gemstones Challenge
    /// Description: Calculate the Set of elements which is used in all stones
    /// Problem Statement: https://www.hackerrank.com/challenges/gem-stones
    /// </summary>
    class Gemstones
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            uint sharedGems = uint.MaxValue;
            for (int i = 0; i < n; i++)
            {
                sharedGems = sharedGems & ReadStone();
            }

            // Now count the high bits, to find the amount of shared Gems
            int count = 0;
            for (int i = 0; i < 26; i++)
            {
                if ((sharedGems & (1 << i)) != 0) { count++; }
            }

            Console.WriteLine(count);
        }


        /// <summary>
        /// Store the Alphabet of the Stone, inside of a 32 bit Integer
        /// So that evaluation will be just an AND over all stones :)
        /// Could use BitVector instead, but wanted to do this lower level.
        /// </summary>
        static uint ReadStone()
        {
            int c;
            uint stone = 0;
            while ((c = Console.Read()) != -1)
            {
                if (c >= 'a' && c <= 'z') { stone = (stone | (uint)(1 << c - 'a')); }
                else if (c == '\n') { break; }
            }

            return stone;
        }

    }
}