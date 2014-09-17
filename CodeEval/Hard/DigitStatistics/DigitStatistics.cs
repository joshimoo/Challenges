using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CodeEval.DigitStatistics
{
    /// <summary>
    /// Digit Statistics Challenge
    /// Difficulty: Hard
    /// Description: find out how many times each digit from zero to nine is the last digit of the number in a sequence
    /// Problem Statement: https://www.codeeval.com/open_challenges/144/
    /// </summary>
    class DigitStatistics
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
                // Each line of input contains two space separated integers "a" and "n" E.g: 
                var split = line.Split(' ');
                ulong numberBase = ulong.Parse(split[0]);
                ulong maxExponent = ulong.Parse(split[1]);

                // Constraints // 1000 000 000 000 > uint
                Debug.Assert(2 <= numberBase && numberBase <= 9);
                Debug.Assert(1 <= maxExponent && maxExponent <= 1000000000000);

                // Calculate the digit statistics
                ulong[] digitCounts = CalculateDigitStatistics(numberBase, maxExponent);

                // Print out the digit Statistics
                var sb = new StringBuilder();
                for (int i = 0; i < digitCounts.Length; i++)
                {
                    sb.AppendFormat("{0}: {1}, ", i, digitCounts[i]);
                }

                Console.WriteLine(sb.ToString(0, sb.Length - 2));
            }
        }

        /// <summary>
        /// Calculates the statistics for the last digit upto maxExponent(including)
        /// As long as numberBase is beetwen 0[inklusive] and 9[inklusive] it runs in O(1)
        /// For all other bases the algorithm runs in O(n) where n = maxExponent
        /// </summary>
        static ulong[] CalculateDigitStatistics(ulong numberBase, ulong maxExponent)
        {
            /* Discussion Time:
             * This algorithm is O(n) all the better pow calculation algorithms are O(log(n))
             * http://en.wikipedia.org/wiki/Exponentiation_by_squaring#Further_applications
             * http://en.wikipedia.org/wiki/Modular_exponentiation
             * 
             * But since we require all exponents and not just the highest, they would be O(n * log(n))
             * Therefore my O(n) algorithm is already better. But since an O(n) algorithm is still to slow.
             * 
             * TODO: I was thinking we need an O(1) algorithm, which I think we can get if we look at the number sequences.
             * For example:       [5] * 5 = 2[5] * 5 = 12[5] * 5 = 62[5] * 5 = 312[5]
             * Found another one: [2] * 2 = [4] * 2 = [8] * 2 = 1[6] * 2 = 3[2] * 2 = 6[4] * 2 = 12[8] * 2 = 25[6]
             * Found another one: [3] * 3 = [9] * 3 = 2[7] * 3 = 8[1] * 3 = 24[3] * 3 = 72[9] * 3 = 218[7] * 3 = 656[1]
             * Found another one: [4] * 4 = 1[6] * 4 = 6[4] * 4 = 25[6] * 4 = 102[4] * 4 = 409[6] * 4 = 1638[4] * 4 = 6553[6]
             * Found another one: [6] * 6 = 3[6] * 6 = 21[6] * 6 = 129[6] * 6 = 7,77[6]
             * Found another one: [7] * 7 = 4[9] * 7 = 34[3] * 7 = 240[1] * 7 = 1680[7] * 7 = 11764[9] * 7 = 82354[3] * 7 = 576480[1]
             * Found another one: [8] * 8 = 6[4] * 8 = 51[2] * 8 = 409[6] * 8 = 3276[8] * 8 = 26214[4] * 8 = 209715[2] * 8 = 1677721[6]
             * Found another one: [9] * 9 = 8[1] * 9 = 72[9] * 9 = 656[1] * 9 = 5904[9] * 9 = 53144[1]
             * 
             * TODO: Design a function f(x,y) = x^y % 10  then plot that function foreach x[0,9] as well as y[1, maxExponent]
             * That will alow me to spot if their is a sequence for each x. Each sequence we find reduces the workload by 1 * maxExponent
             * 
             * NOTE: I decided to put the function plotting on the backburner and just do a quick test with windows calculator, up to a pretty big number.
             * Ofcourse this is not really a mathematical proof, but it seemed like the sequences would continue infinitly
             * 
             * Interesting that they are repeating like this, there is probally a name for this in mathematics already.
             */

            ulong[] digitCounts = new ulong[10];
            ulong count = 0;
            ulong rem = 0;

            switch (numberBase)
            {
                case 2:
                count = maxExponent / 4;
                rem = maxExponent % 4;
                digitCounts[2] = rem >= 1 ? count + 1 : count;
                digitCounts[4] = rem >= 2 ? count + 1 : count;
                digitCounts[8] = rem >= 3 ? count + 1 : count;
                digitCounts[6] = count;
                break;

                case 3:
                count = maxExponent / 4;
                rem = maxExponent % 4;
                digitCounts[3] = rem >= 1 ? count + 1 : count;
                digitCounts[9] = rem >= 2 ? count + 1 : count;
                digitCounts[7] = rem >= 3 ? count + 1 : count;
                digitCounts[1] = count;
                break;

                case 4:
                count = maxExponent / 2;
                rem = maxExponent % 2;
                digitCounts[4] = rem > 0 ? count + 1 : count; ;
                digitCounts[6] = count; ;
                break;

                case 5:
                digitCounts[5] = maxExponent;
                break;

                case 6:
                digitCounts[6] = maxExponent;
                break;

                case 7:
                count = maxExponent / 4;
                rem = maxExponent % 4;
                digitCounts[7] = rem >= 1 ? count + 1 : count;
                digitCounts[9] = rem >= 2 ? count + 1 : count;
                digitCounts[3] = rem >= 3 ? count + 1 : count;
                digitCounts[1] = count;
                break;

                case 8:
                count = maxExponent / 4;
                rem = maxExponent % 4;
                digitCounts[8] = rem >= 1 ? count + 1 : count;
                digitCounts[4] = rem >= 2 ? count + 1 : count;
                digitCounts[2] = rem >= 3 ? count + 1 : count;
                digitCounts[6] = count;
                break;

                case 9:
                count = maxExponent / 2;
                rem = maxExponent % 2;
                digitCounts[9] = rem > 0 ? count + 1 : count; ;
                digitCounts[1] = count; ;
                break;

                default:
                ulong num = 1;
                for (ulong i = 1; i <= maxExponent; i++)
                {
                    num = num * numberBase;
                    digitCounts[(num % 10)]++;
                }
                break;
            }

            return digitCounts;
        }

    }
}
