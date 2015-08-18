using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEval.MagicNumbers
{
    /// <summary>
    /// Magic Numbers Challenge
    /// Difficulty: Medium
    /// Description: Return all Magic Numbers beetwen A and B inclusive
    /// Problem Statement: https://www.codeeval.com/open_challenges/193/
    /// </summary>
    class MagicNumbers
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                // Since we have multiple queries, I could cache the magicnumbers
                // 1 <= A <= B <= 10000. 
                var split = line.Split(' ');
                int lowerBound = Convert.ToInt32(split[0]);
                int upperBound = Convert.ToInt32(split[1]);
                var magicNumbers = new List<int>();

                for (int x = lowerBound; x <= upperBound; x++)
                {
                    if (IsMagicNumber(x)) { magicNumbers.Add(x); }
                }

                Console.WriteLine(magicNumbers.Count > 0 ? String.Join(" ", magicNumbers) : "-1");
            }
        }

        /// <summary>
        /// A magic number is a number that has two characteristics:
        /// 1) No digits repeat.
        /// 2) Beginning with the leftmost digit, take the value of the digit and move that number of digits to the right.
        /// Repeat the process again using the value of the current digit to move right again.
        /// Wrap back to the leftmost digit as necessary.
        /// A magic number will visit every digit exactly once and end at the leftmost digit.
        /// </summary>
        static bool IsMagicNumber(int number)
        {
            // TODO: this is quick and dirty, a better approach is to convert to quotient representation
            char[] a = number.ToString().ToCharArray();
            bool[] visited = new bool[a.Length];
            bool[] digits = new bool[10];

            // Evaluate the unique digit condition
            foreach (int d in a.Select(c => c - '0'))
            {
                if (digits[d]) { return false; }
                digits[d] = true;
            }

            // Evaluate Visiting Condition
            int index = 0;
            while (!visited[index])
            {
                visited[index] = true;
                index = ((index + (a[index] - '0')) % a.Length);
            }

            return visited.All(b => b) && index == 0;
        }
    }
}
