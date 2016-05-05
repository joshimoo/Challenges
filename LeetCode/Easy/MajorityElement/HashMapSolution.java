package Easy.MajorityElement;

import java.util.*;

/**
 * 169 - Majority Element Challenge
 * Difficulty: Easy
 * Description: Find the Majority Element in an array
 * Problem Statement: https://leetcode.com/problems/majority-element/
 * NOTE: the hashmap solution is slow and requires alot of memory
 */
public class HashMapSolution {
    public int majorityElement(int[] nums) {
		
		// a majority-element is contained more then (n/2) times in the array
        // keep track of how often we have seen a specific element
        Map<Integer,Integer> count = new HashMap<Integer,Integer>();
        for(int x : nums) { count.put(x, count.getOrDefault(x, 0) + 1); }
        
        Map.Entry<Integer,Integer> entry = count.entrySet().stream().max(
            (a, b) -> Integer.compare(a.getValue(), b.getValue())
        ).get(); // since we can assume it always exists, we bypass the optional
        return entry.getKey();
    }
}