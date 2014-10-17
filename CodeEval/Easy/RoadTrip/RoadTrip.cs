using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace CodeEval.RoadTrip
{
    /// <summary>
    /// Road Trip Challenge
    /// Difficulty: Easy
    /// Description: Return the distance beetwen adjacent Cities
    /// Problem Statement: https://www.codeeval.com/open_challenges/124/
    /// </summary>
    class RoadTrip
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
                var distances = new List<int>();
                int i = 0;
                while ((i = line.IndexOf(',', i + 1)) != -1)
                {
                    // Rkbs,5453;
                    // 0123456789
                    // 9 - 5 = 4
                    int j = line.IndexOf(';', ++i);
                    int length = j - i;
                    distances.Add(int.Parse(line.Substring(i, length)));
                }

                distances.Sort();
                StringBuilder sb = new StringBuilder();
                int prev = 0;
                for (i = 0; i < distances.Count; i++) 
                {
                    sb.AppendFormat("{0},", distances[i] - prev);
                    prev = distances[i];
                }

                Console.WriteLine(sb.ToString(0, sb.Length -1));
            }
        }
    }
}
