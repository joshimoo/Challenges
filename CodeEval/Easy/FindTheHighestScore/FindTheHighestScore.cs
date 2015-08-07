using System;
using System.IO;

namespace CodeEval.FindTheHighestScore
{
    /// <summary>
    /// Find The Highest Score Challenge
    /// Difficulty: Easy
    /// Description: Map age numbers to states
    /// Problem Statement: https://www.codeeval.com/open_challenges/208/
    /// </summary>
    class FindTheHighestScore
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                // All the Splitting sucks, but the time to write the code is quick :)
                var rows = line.Split('|');
                var max = Array.ConvertAll(rows[0].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries), int.Parse);

                foreach (var row in rows)
                {
                    var col = row.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < col.Length; i++)
                    {
                        int val = int.Parse(col[i]);
                        if (val > max[i]) { max[i] = val; }
                    }
                }

                Console.WriteLine(String.Join(" ", max));
            }
        }

    }
}
