using System;

// Using Floyd's tortoise and hare algorithm - Time: O(n) 

public class ListNode
{
    public int val;
    public ListNode next; // ? means nullable

    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}

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

class Program
{
    static void Main()
    {
        // Example 1 
        // 3 -> 2 -> 0 -> -4 
        ListNode node1 = new ListNode(3);
        ListNode node2 = new ListNode(2);
        ListNode node3 = new ListNode(0);
        ListNode node4 = new ListNode(-4);

        // pos = 1
        node1.next = node2;
        node2.next = node3;
        node3.next = node4;
        node4.next = node2;

        Console.WriteLine("Input: head = [3,2,0,-4], pos = 1");

        // Example 2
        // 1 -> 2
        // ListNode node1 = new ListNode(1);
        // ListNode node2 = new ListNode(2);
        
        // pos = 0
        // node1.next = node2;
        // node2.next = node1;

        // Console.WriteLine("Input: head = [1,2], pos = 0");

        Solution sol = new Solution();
        bool hasCycle = sol.HasCycle(node1);

        if (hasCycle)
        {
            Console.WriteLine("Output: true");
        }
        else
        {
            Console.WriteLine("Output: false");
        }
    }
}
