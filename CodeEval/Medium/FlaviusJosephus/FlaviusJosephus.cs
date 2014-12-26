using System;
using System.IO;
using System.Text;

namespace CodeEval.FlaviusJosephus
{
    /// <summary>
    /// Flavius Josephus Challenge
    /// Difficulty: Medium
    /// Description: Return the list of killed people
    /// Problem Statement: https://www.codeeval.com/open_challenges/75/
    /// </summary>
    class FlaviusJosephus
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                var split = Array.ConvertAll(line.Split(','), int.Parse);
                int n = split[0];
                int killDistance = split[1];
                var deaths = new bool[n];
                int deathCount = 0;
                var sb = new StringBuilder();

                // Death People, are no longer part of the step counter
                for (int i = 0; deathCount < n; i = (i + 1) % n)
                {
                    // Kill this person?
                    if (!deaths[i] && --killDistance == 0)
                    {
                        deaths[i] = true;
                        deathCount++;
                        killDistance = split[1];
                        sb.AppendFormat("{0} ", i);
                    }
                }

                Console.WriteLine(sb.ToString(0, sb.Length - 1));
            }
        }


    }
}
