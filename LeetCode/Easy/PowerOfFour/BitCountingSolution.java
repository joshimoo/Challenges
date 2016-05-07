package Easy.PowerOfFour;

/**
 * 342 - Power of Four Challenge
 * Difficulty: Easy
 * Description: Determine whether a number is a power of four
 * Problem Statement: https://leetcode.com/problems/power-of-four/
 */
public class BitCountingSolution {

    /**
     * to be a power of 4, only 1 bit can be set
     * the exponent (bit-index) needs to be even
     * challenge: requires to treat num as signed
     * so any negative number is out already :)
     */
    public boolean isPowerOfFour(int num) {
        int count = 0;
        int exponent = 0;
        while(num > 0) {
            if((num & 0x01) > 0) {
                if(++count > 1) { return false; }
                if(exponent % 2 != 0) { return false; }
            }
            
            num = num >> 1;
            exponent++;
        }
        
        
        return (count == 1);
    }
}