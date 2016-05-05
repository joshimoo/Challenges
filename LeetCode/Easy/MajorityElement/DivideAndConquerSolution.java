package Easy.MajorityElement;

/**
 * 169 - Majority Element Challenge
 * Difficulty: Easy
 * Description: Find the Majority Element in an array
 * Problem Statement: https://leetcode.com/problems/majority-element/
 * NOTE: the divide and conquer solution requires O(n*log(n)) and exceeds the timelimit
 */
public class DivideAndConquerSolution {
    public int majorityElement(int[] nums) {
        return majorityElementRec(nums, 0, nums.length);
    }
    
    /**
     * finds the majority element
     * recursivly via divide and conquer
     * low is inclusive
     * high is exclusive
     */
    public int majorityElementRec(int[] nums, int low, int high) {
        
        // base-case: single element
        int elemCount = high - low;
        if(elemCount == 1) { return nums[low]; }
        
        // mid is exclusive
        int mid = low + (elemCount / 2);
        int leftCandidate = majorityElementRec(nums, low, mid);
        int rightCandidate = majorityElementRec(nums, mid, nums.length);
        
        // evaluate which candidate is better
        int leftCount = 0;
        for(int i = low; i < high; i++) {
            if(nums[i] == leftCandidate) { leftCount++; }
        }
        
        return leftCount > (high / 2) ? leftCandidate : rightCandidate;
    }
}