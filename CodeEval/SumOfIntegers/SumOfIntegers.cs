using System;
using System.IO;

namespace CodeEval.SumOfIntegers
{
    /// <summary>
    /// Sum of Integers Challenge
    /// Description: Print out the sum of integers read from a file
    /// Problem Statement: https://www.codeeval.com/open_challenges/24/
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
            int sum = 0;
            foreach (var line in lines) { sum += int.Parse(line); }
            Console.WriteLine(sum);
        }

        /* Line by line reading exmaple
        static void Main(string[] args)
        {
            int sum = 0;
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!String.IsNullOrEmpty(line)) { sum += int.Parse(line); }
                }
            }
         
            Console.WriteLine(sum);
        } */
    }
}
