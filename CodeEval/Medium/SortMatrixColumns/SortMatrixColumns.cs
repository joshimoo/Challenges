using System;
using System.IO;
using System.Text;

namespace CodeEval.SortMatrixColumns
{
    /// <summary>
    /// Sort Matrix Columns Challenge
    /// Difficulty: Medium
    /// Description: Sort a Matrix based on a unique row
    /// Problem Statement: https://www.codeeval.com/open_challenges/200/
    /// </summary>
    class SortMatrixColumns
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                // Matrix Format N*N: -3 29 -3 | -17 69 -17 | 44 3 8
                var split = line.Split('|');
                int[][] matrix = new int[split.Length][];

                for (int i = 0; i < split.Length; i++)
                {
                    matrix[i] = Array.ConvertAll(split[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
                }

                // For the Sort, we use regular Selection Sort, but instead of just swapping indiviual values we swap all columns
                // For a quicker swap operation one could change the matrix represenation to be matrix[col][row]
                int sortByRow = FindStartRow(matrix);
                if (sortByRow != -1) { SelectionSort(matrix, sortByRow); }

                // Print out Matrix
                Console.WriteLine(MatrixToString(matrix));
            }
        }

        /// <summary>
        /// Turns the Matrix into a string in the Challenge format
        /// Matrix Format N*N: -3 29 -3 | -17 69 -17 | 44 3 8
        /// </summary>
        static string MatrixToString(int[][] matrix)
        {
            var sb = new StringBuilder();
            foreach (var row in matrix)
            {
                foreach (var col in row)
                {
                    sb.Append(col).Append(' ');
                }

                sb.Append('|').Append(' ');
            }

            // Remove the last three elements " | "
            return sb.ToString(0, sb.Length - 3);
        }


        /// <summary>
        /// SelectionSort always finds the min from the not sorted part and puts it at the tail from the sorted part.
        /// The Challenge examples, requires a non Stable Sort, so also swap on equality
        /// </summary>
        static void SelectionSort(int[][] matrix, int sortByRow)
        {
            int[] data = matrix[sortByRow];
            for (int i = 0; i < data.Length - 1; i++)
            {
                // Assume the first element is the minimum
                int minIndex = i;

                // test against elements after i to find the smallest
                for (int j = i + 1; j < data.Length; j++)
                {
                    // if data[j] is less, then it is the new minimum
                    if (data[j] <= data[minIndex]) { minIndex = j; }
                }

                // Swap the Elements
                if (minIndex != i) { SwapColumn(matrix, i, minIndex); }
            }
        }


        /// <summary>
        /// Swap Column A and B for each Row
        /// </summary>
        static void SwapColumn(int[][] matrix, int a, int b)
        {
            foreach (var row in matrix)
            {
                int temp = row[a];
                row[a] = row[b];
                row[b] = temp;
            }
        }

        /// <summary>
        /// Finds a unique row, if all rows of the matrix are non unique returns -1;
        /// Because then the input matrix => output matrix, no need to sort
        /// </summary>
        static int FindStartRow(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j - 1] != matrix[i][j]) { return i; }
                }
            }

            // No Unique Rows
            return -1;
        }


    }
}
