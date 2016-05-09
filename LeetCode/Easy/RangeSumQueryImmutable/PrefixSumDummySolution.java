package Easy.RangeSumQueryImmutable;

/**
 * 303 - Range Sum Query Immutable Challenge
 * Difficulty: Easy
 * Description: create a DS that allows quick Range Sum Queries
 * Problem Statement: https://leetcode.com/problems/range-sum-query-immutable/
 * NOTE: we add an additional dummy element, to save conditional checks
 * NOTE: this also equals, the math definition
 */
public class PrefixSumDummySolution {
    int[] prefixSum;

    public PrefixSumDummySolution(int[] nums) {

        // add an additional 0 dummy element
        prefixSum = new int[nums.length + 1];
        for(int i = 0; i < nums.length; i++) {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }
    }

    public int sumRange(int i, int j) {
        // i is the previous prefix sum, because of the dummy element
        // therefore we also need to look at j + 1 instead of j
        return prefixSum[j + 1] - prefixSum[i];
    }
}
