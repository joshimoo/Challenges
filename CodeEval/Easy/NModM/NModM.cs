using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace CodeEval.NModM
{
    /// <summary>
    /// N Mod M Challenge
    /// Difficulty: Easy
    /// Description: Given two integers N and M, calculate N Mod M (without using any inbuilt modulus operator)
    /// Problem Statement: https://www.codeeval.com/open_challenges/62/
    /// </summary>
    class NModM
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
                var split = line.Split(',');
                int num = int.Parse(split[0]);
                int div = int.Parse(split[1]);
                Console.WriteLine(PoorMansMod(num, div));
            }
        }

        /// <summary>
        /// A poor mans modulus implementation
        /// </summary>
        static int PoorMansMod(int num, int div)
        {
            // Mono Does not Support: Contract.Requires<ArgumentOutOfRangeException>(div != 0, "Divide by zero is not allowed.");
            int result = num / div;
            return num - (result * div);
        }

    }
}
