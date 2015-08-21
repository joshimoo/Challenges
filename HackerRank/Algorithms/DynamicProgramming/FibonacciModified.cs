using System;
using System.Collections.Generic;
using System.Numerics;

namespace HackerRank.Algorithms.DynamicProgramming
{
    /// <summary>
    /// Fibonacci Modified Challenge
    /// Description: Calculate the Series: Tn+2 = (Tn+1)^2 + Tn with custom start params
    /// Problem Statement: https://www.hackerrank.com/challenges/fibonacci-modified
    /// </summary>
    class FibonacciModified
    {
        public static void Main(string[] args)
        {
            var par = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int a = par[0];
            int b = par[1];
            int n = par[2];
            PrintBigInterger(CalculateNthTerm(a, b, n));
        }


        /// <summary>
        /// The BigInteger To String Conversion takes to much time.
        /// Therefore "shashank21j" developed the below solution, which splits the int into different quotients
        /// That allow to more easily convert the whole BigInt
        /// </summary>
        static void PrintBigInterger(BigInteger x)
        {
            var ans = new List<BigInteger>();
            var p10 = BigInteger.Pow(10, 100);
            while (x != 0)
            {
                ans.Add(x % p10);
                x = x / p10;
            }

            // Output Last Element
            Console.Write(ans[ans.Count - 1]);
            var fmt = new string('0', 100);

            for (var i = ans.Count - 2; i >= 0; i--)
            {
                var str = ans[i].ToString();
                Console.Write("{0}{1}", fmt.Substring(0, 100 - str.Length), str);
            }

            Console.WriteLine();
        }


        static BigInteger CalculateNthTerm(int a, int b, int n)
        {
            BigInteger term1 = a;
            BigInteger term2 = b;
            BigInteger cur = 0;

            for (int i = 3; i <= n; i++)
            {
                // Push the terms backwards
                cur = BigInteger.Pow(term2, 2) + term1;
                term1 = term2;
                term2 = cur;
            }

            return cur;
        }


    }
}