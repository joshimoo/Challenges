package Medium.BinaryTreePreOrderTraversal;
import java.util.*;

/**
 * 144 - Binary Tree Preorder Traversal Challenge
 * Difficulty: Medium
 * Description: traverse a binary tree preorder
 * Problem Statement: https://leetcode.com/problems/binary-tree-preorder-traversal/
 */
public class RecursiveSolution {
    public List<Integer> preorderTraversal(TreeNode root) {
        List<Integer> order = new ArrayList<>();
        preorderTraversalRec(order, root);
        return order;
    }
    
    private void preorderTraversalRec(List<Integer> values, TreeNode node) {
        
        // base-case: empty tree
        if(node == null) { return; }
        
        // preorder traversal (current, left, right)
        values.add(node.val);
        preorderTraversalRec(values, node.left);
        preorderTraversalRec(values, node.right);
    }

    /** Definition for a binary tree node. */
    private class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;
        TreeNode(int x) { val = x; }
    }
}