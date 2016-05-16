package Easy.ReverseLinkedList;

/**
 * 206 - Reverse Linked List Challenge
 * Difficulty: Easy
 * Description: Reverse a Linked List
 * Problem Statement: https://leetcode.com/problems/reverse-linked-list/
 */
public class Solution {
    public ListNode reverseList(ListNode head) {

        // lets find the tail first
        // so that all our changes can be done in O(1)
        // and the total problem in linear time O(n)
        // init: A,B,C,D
        // 0: B,C,D,A
        // 1: C,D,B,A
        // 2: D,C,B,A

        ListNode tail = head;
        int count = head != null ? 1 : 0;
        while(tail != null && tail.next != null) {
            count++;
            tail = tail.next;
        }

        for(int i = 0; i < count - 1; i++) {
            ListNode tmp = head;
            head = head.next;
            tmp.next = tail.next;
            tail.next = tmp;
        }

        // TODO: a better approach would be to switch at the beginning
        // that way we don't even need to find the tail.
        // we just store a reference to the original head
        // init: A,B,C,D
        // 0: B,A,C,D
        // 1: C,B,A,D
        // 2: D,C,B,A

        return head;
    }


    /**
     * Definition for singly-linked list.
     */
     private class ListNode {
        int val;
        ListNode next;
        ListNode(int x) { val = x; }
     }
}