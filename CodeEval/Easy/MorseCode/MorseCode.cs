using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeEval.MorseCode
{
    /// <summary>
    /// Morse Code Challenge
    /// Difficulty: Easy
    /// Description: Decode Morse Code to Text
    /// Problem Statement: https://www.codeeval.com/open_challenges/116/
    /// </summary>
    class MorseCode
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(args[0]);
            foreach (var line in lines)
            {
                Console.WriteLine(MorseCommunicator.Decode(line));
            }
        }

        /// <summary>
        /// Converts beetwen Morse Code and Asci text
        /// By using a Dictionary for O(1) lookup
        /// An alternative approach would be doing an http://en.wikipedia.org/wiki/Dichotomic_search
        /// Since the morse code can easily be represented as a Binary Tree / Trie
        /// </summary>
        static class MorseCommunicator
        {
            static readonly Dictionary<char, string> asciToMorse = new Dictionary<char, string>
            {
                {'A', ".-"},    {'B', "-..."},  {'C', "-.-."},  {'D', "-.."}, 
                {'E', "."},     {'F', "..-."},  {'G', "--."},   {'H', "...."},
                {'I', ".."},    {'J', ".---"},  {'K', "-.-"},   {'L', ".-.."},
                {'M', "--"},    {'N', "-."},    {'O', "---"},   {'P', ".--."}, 
                {'Q', "--.-"},  {'R', ".-."},   {'S', "..."},   {'T', "-"}, 
                {'U', "..-"},   {'V', "...-"},  {'W', ".--"},   {'X', "-..-"}, 
                {'Y', "-.--"},  {'Z', "--.."},  {'0', "-----"}, {'1', ".----"}, 
                {'2', "..---"}, {'3', "...--"}, {'4', "....-"}, {'5', "....."}, 
                {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."}    
            };

            static readonly Dictionary<string, char> morseToAsci = new Dictionary<string, char>
            {
                {".-", 'A'},    {"-...", 'B'},  {"-.-.", 'C'},  {"-..", 'D'}, 
                {".", 'E'},     {"..-.", 'F'},  {"--.", 'G'},   {"....", 'H'},
                {"..", 'I'},    {".---", 'J'},  {"-.-", 'K'},   {".-..", 'L'},
                {"--", 'M'},    {"-.", 'N'},    {"---", 'O'},   {".--.", 'P'}, 
                {"--.-", 'Q'},  {".-.", 'R'},   {"...", 'S'},   {"-", 'T'}, 
                {"..-",'U'},    {"...-", 'V'},  {".--", 'W'},   {"-..-", 'X'}, 
                {"-.--", 'Y'},  {"--..", 'Z'},  {"-----", '0'}, {".----", '1'}, 
                {"..---", '2'}, {"...--", '3'}, {"....-", '4'}, {".....", '5'}, 
                {"-....", '6'}, {"--...", '7'}, {"---..", '8'}, {"----.", '9'}    
            };

            public static string Encode(string text)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var c in text)
                {
                    sb.AppendFormat("{0} ", asciToMorse.ContainsKey(c) ? asciToMorse[c] : " ");
                }

                return sb.ToString().Trim();
            }

            public static string Decode(string morse)
            {
                string[] split = morse.Split(' ');
                StringBuilder sb = new StringBuilder();
                foreach (var s in split)
                {
                    sb.Append(morseToAsci.ContainsKey(s) ? morseToAsci[s] : ' ');
                }

                return sb.ToString();
            }
        }


    }
}
