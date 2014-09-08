using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEval.NumberPairs
{
    /// <summary>
    /// Number Pairs Challenge
    /// Difficulty: Medium
    /// Description: Print out all pairs of numbers whose sum is equal to X. Print out only unique pairs and the pairs should be in ascending order
    /// Problem Statement: https://www.codeeval.com/open_challenges/34/
    /// </summary>
    class NumberPairs
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(args[0]);
            foreach (string line in lines)
            {
                string[] split = line.Split(';');
                int[] numbers = split[0].Split(',').Select(s => int.Parse(s)).ToArray();
                int target = int.Parse(split[1]);
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < numbers.Length; i++)
                {
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        if (numbers[i] + numbers[j] == target)
                        {
                            // We found a pair, exit inner loop now since all following numbers are greater or duplicate numbers.
                            sb.AppendFormat("{0},{1};", numbers[i], numbers[j]);
                            break;
                        }
                    }
                }

                // Done with this line, remove the last semicolon
                Console.WriteLine(sb.Length != 0 ? sb.ToString(0, sb.Length - 1) : "NULL");
            }
        }

    }
}
