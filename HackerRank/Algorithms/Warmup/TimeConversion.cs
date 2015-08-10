using System;

namespace HackerRank.Algorithms.Warmup
{
    /// <summary>
    /// Time Conversion Challenge
    /// Description: Convert 12 Hour Format into 24 Hour Format
    /// Problem Statement: https://www.hackerrank.com/challenges/time-conversion
    /// </summary>
    class TimeConversion
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(ConvertTo24HourFormat(s));
        }

        static string ConvertTo24HourFormat(string time) { return ConvertTo24HourFormat(time.Substring(0, time.Length - 2), time.Substring(time.Length - 2)); }
        static string ConvertTo24HourFormat(string time, string modifier)
        {
            var quotients = time.Split(':');
            int hour = int.Parse(quotients[0]);

            // Note: Midnight is 12:00:00AM or 00:00:00 and 12 Noon is 12:00:00PM. 
            if (modifier == "AM") { hour = hour % 12; }
            else if (modifier == "PM") { hour = (hour % 12) + 12; }

            // Pad the hours with 0 if they are smaller then 10
            quotients[0] = hour.ToString("D2");
            return String.Join(":", quotients);
        }
    }
}