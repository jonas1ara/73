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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode head = new ListNode(0);
        ListNode p = head;
        head.next = list1;

        while (p.next != null && list2 != null)
        {
            if (p.next.val > list2.val)
            {
                ListNode node = list2;
                list2 = list2.next;
                node.next = p.next;
                p.next = node;
            }
            p = p.next;
        }

        if (list2 != null)
        {
            p.next = list2;
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

    static void Main()
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