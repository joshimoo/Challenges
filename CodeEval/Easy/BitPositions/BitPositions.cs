using System;
using System.IO;
using System.Text;

namespace CodeEval.BitPositions
{
    /// <summary>
    /// Bit Positions Challenge
    /// Difficulty: Easy
    /// Description: Compare if the bits at 2 different positions are the same
    /// Problem Statement: https://www.codeeval.com/open_challenges/19/
    /// </summary>
    class BitPositions
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
                int num = int.Parse(split[0]);

                // the bit positions are 1 based
                int p1 = int.Parse(split[1]) - 1;
                int p2 = int.Parse(split[2]) - 1;
                int r1 = (num >> p1) & 1;
                int r2 = (num >> p2) & 1;

                Console.WriteLine(r1 == r2 ? "true" : "false");
            }
        }
    }
}
