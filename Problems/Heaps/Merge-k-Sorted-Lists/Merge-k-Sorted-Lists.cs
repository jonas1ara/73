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
**/

public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        var dummy = new ListNode(0);
        var tail = dummy;

        var pq = new PriorityQueue<ListNode, int>(lists.Where(x => x != null).Select(x => (x, x.val)));

        while (pq.Count > 0)
        {
            var node = pq.Dequeue();

            if (node.next != null)
            {
                pq.Enqueue(node.next, node.next.val);
            }

            tail.next = node;
            tail = node;
        }

        return dummy.next;
    }
}
