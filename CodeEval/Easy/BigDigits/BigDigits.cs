using System;
using System.IO;
using System.Text;

namespace CodeEval.BigDigits
{
    /// <summary>
    /// Big Digits Challenge
    /// Difficulty: Easy
    /// Description: Output Big Digits
    /// Problem Statement: https://www.codeeval.com/open_challenges/163/
    /// </summary>
    class BigDigits
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
                var display = new SegmentDisplay();
                display.Display(line);
            }
        }

        class SegmentDisplay
        {
            private int segmentWidth = 5;
            private int segmentHeigth = 6;
            StringBuilder[] output;

            private static readonly string[] numbers = new string[]
            {
                "-**----*--***--***---*---****--**--****--**---**--",
                "*--*--**-----*----*-*--*-*----*-------*-*--*-*--*-",
                "*--*---*---**---**--****-***--***----*---**---***-",
                "*--*---*--*-------*----*----*-*--*--*---*--*----*-",
                "-**---***-****-***-----*-***---**---*----**---**--",
                "--------------------------------------------------"
            };

            public SegmentDisplay()
            {
                // Variable Width Segment Display, since I am lazy
                // For fixed width create char arrays and add the max segment count = 16
                // Then increment an output count for each digit that is addded
                // To print at the end send the output buffers to Console.Writeline(output,0, outputCount * segmentWidth);
                output = new StringBuilder[segmentHeigth];
                for (int i = 0; i < output.Length; i++)
                {
                    output[i] = new StringBuilder();
                }
            }

            void PrintOutput()
            {
                for (int i = 0; i < segmentHeigth; i++)
                {
                    Console.WriteLine(output[i].ToString());
                }
            }

            public void Display(string s)
            {
                // Convert to Segment output
                foreach (var c in s)
                {
                    if (c >= '0' && c <= '9') { AddDigit(c - '0'); }
                }

                PrintOutput();
            }

            void AddDigit(int digit)
            {
                // Copy to the output Buffer
                // NOTE: Different Approach fixed size output array: outputCount++;
                for (int i = 0; i < segmentHeigth; i++)
                {
                    string line = numbers[i].Substring(digit * segmentWidth, segmentWidth);
                    output[i].Append(line);
                }
            }
        }

    }
}
