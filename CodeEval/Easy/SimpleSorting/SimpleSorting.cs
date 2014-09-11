using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeEval.SimpleSorting
{
    /// <summary>
    /// Simple Sorting Challenge
    /// Difficulty: Easy
    /// Description: Sort Numbers ascending
    /// Problem Statement: https://www.codeeval.com/open_challenges/91/
    /// </summary>
    class SimpleSorting
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
                string[] split = line.Split(' ');
                StringBuilder sb = new StringBuilder();

                /* Fun but highly inefficient
                Comparison<string> c = (s, s1) =>
                {
                    double x = Convert.ToDouble(s);
                    double y = Convert.ToDouble(s1);
                    return x < y ? -1 : x > y ? 1 : 0;
                };
                Array.Sort(split, c);*/

                double[] numbers = new double[split.Length];
                for (int i = 0; i < split.Length; i++) { numbers[i] = double.Parse(split[i]); }
                Array.Sort(numbers);

                // Fixed point format with precision 3: http://msdn.microsoft.com/en-us/library/dwhawy9k.aspx
                foreach (double number in numbers) { sb.AppendFormat("{0:F3} ", number); }
                Console.WriteLine(sb.ToString(0, sb.Length - 1));
            }
        }
    }
}
