using System;
using System.IO;
using System.Text;

namespace CodeEval.CapitalizeWords
{
    /// <summary>
    /// Capitalize Words Challenge
    /// Difficulty: Easy
    /// Description: Capitalize the first character (a-->z) of each Word
    /// Problem Statement: https://www.codeeval.com/open_challenges/93/
    /// </summary>
    class CapitalizeWords
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
                Console.WriteLine(CapitalizeAllWords(line));
            }
        }

        /// <summary>
        /// Capitalizes all the Words in a sentece, by iterating trough the sentence
        /// </summary>
        static string CapitalizeAllWords(string sentence)
        {
            var words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder(sentence);
            bool newWord = true;

            for (int i = 0; i < sb.Length; i++)
            {
                // The case flag, is bit 6 (n^5 = 32) in asci
                // upper case: bit 6 = 0
                // lower case: bit 6 = 1
                char c = sb[i];
                if (newWord && c >= 'a' && c <= 'z')
                {
                    sb[i] = (char)(c & (255 - 32)); ;
                    newWord = false;
                }
                else if (c == ' ') { newWord = true; }
                else { newWord = false; }
            }

            return sb.ToString();
        }

    }
}
