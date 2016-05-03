package Easy.HouseRobber;

/**
 * 198 - House Robber Challenge
 * Difficulty: Easy
 * Description: Find maximal sum, of stolen goods.
 * Problem Statement: https://leetcode.com/problems/house-robber/
 * NOTE: the top-down dp solution does not reevalute already evaluated sub-paths. (memoization)
 */
public class TopDownDPSolution {
    public int rob(int[] nums) {
        // init arrays, with negative value
        // to make sure to not reprocess 0 value paths
        int[] best = new int[nums.length];
        java.util.Arrays.fill(best, -1);
        
        // we do the iteration top-down
        return evaluatePath(nums, best, 0);
    }
    
    public int evaluatePath(int[] nums, int[] best, int i) {
        // base-case:
        if(nums == null || i < 0 || i >= nums.length) { return 0; }
        
        // check wheter we have a cached value
        if(best[i] != -1) { return best[i]; }
        
        // we either take this house, or not
        // if we take it, then we cannot take it's neighbour
        // this will recurse down, and will return at each level, the most valuable sub-path
        best[i] = Math.max( nums[i] + evaluatePath(nums, best, i + 2), evaluatePath(nums, best, i + 1) );
        return best[i];
    }
}