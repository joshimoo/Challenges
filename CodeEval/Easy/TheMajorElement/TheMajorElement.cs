using System;
using System.Collections.Generic;
using System.IO;

namespace CodeEval.TheMajorElement
{
    /// <summary>
    /// The Major Element Challenge
    /// Difficulty: Easy
    /// Description: The major element in a sequence with the length of L is the element which appears in a sequence more than L/2 times
    /// Problem Statement: https://www.codeeval.com/open_challenges/132/
    /// </summary>
    class TheMajorElement
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                string[] split = line.Split(',');
                var counts = new Dictionary<string, int>();
                string majorElement = string.Empty;

                // TODO: Optimize memory, since we are losing lots of points there.
                // Maybe do an inplace sort which is O(n*log(n)) them count the duplicate occurences.
                // This is faster with O(n) but also requires additional storage
                foreach (var s in split)
                {
                    if (!counts.ContainsKey(s)) { counts.Add(s, 0); }
                    if (++counts[s] > split.Length / 2)
                    {
                        majorElement = s;
                        break;
                    }
                }

                Console.WriteLine(String.IsNullOrEmpty(majorElement) ? "None" : majorElement);
            }
        }

    }
}
