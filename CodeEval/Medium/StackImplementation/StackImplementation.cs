using System;
using System.IO;
using System.Text;

namespace CodeEval.StackImplementation
{
    /// <summary>
    /// Stack Implementation Challenge
    /// Difficulty: Medium
    /// Description: Implement a Stack then print every second integer that you pop from it.
    /// Problem Statement: https://www.codeeval.com/open_challenges/9/
    /// </summary>
    class StackImplementation
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
                string[] split = line.Split(' ');
                StringBuilder sb = new StringBuilder();

                // NOTE: Using a Stack for this is quite unnecessary, see below
                for (int i = split.Length - 1; i >= 0; i -= 2) { sb.AppendFormat("{0} ", split[i]); }

                /*// Stack usage - We could convert to number here, but why?
                var stack = new Stack<string>();
                bool include = true;
                foreach (var s in split) { stack.Push(s); }
                while (stack.Count > 0)
                {
                    var item = stack.Pop();
                    if (include) { sb.AppendFormat("{0} ", item); }
                    include = !include;
                }*/

                Console.WriteLine(sb.ToString(0, sb.Length - 1));
            }
        }

        /// <summary>
        /// Quick implementation of a Generic Stack DataStructure
        /// Missing functionality: Ctors, Peek, Enumerator, CopyToArray
        /// 
        /// For production I recommed to use the NetFramework Implementation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class Stack<T>
        {
            private T[] data = new T[0];
            private const int defaultCapacity = 4;
            private int count = 0;
            public int Count { get { return count; } }

            public void Clear()
            {
                Array.Clear(data, 0, count);
                count = 0;
            }

            public void Push(T item)
            {
                // Make sure we have enough space
                if (count == data.Length)
                {
                    T[] newStorage = new T[data.Length > 0 ? data.Length * 2 : defaultCapacity];
                    Array.Copy(data, newStorage, data.Length);
                    data = newStorage;
                }

                data[count++] = item;
            }

            public T Pop()
            {
                // There is nothing to pop
                if (count == 0) { throw new InvalidOperationException("Stack is empty"); }

                T item = data[--count];
                data[count] = default(T);
                return item;
            }
        }

    }
}
