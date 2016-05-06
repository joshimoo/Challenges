package Medium.BinaryTreePreOrderTraversal;
import java.util.*;

/**
 * 144 - Binary Tree Preorder Traversal Challenge
 * Difficulty: Medium
 * Description: traverse a binary tree preorder
 * Problem Statement: https://leetcode.com/problems/binary-tree-preorder-traversal/
 */
public class IterativeSolution {
    public List<Integer> preorderTraversal(TreeNode root) {
        List<Integer> values = new ArrayList<>();
        Stack<TreeNode> nodes = new Stack<>();
        
        // inorder traversal
        TreeNode node = root;
        while(!nodes.isEmpty() || node != null) {

            if(node != null) {
                // process node
                values.add(node.val);
                nodes.push(node);
                node = node.left;
            } else {
                node = nodes.pop();
                node = node.right;
            }
        }
        
        return values;
    }

    /** Definition for a binary tree node. */
    private class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;
        TreeNode(int x) { val = x; }
    }
}