using System;
using System.Diagnostics;
using System.Linq;

namespace HackerRank.Competitions._101_Hack_Aug_2015
{
    /// <summary>
    /// Bags Of Apples Challenge
    /// Description: Sell the Maximum amount of Bags, making sure that the sum is divisble by 3
    /// Problem Statement: https://www.hackerrank.com/contests/101hack28/challenges/bags-of-apples
    /// </summary>
    class BagsOfApples
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var bags = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
            Console.WriteLine(MaximumSum(bags, n));
        }

        static int CalculateElementsToExclude(int[] bags, int remSingle, int remDouble)
        {
            Debug.Assert(remSingle != remDouble);
            int s0 = int.MaxValue;
            int d0 = int.MaxValue;
            int d1 = int.MaxValue;

            foreach (var b in bags)
            {
                if (b % 3 == remSingle && b < s0) { s0 = b; }
                else if (b % 3 == remDouble)
                {
                    // Cycle Elem1 back
                    if (b <= d0)
                    {
                        d1 = d0;
                        d0 = b;
                    }
                    else if (b <= d1) { d1 = b; }
                }
            }

            // NOTE: Make sure that we have valid Elements
            if (d0 != int.MaxValue && d1 != int.MaxValue) { return Math.Min(s0, d0 + d1); }
            if (s0 != int.MaxValue) { return s0; }
            return 0;
        }



        static int MaximumSum(int[] bags, int n)
        {
            // TODO: you could optimize by iterating once and keeping track of the different apple counts in a preallocated count[] array
            // Remove the Smallest possible element, so that sum -> max and divisible by 3
            int sum = bags.Sum();
            int rem = sum % 3;

            // There is a maximum of 2 Deletions I need to make, to get the optimal Sum
            // Rem 0:
            // The complete array is the solution

            // Rem 1:
            // Path1: The single Element % 3 == 1, is smaller then the two elements
            // Path2: The two Elements % 3 == 2, are smaller then the single element
            // Remove the Min of the two Solutions from the Complete Sum

            // Rem 2:
            // Path1: The single Element % 3 == 2, is smaller then the two elements
            // Path2: The two Elements % 3 == 1, are smaller then the single elemen
            // Remove the Min of the two Solutions from the Complete Sum


            // TODO: The way I differentiate beetwen the rems sucks!
            if (rem == 1)
            {
                int dif = CalculateElementsToExclude(bags, rem, 2);
                return dif > 0 ? sum - dif : 0;
            }
            if (rem == 2)
            {
                int dif = CalculateElementsToExclude(bags, rem, 1);
                return dif > 0 ? sum - dif : 0;
            }

            return sum;
        }
    }
}