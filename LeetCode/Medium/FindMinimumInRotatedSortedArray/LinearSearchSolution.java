package Medium.FindMinimumInRotatedSortedArray;

/**
 * 153 - Find Minimum in Rotated Sorted Array Challenge
 * Difficulty: Medium
 * Description: Find the minimum in a rotated sorted array
 * Problem Statement: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
 */
public class LinearSearchSolution {
    public int findMin(int[] nums) {
        if(nums.length <= 0) { throw new IllegalArgumentException(); }
        
        // linear search takes O(n) worst case
        // find rotation pivot, since that is the minimum element
        for(int i = 1; i < nums.length; i++) {
            if(nums[i - 1] > nums[i]) { return nums[i]; }
        }
        
        return nums[0];
    }
}