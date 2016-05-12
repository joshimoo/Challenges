package Easy.MoveZeroes;

/**
 * 283 - Move Zeroes Challenge
 * Difficulty: Easy
 * Description: Move all Zeroes in an array to the end in place (minimize operations)
 * Problem Statement: https://leetcode.com/problems/move-zeroes/
 */
public class Solution {
    public void moveZeroes(int[] nums) {

        // we go backwards, and if we find a zero,
        // we push all the other elements to it to make space at the end
        // then we move it and reduce the unsorted partition (end--)
        int end = nums.length -1;
        for(int i = nums.length -1; i >= 0; i--) {
            if(nums[i] == 0) {
                int tmp = nums[i];
                for(int j = i; j < end; j++) { nums[j] = nums[j+1]; }
                nums[end--] = tmp;
            }
        }
    }
}