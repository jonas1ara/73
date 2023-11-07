// Definition for singly-linked list.
 public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
    }
}


public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode p = head, q = head;
        while (n > 0)
        {
            q = q.next;
            n--;
        }

        if (q == null)
        {
            return head.next;
        }

        while (q.next != null)
        {
            p = p.next;
            q = q.next;
        }

        p.next = p.next.next;

        return head;
    }
}