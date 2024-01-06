using System;

// Using merge sort algorithm - Time: O(nlogn)

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
    private ListNode MergeTwoLists(ListNode a, ListNode b)
    {
        // a = lists[i], b = lists[i + step]
        
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
        int n = lists.Length;
        for (int step = 1; step < n; step <<= 1)
        {
            for (int i = 0; i < n - step; i += step << 1)
            {
                lists[i] = MergeTwoLists(lists[i], lists[i + step]);
            }
        }

        return lists[0];
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
        ListNode list1 = new ListNode(1, new ListNode(4, new ListNode(5)));
        ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(6)));
        ListNode list3 = new ListNode(2, new ListNode(7, new ListNode(8)));

        ListNode[] lists = { list1, list2, list3 };

        Console.Write("Input: lists = [");
        for (int i = 0; i < lists.Length; i++)
        {
            PrintList(lists[i]);
            if (i < lists.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        Solution sol = new Solution();
        ListNode mergedList = sol.MergeKLists(lists);

        Console.Write("Output: ");
        PrintList(mergedList);
        Console.WriteLine();
    }
}