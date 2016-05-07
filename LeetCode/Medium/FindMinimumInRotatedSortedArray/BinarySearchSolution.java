package Medium.FindMinimumInRotatedSortedArray;

/**
 * 153 - Find Minimum in Rotated Sorted Array Challenge
 * Difficulty: Medium
 * Description: Find the minimum in a rotated sorted array
 * Problem Statement: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
 * NOTE: this runs in O(log(n))
 * NOTE: the values need to be distinct
 */
public class BinarySearchSolution {
    public int findMin(int[] nums) {
        int left = 0;
        int right = nums.length - 1;

        // is the array sorted (identity rotation) || (single element array)?
        // if(nums[left] <= nums[right]) { return nums[left]; }
        while(left >= 0 && right < nums.length && left <= right) {

            int mid = left + (right - left) / 2;

            // is the range sorted || (single element array)?
            if(nums[left] <= nums[right]) { return nums[left]; }

            // element must be in the range [left, mid] inklusive
            if(nums[left] > nums[mid]) { right = mid; }
            else { left = mid + 1; } // must be in the range [mid+1, right]
        }


        return nums[left];
    }
}