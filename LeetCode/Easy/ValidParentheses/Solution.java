package Easy.ValidParentheses;

import java.util.Stack;

/**
 * 20 - Valid Parentheses Challenge
 * Difficulty: Easy
 * Description: evaluate whether a string is a valid parentheses combination
 * Problem Statement: https://leetcode.com/problems/valid-parentheses/
 */
public class Solution {

    public boolean isValid(String s) {
        char[] open = new char[] { '(', '{', '[' };
        char[] close = new char[] { ')', '}', ']' };
        Stack<Character> stack = new Stack<>();
        int index = -1;

        for(char c : s.toCharArray()) {
            if((index = indexOf(open, c)) != -1) {
                stack.push(c);
            } else if((index = indexOf(close, c)) != -1) {
                if(stack.isEmpty()) { return false; }
                char lastOpen = stack.pop();
                int openIndex = indexOf(open, lastOpen);
                if(index != openIndex) { return false; }
            } else { // invalid character read
                return false;
            }
        }

        // if their is still an open brace left, then we are invalid
        return stack.isEmpty();
    }

    private boolean contains(char[] data, char c) {
        return indexOf(data, c) != -1;
    }

    private int indexOf(char[] data, char c) {
        for(int i = 0; i < data.length; i++) {
            if(data[i] == c) { return i; }
        }

        return -1;
    }




}