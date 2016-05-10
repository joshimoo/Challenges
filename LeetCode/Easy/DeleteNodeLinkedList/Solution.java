package Easy.DeleteNodeLinkedList;

/**
 * 237 - Delete Node in a Linked List Challenge
 * Difficulty: Easy
 * Description: Delete a node (except tail) with only a reference to itself
 * Problem Statement: https://leetcode.com/problems/delete-node-in-a-linked-list/
 */
public class Solution {
    public void deleteNode(ListNode node) {
        // don't delete the tail
        if(node != null && node.next != null) {
            
            // since we cannot bypass this node,
            // we are going to copy the stuff from the next node
            // replacing our values and then bypass the next node
            // NOTE: this does not really delete the node though,
            // NOTE: since an outside user might still have a reference to this
            // NOTE: he would not know about the replacement part and would assume it still
            // NOTE: contains the same value as before, etc. So not a big fan of this
            // NOTE: unless, we only use the ListNode Elements, inside this class and never expose them.
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }

    /** Definition for singly-linked list. */
    private class ListNode {
      int val;
      ListNode next;
      ListNode(int x) { val = x; }
    }
}