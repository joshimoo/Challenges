using System;

namespace CodeEval
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test Run
            var input = new string[] { "Easy/MorseCode/input.txt" };
            MorseCode.MorseCode.Main(input);

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}
