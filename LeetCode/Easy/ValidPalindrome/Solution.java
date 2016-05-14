package Easy.ValidPalindrome;

/**
 * 125 - Valid Palindrome Challenge
 * Difficulty: Easy
 * Description: evaluate whether a string is a valid palindrome
 * Problem Statement: https://leetcode.com/problems/valid-palindrome/
 * NOTE: we consider empty strings to be a palindrome
 */
public class Solution {
    public boolean isPalindrome(String s) {
        char[] o = s.toCharArray();
        int start = 0;
        int end = o.length -1;
        
        while(start < end) {
            if(!Character.isLetterOrDigit(o[start])) { start++; }
            else if(!Character.isLetterOrDigit(o[end])) { end--; }
            else if(Character.toLowerCase(o[start++]) != Character.toLowerCase(o[end--])) { return false; }
        }
        
        return true;
    }
}