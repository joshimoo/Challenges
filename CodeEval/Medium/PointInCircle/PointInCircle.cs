using System;
using System.IO;
using System.Text;

namespace CodeEval.PointInCircle
{
    /// <summary>
    /// Point In Circle Challenge
    /// Difficulty: Medium
    /// Description: Determine wether a point is inside of a circle
    /// Problem Statement: https://www.codeeval.com/open_challenges/98/
    /// </summary>
    class PointInCircle
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
                // Center: (2.12, -3.48); Radius: 17.22; Point: (16.21, -5)
                // Center: (5.05, -11); Radius: 21.2; Point: (-31, -45)
                // Center: (-9.86, 1.95); Radius: 47.28; Point: (6.03, -6.42)
                // All numbers in input are between -100 and 100

                // TODO: All this splitting & text processign sucks, maybe switch over to using Regex
                string[] split = line.Split(';');

                int startIndex = split[0].IndexOf(' ') + 1;
                int length = split[0].Length - startIndex;
                var center = new Vector2D(split[0].Substring(startIndex, length));

                startIndex = split[1].LastIndexOf(' ') + 1;
                length = split[1].Length - startIndex;
                double radius = double.Parse(split[1].Substring(startIndex, length));

                startIndex = split[2].IndexOf(' ', 1) + 1;
                length = split[2].Length - startIndex;
                var point = new Vector2D(split[2].Substring(startIndex, length));

                // vector from center to point
                Vector2D target = point - center;

                // NOTE: a point on the radius is neither inside nor outside of the circle?
                // TOOD: see if there is a math definition for this
                Console.WriteLine(target.Magnitude < radius ? "true" : "false");
            }
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
                int mid = input.IndexOf(',');
                x = double.Parse(input.Substring(1, mid - 1));
                y = double.Parse(input.Substring(mid + 2, input.Length - (mid + 2 + 1)));
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
