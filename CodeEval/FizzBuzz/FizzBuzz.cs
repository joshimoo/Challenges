﻿using System;
using System.IO;
using System.Text;

namespace CodeEval.FizzBuzz
{
    /// <summary>
    /// Fizz Buzz Challenge
    /// Description: Fizz Buzz with different divisors
    /// Problem Statement: https://www.codeeval.com/open_challenges/1/
    /// </summary>
    class FizzBuzz
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                string[] split = line.Split(' ');
                int modA = int.Parse(split[0]);
                int modB = int.Parse(split[1]);
                int max = int.Parse(split[2]);
                StringBuilder s = new StringBuilder();

                for (int num = 1; num <= max; num++)
                {
                    if (num % modA == 0 && num % modB == 0) { s.Append("FB"); }
                    else if (num % modA == 0) { s.Append("F"); }
                    else if (num % modB == 0) { s.Append("B"); }
                    else { s.Append(num); }

                    // Could just remove the last space instead
                    if (num != max) { s.Append(" "); }
                }

                Console.WriteLine(s.ToString());
            }
        }
    }
}
