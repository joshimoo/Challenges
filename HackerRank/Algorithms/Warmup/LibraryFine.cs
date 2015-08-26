using System;

namespace HackerRank.Algorithms.Warmup
{
    /// <summary>
    /// Library Fine Challenge
    /// Description: Return the Fine for late returns.
    /// Problem Statement: https://www.hackerrank.com/challenges/library-fine
    /// </summary>
    class LibraryFine
    {
        private struct Date
        {
            public Date(int day, int month, int year)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }

            public Date(int[] dmy)
            {
                this.day = dmy[0];
                this.month = dmy[1];
                this.year = dmy[2];
            }

            public readonly int day;
            public readonly int month;
            public readonly int year;
        }


        public static void Main(string[] args)
        {
            // Format: D M Y
            // 1 <= D <= 31
            // 1 <= M <= 12
            // 1 <= Y <= 3000
            var returnDate = new Date(Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse));
            var expectedDate = new Date(Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse));

            Console.WriteLine(CalculateFee(returnDate, expectedDate));
        }


        /// <summary>
        /// If the book is returned on or before the expected return date, no fine will be charged, in other words fine is 0. 
        /// If the book is returned in the same month as the expected return date, Fine = 15 Hackos × Number of late days
        /// If the book is not returned in the same month but in the same year as the expected return date, Fine = 500 Hackos × Number of late months
        /// If the book is not returned in the same year, the fine is fixed at 10000 Hackos.
        /// </summary>
        static int CalculateFee(Date returnDate, Date expectedDate)
        {
            if (returnDate.year > expectedDate.year) { return 10000; }
            else if ((returnDate.year == expectedDate.year) && returnDate.month > expectedDate.month) { return (returnDate.month - expectedDate.month) * 500; }
            else if ((returnDate.year == expectedDate.year && returnDate.month == expectedDate.month) && returnDate.day > expectedDate.day) { return (returnDate.day - expectedDate.day) * 15; }
            else { return 0; } // returned early
        }
    }
}
