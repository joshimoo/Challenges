using System;
using System.IO;

namespace CodeEval.AgeDistribution
{
    /// <summary>
    /// Age Distribution Challenge
    /// Difficulty: Easy
    /// Description: Map age numbers to states
    /// Problem Statement: https://www.codeeval.com/open_challenges/152/
    /// </summary>
    class AgeDistribution
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
                /* If they're from 0 to 2 the child should be with parents print : 'Still in Mama's arms'
                 * If they're 3 or 4 and should be in preschool print : 'Preschool Maniac'
                 * If they're from 5 to 11 and should be in elementary school print : 'Elementary school'
                 * From 12 to 14: 'Middle school'
                 * From 15 to 18: 'High school'
                 * From 19 to 22: 'College'
                 * From 23 to 65: 'Working for the man'
                 * From 66 to 100: 'The Golden Years'
                 * If the age of the person less than 0 or more than 100 - it might be an alien - print: "This program is for humans"
                 */

                int age = int.Parse(line);
                if (age >= 0 && age <= 2) { Console.WriteLine("Still in Mama's arms"); }
                else if (age >= 3 && age <= 4) { Console.WriteLine("Preschool Maniac"); }
                else if (age >= 5 && age <= 11) { Console.WriteLine("Elementary school"); }
                else if (age >= 12 && age <= 14) { Console.WriteLine("Middle school"); }
                else if (age >= 15 && age <= 18) { Console.WriteLine("High school"); }
                else if (age >= 19 && age <= 22) { Console.WriteLine("College"); }
                else if (age >= 23 && age <= 65) { Console.WriteLine("Working for the man"); }
                else if (age >= 66 && age <= 100) { Console.WriteLine("The Golden Years"); }
                else { Console.WriteLine("This program is for humans"); }
            }
        }

    }
}
