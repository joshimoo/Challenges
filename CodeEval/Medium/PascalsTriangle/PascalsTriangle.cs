using System;
using System.IO;

namespace CodeEval.PascalsTriangle
{
    /// <summary>
    /// Pascals Triangle Challenge
    /// Difficulty: Medium
    /// Description: return the pascal triangle in row major format upto the specified depth 
    /// Problem Statement: https://www.codeeval.com/open_challenges/66/
    /// </summary>
    class PascalsTriangle
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                int targetDepth = int.Parse(line);
                int count = GausSum(targetDepth);
                var triangle = new int[count];

                // Lets start with the triangle construction
                triangle[0] = 1;
                int depth = 2;
                int c = 0;
                for (int i = 1; i < count; i++)
                {
                    // left parent can be calculated by subtracting from our index our depth
                    // right parent can be calculated by subtracting from our index our depth-1
                    // then check that each of these new indexes end up in depth-1 to be valid
                    // otherwise they are outside the triangle, and should be substitute with 0
                    int leftIndex = i - depth;
                    int rightIndex = i - (depth - 1);

                    // Calculate Value for current Index
                    // TODO: feels a little hacky, the index to depth function would simplify this
                    int sum = 0;
                    if (leftIndex > (GausSum(depth - 2) - 1)) { sum += leftIndex >= 0 ? triangle[leftIndex] : 0; }
                    if (rightIndex <= (GausSum(depth - 1) - 1)) { sum += rightIndex >= 0 ? triangle[rightIndex] : 0; }
                    triangle[i] = sum;

                    // TODO: Calculate our depth based on the current index
                    if (++c == depth)
                    {
                        depth++;
                        c = 0;
                    }
                }

                for (int i = 0; i < triangle.Length; i++)
                {
                    if (i != triangle.Length - 1) { Console.Write("{0} ", triangle[i]); }
                    else { Console.WriteLine(triangle[i]); }
                }
            }
        }

        static int GausSum(int n) { return (n * (n + 1)) / 2; }
        static int Depth(int index)
        {
            // TODO: Come up with a method to calculate depth via a passed index
            throw new NotImplementedException();
        }


    }
}
