using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace CodeEval.InterruptedBubbleSort
{
    /// <summary>
    /// Interrupted Bubble Sort Challenge
    /// Difficulty: Medium
    /// Description: output the array after a certain amount of BubbleSort iterations
    /// Problem Statement: https://www.codeeval.com/open_challenges/158/
    /// </summary>
    class InterruptedBubbleSort
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

                // NOTE: using my ArraySlice class would be cleaner & nicer
                int[] numbers = new int[split.Length - 2];
                int iterations = int.Parse(split[split.Length - 1]);
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = int.Parse(split[i]);
                }
                    
                BubbleSort(numbers, iterations);


                // Output the (partially) sorted array
                var sb = new StringBuilder(line.Length);
                foreach (var s in numbers)
                {
                    sb.AppendFormat("{0} ", s);
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

        /// <summary>
        /// A BubbleSort that stops after iterations count is reached
        /// </summary>
        static void BubbleSort<T>(IList<T> data, int iterations)
        {
            // Comparer normally you would wrap and pass this
            IComparer<T> cmp = Comparer<T>.Default;

            bool sorted = false;
            while (!sorted && iterations-- > 0)
            {
                sorted = true;
                for (int i = 1; i < data.Count; i++)
                {
                    // Compare & swap the elements
                    if (cmp.Compare(data[i-1], data[i]) > 0)
                    {
                        Swap(data, i - 1, i);
                        sorted = false;
                    }
                }
            }
        }
            
    }
}