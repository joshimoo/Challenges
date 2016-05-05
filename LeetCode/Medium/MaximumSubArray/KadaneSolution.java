package Medium.MaximumSubArray;


/**
 * 53 - Maximum SubArray Challenge
 * Difficulty: Medium
 * Description: Find the maximum contiguous subarray (max-sum over time)
 * Problem Statement: https://leetcode.com/problems/maximum-subarray/
 * NOTE: Kadane's O(n) Algorithm:
 * NOTE: https://en.wikipedia.org/wiki/Maximum_subarray_problem#Kadane.27s_algorithm
 */
public class KadaneSolution {

    public int maxSubArray(int[] nums) {

        // this allows 0 length subarrays
        int maxSum = 0;
        int sum = 0;
        for(int i = 0; i < nums.length; i++) {
            sum = Math.max(sum + nums[i], 0);
            maxSum = Math.max(sum, maxSum);
        }

        return maxSum;
    }
}