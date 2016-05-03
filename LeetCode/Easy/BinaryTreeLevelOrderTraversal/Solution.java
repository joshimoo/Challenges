package Easy.BinaryTreeLevelOrderTraversal;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;


/**
 * 102 - Binary Tree Level Order Traversal Challenge
 * Difficulty: Easy
 * Description: return binary tree, level order
 * Problem Statement: https://leetcode.com/problems/binary-tree-level-order-traversal/
 */
public class Solution {

    public List<List<Integer>> levelOrder(TreeNode root) {

        // prepare result list
        List<List<Integer>> levelOrder = new ArrayList<List<Integer>>();

        // add the root to our queue
        Queue<TreeNode> level = new LinkedList<TreeNode>();
        if(root != null) { level.add(root); }

        // iterate all levels
        while(!level.isEmpty()) {

            // iterate current level
            List<Integer> levelValues = new ArrayList<Integer>();
            Queue<TreeNode> children = new LinkedList<TreeNode>();
            for(TreeNode node : level) {
                if(node.left != null) { children.add(node.left); }
                if(node.right != null) { children.add(node.right); }
                levelValues.add(node.val);
            }

            // we finished this level, cycle children
            levelOrder.add(levelValues);
            level = children;
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