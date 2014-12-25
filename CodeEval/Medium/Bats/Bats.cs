using System;
using System.IO;

namespace CodeEval.Bats
{
    /// <summary>
    /// Bats Challenge
    /// Difficulty: Medium
    /// Description: Calculate how many additional bats can fit on the wire
    /// Problem Statement: https://www.codeeval.com/open_challenges/146/
    /// </summary>
    class Bats
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
                int wire = split[0];
                int distance = split[1]; // distance beetwen bats, bats need to be 6 units from the buildings
                int initialBatCount = split[2];
                if (initialBatCount > 0) { Array.Sort(split, 3, initialBatCount); }
                
                // Bats need to be 6 units from the building
                int pos = 6;
                int count = 0;
                int i = 3;

                // TODO: Redo the Bats challenge, I don't like the way I solved it.
                while (pos <= wire - 6)
                {
                    int bat = i < split.Length ? split[i] : pos + distance;
                    if (pos <= bat - distance)
                    {
                        // I am in front of the current Bat
                        count++;
                        pos += distance;
                    }
                    else
                    {
                        // no more space in front of this bat
                        pos = bat + distance;
                        i++;
                    }
                }

                Console.WriteLine(count);
            }
        }

    }
}
