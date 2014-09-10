using System;
using System.IO;

namespace CodeEval.TextToNumber
{
    /// <summary>
    /// Text to Number Challenge
    /// Difficulty: Hard
    /// Description: Convert an english text representation of a number to a number
    /// Problem Statement: https://www.codeeval.com/open_challenges/110/
    /// </summary>
    class TextToNumber
    {
        enum Numbers
        {
            negative = -1,
            zero = 0, one = 1, two = 2, three = 3, four = 4, five = 5, six = 6, seven = 7, eight = 8, nine = 9,
            ten = 10, eleven = 11, twelve = 12, thirteen = 13, fourteen = 14, fifteen = 15, sixteen = 16, seventeen = 17, eighteen = 18, nineteen = 19,
            twenty = 20, thirty = 30, forty = 40, fifty = 50, sixty = 60, seventy = 70, eighty = 80, ninety = 90,
            hundred = 100,
            thousand = 1000,
            million = 1000000
        }

        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                Console.WriteLine(GetNumber(line));
            }
        }

        /// <summary>
        /// Returns a numbers from an english textual representation of that number
        /// </summary>
        public static int GetNumber(string textualNumber)
        {
            string[] split = textualNumber.Split(' ');
            int sum = 0;
            int multiplier = 1;

            for (int i = split.Length - 1; i >= 0; i--)
            {
                // Could instead do my own switch case comparison, but I like this better =)
                Numbers selector = (Numbers)Enum.Parse(typeof(Numbers), split[i], true);
                int number = (int)selector;

                // hundred = multiply the multiplier by hundred since, hundred can be a part of another multiplier (nine hundred thousand)
                // thousand, million, billion = set the multiplier to thousand/million/billion, since its currently the highest possible
                if (selector == Numbers.hundred) { multiplier *= number; }
                else if (selector == Numbers.thousand) { multiplier = number; }
                else if (selector == Numbers.million) { multiplier = number; }
                else if (selector == Numbers.negative) { sum *= number; }
                else { sum += multiplier * number; }
            }

            return sum;
        }

    }
}
