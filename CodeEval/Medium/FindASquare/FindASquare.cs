using System;
using System.IO;
using System.Text;

namespace CodeEval.FindASquare
{
    /// <summary>
    /// Find A Square Challenge
    /// Difficulty: Medium
    /// Description: Determine if 4 Points form a square
    /// Problem Statement: https://www.codeeval.com/open_challenges/101/
    /// </summary>
    class FindASquare
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
                //(1,6), (6,7), (2,7), (9,1)
                // All numbers in input are between 0 and 10

                // TODO: All this splitting & text processign sucks, maybe switch over to using Regex
                string[] split = line.Split(' ');
                var points = new Vector2D[4];
                points[0] = new Vector2D(split[0].Substring(0, split[0].Length - 1));
                points[1] = new Vector2D(split[1].Substring(0, split[1].Length - 1));
                points[2] = new Vector2D(split[2].Substring(0, split[2].Length - 1));
                points[3] = new Vector2D(split[3]);
                Console.WriteLine(IsSquare(points) ? "true" : "false");
            }
        }

        /// <summary>
        /// Determines if 4 points form a square
        /// it checks wether the lengths beetwen the points 
        /// are in pairs of 4 and 2
        /// 
        /// NOTE: a better approach is probally to check 
        /// if the diagonal vectors are orthogonal 
        /// and there lengths are the same
        /// (m1 * m2 = -1) if they are ontop of each other
        /// </summary>
        static bool IsSquare(Vector2D[] points)
        {
            // TODO: Add eror handling for points.Length etc
            double[] lengths = new double[6];
            int l = 0;
            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1 ; j < points.Length; j++) 
                {
                    // NOTE: Instead of doing Magnitude we could just compare the square Magnitudes
                    lengths[l++] = (points[i] - points[j]).Magnitude;
                }
            }

            // Check if the lengths are in pairs of 4 and 2
            Array.Sort(lengths);
            bool square = true;

            // Make sure that all points are not the same
            if (lengths[3] == lengths[4]) { square = false; }
            if (lengths[4] != lengths[5]) { square = false; }
            for (int i = 1; i < 4; i++)
            {
                if (lengths[i - 1] != lengths[i]) { square = false; }
            }

            return square;
        }

        /// <summary>
        /// Implements a basic 2D Vector
        /// </summary>
        struct Vector2D
        {
            public double x;
            public double y;
            public double Magnitude { get { return Math.Sqrt(x * x + y * y); } }

            public Vector2D(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            // (25.22, -4)
            public Vector2D(string input) 
            {
                // TODO: All this splitting & text processign sucks, maybe switch over to using Regex
                int mid = input.IndexOf(',');
                x = double.Parse(input.Substring(1, mid - 1));
                y = double.Parse(input.Substring(mid + 1, input.Length - (mid + 1 + 1)));
            }

            // Operator Overloads
            public static Vector2D operator-(Vector2D v1, Vector2D v2 )
            {
                return new Vector2D(v1.x - v2.x, v1.y - v2.y);
            }

            public static Vector2D operator+(Vector2D v1, Vector2D v2 )
            {
                return new Vector2D(v1.x + v2.x, v1.y + v2.y);
            }
        }
            
    }
}
