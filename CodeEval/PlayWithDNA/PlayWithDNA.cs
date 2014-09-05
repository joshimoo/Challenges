using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CodeEval.PlayWithDNA
{
    /// <summary>
    /// Play with DNA Challenge
    /// Difficulty: Hard
    /// Description: find all occurrences of segment S in DNA string, with maximum allowed mismatches of M.
    /// Problem Statement: https://www.codeeval.com/open_challenges/126/
    /// 
    /// Constrains:
    /// The DNA string length is in range [100, 300]
    /// The M is in range [0, 40]
    /// The segment S length is in range [3, 50] 
    /// </summary>
    class PlayWithDNA
    {
        /// <summary>
        /// A structure to keep track of how often we have seen a specific substring
        /// Could use a tuple instead but they are Reference types (Class)
        /// </summary>
        private struct Match
        {
            internal short seenCount;
            internal readonly short mismatchCount;

            internal Match(short seenCount, short mismatchCount)
            {
                this.seenCount = seenCount;
                this.mismatchCount = mismatchCount;
            }
        }


        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(args[0]);
            foreach (string line in lines)
            {
                string[] split = line.Split(' ');
                string segment = split[0];
                int maxMismatches = int.Parse(split[1]);
                string dna = split[2];
                var sb = new StringBuilder();
                var map = new Dictionary<string, Match>();

                // Find all partial matches, with edit distance <= maxMismatches
                for (int i = 0; i <= dna.Length - segment.Length; i++)
                {
                    // NOTE: Optimization pass the string array + index, instead of creating a new substring everytime
                    string candidate = dna.Substring(i, segment.Length);
                    int mismatchCount = CountMismatches(segment, candidate);
                    if (mismatchCount <= maxMismatches)
                    {
                        if (map.ContainsKey(candidate))
                        {
                            var match = map[candidate];
                            match.seenCount += 1;
                            map[candidate] = match;
                        }
                        else { map.Add(candidate, new Match(1, (short)mismatchCount)); }
                    }
                }

                // Display all the partial matches, with edit distance <= maxMismatches
                if (map.Count > 0)
                {
                    // Sort all missmatches, by missmatch count then alphabeticly
                    var ordered = map.OrderBy(pair => pair.Value.mismatchCount).ThenBy(pair => pair.Key);
                    foreach (var pair in ordered)
                    {
                        for (int i = 0; i < pair.Value.seenCount; i++)
                        {
                            sb.AppendFormat("{0} ", pair.Key);
                        }
                    }
                    Console.WriteLine(sb.ToString(0, sb.Length - 1));
                }
                else { Console.WriteLine("No match"); }
            }
        }


        /// <summary>
        /// Count the missmatches beetwen two strings
        /// </summary>
        static int CountMismatches(string pattern, string candidate)
        {
            int mismatchCount = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] != candidate[i]) { mismatchCount++; }
            }

            return mismatchCount;
        }

    }
}
