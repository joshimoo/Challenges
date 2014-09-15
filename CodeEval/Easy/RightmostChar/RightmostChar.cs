using System;
using System.IO;

namespace CodeEval.RightmostChar
{
    /// <summary>
    /// Rightmost Char Challenge
    /// Difficulty: Easy
    /// Description: return last index of a searched char inside of a string.
    /// Problem Statement: https://www.codeeval.com/open_challenges/31/
    /// </summary>
    class RightmostChar
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!String.IsNullOrEmpty(line))
                    {
                        // Process line
                        var split = line.Split(',');
                        string sentence = split[0];
                        char characterToFind = split[1][0];

                        // iterate the string from behind, and set the result (initial value = -1) to i when you find a matching character then break the iteration and return result.
                        Console.WriteLine(sentence.LastIndexOf(characterToFind));
                    }
                }
            }
        }

    }
}
