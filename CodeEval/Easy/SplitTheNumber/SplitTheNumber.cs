using System;
using System.IO;

namespace CodeEval.SplitTheNumber
{
    /// <summary>
    /// Split The Number Challenge
    /// Difficulty: Easy
    /// Description: Split the number according to the provided pattern.
    /// Problem Statement: https://www.codeeval.com/open_challenges/131/
    /// </summary>
    class SplitTheNumber
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            var operators = new char[] { '+', '-' };
            foreach (var line in File.ReadLines(args[0]))
            {
                // Since there is only one operator and the substitution pattern is always linearly increasing a->z
                // It's enough, to find the operator and cut up the number according to the operator index :)
                var split = line.Split(' ');
                int opIndex = split[1].IndexOfAny(operators);
                int n0 = int.Parse(split[0].Substring(0, opIndex));
                int n1 = int.Parse(split[0].Substring(opIndex));
                int result = 0;

                switch (split[1][opIndex])
                {
                    case '+':
                    result = n0 + n1;
                    break;

                    case '-':
                    result = n0 - n1;
                    break;
                }

                Console.WriteLine(result);
            }
        }

    }
}
