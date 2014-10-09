using System;
using System.IO;

namespace CodeEval.GameOfLife
{
    /// <summary>
    /// Game Of Life Challenge
    /// Difficulty: Medium
    /// Description: Run the Life Simulation for 10 ticks and print out the state
    /// Problem Statement: https://www.codeeval.com/open_challenges/161/
    /// </summary>
    class GameOfLife
    {
        /// <summary>
        /// Entry Point for the Challenge
        /// </summary>
        /// <param name="args">Command line Arguments</param>
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(args[0]);
            GameOfLifeSim life = new GameOfLifeSim();
            life.InitalizeSimulation(lines, '*', '.');

            // Question: Do I need 10 Generations or 11?
            // Run the simulation for 10 iterations
            for (int i = 0; i < 10; i++) { life.UpdateSimulation(); }
            life.DrawSimulation();
        }


        /// <summary>
        /// Simulates a GameOfLife board
        /// The Simulation assumes that all cells outside of the board are dead
        /// Its build for 100x100 cells for bigger boards you would want to optimize
        /// 
        /// Optimizations:
        /// - instead of having the board state twice, keep one copy and use 3 lines of output buffer
        /// - TODO: double check multi / jagged performance on mono, flatten the array if needed
        /// </summary>
        class GameOfLifeSim
        {
            // NOTE: Multi/Jagged arrays are relativly slow on mono
            bool[,] currentState, newState;
            char alive = '*', death = '.';
            int generation = 0;

            // TODO: Add Ctors and change Initalizitation to use de/serialization instead
            public void InitalizeSimulation(string[] seedState, char alive = '*', char death = '.')
            {
                this.alive = alive;
                this.death = death;
                generation = 0;
                currentState = new bool[seedState.Length, seedState[0].Length];
                newState = new bool[seedState.Length, seedState[0].Length];

                for (int y = 0; y < seedState.Length; y++)
                {
                    for (int x = 0; x < seedState[0].Length; x++)
                    {
                        bool state = seedState[y][x] == alive ? true : false;
                        currentState[y, x] = state;
                    }
                }
            }

            public void DrawSimulation()
            {
                // Process Board
                char[] output = new char[currentState.GetLength(1)];
                for (int y = 0; y < currentState.GetLength(0); y++)
                {
                    for (int x = 0; x < currentState.GetLength(1); x++)
                    {
                        bool state = currentState[y, x];
                        output[x] = state ? alive : death;
                    }

                    Console.WriteLine(output);
                }
            }
                
            public void UpdateSimulation()
            {
                // Process Board rules
                for (int y = 0; y < currentState.GetLength(0); y++)
                {
                    for (int x = 0; x < currentState.GetLength(1); x++)
                    {
                        // Any live cell with fewer than two live neighbors dies, as if caused by under-population.
                        // Any live cell with two or three live neighbors lives on to the next generation.
                        // Any live cell with more than three live neighbors dies, as if by overcrowding.
                        // Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

                        bool state = currentState[y, x];
                        int aliveCount = GetAliveNeighboursCount(y, x);
                        if (aliveCount < 2 || aliveCount > 3) { newState[y, x] = false; }
                        else if (aliveCount == 3) { newState[y, x] = true; }
                        else { newState[y, x] = state; }
                    }
                }

                // Switch the board References
                var temp = currentState;
                currentState = newState;
                newState = temp;
                generation++;
            }

            private int GetAliveNeighboursCount(int y, int x)
            {
                int aliveCount = 0;
                for (int row = y - 1; row <= y + 1; row++)
                {
                    for (int column = x - 1; column <= x + 1; column++)
                    {
                        // Check the neighbour
                        if (row == y && column == x) { continue; }
                        if (row >= 0 && row < currentState.GetLength(0) && column >= 0 && column < currentState.GetLength(1))
                        {
                            aliveCount += currentState[row, column] ? 1 : 0;
                        }
                    }
                }

                return aliveCount;
            }

        }
            

    }
}
