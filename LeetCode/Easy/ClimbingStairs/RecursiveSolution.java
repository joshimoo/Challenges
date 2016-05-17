package Easy.ClimbingStairs;

/**
 * 70 - Climbing Stairs Challenge
 * Difficulty: Easy
 * Description: you can either take 1 step or 2 steps, In how many distinct ways can you climb to the top?
 * Problem Statement: https://leetcode.com/problems/climbing-stairs/
 * NOTE: simple recursive solutions exceeds the time limit
 */
public class RecursiveSolution {
	
	/** fibonaci, progression with different start values */
    public int climbStairs(int n) {
        
        // base-case
        if(n <= 0) { return 0; }
        if(n == 1) { return 1; }
        if(n == 2) { return 2; }
        
        return climbStairs(n-1) + climbStairs(n-2);
    }
}