using System;

namespace HackerRank.Algorithms
{
    /// <summary>
    /// Solve Me Second Challenge
    /// Description: This is mainly used as an io template
    /// Problem Statement: https://www.hackerrank.com/challenges/solve-me-second
    /// </summary>
    class SolveMeSecond
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                var split = Console.ReadLine().Split(' ');
                int leftOperand = Convert.ToInt32(split[0]);
                int rightOperand = Convert.ToInt32(split[1]);
                int sum = Sum(leftOperand, rightOperand);
                Console.WriteLine(sum);
            }
        }

        static int Sum(int leftOperand, int rightOperand)
        {
            return leftOperand + rightOperand;
        }
    }
}