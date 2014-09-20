using System;
using System.IO;
using System.Linq;

namespace CodeEval.JollyJumpers
{
    /// <summary>
    /// Jolly Jumpers Challenge
    /// Difficulty: Medium
    /// Description: A sequence of n > 0 ints is called a jj if the absolute values of the differences between successive elements takes on all possible values 1 through n - 1
    /// Problem Statement: https://www.codeeval.com/open_challenges/43/
    /// </summary>
    class JollyJumpers
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
                // Arithmetic Progressions (Gaus) will not work example:
                // n=4, [1,2,1,5] sum: 1+1+4 = 6   expected: (3*(4))/2 = 6
                int[] numbers = line.Split(' ').Select(int.Parse).ToArray();
                int n = numbers[0] - 1;
                int[] counts = new int[n];

                // Ignore the first number since it's the sequence count
                bool jolly = true;
                for (int i = 2; i < numbers.Length; i++)
                {
                    int dif = Math.Abs(numbers[i - 1] - numbers[i]);
                    if (dif > 0 && dif <= n)
                    {
                        counts[dif - 1]++;
                        if (counts[dif - 1] > 1)
                        {
                            jolly = false;
                            break;
                        }
                    }
                    else
                    {
                        jolly = false;
                        break;
                    }
                }

                Console.WriteLine(jolly ? "Jolly" : "Not jolly");
            }
        }

    }
}
