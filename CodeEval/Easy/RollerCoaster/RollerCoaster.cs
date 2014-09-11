using System;
using System.IO;

namespace CodeEval.RollerCoaster
{
    /// <summary>
    /// Roller Coaster Challenge
    /// Difficulty: Easy
    /// Description: Print the english(asci) text in RoLlEr CoAsTeR formatting
    /// Problem Statement: https://www.codeeval.com/open_challenges/156/
    /// </summary>
    class RollerCoaster
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
                char[] output = new char[line.Length];
                bool makeUpperCase = true;
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                    {
                        // The case flag, is bit 6 (n^5 = 32) in asci
                        // upper case: bit 6 = 0
                        // lower case: bit 6 = 1
                        if (makeUpperCase) { c = (char)(c & (255 - 32)); }
                        else { c = (char)(c | 32); }
                        makeUpperCase = !makeUpperCase;
                    }

                    output[i] = c;
                }

                Console.WriteLine(new string(output));
            }
        }

    }
}
