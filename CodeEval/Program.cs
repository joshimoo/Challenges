using System;

namespace CodeEval
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test Run
            var input = new string[] { "Medium/GameOfLife/input.txt" };
            GameOfLife.GameOfLife.Main(input);

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}
