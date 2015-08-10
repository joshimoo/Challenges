using System;

namespace HackerRank.Algorithms.Warmup
{
    /// <summary>
    /// Caesar Cipher Challenge
    /// Description: Apply a Caesar Cipher but only to the chars a-z & A-Z
    /// Problem Statement: https://www.hackerrank.com/challenges/caesar-cipher-1
    /// </summary>
    class CaesarCipher
    {
        public static void Main(string[] args)
        {
            int length = Convert.ToInt32(Console.ReadLine());
            string msg = Console.ReadLine();
            int rot = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Encode(msg, rot));
        }


        static string Encode(string msg, int rot)
        {
            var encoded = new char[msg.Length];
            for (int i = 0; i < encoded.Length; i++)
            {
                char c = msg[i];
                if (c >= 'a' && c <= 'z')
                {
                    c = (char)((((c - 'a') + rot) % 26) + 'a');
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    c = (char)((((c - 'A') + rot) % 26) + 'A');
                }

                encoded[i] = c;
            }

            return new string(encoded);
        }
    }
}