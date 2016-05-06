package Medium.BinaryTreeInOrderTraversal;
import java.util.*;

/**
 * 94 - Binary Tree Inorder Traversal Challenge
 * Difficulty: Easy
 * Description: traverse a binary tree inorder
 * Problem Statement: https://leetcode.com/problems/binary-tree-inorder-traversal/
 */
public class IterativeSolution {
    public List<Integer> inorderTraversal(TreeNode root) {
        List<Integer> inorder = new ArrayList<>();
        Stack<TreeNode> nodes = new Stack<>();
        
        // inorder traversal
        TreeNode node = root;
        while(!nodes.isEmpty() || node != null) {
            if(node != null) {
                // push and go left
                nodes.push(node);
                node = node.left;
            } else {
                // process current node
                node = nodes.pop();
                inorder.add(node.val);
                
                // go right
                node = node.right;
            }
        }
        
        return inorder;
    }

    /** Definition for a binary tree node. */
    private class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;
        TreeNode(int x) { val = x; }
    }
}