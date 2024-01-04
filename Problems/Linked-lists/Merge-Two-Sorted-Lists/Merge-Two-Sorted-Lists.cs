using System;

// Using a part of the merge sort algorithm - Time: O(m + n)

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

class Program
{
    static void PrintList(ListNode node)
    {
        Console.Write("[");
        while (node != null)
        {
            Console.Write(node.val);
            node = node.next;
            if (node != null)
            {
                Console.Write(", ");
            }
        }
        Console.Write("]");
    }
    public static void Main()
    {
        ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
        ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

        Console.Write("Input: list 1 = ");
        PrintList(list1);

        Console.Write(", list 2 = ");
        PrintList(list2);
        Console.WriteLine();

        Solution sol = new Solution();
        ListNode mergedList = sol.MergeTwoLists(list1, list2);

        Console.Write("Output: ");
        PrintList(mergedList);
        Console.WriteLine();
    }
}