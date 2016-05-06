package Easy.InvertBinaryTree;

import java.util.LinkedList;
import java.util.Queue;

/**
 * 226 - Invert Binary Tree Challenge
 * Difficulty: Easy
 * Description: invert a binary tree
 * Problem Statement: https://leetcode.com/problems/invert-binary-tree/
 */
public class IterativeSolution {

    /** iterative approach - postorder traversal */
    public TreeNode invertTree(TreeNode root) {

        Queue<TreeNode> q = new LinkedList<TreeNode>();
        if(root != null) { q.add(root); }

        while(!q.isEmpty()) {
            TreeNode node = q.remove();
            if(node.left != null) { q.add(node.left); }
            if(node.right != null) { q.add(node.right); }
            swapChildren(node);
        }

        return root;
    }

    /** swaps the two children of a TreeNode */
    private void swapChildren(TreeNode node) {
        if(node == null) { return; }

        // switch nodes left/right child
        TreeNode temp = node.left;
        node.left = node.right;
        node.right = temp;
    }


    /** Definition for a binary tree node. */
    private class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;
        TreeNode(int x) { val = x; }
    }
}