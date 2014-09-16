using System;
using System.Collections.Generic;
using System.IO;

namespace CodeEval.WordToDigit
{
    /// <summary>
    /// Word to Digit Challenge
    /// Difficulty: Easy
    /// Description: Having a textual representation of a set of numbers you need to print these in numeric representation
    /// Problem Statement: https://www.codeeval.com/open_challenges/104/
    /// </summary>
    class WordToDigit
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
                var split = line.Split(';');
                var output = new char[split.Length];

                for (int i = 0; i < split.Length; i++)
                {
                    output[i] = numValues[split[i]];
                }

                Console.WriteLine(new string(output));
            }
        }

        /// <summary>
        /// Maps the Textual Representation to their numeric (using char for optimization) representation
        /// </summary>
        static readonly Dictionary<string, char> numValues = new Dictionary<string, char>()
        {
            {"zero", '0'}, {"one", '1'}, {"two", '2'}, {"three", '3'}, {"four", '4'}, {"five", '5'}, {"six", '6'}, {"seven", '7'},{"eight", '8'}, {"nine", '9'}
        };

    }
}
