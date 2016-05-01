package Easy.TwoSums;
import java.util.HashMap;
import java.util.Map;


/**
 * 001 - Two Sums Challenge
 * Difficulty: Easy
 * Description: Return the indexes of 2 numbers that add to target
 * Problem Statement: https://leetcode.com/problems/two-sum/
 */
public class Solution {
    public int[] twoSum(int[] nums, int target) {

        int[] result = new int[] {-1, -1};
        Map<Integer, Integer> map = new HashMap<Integer, Integer>();
        for(int i = 0; i < nums.length; i++) {

            // we check while inserting, this way we can exit early
            // if the looked for number is in the front part of the array
            // but also, since it requires 2 numbers to get to target
            // eventually the other number will be already in the map
            if(map.containsKey(target - nums[i])) {
                result[0] = map.get(target - nums[i]);
                result[1] = i;
                break;
            }

            // we need to first check before adding this entry
            // otherwise we might use this entry twice
            map.put(nums[i], i);
        }

        return result;
    }
}