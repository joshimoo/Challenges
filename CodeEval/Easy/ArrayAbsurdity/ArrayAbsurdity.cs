using System;
using System.IO;
using System.Linq;

namespace CodeEval.ArrayAbsurdity
{
    /// <summary>
    /// Array Absurdity Challenge
    /// Difficulty: Easy
    /// Description: Find a duplicate element inside of an immutable array in O(n)
    /// Problem Statement: https://www.codeeval.com/open_challenges/41/
    /// </summary>
    class ArrayAbsurdity
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
                // Arithmetic Progressions (Gaus)
                string[] split = line.Split(';');
                int[] numbers = split[1].Split(',').Select(int.Parse).ToArray();
                int highestNumber = int.Parse(split[0]) - 2; 
                int expectedSum = (highestNumber * (highestNumber + 1)) / 2;

                int sum = 0;
                for (int i = 0; i < numbers.Length; i++) { sum += numbers[i]; }

                Console.WriteLine(sum - expectedSum);
            }
        }

    }
}
