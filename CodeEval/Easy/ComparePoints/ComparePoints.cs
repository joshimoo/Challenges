using System;
using System.IO;
using System.Text;

namespace CodeEval.ComparePoints
{
    /// <summary>
    /// Compare Points Challenge
    /// Difficulty: Easy
    /// Description: Return the cardinal direction beetwen 2 points
    /// Problem Statement: https://www.codeeval.com/open_challenges/192/
    /// </summary>
    class ComparePoints
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadAllLines(args[0]))
            {
                int[] c = Array.ConvertAll(line.Split(' '), int.Parse);
                Vector2D origin = new Vector2D(c[0], c[1]);
                Vector2D target = new Vector2D(c[2], c[3]);
                StringBuilder sb = new StringBuilder();

                // Are we there yet?
                if (origin == target) { sb.Append("here"); }

                // North/South
                if (origin.y < target.y) { sb.Append('N'); }
                if (origin.y > target.y) { sb.Append('S'); }

                if (origin.x < target.x) { sb.Append('E'); }
                if (origin.x > target.x) { sb.Append('W'); }

                Console.WriteLine(sb.ToString());
            }
        }


        /// <summary>
        /// A quick and dirty Vector Struct,
        /// Only implmented what I need for this challenge
        /// </summary>
        struct Vector2D
        {
            public int x;
            public int y;

            public Vector2D(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public static Vector2D operator -(Vector2D v1, Vector2D v2) { return new Vector2D(v1.x - v2.x, v1.y - v2.y); }
            public static bool operator ==(Vector2D v1, Vector2D v2) { return v1.x == v2.x && v1.y == v2.y; }
            public static bool operator !=(Vector2D v1, Vector2D v2) { return !(v1 == v2); }
        }

    }
}
