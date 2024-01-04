using System;

// Using recursion - Time: O(n)

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

// Using iteration - Time: O(n)

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
    static void Main(string[] args)
    {
        ListNode list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));

        Console.Write("Input: head = ");
        PrintList(list);
        Console.WriteLine();

        Solution sol = new Solution();
        ListNode reversedList = sol.ReverseList(list);

        Console.Write("Output: ");
        PrintList(reversedList);
        Console.WriteLine();
    }
}
