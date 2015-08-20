using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerRank.Competitions._101_Hack_Aug_2015
{
    /// <summary>
    /// Squares And Points Challenge
    /// Description: Find the Point that is contained in the maximum amount of squares
    /// Problem Statement: https://www.hackerrank.com/contests/101hack28/challenges/squares-1
    /// </summary>
    class SquaresAndPoints
    {
        private struct Vector2D
        {
            public Vector2D(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public readonly int x;
            public readonly int y;
        }

        public static void Main(string[] args)
        {
            // n, m, and l (1 <= n,m <= 10^5, 1 <= l <= 10^9),
            // the number of squares, the number of points and the side length of each square.
            var split = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(split[0]);
            int m = Convert.ToInt32(split[1]);
            int l = Convert.ToInt32(split[2]);

            // Read in Squares
            var squares = new Vector2D[n];
            for (int i = 0; i < n; i++)
            {
                var coords = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                squares[i] = new Vector2D(coords[0], coords[1]);
            }

            // Read in Points
            var points = new Vector2D[m];
            for (int i = 0; i < m; i++)
            {
                var coords = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                points[i] = new Vector2D(coords[0], coords[1]);
            }

            // Find the Point that is contained in the maximum amount of squares
            // Return the maximum number of squares
            // Bruteforce: Worstcase (n * m) => 10^10
            // TODO: Bruteforce solutions is to slow for the contest, lead to timeout

            /* Linq Solution */
            int max = points.Select(p => squares.Count(s => Contains(s, l, p))).Max();

            /* Parallel Solution
            int[] res = new int[m];
            Parallel.ForEach(Partitioner.Create(0, m), (range) => {
                for (int i = range.Item1; i < range.Item2; i++) { res[i] = squares.Count(s => Contains(s, l, points[i])); }
            });
            int max = res.Max();
            */

            Console.WriteLine(max);
        }



        static bool Contains(Vector2D s, int l, Vector2D p)
        {
            // bool horizontal = (p.x >= s.x) && (p.x <= (s.x + l));
            // bool vertical = (p.y >= s.y) && (p.y <= s.y + l);
            return ((p.x >= s.x) && (p.x <= (s.x + l))) &&
                   ((p.y >= s.y) && (p.y <= s.y + l));
        }
    }
}