package Medium.BitwiseAndOfNumbersRange;

/**
 * 201 - Bitwise AND of Numbers Range Challenge
 * Difficulty: Medium
 * Description: Calculate the BitWise and of a numbers Range
 * Problem Statement: https://leetcode.com/problems/bitwise-and-of-numbers-range/
 */
public class Solution {

    /**
     * this finds the common part of the numbers
     * by keeping all bits till the first difference.
     * that will be the shared part of the range
     */
    public int commonOffset(int m, int n) {
         int result = 0;
         for(int i = 31; i >= 0; i--) {
             int exp = 1 << i;
             
             // once we detect the first difference,
             // we have calculated the shared part of the range
             if( (m & exp) != (n & exp) ) { break; }
             result += (m & exp);
        }
        
        return result;
    }
    
    public int rangeBitwiseAnd(int m, int n) {
        
        // If they are in two different ranges, you will always get 0
        // since the crossover exponent, only has 1 bit set
        //if(highestExponent(m) != highestExponent(n)) { return 0; }
        
        // now comes the interesting part, since they are in the same range
        // 2^x <= m <= n < 2^(x+1)
        //int highest = highestExponent(m);
        
        // Here we could probably find some more optimization criteria
        // But for now, we are just going to check inside of the range, 
        // Worst case: 3^31 - 2^30 ~ 1 billion ands
        
        // By looking at the numbers, you can find a pattern,
        // that only all bits that are the same till the first difference are relevant
        // for the shared part, since the other bits will eventually flip and therefore are not
        // included in the and range.
        return commonOffset(m, n);
    }
}