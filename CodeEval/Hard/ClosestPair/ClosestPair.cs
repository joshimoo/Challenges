using System;
using System.IO;

namespace CodeEval.ClosestPair
{
    /// <summary>
    /// Closest Pair Challenge
    /// Difficulty: Hard
    /// Description: Find the closest pair from a set of points
    /// Problem Statement: https://www.codeeval.com/open_challenges/51/
    /// </summary>
    class ClosestPair
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            //const double maxDistance = 10000;
            const double maxDistance = double.MaxValue;
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line;
                    int count = int.Parse(reader.ReadLine());
                    if (count == 0) { break; }
                    Vector2D[] points = new Vector2D[count];

                    // Parse the cordinates
                    while (count-- > 0 && (line = reader.ReadLine()) != null)
                    {
                        // NOTE: The string Processing can easily be optimized
                        var split = line.Split(' ');
                        points[count].x = uint.Parse(split[0]);
                        points[count].y = uint.Parse(split[1]);
                    }

                    // Find the closest Pair
                    var closestPair = FindClosestPair(points);
                    double distance = (closestPair[0] - closestPair[1]).Magnitude;
                    Console.WriteLine(distance < maxDistance ? distance.ToString("F04") : "INFINITY");
                }
            }
        }

        /// <summary>
        /// Finds the closest pair
        /// Runs in O(n^2) which sucks.
        /// 
        /// TODO: Sectioning the space 
        /// and then only checking points inside of the space + delta
        /// should lower the runtime
        /// 
        /// Examples: Quadtree, Scene Graph.
        /// </summary>
        static Vector2D[] FindClosestPair(Vector2D[] points)
        {
            Vector2D[] closestPair = new Vector2D[2];
            uint closestDistance = int.MaxValue;
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points.Length; j++) 
                {
                    // NOTE: The max x&y position is 40 000
                    // therefore MagnitudeSquared could overflow an int
                    // Example: 2 * 40 000 ^ 2  > int.MaxValue
                    uint distance = (points[i] - points[j]).MagnitudeSquared;
                    if (i != j  && distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestPair[0] = points[i];
                        closestPair[1] = points[j];
                    }
                }
            }

            return closestPair;
        }

        struct Vector2D
        {
            public uint x, y;
            public uint MagnitudeSquared { get{ return x*x + y*y; } }
            public double Magnitude { get{ return Math.Sqrt(x*x + y*y); } }

            public Vector2D(uint x, uint y)
            {
                this.x = x;
                this.y = y;
            }

            public static Vector2D operator+(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.x + v2.x, v1.y + v2.y);
            }

            public static Vector2D operator-(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.x - v2.x, v1.y - v2.y);
            }
        }
            
    }
}
