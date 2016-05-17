package Easy.ClimbingStairs;

/**
 * 70 - Climbing Stairs Challenge
 * Difficulty: Easy
 * Description: you can either take 1 step or 2 steps, In how many distinct ways can you climb to the top?
 * Problem Statement: https://leetcode.com/problems/climbing-stairs/
 * NOTE: Bottom Up builds the solution forward
 */
public class BottomUpDPSolution {

    /** fibonaci, progression with different start values */
    public int climbStairs(int n) {

        // base cases
        if(n <= 0) { return 0; }
        if(n == 1) { return 1; }
        if(n == 2) { return 2; }

        // build results up, we actually only need the last two counts
        // so no need to build the full table
        int[] results = new int[n + 1];
        results[0] = 0;
        results[1] = 1;
        results[2] = 2;

        for (int i = 3; i <= n ; i++) {
            results[i] = results[i-1] + results[i-2];
        }

        return results[n];
    }
}