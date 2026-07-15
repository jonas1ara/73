public class MergeTwoSortedListsTests
{
    private static ListNode? BuildList(int[] values)
    {
        ListNode? head = null;
        ListNode? tail = null;

        foreach (var v in values)
        {
            var node = new ListNode(v);
            if (head == null)
            {
                head = node;
            }
            else
            {
                tail!.next = node;
            }
            tail = node;
        }

        return head;
    }

    private static int[] ToArray(ListNode? head)
    {
        var values = new List<int>();
        while (head != null)
        {
            values.Add(head.val);
            head = head.next;
        }
        return values.ToArray();
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 })]
    [InlineData(new int[] { }, new int[] { }, new int[] { })]
    [InlineData(new int[] { }, new int[] { 0 }, new int[] { 0 })]
    [InlineData(new int[] { 5 }, new int[] { }, new int[] { 5 })]
    [InlineData(new int[] { 1, 3, 5 }, new int[] { 2, 4, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
    public void MergeTwoLists_MergesInAscendingOrder(int[] a, int[] b, int[] expected)
    {
        var sol = new Solution();
        var list1 = BuildList(a);
        var list2 = BuildList(b);

        var result = sol.MergeTwoLists(list1, list2);

        Assert.Equal(expected, ToArray(result));
    }
}
