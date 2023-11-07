/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    private (ListNode, ListNode) Reverse(ListNode head)
    {
        if (head.next == null) return (head, head);
        var (h, t) = Reverse(head.next);
        t.next = head;
        head.next = null;
        return (h, head);
    }

    public ListNode ReverseList(ListNode head)
    {
        if (head == null) return null;
        return Reverse(head).Item1;
    }
}

// public class Solution {
//     public ListNode ReverseList(ListNode head) {
//         ListNode h = new ListNode();
//         while (head != null) {
//             var p = head;
//             head = head.next;
//             p.next = h.next;
//             h.next = p;
//         }
//         return h.next;
//     }
// }

