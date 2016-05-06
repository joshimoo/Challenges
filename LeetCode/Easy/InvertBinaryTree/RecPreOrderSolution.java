package Easy.InvertBinaryTree;

/**
 * 226 - Invert Binary Tree Challenge
 * Difficulty: Easy
 * Description: invert a binary tree
 * Problem Statement: https://leetcode.com/problems/invert-binary-tree/
 */
public class RecPreOrderSolution {
    public TreeNode invertTree(TreeNode root) {
        invertTreeRec(root);
        return root;
    }

    /** recursive approach - preorder traversal */
    void invertTreeRec(TreeNode node) {

        // base-case (empty tree)
        if(node == null) { return; }

        // switch nodes left/right child
        TreeNode temp = node.left;
        node.left = node.right;
        node.right = temp;

        // descend into children
        invertTreeRec(node.left);
        invertTreeRec(node.right);
    }

    /** Definition for a binary tree node. */
    private class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;
        TreeNode(int x) { val = x; }
    }
}