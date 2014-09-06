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
            var input = new string[] { "RemoveCharacters/input.txt" };
            RemoveCharacters.RemoveCharacters.Main(input);

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}
