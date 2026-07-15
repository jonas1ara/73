public class RemoveNthNodeFromEndOfListTests
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
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 3, 5 })]
    [InlineData(new int[] { 1 }, 1, new int[] { })]
    [InlineData(new int[] { 1, 2 }, 1, new int[] { 1 })]
    [InlineData(new int[] { 1, 2 }, 2, new int[] { 2 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 2, 3, 4, 5 })]
    public void RemoveNthFromEnd_RemovesCorrectNode(int[] input, int n, int[] expected)
    {
        var sol = new Solution();
        var head = BuildList(input);

        var result = sol.RemoveNthFromEnd(head, n);

        Assert.Equal(expected, ToArray(result));
    }
}
