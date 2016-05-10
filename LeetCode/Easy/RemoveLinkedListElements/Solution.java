package Easy.RemoveLinkedListElements;

/**
 * 203 - Remove Linked List Elements Challenge
 * Difficulty: Easy
 * Description: Delete all Nodes, with a specific val
 * Problem Statement: https://leetcode.com/problems/remove-linked-list-elements/
 */
public class Solution {
    public ListNode removeElements(ListNode head, int val) {

        ListNode node = head;
        while(node != null) {

            // this is only possible, while beeing the head
            if(node == head && node.val == val) {
                head = head.next;
                node = node.next;
            } else if(node.next != null && node.next.val == val) {
                node.next = node.next.next;
            } else { // we can go to the next node only, if we made no changes this run
                node = node.next;
            }
        }

        return head;
    }

    /** Definition for singly-linked list. */
    private class ListNode {
      int val;
      ListNode next;
      ListNode(int x) { val = x; }
    }
}