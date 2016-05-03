package Easy.HouseRobber;

/**
 * 198 - House Robber Challenge
 * Difficulty: Easy
 * Description: Find maximal sum, of stolen goods.
 * Problem Statement: https://leetcode.com/problems/house-robber/
 * NOTE: the bottom-up dp solution, calculates the best-paths from shortest to longest
 */
public class BottomUpDPSolution {
    public int rob(int[] nums) {
        // we build our dp, table backwards (bottom-up)
        // this way all required levels are already present
        // and we just need to make 1 max evaluation per level
        int[] best = new int[nums.length];
        for(int i = nums.length -1; i >= 0; i--) {
            best[i] = Math.max(
                    nums[i] + ((i+2) < nums.length ? best[i+2] : 0),
                    ((i+1) < nums.length ? best[i+1] : 0)
            );
        }

        return nums.length > 0 ? best[0] : 0;
    }
}