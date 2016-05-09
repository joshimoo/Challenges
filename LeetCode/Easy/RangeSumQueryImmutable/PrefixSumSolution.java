package Easy.RangeSumQueryImmutable;

/**
 * 303 - Range Sum Query Immutable Challenge
 * Difficulty: Easy
 * Description: create a DS that allows quick Range Sum Queries
 * Problem Statement: https://leetcode.com/problems/range-sum-query-immutable/
 */
public class PrefixSumSolution {
    int[] prefixSum;

    public PrefixSumSolution(int[] nums) {

        // the idea is to calculate the prefix sum
        // for the array once, then then
        // then subtract the prefix sums
        prefixSum = new int[nums.length];
        int sum = 0;
        for(int i = 0; i < prefixSum.length; i++) {
            // we include the current value, into the prefix sum
            // and let [0]->[0] an alternative is to add a constant,
            // at the beginning of the prefix array (length + 1)
            sum += nums[i];
            prefixSum[i] = sum;
        }
    }

    public int sumRange(int i, int j) {
        int prevSum = i > 0 ? prefixSum[i-1] : 0;
        return prefixSum[j] - prevSum;
    }
}
