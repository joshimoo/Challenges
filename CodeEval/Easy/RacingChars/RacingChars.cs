using System;
using System.Diagnostics;
using System.IO;

namespace CodeEval.RacingChars
{
    /// <summary>
    /// Racing Chars Challenge
    /// Difficulty: Easy
    /// Description: Find a Path trough a racetrack
    /// Problem Statement: https://www.codeeval.com/open_challenges/136/
    /// </summary>
    class RacingChars
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] graph = File.ReadAllLines(args[0]);
            PrintPath(graph, FindPath(graph));
        }


        /// <summary>
        /// Find a Path through a graph, 
        /// An obstruction is represented by a number sign "#"
        /// A gate is represented by an underscore "_"
        /// A checkpoint is represented by a letter C
        /// Where "C" always has priority over "_"
        /// </summary>
        private static int[] FindPath(string[] graph)
        {
            int[] path = new int[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                // TODO: The searching here could be optimized, by implementing my own FindAny() with priority parameters
                // "C" has priority over "_"
                int pos = graph[i].IndexOf('C');
                if (pos == -1) { pos = graph[i].IndexOf('_'); }
                path[i] = pos;
            }

            return path;
        }


        /// <summary>
        /// Print out the way of passing this race track starting from the first line in the file. 
        /// Use a pipe "|" for the straight, 
        /// Use a slash "/" for the left turn, 
        /// Use a backslash "\" for the right turn.
        /// </summary>
        private static void PrintPath(string[] graph, int[] path)
        {
            Debug.Assert(path.Length > 0);
            Debug.Assert(graph.Length == path.Length);
            
            // Start is always straight, since we don't know what his previous was
            int prev = path[0];
            for (int i = 0; i < graph.Length; i++)
            {
                int cur = path[i];
                char dir = cur < prev ? '/' : cur > prev ? '\\' : '|';

                char[] line = graph[i].ToCharArray();
                line[path[i]] = dir;
                Console.WriteLine(line);

                prev = cur;
            }
        }


    }
}
