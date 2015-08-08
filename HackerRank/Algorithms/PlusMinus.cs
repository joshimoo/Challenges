using System;

namespace HackerRank.Algorithms
{
    /// <summary>
    /// Plus Minus Challenge
    /// Description: Accuratly count the distribution of numbers
    /// Problem Statement: https://www.hackerrank.com/challenges/plus-minus
    /// </summary>
    class PlusMinus
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var nums = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
            int pos = 0;
            int neg = 0;

            // Calculate Number Type Count
            foreach (var num in nums)
            {
                if (num > 0) { pos++; }
                else if (num < 0) { neg++; }
            }

            int zero = n - (pos + neg);
            
            // Calculate Fractions - pos,neg,zero
            var fractions = new double[]
            {
                (double) pos/n,
                (double) neg/n,
                (double) zero/n
            };

            // Output Rounded Fractions
            foreach (var fraction in fractions)
            {
                Console.WriteLine(Math.Round(fraction, 3));
            }
        }
    }
}