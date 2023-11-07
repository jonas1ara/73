/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution
{
    public bool HasCycle(ListNode head)
    {
        ListNode p = head;
        ListNode q = head;
        while (q != null && q.next != null)
        {
            p = p.next;
            q = q.next.next;
            if (p == q)
            {
                return true;
            }
        }
        return false;
    }
}