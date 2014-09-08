using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CodeEval.RemoveCharacters
{
    /// <summary>
    /// Remove Characters Challenge
    /// Difficulty: Medium
    /// Description: remove specific characters from a string
    /// Problem Statement: https://www.codeeval.com/open_challenges/13/
    /// </summary>
    class RemoveCharacters
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
                string pattern = "[" + split[1].Trim() + "]";
                string text = Regex.Replace(split[0], pattern, String.Empty).Trim();
                Console.WriteLine(text);
            }
        }

    }
}
