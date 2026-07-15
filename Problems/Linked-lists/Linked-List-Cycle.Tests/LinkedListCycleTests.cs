public class LinkedListCycleTests
{
    private static ListNode? BuildList(int[] values, int pos = -1)
    {
        ListNode? head = null;
        ListNode? tail = null;
        var nodes = new List<ListNode>();

        foreach (var v in values)
        {
            var node = new ListNode(v);
            nodes.Add(node);
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

        if (pos >= 0 && nodes.Count > 0)
        {
            tail!.next = nodes[pos];
        }

        return head;
    }

    [Fact]
    public void HasCycle_TailConnectsToFirstNode_ReturnsTrue()
    {
        var sol = new Solution();
        var head = BuildList(new[] { 3, 2, 0, -4 }, pos: 1);

        Assert.True(sol.HasCycle(head));
    }

    [Fact]
    public void HasCycle_TwoNodesCycleToHead_ReturnsTrue()
    {
        var sol = new Solution();
        var head = BuildList(new[] { 1, 2 }, pos: 0);

        Assert.True(sol.HasCycle(head));
    }

    [Fact]
    public void HasCycle_SingleNodeNoCycle_ReturnsFalse()
    {
        var sol = new Solution();
        var head = BuildList(new[] { 1 });

        Assert.False(sol.HasCycle(head));
    }

    [Fact]
    public void HasCycle_LinearListNoCycle_ReturnsFalse()
    {
        var sol = new Solution();
        var head = BuildList(new[] { 1, 2, 3, 4, 5 });

        Assert.False(sol.HasCycle(head));
    }

    [Fact]
    public void HasCycle_EmptyList_ReturnsFalse()
    {
        var sol = new Solution();

        Assert.False(sol.HasCycle(null));
    }
}
