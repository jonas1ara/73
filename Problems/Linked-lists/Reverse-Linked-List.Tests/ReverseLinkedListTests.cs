public class ReverseLinkedListTests
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
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 1, 2 }, new int[] { 2, 1 })]
    [InlineData(new int[] { 1 }, new int[] { 1 })]
    public void ReverseList_ReversesNodeOrder(int[] input, int[] expected)
    {
        var sol = new Solution();
        var head = BuildList(input);

        var result = sol.ReverseList(head);

        Assert.Equal(expected, ToArray(result));
    }

    [Fact]
    public void ReverseList_EmptyList_ReturnsNull()
    {
        var sol = new Solution();

        var result = sol.ReverseList(null);

        Assert.Null(result);
    }
}
