package Medium.BinaryTreeZigZagLevelOrderTraversal;

import java.util.*;


/**
 * 103 - Binary Tree Zig Zag Level Order Traversal Challenge
 * Difficulty: Medium
 * Description: return binary tree, in Zig Zag level order
 * Problem Statement: https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
 */
public class Solution {
    public List<List<Integer>> zigzagLevelOrder(TreeNode root) {
        List<List<Integer>> levelOrder = new ArrayList<List<Integer>>();

        // add root
        Deque<TreeNode> level = new LinkedList<TreeNode>(); // stack
        if(root !=null) { level.add(root); }
        boolean leftToRight = true;

        // iterate all levels
        while(!level.isEmpty()) {

            Deque<TreeNode> children = new LinkedList<TreeNode>(); // stack
            List<Integer> levelValues = new LinkedList<Integer>();
            while(!level.isEmpty()) {
                TreeNode node = level.pop();

                // if we have reverse order, all the children need to be added from right to left
                // remember we are using a stack, so the processing order changes again
                if(leftToRight) {
                    if(node.left != null) { children.push(node.left); }
                    if(node.right != null) { children.push(node.right); }
                } else {
                    if(node.right != null) { children.push(node.right); }
                    if(node.left != null) { children.push(node.left); }
                }

                levelValues.add(node.val);
            }

            // cycle children
            levelOrder.add(levelValues);
            level = children;
            leftToRight = !leftToRight;
        }

        return levelOrder;
    }

    /**
     * Definition for a binary tree node.
     */
    private class TreeNode {
        int val;
        TreeNode left;
        TreeNode right;
        TreeNode(int x) { val = x; }
    }
}