using System;
using System.IO;

namespace CodeEval.Locks
{
    /// <summary>
    /// Locks Challenge
    /// Difficulty: Medium
    /// Description: Calculate how many locks are still open after m iterations
    /// Problem Statement: https://www.codeeval.com/open_challenges/153/
    /// </summary>
    class Locks
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                var split = Array.ConvertAll(line.Split(' '), int.Parse);
                int doors = split[0];
                int iterations = split[1];
                int locked = 0;

                // Solves the Problem in O(1)
                // Since we only have 1 iterations, we skip everything except the last door
                if (iterations <= 1) { locked = 1; }
                else
                {
                    // we ignore the last iteration
                    iterations--;

                    // Every second door is locked
                    locked = doors / 2;

                    // every third door flips state,
                    // if iterations count is even, the close -> open cycle cancel each other
                    // therefore if it's odd, we end up with additional closed doors
                    // we need to exclude the %6 since they always get cancelled by the %2
                    if (iterations % 2 != 0) { locked += doors / 3 - doors / 6; }

                    // since 2*3 = 6, every 6 door is open afterwards (cancels the 2)
                    locked -= doors / 6;

                    // The last iteration only the last door is flipped
                    if (doors % 6 == 0) { locked++; }
                    else if (doors % 2 == 0) { locked--; }
                    else if (doors % 3 == 0)
                    {
                        // Since iterations is odd, every 3rd door is closed
                        if (iterations % 2 != 0) { locked--; }
                        else { locked++; }
                    }
                    else { locked++; } // the last door was never touched, therefore close it
                }

                // How many doors are still open
                Console.WriteLine(doors - locked);
            }
        }

    }
}
