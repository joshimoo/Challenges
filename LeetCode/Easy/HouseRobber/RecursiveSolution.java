package Easy.HouseRobber;

/**
 * 198 - House Robber Challenge
 * Difficulty: Easy
 * Description: Find maximal sum, of stolen goods.
 * Problem Statement: https://leetcode.com/problems/house-robber/
 * NOTE: The unoptimized Recursive Solution exceeds the time limit
 */
public class RecursiveSolution {
    public int rob(int[] nums) {
        return evaluatePath(nums, 0);
    }
    
    public int evaluatePath(int[] nums, int i) {
        // base-case:
        if(nums == null || i >= nums.length) { return 0; }
        
        // we either take this house, or not
        // if we take it, then we cannot take it's neighbour
        // this will recurse down, and will return at each level, the most valuable sub-path
        return Math.max( nums[i] + evaluatePath(nums, i + 2), evaluatePath(nums, i + 1) );
    }
}