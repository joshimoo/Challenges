using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CodeEval.SwapElements
{
    /// <summary>
    /// Swap Elements Challenge
    /// Difficulty: Easy
    /// Description: Swap Elements according to a swap list
    /// Problem Statement: https://www.codeeval.com/open_challenges/112/
    /// </summary>
    class SwapElements
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
                // 1 2 3 4 5 6 7 8 9 : 0-8
                // 1 2 3 4 5 6 7 8 9 10 : 0-1, 1-3
                string[] split = line.Split(':');
                string[] numbers = split[0].Split(' ');
                string[] swapList = split[1].Split(',');

                // TODO: Optimize this once, I am past the flu.
                // highly innefiecient, but I got the flu at the moment.
                for (int i = 0; i < swapList.Length; i++)
                {
                    var idx = Array.ConvertAll(swapList[i].Trim().Split('-'), int.Parse);
                    Swap(numbers, idx[0], idx[1]);
                }

                var sb = new StringBuilder(split[0].Length);
                foreach (var number in numbers)
                {
                    sb.AppendFormat("{0} ", number);
                }

                Console.WriteLine(sb.ToString(0, sb.Length - 1));
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
