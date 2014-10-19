using System;
using System.IO;

namespace CodeEval.DeltaTime
{
    /// <summary>
    /// Delta Time Challenge
    /// Difficulty: Easy
    /// Description: Calculate the time difference beetwen 2 times
    /// Problem Statement: https://www.codeeval.com/open_challenges/166/
    /// </summary>
    class DeltaTime
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
                // NOTE: For production I would use the builtin DateTime handling
                string[] split = line.Split(' ');
                int[] t1 = Array.ConvertAll(split[0].Split(':'), int.Parse);
                int[] t2 = Array.ConvertAll(split[1].Split(':'), int.Parse);

                int time1 = t1[0] * 60 * 60 + t1[1] * 60 + t1[2];
                int time2 = t2[0] * 60 * 60 + t2[1] * 60 + t2[2];
                int delta = time1 > time2 ? time1 - time2 : time2 - time1;

                // We could floor instead but, since we are doing int math its not necessary
                int hours = delta / (60 * 60);
                delta = delta - hours * 60 * 60;
                int minutes = delta / 60;
                delta = delta - minutes * 60;
                int seconds = delta;
                Console.WriteLine("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
            }
        }
    }
}
