using System;

// Using two pointers - Time: O(n)
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
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

class Program
{
    static void PrintList(ListNode head)
    {
        Console.Write("[");
        while (head != null)
        {
            Console.Write(head.val);
            head = head.next;
            if (head != null)
            {
                Console.Write(", ");
            }
        }
        Console.Write("]");
    }
    
    static void Main()
    {
        ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        int n = 2;

        Console.Write("Input: head = ");
        PrintList(head);
        Console.WriteLine(", n = {0}", 2);

        Solution sol = new Solution();
        head = sol.RemoveNthFromEnd(head, n);

        Console.Write("Output: ");
        PrintList(head);
        Console.WriteLine();
    }
}
