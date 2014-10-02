using System;
using System.IO;

namespace CodeEval.FindAWriter
{
    /// <summary>
    /// Find a Writer Challenge
    /// Difficulty: Easy
    /// Description: Output characters based on an 1-based index list
    /// Problem Statement: https://www.codeeval.com/open_challenges/97/
    /// </summary>
    class FindAWriter
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
                // osSE5Gu0Vi8WRq93UvkYZCjaOKeNJfTyH6tzDQbxFm4M1ndXIPh27wBA rLclpg| 3 35 27 62 51 27 46 57 26 10 46 63 57 45 15 43 53
                string[] split = line.Split('|');
                int[] indexes = Array.ConvertAll(split[1].Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s) - 1);
                char[] output = new char[indexes.Length];

                for (int i = 0; i < indexes.Length; i++)
                {
                    output[i] = split[0][indexes[i]];
                }
               
                Console.WriteLine(output);
            }
        }

    }
}
