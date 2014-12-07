using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CodeEval.CashRegister
{
    /// <summary>
    /// Cash Register Challenge
    /// Difficulty: Easy
    /// Description: Calculate the change, that needs to be returned
    /// Problem Statement: https://www.codeeval.com/open_challenges/54/
    /// </summary>
    class CashRegister
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] denomTexts = new string[]
            {
                "PENNY", "NICKEL", "DIME", "QUARTER", "HALF DOLLAR",
                "ONE", "TWO", "FIVE", "TEN", "TWENTY", 
                "FIFTY", "ONE HUNDRED"
            };

            double[] denomValues = new double[]
            {
                0.01, 0.05, 0.10, 0.25, 0.50,
                1.00, 2.00, 5.00, 10.00, 20.00,
                50.00, 100.00
            };

            foreach (var line in File.ReadLines(args[0]))
            {
                var split = line.Split(';');
                double price = double.Parse(split[0]);
                double given = double.Parse(split[1]);
                Console.WriteLine(ReturnChange(denomTexts, denomValues, given - price));
            }
        }

        /// <summary>
        /// Greedy Algorithm
        /// Return the Change Amount in the required Denominations, for the passed value
        /// Denomination values/texts need to be in ascending Order
        /// </summary>
        static string ReturnChange(string[] texts, double[] values, double value)
        {
            Debug.Assert(texts.Length == values.Length);
            if (value == 0) { return "ZERO"; }
            else if (value < 0) { return "ERROR"; }
            else
            {
                var sb = new StringBuilder();
                for (int i = values.Length - 1; i >= 0; i--)
                {
                    while (values[i] <= value)
                    {
                        value -= values[i];
                        sb.Append(texts[i]);
                        sb.Append(' ');
                    }
                }

                return sb.ToString(0, sb.Length - 1);
            }
        }

    }
}
