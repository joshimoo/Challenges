using System;
using System.Diagnostics;
using System.IO;

namespace CodeEval.ReadMore
{
    /// <summary>
    /// Read More Challenge
    /// Difficulty: Easy
    /// Description: Trim Lines and include a Readmore function
    /// Problem Statement: https://www.codeeval.com/open_challenges/167/
    /// </summary>
    class ReadMore
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            const string READMORE = "... <Read More>";

            foreach (var line in File.ReadLines(args[0]))
            {
                if (line.Length <= 55) { Console.WriteLine(line); }
                else
                {
                    // We find the last space to make sure that we have a complete word before our readmore
                    int lastWord = line.LastIndexOf(' ', 39);
                    string sub = lastWord != -1 ? line.Substring(0, lastWord) : line.Substring(0, 40);
                    Console.WriteLine(sub + READMORE);
                }
            }
        }

    }
}
