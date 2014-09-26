using System;

namespace CodeEval.Endianness
{
    /// <summary>
    /// Endianness Challenge
    /// Difficulty: Easy
    /// Description: Return wether the system is Little Or BigEndianness
    /// Problem Statement: https://www.codeeval.com/open_challenges/15/
    /// </summary>
    class Endianness
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            // System Endian Flag: http://msdn.microsoft.com/en-us/library/system.bitconverter.islittleendian(v=vs.110).aspx
            Console.WriteLine(BitConverter.IsLittleEndian ? "LittleEndian" : "BigEndian");
        }
    }
}
