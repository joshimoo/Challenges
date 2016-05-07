package Easy.PowerOfFour;

/**
 * 342 - Power of Four Challenge
 * Difficulty: Easy
 * Description: Determine whether a number is a power of four
 * Problem Statement: https://leetcode.com/problems/power-of-four/
 * NOTE: this solution is an extension of the BitCountingSolution
 */
public class BitModSolution {

    /**
     * to be a power of 4, only 1 bit can be set
     * the exponent (bit-index) needs to be even
     */
    public boolean isPowerOfFour(int num) {

        // 1) the number needs to be positive
        if(num <= 0) { return false; }

        // 2) must be a power of 2 => only 1 bit can be set
        // we can check this quickly, by doing an
        // AND with a number that is one smaller then us
        // since that will only have bits (exponents) set that are smaller then us
        // the AND must return 0, because otherwise that would mean we have multiple bits set.
        // which would mean that we are not a power of two, since only 1 bit can be set.
        if((num & (num-1)) != 0) { return false; }


        // 3) the power of two exponent needs to be even
        // since 2^1 * 2^1 = 2^2 = 4^1
        // since 2^2 * 2^2 = 4^1 * 4^1 = 4^2
        //
        // now comes the interesting fact
        // since 4 can be expressed as 4 = (3+1)
        // any power of 4 can also be expressed as
        // 4^x = (3+1)^x
        //
        // so if we remember modular arithmetic:
        // the one will remain if we take the modulus of 3
        // since 4 % 3 = (3+1) % 3 = (3%3 + 1%3) = (0 + 1) % 3 = 1 (MOD 3);
        // so as long as the remainder of the number divided by 3 is 1.
        // it's a valid power of 4, as long as all the other criteria lasts
        return (num % 3) == 1;
    }
}