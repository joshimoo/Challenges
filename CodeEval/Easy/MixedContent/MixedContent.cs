using System;
using System.IO;
using System.Text;

namespace CodeEval.MixedContent
{
    /// <summary>
    /// Mixed Content Challenge
    /// Difficulty: Easy
    /// Description: separate the words and digits, don't change the order of the elements
    /// Problem Statement: https://www.codeeval.com/open_challenges/115/
    /// </summary>
    class MixedContent
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
                var words = new StringBuilder();
                var numbers = new StringBuilder();

                // 2 Iterations or 2 output streams pick one
                foreach (var s in split)
                {
                    int c = s[0] - '0';
                    if (c >= 0 && c <= 9) { numbers.AppendFormat("{0},", s); }
                    else { words.AppendFormat("{0},", s); }
                }

                // Print the output
                if (words.Length > 0)
                {
                    if (numbers.Length > 0) { Console.WriteLine(string.Format("{0}|{1}", words.ToString(0, words.Length - 1), numbers.ToString(0, numbers.Length - 1))); }
                    else { Console.WriteLine(words.ToString(0, words.Length - 1)); }
                }
                else { Console.WriteLine(numbers.ToString(0, numbers.Length - 1)); }
            }
        }

    }
}
