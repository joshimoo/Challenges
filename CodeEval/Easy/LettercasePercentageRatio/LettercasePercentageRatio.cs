using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CodeEval.LettercasePercentageRatio
{
    /// <summary>
    /// Lettercase Percentage Ratio Challenge
    /// Difficulty: Easy
    /// Description: Calculate the Lettercase Percentage Ratio
    /// Problem Statement: https://www.codeeval.com/open_challenges/147/
    /// </summary>
    class LettercasePercentageRatio
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
                // Exit early if its a not well formed input, since otherwise we would do division by 0
                if (String.IsNullOrEmpty(line))
                {
                    Console.WriteLine("lowercase: {0} uppercase: {1}", 0.ToString("F2", CultureInfo.InvariantCulture), 0.ToString("F2", CultureInfo.InvariantCulture));
                    break;
                }

                // nice Linq one liner to get the lowercase count, this assumes English letters only
                int total = line.Length;
                double lower = line.Count(c => c >= 'a' && c <= 'z');
                double upper = total - lower;

                // Fixed point format with precision 2: http://msdn.microsoft.com/en-us/library/dwhawy9k.aspx
                // Composite Format does not seem to support setting an explicit culture: http://msdn.microsoft.com/en-us/library/txafckwd.aspx
                // Culture Information: http://msdn.microsoft.com/en-us/library/x2bh6292%28v=vs.90%29.aspx
                // Alternativly set the culture for the whole Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                // count / total * 100 = percentage ratio
                Console.WriteLine("lowercase: {0} uppercase: {1}", (lower / total * 100).ToString("F2", CultureInfo.InvariantCulture), (upper / total * 100).ToString("F2", CultureInfo.InvariantCulture));
            }
        }

    }
}
