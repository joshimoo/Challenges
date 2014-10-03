using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace CodeEval.LowestUniqueNumber
{
    /// <summary>
    /// Lowest Unique Number Challenge
    /// Difficulty: Easy
    /// Description: Return the index of the lowest unique number. Indexes are 1Based. So 0 means no entry
    /// Problem Statement: https://www.codeeval.com/open_challenges/103/
    /// </summary>
    class LowestUniqueNumber
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
                // TODO: Refactor this into a better solution
                // The Input is single digits only and very small. So use a fast integer Conversion instead of this string handling.
                // Count each Numbers Occurence
                string[] input = line.Split(' ');
                var counts = new Dictionary<string, int>();
                foreach (var num in input)
                {
                    if (!counts.ContainsKey(num)) { counts.Add(num, 0); }
                    counts[num]++;
                }

                // Find the lowest Unique Number
                string lowestUnique = String.Empty;
                foreach (var kvp in counts.OrderBy(kvp => kvp.Key))
                {
                    if (kvp.Value == 1)
                    {
                        lowestUnique = kvp.Key;
                        break;
                    }
                }

                // Find the Index of the Lowest Unique Number
                int index = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == lowestUnique)
                    {
                        index = i + 1;
                        break;
                    }
                }

                Console.WriteLine(index.ToString());
            }
        }

    }
}
