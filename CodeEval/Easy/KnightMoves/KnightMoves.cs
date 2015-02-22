using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CodeEval.KnightMoves
{
    /// <summary>
    /// Knight Moves Challenge
    /// Difficulty: Easy
    /// Description: Evalute possible Knight Moves (chesss)
    /// Problem Statement: https://www.codeeval.com/open_challenges/180/
    /// </summary>
    class KnightMoves
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                Console.WriteLine(ReturnValidPositions(line[0], line[1]));
            }
        }

        /// <summary>
        /// Returns an alphabeticly sorted list of all possible positons, 
        /// requires the intial position to be inside of the board
        /// only works on empty boards
        /// </summary>
        /// <param name="col">a letter from 'a' to 'h'</param>
        /// <param name="row">a letter from '1' to '8'</param>
        private static string ReturnValidPositions(char col, char row)
        {
            // Make sure the initial position is inside of the board
            Debug.Assert(col >= 'a' && col <= 'h');
            Debug.Assert(row >= '1' && row <= '8');
            var sb = new StringBuilder();

            // Output needs to be alphabeticly sorted
            // Left / BL / TL
            if (col - 2 >= 'a' && row - 1 >= '1') { sb.Append((char)(col - 2)).Append((char)(row - 1)).Append(' '); }
            if (col - 2 >= 'a' && row + 1 <= '8') { sb.Append((char)(col - 2)).Append((char)(row + 1)).Append(' '); }
            if (col - 1 >= 'a' && row - 2 >= '1') { sb.Append((char)(col - 1)).Append((char)(row - 2)).Append(' '); }
            if (col - 1 >= 'a' && row + 2 <= '8') { sb.Append((char)(col - 1)).Append((char)(row + 2)).Append(' '); }

            // BR / TR / Right
            if (col + 1 <= 'h' && row - 2 >= '1') { sb.Append((char)(col + 1)).Append((char)(row - 2)).Append(' '); }
            if (col + 1 <= 'h' && row + 2 <= '8') { sb.Append((char)(col + 1)).Append((char)(row + 2)).Append(' '); }
            if (col + 2 <= 'h' && row - 1 >= '1') { sb.Append((char)(col + 2)).Append((char)(row - 1)).Append(' '); }
            if (col + 2 <= 'h' && row + 1 <= '8') { sb.Append((char)(col + 2)).Append((char)(row + 1)).Append(' '); }
            
            // As long as the initial position is a valid position on the board, there will alway be atleast 2 possible moves
            return sb.ToString(0, sb.Length - 1);
        }

    }
}
