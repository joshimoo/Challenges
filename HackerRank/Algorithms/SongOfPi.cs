using System;
using System.Linq;

namespace HackerRank.Algorithms
{
    /// <summary>
    /// SongOfPi Challenge
    /// Description: Evaluate whether the word lengths map to pi
    /// Problem Statement: https://www.hackerrank.com/challenges/song-of-pi
    /// </summary>
    class SongOfPi
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                Console.WriteLine(MapsToPi(Console.ReadLine()) ? "It's a pi song." : "It's not a pi song.");
            }
        }

        static bool MapsToPi(string s)
        {
            const string pi = "31415926535897932384626433833";
            var words = s.Split(' ');
            return !words.Where((t, i) => t.Length != (pi[i] - '0')).Any();
        }
    }
}