using System;
using System.IO;

namespace CodeEval.JugglingWithZeros
{
    /// <summary>
    /// Juggling With Zeros Challenge
    /// Difficulty: Easy
    /// Description: A zero based number is set in the following form: "flag" "sequence of zeroes" "flag" "sequence of zeroes" etc. Separated by a single space
    /// Problem Statement: https://www.codeeval.com/open_challenges/149/
    /// </summary>
    class JugglingWithZeros
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
                string[] split = line.Split(' ');
                ulong sum = 0;

                for (int i = 0; i < split.Length; i += 2)
                {
                    string flag = split[i];
                    string elements = split[i + 1];

                    // Flag ==  0: Elements = 0
                    // Flag == 00: Elements = 1 
                    if (flag == "0")
                    {
                        // Left Shift
                        sum = sum << elements.Length;
                    }
                    else if (flag == "00")
                    {
                        for (int j = 0; j < elements.Length; j++)
                        {
                            // Left Shift then flip the first bit
                            sum = sum << 1;
                            sum = sum | 1;
                        }

                        /* Alternative where we shift at once
                        ulong mask = (ulong)Math.Pow(2, elements.Length) - 1;
                        sum = sum << elements.Length;
                        sum = sum | mask;*/
                    }
                }

                Console.WriteLine(sum);
            }
        }

    }
}
