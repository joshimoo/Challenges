package Medium.MaximumSubArray;

/**
 * 53 - Maximum SubArray Challenge
 * Difficulty: Medium
 * Description: Find the maximum contiguous subarray (max-sum over time)
 * Problem Statement: https://leetcode.com/problems/maximum-subarray/
 * NOTE: the divide and conquer solution requires O(n*log(n)) and exceeds the timelimit
 * NOTE: this solution also, keeps track of the indexes via the Result struct
 * NOTE: which is unnecessary for this challenge
 */
public class DivideAndConquerSolution {
    
    public int maxSubArray(int[] nums) {
        return maxSubArrayRec(nums, 0, nums.length).sum;
    }
    
    /** 
     * low is inclusive
     * high is exclusive
     */
    Result maxSubArrayRec(int[] nums, int low, int high) {

        // base-case: single element array
        int elementCount = (high - low);
        if(elementCount < 1) { return new Result(low, high, Integer.MIN_VALUE); } // or throw an exception
        if(elementCount == 1) { return new Result(low, high, nums[low]); }
        
        int mid = low + (elementCount / 2);
        Result left = maxSubArrayRec(nums, low, mid);
        Result right = maxSubArrayRec(nums, mid, high);
        Result cross = maxSubArrayCross(nums, low, high, mid);
        
        // evaluate which subarray is the best
        if(left.sum > right.sum && left.sum > cross.sum) { return left; }
        else if(right.sum > left.sum && right.sum > cross.sum) { return right; }
        else { return cross; }
    }
    
    /**
     * returns the maximum subarray, that crosses the mid point
     * low is inclusive
     * high is exlusive
     */
    Result maxSubArrayCross(int[] nums, int low, int high, int mid) {
        
        // check mid to left
        int sum = 0;
        int leftIndex = 0;
        int leftSum = Integer.MIN_VALUE;
        for(int i = mid - 1; i >= 0; i--) {
            sum += nums[i];
            if(sum > leftSum)  {
                leftSum = sum;
                leftIndex = i;
            }
        }
        
        // check right to end
        sum = 0;
        int rightIndex = 0;
        int rightSum = Integer.MIN_VALUE;
        for(int i = mid; i < high; i++) {
            sum += nums[i];
            if(sum > rightSum) {
                rightSum = sum;
                rightIndex = i;
            }
        }
        
        // return combines subarray sums
        return new Result(leftIndex, rightIndex, leftSum + rightSum);
    }
    
    /**
     * immutable result tuple
     * low is inclusive
     * high is exclusive
     */
    static class Result {
        final int low;
        final int high;
        final int sum;
        
        Result(int low, int high, int sum) {
            this.low = low;
            this.high = high;
            this.sum = sum;
        }
    }
}