package Medium.BinarySearchTreeIterator;

import java.util.Stack;

/**
 * 173 - Binary Search Tree Iterator Challenge
 * Difficulty: Medium
 * Description: create an iterator that traverses a binary tree inorder
 * Problem Statement: https://leetcode.com/problems/binary-search-tree-iterator/
 */
public class BSTIterator {
    private Stack<TreeNode> nodes;
    private TreeNode node;

    /** if we do an inorder traversal, we get the sorted order */
    public BSTIterator(TreeNode root) {
        // traverse to the smallest node (max-left-element)
        nodes = new Stack<TreeNode>();
        node = root;
        while(node != null) {
            nodes.add(node);
            node = node.left;
        }
    }

    /** @return whether we have a next smallest number */
    public boolean hasNext() { return !nodes.isEmpty() || node != null; }

    /** @return the next smallest number */
    public int next() {
        while(!nodes.isEmpty() || node != null) {
            // go down left
            if(node != null) {
                nodes.push(node);
                node = node.left;
            } else {
                // process node, go down right
                node = nodes.pop();
                int value = node.val;
                node = node.right;
                return value;
            }
        }

        // should never get here
        throw new RuntimeException("should never get here");
    }

    /** Definition for a binary tree node. */
    private class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;
        TreeNode(int x) { val = x; }
    }
}