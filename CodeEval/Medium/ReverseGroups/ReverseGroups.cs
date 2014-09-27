using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeEval.ReverseGroups
{
    /// <summary>
    /// Reverse Groups Challenge
    /// Difficulty: Medium
    /// Description: Reverse an Array K items at a time.
    /// Problem Statement: https://www.codeeval.com/open_challenges/71/
    /// </summary>
    class ReverseGroups
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
                string[] split = line.Split(';');
                int[] numbers = Array.ConvertAll(split[0].Split(','), int.Parse);
                int k = int.Parse(split[1]);

                // Reverse the data k Items at a time
                for (int i = 0; i + k - 1 < numbers.Length; i += k)
                {
                    Reverse(numbers, i, k);
                }

                // Output the reversed Data
                var sb = new StringBuilder(numbers.Length * 2);
                foreach (var number in numbers) { sb.AppendFormat("{0},", number); }
                Console.WriteLine(sb.ToString(0, sb.Length - 1));
            }
        }

        /// <summary>
        /// Array Reverse for specific Slices.
        /// For a production system a better approach would be creating an ArraySlice T Class
        /// Which implementes the IList T Interface to encapsulate the data Array
        /// That Way one can use all prior existing Array Algorithms (Reverse, Search, Sort, etc)
        /// </summary>
        static void Reverse<T>(IList<T> data, int startIndex, int length)
        {
            int endIndex = startIndex + length - 1;
            while (startIndex < endIndex)
            {
                Swap(data, startIndex++, endIndex--);
            }
        }

        /// <summary>
        /// Swap the elements at index i & j
        /// </summary>
        static void Swap<T>(IList<T> data, int i, int j)
        {
            T temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

    }
}
