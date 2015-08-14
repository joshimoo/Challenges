using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HackerRank.Algorithms.Search
{
    /// <summary>
    /// Ice Cream Parlor Challenge
    /// Description: Find 2 Entries that sum to x
    /// Problem Statement: https://www.hackerrank.com/challenges/icecream-parlor
    /// </summary>
    class IceCreamParlor
    {
        public static void Main(string[] args)
        {
            // TODO: The way hackerrank handles the input, leads to size issues, even when trying to use custom input source
            Console.SetIn(new StreamReader(Console.OpenStandardInput(10240 * 10000), Encoding.Default, false, 10240 * 10000));
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                int targetSum = Convert.ToInt32(Console.ReadLine());
                int count = Convert.ToInt32(Console.ReadLine());
                var nums = Array.ConvertAll(ReadLine().Split(' '), int.Parse);

                var elements = FindElementsThatSumToX(nums, targetSum);
                Console.WriteLine("{0} {1}", elements[0], elements[1]);
            }
        }


        /// <summary>
        /// Since we don't know the size of the numbers array and it's bigger then the Console Buffer
        /// We store one character at a time
        /// </summary>
        static string ReadLine()
        {
            var sb = new StringBuilder();
            while (true)
            {
                int c = Console.Read();
                if (c == -1) { break; }
                if (c == '\r') { c = Console.Read(); }      // don't store '\r'
                if (c == '\n') { return sb.ToString(); }

                sb.Append((char)c);
            }

            return sb.Length > 0 ? sb.ToString() : null;
        }

        /// <summary>
        /// Returns the ascendling sorted indexes of the two elements which sum to x
        /// The Indexes are 1-based
        /// </summary>
        static int[] FindElementsThatSumToX(int[] nums, int x)
        {
            var map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int diff = x - nums[i];
                if (map.ContainsKey(diff)) { return new int[] { map[diff] + 1, i + 1 }; }
                map.Add(nums[i], i);
            }

            // Elements could not be found
            return null;
        }

    }
}