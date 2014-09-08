using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CodeEval.PlayWithDNA
{
    /// <summary>
    /// Play with DNA Challenge
    /// Difficulty: Hard
    /// Description: find all occurrences of segment S in DNA string, with maximum allowed mismatches of M.
    /// Problem Statement: https://www.codeeval.com/open_challenges/126/
    /// 
    /// Constrains:
    /// The DNA string length is in range [100, 300]
    /// The M is in range [0, 40]
    /// The segment S length is in range [3, 50] 
    /// </summary>
    class PlayWithDNA
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(args[0]);
            foreach (string line in lines)
            {
                string[] split = line.Split(' ');
                string segment = split[0];
                int maxMismatches = int.Parse(split[1]);
                string dna = split[2];
                var matches = new List<KeyValuePair<string, int>>();

                // Find all substituion matches, with edit distance <= maxMismatches
                for (int i = 0; i <= dna.Length - segment.Length; i++)
                {
                    // NOTE: Optimization pass the string array + index, instead of creating a new substring everytime
                    string candidate = dna.Substring(i, segment.Length);
                    int substitutionCount = CountMismatches(segment, candidate);
                    if (substitutionCount <= maxMismatches)
                    {
                        matches.Add(new KeyValuePair<string, int>(candidate, substitutionCount));
                    }
                }

                // TODO: Need to also consider insertion & deletions
                var work = new List<string>();
                for (int i = 1; i <= maxMismatches; i++)
                {
                    // TODO: This code is shit think about a better approach
                    // Process Insertions (END)
                    int index = (dna.Length - segment.Length) + i;
                    string candidate = dna.Substring(index, segment.Length - i);
                    int substitutionCount = CountMismatches(segment.Substring(0, segment.Length - i), candidate);
                    if (substitutionCount + i <= maxMismatches) // This will either trigger on the first run or not at all
                    {
                        // TODO: Create Permutations for candidate + i and add them here.
                        // This is the start item from the first level
                        if (work.Count == 0) { work.Add(candidate); }
                        char[] alphabet = new char[] { 'A', 'C', 'T', 'G' };

                        // process the items from the prior run, save the items from this run
                        var toProcess = new List<string>();
                        foreach (var item in work)
                        {
                            foreach (var c in alphabet)
                            {
                                // to much string concatination
                                string match = item + c;
                                matches.Add(new KeyValuePair<string, int>(match, substitutionCount + i));
                                toProcess.Add(match);
                            }
                        }

                        // Cycle the list
                        work = toProcess;
                    }

                    // Process Insertions (BEGINNING)
                }

                // Display all the partial matches, with edit distance <= maxMismatches
                DisplayMatches(matches);
            }
        }

        static void DisplayMatches(List<KeyValuePair<string, int>> matches)
        {
            var sb = new StringBuilder();
            if (matches.Count > 0)
            {
                // Sort all missmatches, by missmatch count then alphabeticly
                //var ordered = matches.OrderBy(pair => pair.Value).ThenBy(pair => pair.Key);
                matches.Sort((firstPair, nextPair) =>
                {
                    int c = firstPair.Value.CompareTo(nextPair.Value);
                    return c == 0 ? firstPair.Key.CompareTo(nextPair.Key) : c;
                });

                foreach (var pair in matches) { sb.AppendFormat("{0} ", pair.Key); }
                Console.WriteLine(sb.ToString(0, sb.Length - 1));
            }
            else { Console.WriteLine("No match"); }
        }

        /// <summary>
        /// Count the missmatches beetwen two strings using Hamming Distance
        /// TODO: Change to Levenshtein distance, since we also need to consider insertions/deletions
        /// </summary>
        static int CountMismatches(string pattern, string candidate)
        {
            int mismatchCount = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] != candidate[i]) { mismatchCount++; }
            }

            return mismatchCount;
        }


        #region Permutation Code
        // Mutation Generation
        public static List<string> GetMutations(string kmer, int d)
        {
            // Calculate all mutations with maximal d differences provide the result list with ref mutations
            var mutations = new List<string>();
            Permute(kmer.ToCharArray(), 0, d, "ACTG".ToCharArray(), ref mutations);
            return mutations;
        }

        private static void Permute(char[] arr, int pos, int distance, char[] candidates, ref List<string> mutations)
        {
            // We are done with this Permutation Loop - Therefore add our permutation
            if (pos == arr.Length)
            {
                var permutation = new string(arr);
                mutations.Add(permutation);
                return;
            }

            // distance > 0 means we can change the current character,
            // so go through the candidates
            if (distance > 0)
            {
                char temp = arr[pos];
                for (int i = 0; i < candidates.Length; i++)
                {
                    arr[pos] = candidates[i];
                    int distanceOffset = 0;

                    // different character, thus decrement distance
                    if (temp != arr[pos]) { distanceOffset = -1; }
                    Permute(arr, pos + 1, distance + distanceOffset, candidates, ref mutations);
                }
                arr[pos] = temp;
            }
            else // otherwise just stick to the same character
            {
                Permute(arr, pos + 1, distance, candidates, ref mutations);
            }
        }
        #endregion

    }
}
