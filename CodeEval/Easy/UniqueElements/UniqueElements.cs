using System;
using System.IO;
using System.Text;

namespace CodeEval.UniqueElements
{
    /// <summary>
    /// Unique Elements Challenge
    /// Difficulty: Easy
    /// Description: Only print out unique elements
    /// Problem Statement: https://www.codeeval.com/open_challenges/29/
    /// </summary>
    class UniqueElements
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
                StringBuilder sb = new StringBuilder();

                string lastAdded = String.Empty;
                for (int i = 0; i < split.Length; i++)
                {
                    if (split[i] != lastAdded)
                    {
                        sb.AppendFormat("{0},", split[i]);
                        lastAdded = split[i];
                    }
                }

                Console.WriteLine(sb.ToString(0, sb.Length - 1));
            }
        }

    }
}
