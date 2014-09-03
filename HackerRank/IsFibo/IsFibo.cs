using System;
using System.Collections.Generic;

namespace HackerRank.IsFibo
{
    /// <summary>
    /// Is Fibo Challenge
    /// Description: Is the number an element in the Fibonacci series
    /// Problem Statement: https://www.hackerrank.com/challenges/is-fibo
    /// </summary>
    class IsFibo
    {
        // Entry Point for the Challenge
        public static void Main(string[] args)
        {
            IsFibo fibo = new IsFibo();
            var numbersToTest = new List<ulong>();

            string line = Console.ReadLine().Trim();
            int n = int.Parse(line);
            for (var i = 0; i < n; i++)
            {
                line = Console.ReadLine().Trim();
                ulong test = ulong.Parse(line);
                numbersToTest.Add(test);
            }

            // Test each number in test Case - could be paralized
            foreach (var i in numbersToTest)
            {
                Console.WriteLine(fibo.IsPartOfFibonacciSequence(i) ? "IsFibo" : "IsNotFibo");
            }
        }

        private List<ulong> fiboSequence;

        public IsFibo() { InitalizeFibonacciSequence(); }

        // Add the starting values to the fibonacci sequence
        private void InitalizeFibonacciSequence() { fiboSequence = new List<ulong>() { 0, 1 }; }

        // Dynamic Programming approach?
        public bool IsPartOfFibonacciSequence(ulong number)
        {
            int index = fiboSequence.Count - 1;
            ulong i = fiboSequence[index];

            // Check the list to see if we already calculated this
            if (i > number) { return fiboSequence.Contains(number); }

            // Continue with the previous calculation
            while (i < number)
            {
                i = fiboSequence[index - 1] + fiboSequence[index];
                fiboSequence.Add(i);
                index++;
            }

            // Did we calculate the fibo number this turn?
            return (i == number);
        }
    }
}
