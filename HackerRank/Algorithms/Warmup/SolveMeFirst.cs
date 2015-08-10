using System;

namespace HackerRank.Algorithms.Warmup
{
    /// <summary>
    /// Solve Me First Challenge
    /// Description: This is mainly used as an io template
    /// Problem Statement: https://www.hackerrank.com/challenges/solve-me-first
    /// </summary>
    class SolveMeFirst
    {
        public static void Main(string[] args)
        {
            int leftOperand = Convert.ToInt32(Console.ReadLine());
            int rightOperand = Convert.ToInt32(Console.ReadLine());
            int sum = Sum(leftOperand, rightOperand);
            Console.WriteLine(sum);
        }

        static int Sum(int leftOperand, int rightOperand)
        {
            return leftOperand + rightOperand;
        }
    }
}