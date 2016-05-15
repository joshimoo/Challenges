package Easy.RotateArray;

/**
 * 189 - Rotate Array Challenge
 * Difficulty: Easy
 * Description: Rotate an array k-times
 * Problem Statement: https://leetcode.com/problems/rotate-array/
 * NOTE: this solution exceeds the time limit
 */
public class Solution {
    public void rotate(int[] nums, int k) {

        // we only need to todo at most n-1 rotations,
        // since anymore are the same, so we can take the mod instead
        int rot = k % nums.length;
        while(rot-- > 0) {
            int tmp = nums[nums.length -1];
            for(int i = nums.length - 1; i > 0; i--) { nums[i] = nums[i-1]; }
            nums[0] = tmp;
        }
    }
}