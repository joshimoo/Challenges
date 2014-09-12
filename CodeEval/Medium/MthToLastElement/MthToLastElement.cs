using System;
using System.IO;

namespace CodeEval.MthToLastElement
{
    /// <summary>
    /// Mth to last element Challenge
    /// Difficulty: Easy
    /// Description: return the Mth element from the reverse of a list.
    /// Problem Statement: https://www.codeeval.com/open_challenges/10/
    /// </summary>
    class MthToLastElement
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

                // Remove the index from the possible elements
                int length = split.Length - 1;
                int index = int.Parse(split[length]);

                // Make sure that the index is inside of the list
                if (index > 0 && length - index >= 0)
                {
                    string element = split[length - index];
                    Console.WriteLine(element);
                }
            }
        }
    }
}
