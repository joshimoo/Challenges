using System;
using System.IO;

namespace CodeEval.LowestCommonAncestor
{
    /// <summary>
    /// Lowest Common Ancestor Challenge
    /// Difficulty: Medium
    /// Description: Find the Lowest Common Ancestor for two nodes in a BST
    /// Problem Statement: https://www.codeeval.com/open_challenges/11/
    /// </summary>
    class LowestCommonAncestor
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            BinarySearchTree<int> bst = GenerateChallengeBst();
            foreach (var line in File.ReadLines(args[0]))
            {
                var numbers = Array.ConvertAll(line.Split(' '), int.Parse);

                // Normally you would want todo error checking
                // This will only work if the bst contains the 2 elements
                Console.WriteLine(bst.FindLowestCommonAncestor(numbers[0], numbers[1]).Value);
            }
        }


        /// <summary>
        /// The Tree to use for this challenge
        ///       30
        ///        |
        ///      ____
        ///      |   |
        ///      8   52
        ///      |
        ///    ____
        ///    |   |
        ///    3  20
        ///        |
        ///       ____
        ///      |   |
        ///      10 29
        /// </summary>
        private static BinarySearchTree<int> GenerateChallengeBst()
        {
            var bst = new BinarySearchTree<int>();
            bst.Root = new BinarySearchTree<int>.Node<int>(30);
            bst.Root.Left = new BinarySearchTree<int>.Node<int>(8);
            bst.Root.Left.Left = new BinarySearchTree<int>.Node<int>(3);
            bst.Root.Left.Right = new BinarySearchTree<int>.Node<int>(20);
            bst.Root.Left.Right.Left = new BinarySearchTree<int>.Node<int>(10);
            bst.Root.Left.Right.Right = new BinarySearchTree<int>.Node<int>(29);
            bst.Root.Right = new BinarySearchTree<int>.Node<int>(52);
            return bst;
        }




        /// <summary>
        /// Simple Binary Search Tree for this challenge
        /// Normally I would make the Node<T> private and only deal with it inside of the BST 
        /// Always return T instead of Node<T>, but for the challenge I wanted to keep it simple.
        /// Therefore I also only implemented the requried operations and not more.
        /// </summary>
        class BinarySearchTree<T> where T : IComparable<T>
        {
            public Node<T> Root { get; set; }

            public Node<T> FindLowestCommonAncestor(T n1, T n2)
            {
                // Node<T> parent = null;
                Node<T> node = Root;

                while (node != null)
                {
                    int c1 = n1.CompareTo(node.Value);
                    int c2 = n2.CompareTo(node.Value);

                    // NOTE: the LCA is defined so that nodes are it's own descendants, so this is not needed.
                    // We found one of our nodes, so it's parent is the LCA
                    //if (c1 == 0 || c2 == 0) { return parent; } 
                    //else { parent = node; } // Update parent, it lags 1 cycle behind

                    if (c1 < 0 && c2 < 0) { node = node.Left; } // Left
                    else if (c1 > 0 && c2 > 0) { node = node.Right; } // Right
                    else { return node; } // Paths diverge, found LCA
                }

                return null;
            }

            internal class Node<T>
            {
                public T Value { get; private set; }
                public Node<T> Left { get; set; }
                public Node<T> Right { get; set; }

                public Node(T value) { Value = value; }
            }
        }

    }
}
