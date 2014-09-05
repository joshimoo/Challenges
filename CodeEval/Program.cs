using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEval
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test Run
            string inputFile = "PlayWithDNA/input.txt";
            string[] input = new string[] { inputFile };
            PlayWithDNA.PlayWithDNA.Main(input);

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}
