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
    public ListNode MergeTwoLists(ListNode a, ListNode b)
    {
        ListNode head = new ListNode(0); 
        ListNode p = head;
        head.next = a;

        while (p.next != null && b != null)
        {
            if (p.next.val > b.val)
            {
                ListNode node = b;
                b = b.next;
                node.next = p.next;
                p.next = node;
            }
            p = p.next;
        }

        if (b != null)
        {
            p.next = b;
        }

        return head.next;
    }
}