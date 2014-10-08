using System;
using System.IO;

namespace CodeEval.StringRotation
{
    /// <summary>
    /// String Rotation Challenge
    /// Difficulty: Medium
    /// Description: Determine wether a string is a rotation of another
    /// Problem Statement: https://www.codeeval.com/open_challenges/76/
    /// </summary>
    class StringRotation
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
                string[] split = line.Split(',');
                bool result = IsRotation(split[0], split[1]);
                Console.WriteLine(result ? "True" : "False");
            }
        }

        /// <summary>
        /// Determines whether s2 is a rotation of s1
        /// </summary>
        private static bool IsRotation(string s1, string s2)
        {
            return FindRotationOffset(s1, s2) >= 0;
        }

        /// <summary>
        /// Finds the rotation offset.
        /// </summary>
        /// <returns>The rotation offset or -1 if s2 is not a rotation of s1</returns>
        private static int FindRotationOffset(string s1, string s2)
        {
            // Exit early if they are not the same length
            if (s1.Length != s2.Length) { return -1; }

            // Find the Rotation offset
            for (int offset = 0; offset < s1.Length; offset++)
            {
                bool isRotation = true;
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] != s2[(i + offset) % s1.Length])
                    {
                        isRotation = false;
                        break;
                    }
                }

                if (isRotation) { return offset; }
            }

            return -1;
        }
            
    }
}
