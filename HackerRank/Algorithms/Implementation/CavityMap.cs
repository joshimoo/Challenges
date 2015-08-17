using System;

namespace HackerRank.Algorithms.Implementation
{
    /// <summary>
    /// Cavity Map Challenge
    /// Description: We will call a cell of the map a cavity if and only if this cell is not on the border of the map and each cell adjacent to it has strictly smaller depth.
    /// Problem Statement: https://www.hackerrank.com/challenges/cavity-map
    /// </summary>
    class CavityMap
    {
        public static void Main(string[] args)
        {
            // Process input
            int n = Convert.ToInt32(Console.ReadLine());
            char[][] map = new char[n][];
            for (int i = 0; i < n; i++) { map[i] = Console.ReadLine().ToCharArray(); }

            // Replace all Cavities with X
            ReplaceAllCavitiesWithX(map, n);

            // Print out Cavity Map
            foreach (char[] row in map) { Console.WriteLine(row); }
        }

        static void ReplaceAllCavitiesWithX(char[][] map, int n)
        {
            for (int y = 1; y < (n - 1); y++)
            {
                for (int x = 1; x < (n - 1); x++)
                {
                    char c = map[y][x];
                    bool cavity = (map[y][x - 1] < c) && (map[y][x + 1] < c) &&
                                  (map[y - 1][x] < c) && (map[y + 1][x] < c);

                    if (cavity) { map[y][x] = 'X'; }
                }
            }
        }


    }
}