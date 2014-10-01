using System;
using System.IO;
using System.Text;
using System.Linq;

namespace CodeEval.DataRecovery
{
    /// <summary>
    /// Data Recovery Challenge
    /// Difficulty: Easy
    /// Description: Reorder the words according to a swap list
    /// Problem Statement: https://www.codeeval.com/open_challenges/140/
    /// </summary>
    class DataRecovery
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
                // programming first The language;3 2 1
                // called Hopper programming in Grace FLOW-MATIC the devised was language Another by early US,;13 9 3 10 8 14 11 6 5 4 1 7 2
                // Another early programming language was devised by Grace Hopper in the  called US,
                string[] split = line.Split(';');
                string[] words = split[0].Split(' ');
                string[] output = new string[words.Length];
                int[] indexes = split[1].Split(' ').Select(int.Parse).ToArray();

                // TODO: Optimize this once, I am past the flu.
                // highly innefiecient, but I got the flu at the moment.
                for (int i = 0; i < words.Length; i++)
                {
                    // TODO: Compare the inputs to see which is the case, the multiple one will work in both cases
                    // If there is only one missing index then 
                    // We can get it by gaus sum - actual index sum
                    // If there is more than one missing index, 
                    // We need to slot the remaining words into the null places in the output
                    int outputIndex = -1;
                    if (i < indexes.Length) 
                    {
                        outputIndex = indexes[i] - 1;
                    }
                    else
                    {
                        for (int j = 0; j < output.Length; j++) 
                        {
                            if (output[j] == null) 
                            {
                                outputIndex = j;
                                break;
                            }
                        }
                    }

                    output[outputIndex] = words[i];
                }

                var sb = new StringBuilder(split[0].Length + 1);
                foreach (var word in output)
                {
                    sb.AppendFormat("{0} ", word);
                }

                Console.WriteLine(sb.ToString(0, sb.Length - 1));
            }
        }

    }
}
