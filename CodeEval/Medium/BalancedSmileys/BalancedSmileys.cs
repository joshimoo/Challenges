using System;
using System.IO;
using System.Collections.Generic;

namespace CodeEval.BalancedSmileys
{
    /// <summary>
    /// Balanced Smileys Challenge
    /// Difficulty: Medium
    /// Description: Check if a message has valid parentheses with some edge cases
    /// Problem Statement: https://www.codeeval.com/open_challenges/84/
    /// </summary>
    class BalancedSmileys
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
                // TODO: Rethink this wildcard approach, it seems messy.
                var openBraces = new Stack<char>();
                int wildcards = 0;
                bool valid = true;

                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];

                    // A colon acts as a wildcard and ignores the next char
                    if (c == ':' && i + 1 < line.Length) 
                    {
                        if (line[i+1] == '(' || line[i+1] == ')')
                        {
                            wildcards++;
                        }
                    }
                    else if (c == '(')
                    {
                        // Push Open braces onto the stack
                        openBraces.Push(c);
                    }
                    else if (c == ')')
                    {
                        // on a closing braces pop the last open braces from the stack
                        if (openBraces.Count > 0) { openBraces.Pop(); }
                        else if (wildcards > 0) { wildcards--; }
                        else
                        {
                            valid = false;
                            break;
                        }
                    }
                }

                // To be valid the stack needs to be empty at this point
                if (openBraces.Count - wildcards > 0) { valid = false; }

                Console.WriteLine(valid ? "YES" : "NO");
            }
        }

    }
}
