using System;
using System.IO;
using System.Text;

namespace CodeEval.SlangFlavor
{
    /// <summary>
    /// Slang Flavor Challenge
    /// Difficulty: Easy
    /// Description: replace every other end punctuation mark with slang
    /// Problem Statement: https://www.codeeval.com/open_challenges/174/
    /// </summary>
    class SlangFlavor
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] slang = new[]
            {
                ", yeah!",
                ", this is crazy, I tell ya.",
                ", can U believe this?",
                ", eh?",
                ", aw yea.",
                ", yo.",
                "? No way!",
                ". Awesome!"
            };

            int slangIndex = 0;
            int slangCount = slang.Length;
            bool substitue = false;

            foreach (var line in File.ReadLines(args[0]))
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in line)
                {
                    // Description is unclear, wheather we have counts for each indiviual exlamation
                    // or one total (count % 2) for substitution enable 
                    if (c == '.' || c == '!' || c == '?')
                    {
                        if (substitue) { sb.Append(slang[slangIndex++]); }
                        else { sb.Append(c); }
                        
                        substitue = !substitue;
                        slangIndex = slangIndex % slangCount;
                    }
                    else { sb.Append(c); }
                }

                Console.WriteLine(sb.ToString());
            }
        }

    }
}
