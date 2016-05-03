package Easy.HouseRobber;

/**
 * 198 - House Robber Challenge
 * Difficulty: Easy
 * Description: Find maximal sum, of stolen goods.
 * Problem Statement: https://leetcode.com/problems/house-robber/
 * NOTE: The Greedy Solution, does not guarantee a global optimal sum
 */
public class GreedySolution {
    public int rob(int[] nums) {
        
        // exit early
        // no houses => nothing to steal
        // only 1 house => steal from it
        if(nums.length == 0) { return 0; }
        if(nums.length == 1) { return nums[0]; }
        
        
        // replace each value, with the value - neighbour values
        // since once I steal from a house, I lose the opportunity,
        // to steal from it's neighbours
        int adjusted[] = new int[nums.length];
        
        // firt and last house only have 1 neighbour
        final int last = nums.length - 1;
        adjusted[0] = nums[0] - nums[1];
        for(int i = 1; i < last; i++) {
            adjusted[i] = nums[i] - (nums[i-1] + nums[i + 1]);
        }
        adjusted[last] = nums[last] - nums[last - 1];


        // now that I have the neighbour-value adjusted list, it's just finding maxima,
        // while no longer allowing neighbours of these maxima
        int money = 0;
        boolean[] invalid = new boolean[nums.length];
        boolean targets = true;
        while(targets) {
            int index = maxIndex(adjusted, invalid);
            if(index != -1) {
                money += nums[index];
                
                // this house + neighbours is no longer valid
                invalid[index] = true;
                if(index == 0) { invalid[1] = true; }
                else if(index == last) {invalid[last - 1] = true; }
                else { invalid[index - 1] = true; invalid[index + 1] = true; }
            } else {
                targets = false;
            }
        }
        
        return money;
    }
    
    
    /** 
     * Returns the index of the maximum value
     * from a selection of valid elements
     */
    int maxIndex(int[] nums, boolean[] invalid) {
        int max = Integer.MIN_VALUE;
        int index = -1;
        
        for(int i = 0; i < nums.length; i++) {
            if((!invalid[i]) && nums[i] >= max) {
                max = nums[i];
                index = i;
            }
        }
        
        return index;
    }
}