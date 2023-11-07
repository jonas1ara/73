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
    private ListNode MergeTwoLists(ListNode a, ListNode b)
    {
        ListNode head = new ListNode(0); 
        ListNode tail = head;
        while (a != null && b != null)
        {
            if (a.val < b.val)
            {
                tail.next = a;
                a = a.next;
            }
            else
            {
                tail.next = b;
                b = b.next;
            }
            tail = tail.next;
        }
        tail.next = a ?? b;
        return head.next;
    }

    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0)
        {
            return null;
        }
        int N = lists.Length;
        for (int step = 1; step < N; step <<= 1)
        {
            for (int i = 0; i < N - step; i += step << 1)
            {
                lists[i] = MergeTwoLists(lists[i], lists[i + step]);
            }
        }
        return lists[0];
    }
}
