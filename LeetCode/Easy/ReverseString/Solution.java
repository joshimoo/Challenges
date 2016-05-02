package Easy.ReverseString;

/**
 * 344 - Reverse String Challenge
 * Difficulty: Easy
 * Description: Reverse a String
 * Problem Statement: https://leetcode.com/problems/reverse-string/
 */
public class Solution {
    public String reverseString(String s) {
        char[] out = s.toCharArray();
        int end = out.length - 1;
        for(int i = 0; i < out.length / 2; i++) {
            char tmp = out[i];
            out[i] = out[end - i];
            out[end - i] = tmp;
        }
        
        return new String(out);
    }
}