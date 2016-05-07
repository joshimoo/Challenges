package Medium.FindMinimumInRotatedSortedArray;

/**
 * 153 - Find Minimum in Rotated Sorted Array Challenge
 * Difficulty: Medium
 * Description: Find the minimum in a rotated sorted array
 * Problem Statement: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
 */
public class DivideAndConquerSolution {
    public int findMin(int[] nums) {
        if(nums.length <= 0) { throw new IllegalArgumentException(); }
        return findMinRec(nums, 0, nums.length - 1);
    }
    
    /** 
     * high is inclusive
     * low  is inclusive
     */
    public int findMinRec(int[] nums, int low, int high) {
        
        // base-case: single element Array
        if(low == high) { return nums[low]; }
        int mid = low + ((high - low) / 2);
        
        return Math.min(findMinRec(nums, low, mid), findMinRec(nums, mid + 1, high));
    }
}