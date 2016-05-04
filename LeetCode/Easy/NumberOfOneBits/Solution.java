package Easy.NumberOfOneBits;

/**
 * 191 - Number of 1 Bits Challenge
 * Difficulty: Easy
 * Description: return the amount of set bits
 * Problem Statement: https://leetcode.com/problems/number-of-1-bits/
 */
public class Solution {
    public int hammingWeight(int n) {

        // we just count the high bits
        // we need to treat this as unsiged, so we need to use logical right shift >>>
        int count = 0;
        while(n != 0) {
            count += (n & 0x01);
            n = n >>> 1;
        }

        return count;
    }
}