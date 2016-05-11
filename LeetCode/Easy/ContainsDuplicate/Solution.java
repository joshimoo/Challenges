package Easy.ContainsDuplicate;

import java.util.HashSet;
import java.util.Set;

/**
 * 217 - Contains Duplicate Challenge
 * Difficulty: Easy
 * Description: Check whether the array contains a duplicate element
 * Problem Statement: https://leetcode.com/problems/contains-duplicate/
 */
public class Solution {
    public boolean containsDuplicate(int[] nums) {
        Set<Integer> count = new HashSet<Integer>();

        // no need to keep track of a count,
        // since once an element is in the set,
        // we must have seen it before
        for(int x : nums) {
            if(count.contains(x)) { return true; }
            count.add(x);
        }

        return false;
    }
}