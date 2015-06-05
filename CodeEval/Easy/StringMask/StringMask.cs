using System;
using System.IO;
using System.Text;

namespace CodeEval.StringMask
{
    /// <summary>
    /// String Mask Challenge
    /// Difficulty: Easy
    /// Description: Change letter case based on a binary mask
    /// Problem Statement: https://www.codeeval.com/open_challenges/199/
    /// </summary>
    class StringMask
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                // s0.length == s1.length
                string[] split = line.Split(' ');
                var sb = new StringBuilder(split[0]);
                for (int i = 0; i < split[0].Length; i++)
                {
                    if (split[1][i] == '1')
                    {
                        sb[i] = Char.ToUpper(sb[i]);
                    }
                }

                Console.WriteLine(sb.ToString());
            }
        }

    }
}
