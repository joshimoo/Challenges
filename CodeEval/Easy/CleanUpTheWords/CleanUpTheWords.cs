using System;
using System.IO;
using System.Text;

namespace CodeEval.CleanUpTheWords
{
    /// <summary>
    /// Clean up the words Challenge
    /// Difficulty: Easy
    /// Description: Clean up the noise beetwen 2 words
    /// Problem Statement: https://www.codeeval.com/open_challenges/205/
    /// </summary>
    class CleanUpTheWords
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                StringBuilder sb = new StringBuilder();
                bool newWord = false;
                bool firstWord = true;

                foreach (char c in line)
                {
                    // (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')
                    if (Char.IsLetter(c))
                    {
                        // Add Space beetwen words
                        if (newWord && !firstWord) { sb.Append(' '); }

                        sb.Append(Char.ToLower(c));
                        firstWord = false;
                        newWord = false;
                    }
                    else 
                    {
                        newWord = true;
                    }
                }

                Console.WriteLine(sb.ToString());
            }
        }

    }
}
