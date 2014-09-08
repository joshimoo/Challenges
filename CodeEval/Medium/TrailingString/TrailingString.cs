using System;
using System.IO;

namespace CodeEval.TrailingString
{
    /// <summary>
    /// Trailing String Challenge
    /// Difficulty: Medium
    /// Description: Print out a 1 if string 'B' occurs at the end of string 'A'. Else a zero.
    /// Problem Statement: https://www.codeeval.com/open_challenges/32/
    /// </summary>
    class TrailingString
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!String.IsNullOrEmpty(line))
                    {
                        // Process line
                        var split = line.Split(',');
                        string text = split[0];
                        string candidate = split[1];

                        bool found = false;
                        if (candidate.Length <= text.Length)
                        {
                            string subString = text.Substring(text.Length - candidate.Length);
                            if (subString == candidate) { found = true; }
                        }

                        Console.WriteLine(found ? 1 : 0);
                    }
                }
            }
        }
    }
}
