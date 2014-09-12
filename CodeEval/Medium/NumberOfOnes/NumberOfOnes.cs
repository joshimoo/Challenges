using System;
using System.IO;

namespace CodeEval.NumberOfOnes
{
    /// <summary>
    /// Number of Ones Challenge
    /// Difficulty: Medium
    /// Description: Count number of high (1) bits
    /// Problem Statement: https://www.codeeval.com/open_challenges/16/
    /// </summary>
    class NumberOfOnes
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
                if (!String.IsNullOrEmpty(line))
                {
                    int number = int.Parse(line);
                    Console.WriteLine(CountNumberOfOnes(number));
                }
            }
        }

        /// <summary>
        /// Devide the number by 2 while num > 0, the remainder will give us the binary digits in reverse
        /// </summary>
        static int CountNumberOfOnes(int number)
        {
            int count = 0;
            while (number > 0)
            {
                count = count + (number % 2);
                number = number / 2;
            }

            return count;
        }
    }
}
