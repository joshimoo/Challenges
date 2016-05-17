package Easy.ClimbingStairs;

/**
 * 70 - Climbing Stairs Challenge
 * Difficulty: Easy
 * Description: you can either take 1 step or 2 steps, In how many distinct ways can you climb to the top?
 * Problem Statement: https://leetcode.com/problems/climbing-stairs/
 * NOTE: Top down DP solution is like the recursive one with a cache
 */
public class TopDownDPSolution {

    /** fibonaci, progression with different start values */
    public int climbStairs(int n) {

        int[] results = new int[n + 1];

        // a little bit redundant, but I am tired
        if(n > 2) {
            results[0] = 0;
            results[1] = 1;
            results[2] = 2;
        }

        return climbStairsRec(n, results);
    }

    public int climbStairsRec(int n, int[] results) {

        // base-case
        if(n <= 0) { return 0; }
        if(n == 1) { return 1; }
        if(n == 2) { return 2; }

        // result is cached
        if(results[n-1] != 0 && results[n-2] != 0) {
            results[n] = results[n-1] + results[n-2];
            return results[n];
        }

        // not in cache, calculate it
        results[n] = climbStairsRec(n-1, results) + climbStairsRec(n-2, results);
        return results[n];
    }
}