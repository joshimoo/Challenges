using System;
using System.IO;
using System.Text;

namespace CodeEval.MultiplicationTables
{
    /// <summary>
    /// Multiplication Tables Challenge
    /// Difficulty: Easy
    /// Description: Print out the grade school multiplication table upto 12*12
    /// Problem Statement: https://www.codeeval.com/open_challenges/23/
    /// </summary>
    class MultiplicationTables
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            // 1   2   3   4   5   6   7   8   9  10  11  12
            // 2   4   6   8  10  12  14  16  18  20  22  24
            // 3   6   9  12  15  18  21  24  27  30  33  36
            PrintMultiplicationTable(12);
        }

        /// <summary>
        /// Prints the multiplication table.
        /// It uses a fixed with of 4 per entry.
        /// </summary>
        /// <param name="max">specifies the largest multiplier</param>
        static void PrintMultiplicationTable(int max)
        {
            var sb = new StringBuilder(max * 4);
            for (int i = 1; i <= max; i++)
            {
                for (int j = 1; j <= max; j++) 
                {
                    // Calculate the number
                    int num = i * j;
                    sb.AppendFormat("{0,4}", num);
                }

                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
        }

    }
}
