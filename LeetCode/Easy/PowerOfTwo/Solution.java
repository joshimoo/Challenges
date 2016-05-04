package Easy.PowerOfTwo;

/**
 * 231 - Power of Two Challenge
 * Difficulty: Easy
 * Description: evaluate whether a number is a power of two
 * Problem Statement: https://leetcode.com/problems/power-of-two/
 */
public class Solution {
    public boolean isPowerOfTwo(int n) {

        // we just count the high bits
        // to be a power of two, only 1 bit must be set
        // we can use an arithmetical right shift >> that way negative numbers will always have a count > 1
        // we could also check that the number is > 0 before entering the loop
        // we exit early, once we know it's no longer a power of two
        int count = 0;
        while(n > 0 && count < 2) {
            count += (n & 0x01);
            n = n >> 1;
        }

        return count == 1;
    }
}