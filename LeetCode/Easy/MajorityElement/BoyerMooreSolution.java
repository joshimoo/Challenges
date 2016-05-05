package Easy.MajorityElement;

/**
 * 169 - Majority Element Challenge
 * Difficulty: Easy
 * Description: Find the Majority Element in an array
 * Problem Statement: https://leetcode.com/problems/majority-element/
 * NOTE: the boyer moore algorithm works, since their can only be one possible candidate 
 * NOTE: because [n/2] only allows their to exists one
 */
public class BoyerMooreSolution {
    public int majorityElement(int[] nums) {
        // https://en.wikipedia.org/wiki/Boyer%E2%80%93Moore_majority_vote_algorithm
        int candidate = 0;
        int count = 0;
        for(int x : nums) {
            if(count == 0) { candidate = x; }
            if(x == candidate) { count++; }
            else { count--; }
        }
        
        // normally we would need to verify that the candidate
        // actually is a majority element, in this challenge it's 
        // guaranteed that their exists always one majority element
        // so we could skip, this step
        count = 0;
        for(int x : nums) { if(x == candidate) { count++; } }
        if(count <= nums.length / 2) { throw new RuntimeException("nums does not contain a majority element"); }
        return candidate;
    }
}