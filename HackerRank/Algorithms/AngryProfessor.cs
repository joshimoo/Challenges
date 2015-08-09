using System;
using System.Linq;

namespace HackerRank.Algorithms
{
    /// <summary>
    /// Angry Professor Challenge
    /// Description: Evaluate wheter a class gets cancelled
    /// Problem Statement: https://www.hackerrank.com/challenges/angry-professor
    /// </summary>
    class AngryProfessor
    {
        public static void Main(string[] args)
        {
            int testCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCount; i++)
            {
                // studentCount(N), requiredStudents(K)
                var split = Console.ReadLine().Split(' ');
                int studentCount = Convert.ToInt32(split[0]);
                int requiredStudents = Convert.ToInt32(split[1]);
                int studentsOnTime = Console.ReadLine().Split(' ').Count(s => int.Parse(s) <= 0);

                // Cancel the Class?
                Console.WriteLine(studentsOnTime < requiredStudents ? "YES" : "NO");
            }
        }
    }
}