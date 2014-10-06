using System;
using System.IO;
using System.Text;

namespace CodeEval.DetectingCycles
{
    /// <summary>
    /// Detecting Cycles Challenge
    /// Difficulty: Medium
    /// Description: Find the shortest repeating sequence
    /// Problem Statement: https://www.codeeval.com/open_challenges/5/
    /// </summary>
    class DetectingCycles
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
                int[] sequence = Array.ConvertAll(line.Split(' '), int.Parse);
                int[] cycle = FloydsCycleDetection(sequence, 0);

                StringBuilder sb = new StringBuilder();
                foreach (var item in cycle) { sb.AppendFormat("{0} ", item); }
                Console.WriteLine(sb.ToString(0, sb.Length - 1));
            }
        }

        static int[] FloydsCycleDetection(int[] sequence, int startIndex)
        {
            // Main phase of algorithm: finding a repetition x_i = x_2i
            // The hare moves twice as quickly as the tortoise and
            // the distance between them increases by 1 at each step.
            // Eventually they will both be inside the cycle and then,
            // at some point, the distance between them will be
            // divisible by the period λ.
            int l = sequence.Length;
            int tortoise = startIndex + 1; // f(x0) is the element/node next to x0.
            int hare = startIndex + 2;
            while (tortoise < l && sequence[tortoise] != sequence[hare])
            {
                tortoise += 1;
                hare = hare + 2 < l ? hare + 2 : hare;
            }

            // At this point the tortoise position, ν, which is also equal
            // to the distance between hare and tortoise, is divisible by
            // the period λ. So hare moving in circle one step at a time, 
            // and tortoise (reset to x0) moving towards the circle, will 
            // intersect at the beginning of the circle. Because the 
            // distance between them is constant at 2ν, a multiple of λ,
            // they will agree as soon as the tortoise reaches index μ.

            // Find the position μ of first repetition.    
            int mu = 0;
            tortoise = startIndex;
            while (hare < l && sequence[tortoise] != sequence[hare])
            {
                // Hare and tortoise move at same speed
                tortoise += 1;
                hare += 1;
                mu += 1;
            }

            // Find the length of the shortest cycle starting from x_μ
            // The hare moves one step at a time while tortoise is still.
            // lam is incremented until λ is found.
            int lam = 1;
            hare = tortoise + 1;
            while (hare < l && sequence[tortoise] != sequence[hare])
            {
                hare += 1;
                lam += 1;
            }


            // Return the cycled sequence
            int[] cycle = new int[lam];
            Array.Copy(sequence, mu, cycle, 0, lam);
            // return lam, mu
            return cycle;
        }

    }
}
