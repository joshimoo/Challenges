using System;
using System.IO;

namespace CodeEval.QueryBoard
{
    /// <summary>
    /// Query Board Challenge
    /// Difficulty: Easy
    /// Description: Implement a tiny dsl
    /// Problem Statement: https://www.codeeval.com/open_challenges/87/
    /// </summary>
    class QueryBoard
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            Board board = new Board();
            foreach (var line in File.ReadLines(args[0]))
            {
                // Evaluate Command
                var command = line.Split(' ');
                switch (command[0])
                {
                    case "SetRow":
                        board.SetRow(Convert.ToInt32(command[1]), Convert.ToByte(command[2]));
                        break;

                    case "SetCol":
                        board.SetCol(Convert.ToInt32(command[1]), Convert.ToByte(command[2]));
                        break;

                    case "QueryRow":
                        Console.WriteLine(board.QueryRow(Convert.ToInt32(command[1])));
                        break;

                    case "QueryCol":
                        Console.WriteLine(board.QueryCol(Convert.ToInt32(command[1])));
                        break;

                    default:
                        throw new NotSupportedException("The command: " + command[0] + "is not supported");
                        break;
                }
            }
        }

        class Board
        {
            byte[,] matrix = new byte[256, 256];

            /// <summary>
            /// SetRow i x: it means that all values in the cells on row "i" have been changed to value "x" after this operation.
            /// </summary>
            public void SetRow(int row, byte value)
            {
                for (int i = 0; i < matrix.GetLength(1); i++) { matrix[row, i] = value; }
            }

            /// <summary>
            /// SetCol j x: it means that all values in the cells on column "j" have been changed to value "x" after this operation.
            /// </summary>
            public void SetCol(int column, byte value)
            {
                for (int i = 0; i < matrix.GetLength(0); i++) { matrix[i, column] = value; }
            }

            /// <summary>
            /// QueryRow i: it means that you should output the sum of values on row "i".
            /// </summary>
            public ushort QueryRow(int row)
            {
                ushort sum = 0;
                for (int i = 0; i < matrix.GetLength(1); i++) { sum += matrix[row, i]; }
                return sum;
            }

            /// <summary>
            /// QueryCol j: it means that you should output the sum of values on column "j". 
            /// </summary>
            public ushort QueryCol(int column)
            {
                ushort sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++) { sum += matrix[i, column]; }
                return sum;
            }
        }

    }
}
