using System;
using System.IO;
using System.Linq;

namespace CodeEval.Details
{
    /// <summary>
    /// Details Challenge
    /// Difficulty: Easy
    /// Description: Find the maximal possible move distance
    /// Problem Statement: https://www.codeeval.com/open_challenges/183/
    /// </summary>
    class Details
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                int distanceMin = int.MaxValue;
                int rowMin = int.MaxValue;
                int distance = 0;
                // . = empty space
                // Y = restart counting
                // , = next row
                foreach (char c in line)
                {
                    if (c == '.')
                    {
                        distance++;
                    }
                    else if (c == 'Y' && distance > 0)
                    {
                        if (distance < rowMin) { rowMin = distance; }
                        distance = 0;
                    }
                    else if (c == ',')
                    {
                        // 0 Freespaces, so no movement possible in the whole matrix
                        if (rowMin == int.MaxValue)
                        {
                            distanceMin = 0;
                            break;
                        }
                        if(rowMin < distanceMin) { distanceMin = rowMin; }

                        // Reset
                        distance = 0;
                        rowMin = int.MaxValue;
                    }
                }

                // Check at the end, since there is no more ,
                if (rowMin == int.MaxValue) { distanceMin = 0; }
                else if (rowMin < distanceMin) { distanceMin = rowMin; }
                Console.WriteLine(distanceMin);
                
                
            }
        }

    }
}
