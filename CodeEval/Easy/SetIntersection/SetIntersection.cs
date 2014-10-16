using System;
using System.IO;
using System.Text;

namespace CodeEval.SetIntersection
{
    /// <summary>
    /// Set Intersection Challenge
    /// Difficulty: Easy
    /// Description: Print out the intersection of these two sets
    /// Problem Statement: https://www.codeeval.com/open_challenges/30/
    /// </summary>
    class SetIntersection
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
                string[] split = line.Split(';');
                int[] setA = Array.ConvertAll(split[0].Split(','), int.Parse);
                int[] setB = Array.ConvertAll(split[1].Split(','), int.Parse);
                StringBuilder sb = new StringBuilder();
                    
                int i = 0, j = 0;
                while (i < setA.Length && j < setB.Length)
                {
                    // The sets are sorted in ascending order,
                    // therefore we can decide which way to move
                    // based on the delta beetwen the two numbers
                    int delta = setA[i] - setB[j];
                    if (delta > 0)
                    {
                        // 10 - 9 = 1
                        j++;
                    }
                    else if (delta < 0)
                    {
                        // 9 - 10 = -1;
                        i++;
                    }
                    else
                    {
                        // They intersect
                        sb.AppendFormat("{0},", setA[i]);
                        i++;
                        j++;
                    }
                }

                Console.WriteLine(sb.Length > 0 ? sb.ToString(0, sb.Length - 1) : "");
            }
        }


    }
}
