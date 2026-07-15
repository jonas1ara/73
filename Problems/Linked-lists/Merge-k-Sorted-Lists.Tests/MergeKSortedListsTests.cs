public class MergeKSortedListsTests
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

    [Fact]
    public void MergeKLists_ThreeSortedLists_MergesAscending()
    {
        var sol = new Solution();
        var lists = new[]
        {
            BuildList(new[] { 1, 4, 5 }),
            BuildList(new[] { 1, 3, 4 }),
            BuildList(new[] { 2, 6 }),
        };

        var result = sol.MergeKLists(lists);

        Assert.Equal(new[] { 1, 1, 2, 3, 4, 4, 5, 6 }, ToArray(result));
    }

    [Fact]
    public void MergeKLists_EmptyArray_ReturnsNull()
    {
        var sol = new Solution();

        var result = sol.MergeKLists(Array.Empty<ListNode>());

        Assert.Null(result);
    }

    [Fact]
    public void MergeKLists_ArrayWithNullList_ReturnsNull()
    {
        var sol = new Solution();
        ListNode?[] lists = { null };

        var result = sol.MergeKLists(lists!);

        Assert.Null(result);
    }

    [Fact]
    public void MergeKLists_NullInput_ReturnsNull()
    {
        var sol = new Solution();

        var result = sol.MergeKLists(null!);

        Assert.Null(result);
    }

    [Fact]
    public void MergeKLists_SingleList_ReturnsSameOrder()
    {
        var sol = new Solution();
        var lists = new[] { BuildList(new[] { 1, 2, 3 }) };

        var result = sol.MergeKLists(lists);

        Assert.Equal(new[] { 1, 2, 3 }, ToArray(result));
    }

    [Fact]
    public void MergeKLists_OddNumberOfLists_MergesAscending()
    {
        var sol = new Solution();
        var lists = new[]
        {
            BuildList(new[] { 1, 10 }),
            BuildList(new[] { 2, 9 }),
            BuildList(new[] { 3, 8 }),
            BuildList(new[] { 4, 7 }),
            BuildList(new[] { 5, 6 }),
        };

        var result = sol.MergeKLists(lists);

        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, ToArray(result));
    }
}
