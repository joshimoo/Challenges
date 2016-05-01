package Medium.AddTwoNumbers;

/**
 * 002 - Add Two Numbers Challenge
 * Difficulty: Medium
 * Description: Add two LinkedLists, that contains single digit elements
 * Problem Statement: https://leetcode.com/problems/add-two-numbers/
 */
public class Solution {
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        // we actually only need a bit for carry since 9+9 = 18
        // but it's probably quicker to just add it always,
        // then todo an if/else switch
        int carry = 0;
        ListNode head = null;
        ListNode tail = null;

        // what if, onle list is bigger then the other?
        // i decided to treat it as if the other list is 0
        while(l1 != null || l2 != null) {
            int x1 = l1 != null ? l1.val : 0;
            int x2 = l2 != null ? l2.val : 0;

            int val = (x1 + x2 + carry) % 10;
            carry = (x1 + x2 + carry) >= 10 ? 1 : 0;
            ListNode lNew = new ListNode(val);

            if(head == null) {
                head = lNew;
                tail = lNew;
            } else {
                tail.next = lNew;
                tail = lNew;
            }

            // point to next item
            l1 = l1 != null ? l1.next : null;
            l2 = l2 != null ? l2.next : null;
        }

        // there could still be a carry left after processing all element
        // example (9) + (9), both lists would be empty,
        if(carry > 0) { tail.next = new ListNode(carry); }


        return head;
    }
}

/** Linked List definition */
class ListNode {
    int val;
    ListNode next;
    ListNode(int x) { val = x; }
}