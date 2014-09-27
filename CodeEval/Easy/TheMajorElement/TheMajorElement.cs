using System;
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
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!String.IsNullOrEmpty(line)) { FindMajorElement(line); }
                }
            }
        }


        /// <summary>
        /// Needed to write a more optimized solution 
        /// Since the original line.split + dictionary approach took to much memory
        /// N is in range [0, 100]
        /// L is in range [10000, 30000]
        /// The number of test cases <= 40 
        /// </summary>
        static void FindMajorElement(string line)
        {
            short l = 0;
            int num = 0;
            var counts = new short[101];
            foreach (var c in line)
            {
                // Digit
                if (c >= '0' && c <= '9') { num = num * 10 + (c - '0'); }
                else
                {
                    l++;
                    counts[num]++;
                    num = 0;
                }
            }

            // Save the last element
            l++;
            counts[num]++;

            // Find the major element
            int majorElement = -1;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > l / 2)
                {
                    majorElement = i;
                    break;
                }
            }

            Console.WriteLine(majorElement < 0 ? "None" : majorElement.ToString());
        }

    }
}
