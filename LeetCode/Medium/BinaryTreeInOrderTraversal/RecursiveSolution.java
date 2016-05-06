package Medium.BinaryTreeInOrderTraversal;
import java.util.*;

/**
 * 94 - Binary Tree Inorder Traversal Challenge
 * Difficulty: Easy
 * Description: traverse a binary tree inorder
 * Problem Statement: https://leetcode.com/problems/binary-tree-inorder-traversal/
 */
public class RecursiveSolution {
    public List<Integer> inorderTraversal(TreeNode root) {
        List<Integer> inorder = new ArrayList<>();
        inorderTraversalRec(inorder, root);
        return inorder;
    }
    
    private void inorderTraversalRec(List<Integer> values, TreeNode node) {
        
        // base-case: empty tree
        if(node == null) { return; }
        
        // inorder traversal (left, current, right)
        inorderTraversalRec(values, node.left);
        values.add(node.val);
        inorderTraversalRec(values, node.right);
    }

    /** Definition for a binary tree node. */
    private class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;
        TreeNode(int x) { val = x; }
    }
}