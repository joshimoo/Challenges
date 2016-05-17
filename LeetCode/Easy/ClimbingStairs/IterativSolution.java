package Easy.ClimbingStairs;

/**
 * 70 - Climbing Stairs Challenge
 * Difficulty: Easy
 * Description: you can either take 1 step or 2 steps, In how many distinct ways can you climb to the top?
 * Problem Statement: https://leetcode.com/problems/climbing-stairs/
 * NOTE: This is like the Bottom UP DP Solution but we don't actually build the table
 */
public class IterativSolution {

    /** fibonaci, progression with different start values */
    public int climbStairs(int n) {

        // base cases
        if(n <= 0) { return 0; }
        if(n == 1) { return 1; }
        if(n == 2) { return 2; }

        // build results up, we actually only need the last two counts
        // so no need to build the full table
        int prevStepOne = 2; // n-1
        int prevStepTwo = 1; // n-2
        int result = prevStepOne + prevStepTwo;

        for (int i = 3; i <= n ; i++) {
            result = prevStepOne + prevStepTwo;
            prevStepTwo = prevStepOne;
            prevStepOne = result;
        }

        return result;
    }
}