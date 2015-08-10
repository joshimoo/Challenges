using System;

namespace HackerRank.Algorithms.Sorting
{
    /// <summary>
    /// Intro to Tutorial Challenges Challenge
    /// Description: Find Value v in a sorted array
    /// Problem Statement: https://www.hackerrank.com/challenges/tutorial-intro
    /// </summary>
    class IntroToTutorialChallenges
    {
        public static void Main(string[] args)
        {
            int find = Convert.ToInt32(Console.ReadLine());
            int count = Convert.ToInt32(Console.ReadLine());
            var nums = Console.ReadLine().Split(' ');

            Console.WriteLine(BinarySearch(nums, find));
        }

        static int BinarySearch(string[] nums, int find)
        {
            int low = 0;
            int high = nums.Length - 1;

            while (low <= high)
            {
                int mid = low + ((high - low) / 2);
                int value = int.Parse(nums[mid]);

                // Adjust bounds
                if (value < find) { low = mid + 1; }
                else if (value > find) { high = mid - 1; }
                else { return mid; }
            }

            // Not found
            return -1;
        }
    }
}