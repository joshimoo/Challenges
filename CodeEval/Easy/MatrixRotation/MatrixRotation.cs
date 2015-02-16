using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeEval.MatrixRotation
{
    /// <summary>
    /// Matrix Rotation Challenge
    /// Difficulty: Easy
    /// Description: Rotate a Matrix 90 Degree
    /// Problem Statement: https://www.codeeval.com/open_challenges/178/
    /// </summary>
    class MatrixRotation
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                int elementCount = line.Length - line.Count(c => c == ' ');
                int n = (int)Math.Sqrt(elementCount);
                Debug.Assert(n * n == elementCount, "matrix needs to be square");

                // TODO: Change all Matrix operation to work on the flattened array (one dimension)
                // LoadFlattened Matrix
                int elementIndex = 0;
                char[,] matrix = new char[n, n];
                for (int x = 0; x < n; x++)
                {
                    for (int y = 0; y < n; y++)
                    {
                        matrix[x, y] = line[elementIndex];
                        elementIndex += 2;
                    }
                }

                // Rotate and Flatten output
                RotateMatrixRight(matrix);
                // RotateMatrixRightSlow(matrix);
                StringBuilder sb = new StringBuilder(line.Length);
                for (int x = 0; x < n; x++)
                {
                    for (int y = 0; y < n; y++)
                    {
                        sb.Append(matrix[x, y]);
                        if (x != n - 1 || y != n - 1) { sb.Append(' '); }
                    }
                }

                Console.WriteLine(sb.ToString());
            }
        }


         #region Matrix Rotation
        /** Matrix Rotation in O(n^2) time and O(1) space algorithm
         * 
         * Rotate by +90:
         * Transpose
         * Reverse each row
         * 
         * Rotate by -90:
         * Transpose
         * Reverse each column
         * 
         * Rotate by +180:
         * Method 1: Rotate by +90 twice
         * Method 2: Reverse each row and then reverse each column
         * 
         * Rotate by -180:
         * Method 1: Rotate by -90 twice
         * Method 2: Reverse each column and then reverse each row
         * Method 3: Reverse by +180 as they are same
         */

        /// <summary>
        /// In place matrix rotation
        /// This will rotate a square matrix 90 Degree right
        /// </summary>
        static void RotateMatrixRight<T>(T[,] m)
        {
            Debug.Assert(m.GetLength(0) == m.GetLength(1), "Matrix needs to be square");
            int n = m.GetLength(0);
            int f = n / 2;       // floor
            int c = (n + 1) / 2; // ceil

            for (int x = 0; x < f; x++)
            {
                for (int y = 0; y < c; y++)
                {
                    // Cyclic Roll
                    T temp = m[x, y];
                    m[x, y] = m[n - 1 - y, x];
                    m[n - 1 - y, x] = m[n - 1 - x, n - 1 - y];
                    m[n - 1 - x, n - 1 - y] = m[y, n - 1 - x];
                    m[y, n - 1 - x] = temp;
                }
            }
        }

        static void RotateMatrixRightSlow<T>(T[,] m)
        {
            TransposeMatrix(m);
            ReverseMatrixRows(m);
        }

        static void TransposeMatrix<T>(T[,] m)
        {
            Debug.Assert(m.GetLength(0) == m.GetLength(1), "Matrix needs to be square");
            int n = m.GetLength(0);

            for (int x = 0; x < n - 1; x++) {
                for (int y = x + 1; y < n; y++)
                {
                    T temp = m[x, y];
                    m[x, y] = m[y, x];
                    m[y, x] = temp;
                }
            }
        }

        static void ReverseMatrixRows<T>(T[,] m)
        {
            Debug.Assert(m.GetLength(0) == m.GetLength(1), "Matrix needs to be square");
            int n = m.GetLength(0);
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n / 2; y++)
                {
                    T temp = m[x, y];
                    m[x, y] = m[x, (n - 1) - y];
                    m[x, (n - 1) - y] = temp;
                }
            }
        }

        #endregion

    }
}
