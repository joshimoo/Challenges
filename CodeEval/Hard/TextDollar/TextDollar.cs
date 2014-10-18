using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CodeEval.TextDollar
{
    /// <summary>
    /// Text Dollar Challenge
    /// Difficulty: Hard
    /// Description: Convert an number to an english text representation of that number
    /// Problem Statement: https://www.codeeval.com/open_challenges/52/
    /// </summary>
    class TextDollar
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
                int number = int.Parse(line);
                Console.WriteLine(GetDollarAmount(number));
            }
        }
            
        // NOTE: The correct spelling for 40 is Forty not Fourty :(
        static readonly Dictionary<int, string> numbers = new Dictionary<int, string>()
        {
            { 1000000000, "Billion" }, 
            { 1000000, "Million" }, { 1000, "Thousand" }, { 100, "Hundred" },
            { 90, "Ninety" }, { 80, "Eighty" }, { 70, "Seventy" }, { 60, "Sixty" }, 
            { 50, "Fifty" }, { 40, "Forty" }, { 30, "Thirty" }, { 20,"Twenty" },
            { 19, "Nineteen" }, { 18, "Eighteen" }, { 17, "Seventeen" }, { 16, "Sixteen" }, { 15, "Fifteen" }, 
            { 14, "Fourteen" }, { 13, "Thirteen" }, { 12, "Twelve" }, { 11, "Eleven" }, { 10, "Ten" }, 
            { 9, "Nine" }, { 8, "Eight" }, { 7, "Seven" }, { 6, "Six" }, { 5, "Five" }, 
            { 4, "Four" }, { 3, "Three" }, { 2, "Two" }, { 1, "One" }, { 0, "Zero" }
        };

        // numbers are smaller then a billion
        const int billion = 1000000000, million = 1000000, thousand = 1000, hundred = 100;
        const int ninety = 90 , eighty= 80 , seventy= 70, sixty = 60, fifty = 50;
        const int forty = 40 , thirty= 30 , twenty= 20 , ten= 10;

        public static string GetDollarAmount(int num)
        {
            StringBuilder sb = new StringBuilder();
            if (num == 0) { sb.Append(numbers[0]); }
            while (num > 0)
            {
                // TODO: This method is messy, think about a better way of doing this
                // NOTE: Handle the multiplier first
                // 987 Million 654 Thousand 123
                int digit = 0;
                int multiplier = num;
                if (num >= million) { multiplier = num / million; }
                else if (num >= thousand) { multiplier = num / thousand; }

                if (multiplier >= hundred)
                {
                    digit = multiplier / hundred;
                    multiplier = multiplier % hundred;
                    sb.Append(numbers[digit]);
                    sb.Append(numbers[hundred]);
                }

                if (multiplier >= twenty)
                {
                    digit = multiplier / ten;
                    multiplier = multiplier % ten;
                    sb.Append(numbers[digit * ten]);
                }

                // By now the multiplier should be 0 unless there is still a remainder
                // or a special case like 11
                if (multiplier > 0) { sb.Append(numbers[multiplier]); }
                    
                // Handle the bases
                if (num >= million)
                {
                    sb.Append(numbers[million]);
                    num = num % million;
                }
                else if (num >= thousand)
                {
                    sb.Append(numbers[thousand]);
                    num = num % thousand;
                }
                else
                {
                    // We are done
                    num = 0;
                    break;
                }
            }

            sb.Append("Dollars");
            return sb.ToString();
        }

    }
}
