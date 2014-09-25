using System;
using System.Collections.Generic;
using System.IO;

namespace CodeEval.PrefixExpressions
{
    /// <summary>
    /// Prefix Expressions Challenge
    /// Difficulty: Hard
    /// Description: Evaluate Prefix Expressions
    /// Problem Statement: https://www.codeeval.com/open_challenges/7/
    /// </summary>
    class PrefixExpressions
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
                Console.WriteLine(EvaluatePrefixExpression(line));
            }
        }

        /// <summary>
        /// You may assume that the only valid operators are '+','*' and '/'(floating-point division). 
        /// </summary>
        static bool IsOperator(string op) { return ("+" == op || "-" == op || "*" == op || "/" == op); }

        /// <summary>
        /// Reverse Stack Approach
        /// Evaluates a prefix expression by reversly adding the operands to a stack
        /// For an idea of how prefix expressions work: http://en.wikipedia.org/wiki/Polish_notation
        /// </summary>
        static double EvaluatePrefixExpression(string prefixExpression)
        {
            var split = prefixExpression.Split(' ');
            var operands = new Stack<float>();

            for (int i = split.Length - 1; i >= 0; i--)
            {
                if (IsOperator(split[i]))
                {
                    var op1 = operands.Pop();
                    var op2 = operands.Pop();

                    if (split[i] == "+") { operands.Push(op1 + op2); }
                    else if (split[i] == "-") { operands.Push(op1 - op2); }
                    else if (split[i] == "*") { operands.Push(op1 * op2); }
                    else if (split[i] == "/") { operands.Push(op1 / op2); }
                }
                else
                {
                    // for numbers just push them onto the stack
                    operands.Push(float.Parse(split[i]));
                }
            }

            // The final result is the last remaining element on the stack
            // since there are n-1 operators and each operation decreases the stack count by 1
            // example: + * 5 4 2
            return operands.Pop();
        }

    }
}
