using System;
using System.IO;

namespace CodeEval.ReverseWords
{
    /// <summary>
    /// Reverse Words Challenge
    /// Difficulty: Easy
    /// Description: reverse the words of an input sentence
    /// Problem Statement: https://www.codeeval.com/open_challenges/8/
    /// </summary>
    class ReverseWords
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
                        var split = line.Split(' ');
                        for (int i = split.Length - 1; i >= 0; i--)
                        {
                            // NOTE: Optimization, replace Conolse.Write with a StringBuilder since Write is slower then building the StringBuilder (Memory vs Runtime)
                            // NOTE: Does not have any impact on the code eval score, so it does not really matter for this exercise.
                            Console.Write(split[i]);
                            if (i != 0) { Console.Write(' '); }
                            else { Console.WriteLine(); }
                        }
                    }
                }
            }
        }

    }
}
