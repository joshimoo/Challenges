using System;
using System.Collections.Generic;
using System.IO;

namespace CodeEval.ChainInspection
{
    /// <summary>
    /// Chain Inspection Challenge
    /// Difficulty: Medium
    /// Description: Evaluate wether a chain is valid (no cycles, all nodes visited)
    /// Problem Statement: https://www.codeeval.com/open_challenges/119/
    /// </summary>
    class ChainInspection
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            foreach (var line in File.ReadLines(args[0]))
            {
                Console.WriteLine(EvaluateChain(line)? "GOOD" : "BAD");
            }
        }


        private static bool EvaluateChain(string chain)
        {
            var nodes = new Dictionary<string, string>();

            // Build LinkedList
            foreach (string pair in chain.Split(';'))
            {
                // Node value: node[0]
                // Next node:  node[1]
                var node = pair.Split('-');
                if (nodes.ContainsKey(node[0])) { return false; }   // Duplicate
                if (node[0].Equals(node[1])) { return false; }      // Cycle
                nodes.Add(node[0], node[1]);
            }


            // Evaluate LinkedList
            // 500 pairs, maximum therefore it is more effective to just iterate at max 500 instead of doing cycle detection.
            // The counter will also make sure that we fail, if we have unconnected nodes :)
            // BEGIN-3;3-4;4-2;2-END --> GOOD
            // BEGIN-3;3-4;4-2;2-3   --> BAD
            string transitionTo = "BEGIN";
            for (int i = 0; i < nodes.Count; i++)
            {
                if (!nodes.ContainsKey(transitionTo)) { return false; }
                transitionTo = nodes[transitionTo];
            }

            // At the end, transitionTo should be Pointing to END
            return transitionTo.Equals("END");
        }

    }
}
