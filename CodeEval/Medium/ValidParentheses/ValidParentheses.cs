using System;
using System.IO;
using System.Collections.Generic;

namespace CodeEval.ValidParentheses
{
    /// <summary>
    /// Valid Parentheses Challenge
    /// Difficulty: Medium
    /// Description: Check if a string is well formed
    /// Problem Statement: https://www.codeeval.com/open_challenges/68/
    /// </summary>
    class ValidParentheses
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
                // (,),{,},[,]
                var matchingBraces = new Dictionary<char, char>() { { '(', ')' }, { '{', '}' }, { '[', ']' } };
                var openBraces = new Stack<char>();
                bool valid = true;

                foreach (var c in line)
                {
                    if (matchingBraces.ContainsKey(c))
                    {
                        // Push Open braces onto the stack
                        openBraces.Push(c);
                    }
                    else if (matchingBraces.ContainsValue(c))
                    {
                        // on a closing braces pop the last open braces from the stack
                        // then compare if they are the same
                        if (openBraces.Count > 0)
                        {
                            char lastOpenBrace = openBraces.Pop();
                            if (c != matchingBraces[lastOpenBrace])
                            {
                                valid = false;
                                break;
                            }
                        }
                        else
                        {
                            valid = false;
                            break;
                        }
                    }
                }

                // To be valid the stack needs to be empty at this point
                if (openBraces.Count != 0)
                {
                    valid = false;
                }

                Console.WriteLine(valid ? "True" : "False");
            }
        }

    }
}
