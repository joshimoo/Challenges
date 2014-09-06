using System;
using System.IO;

namespace CodeEval.FileSize
{
    /// <summary>
    /// File Size Challenge
    /// Difficulty: Easy
    /// Description: Print the size of a file in bytes
    /// Problem Statement: https://www.codeeval.com/open_challenges/26/
    /// </summary>
    class FileSize
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            // FileInfo Class takes care of doing this for us :)
            var fileInfo = new FileInfo(args[0]);
            Console.WriteLine(fileInfo.Length);
        }

    }
}
