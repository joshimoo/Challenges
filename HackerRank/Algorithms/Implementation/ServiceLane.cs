using System;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Service Lane Challenge
    /// Description: Find the appropriate Vehicle (min of start to end)
    /// Problem Statement: https://www.hackerrank.com/challenges/service-lane
    /// </summary>
    class ServiceLane
    {
        public static void Main(string[] args)
        {
            var split = Console.ReadLine().Split(' ');
            int segmentCount = Convert.ToInt32(split[0]);
            int testCount = Convert.ToInt32(split[1]);

            int[] segments = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int t = 0; t < testCount; t++)
            {
                split = Console.ReadLine().Split(' ');
                int startIndex = Convert.ToInt32(split[0]);
                int endIndex = Convert.ToInt32(split[1]);
                Console.WriteLine(Min(segments, startIndex, endIndex));
            }
        }

        static int Min(int[] data, int startIndex, int endIndex)
        {
            int min = data[startIndex];
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (data[i] < min) { min = data[i]; }
            }

            return min;
        }
    }
}