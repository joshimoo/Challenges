using System;
using System.IO;
using System.Text;

namespace CodeEval.SelfDescribingNumbers
{
    /// <summary>
    /// Self Describing Numbers Challenge
    /// Difficulty: Easy
    /// Description: Evaluate wether a number is a self describing number
    /// Problem Statement: https://www.codeeval.com/open_challenges/40/
    /// </summary>
    class SelfDescribingNumbers
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
                int[] counts = new int[10];
                int[] expected = new int[line.Length];

                // Calculate the Digit Counts
                for (int i = 0; i < line.Length; i++)
                {
                    int digit = line[i] - '0';
                    expected[i] = digit;
                    counts[digit]++;
                }

                // Evaluate wether the number is a self describing number
                bool result = true;
                for (int i = 0; i < expected.Length; i++)
                {
                    if (expected[i] != counts[i])
                    {
                        result = false;
                        break;
                    }
                }

                Console.WriteLine(result ? "1" : "0");
            }
        }

    }
}
