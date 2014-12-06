using System;
using System.IO;

namespace CodeEval.NiceAngles
{
    /// <summary>
    /// Nice Angles Challenge
    /// Difficulty: Easy
    /// Description: Convert angle values to sexagesimal format.
    /// Problem Statement: https://www.codeeval.com/open_challenges/160/
    /// </summary>
    class NiceAngles
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
                // Floor rounds towards negative inf, while (int) truncation just cuts of the decimal
                double number = double.Parse(line);
                int angle = (int)number;

                number = (number - angle) * 60;
                int minute = (int)number;

                number = (number - minute) * 60;
                int seconds = (int)number;

                Console.WriteLine("{0}.{1:D2}'{2:D2}\"", angle, minute, seconds);
            }
        }
    }
}
