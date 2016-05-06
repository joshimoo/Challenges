package Easy.InvertBinaryTree;

/**
 * 226 - Invert Binary Tree Challenge
 * Difficulty: Easy
 * Description: invert a binary tree
 * Problem Statement: https://leetcode.com/problems/invert-binary-tree/
 */
public class RecPostOrderSolution {

    /** recursive approach - postorder traversal */
    public TreeNode invertTree(TreeNode root) {
        // base-case (empty-tree)
        if(root == null) { return null; }

        // descend into children
        invertTree(root.left);
        invertTree(root.right);

        // switch nodes left/right child
        TreeNode temp = root.left;
        root.left = root.right;
        root.right = temp;
        return root;
    }

    /** Definition for a binary tree node. */
    private class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;
        TreeNode(int x) { val = x; }
    }
}