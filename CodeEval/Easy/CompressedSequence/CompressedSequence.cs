using System;
using System.IO;
using System.Text;

namespace CodeEval.CompressedSequence
{
    /// <summary>
    /// Compressed Sequence Challenge
    /// Difficulty: Easy
    /// Description: Compress a sequence of numbers into counter + number
    /// Problem Statement: https://www.codeeval.com/open_challenges/128/
    /// </summary>
    class CompressedSequence
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
                string[] split = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var sb = new StringBuilder();

                // NOTE: Dictionary approach will not work, since the number sequence could have the same number later on which would need to be unique.
                int count = 0;
                string prev = String.Empty;
                foreach (var s in split)
                {
                    if (s != prev)
                    {
                        if (count > 0) { sb.AppendFormat("{0} {1} ", count, prev); }
                        prev = s;
                        count = 0;
                    }

                    count++;
                }

                // Add the last element and print out the compressed sequence
                Console.WriteLine(sb.AppendFormat("{0} {1}", count, prev).ToString());
            }
        }

    }
}
