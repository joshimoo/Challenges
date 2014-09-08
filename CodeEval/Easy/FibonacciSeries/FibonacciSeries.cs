using System;
using System.Collections.Generic;
using System.IO;

namespace CodeEval.FibonacciSeries
{
    /// <summary>
    /// Fibonacci Series Challenge
    /// Difficulty: Easy
    /// Description: The Fibonacci series is defined as: F(0) = 0; F(1) = 1; F(n) = F(n-1) + F(n-2) when n>1. Given a positive integer 'n', print out the F(n). 
    /// Problem Statement: https://www.codeeval.com/open_challenges/22/
    /// </summary>
    class FibonacciSeries
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            var fiboSequence = new List<ulong>() { 0, 1 };
            string[] lines = File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                // Calculate the number, if fibIndex < count the for loop will be skipped
                int fiboIndex = int.Parse(line);
                for (int i = fiboSequence.Count - 1; i < fiboIndex; i++)
                {
                    fiboSequence.Add(fiboSequence[i] + fiboSequence[i - 1]);
                }

                Console.WriteLine(fiboSequence[fiboIndex]);
            }
        }

    }
}
