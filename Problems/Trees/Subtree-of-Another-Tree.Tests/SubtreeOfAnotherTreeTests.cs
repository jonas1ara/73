public class SubtreeOfAnotherTreeTests
{
    private static TreeNode? BuildTree(int?[] values)
    {
        if (values.Length == 0 || values[0] == null)
            return null;

        var root = new TreeNode(values[0]!.Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int i = 1;

        while (queue.Count > 0 && i < values.Length)
        {
            var node = queue.Dequeue();

            if (i < values.Length)
            {
                var leftVal = values[i++];
                if (leftVal != null)
                {
                    node.left = new TreeNode(leftVal.Value);
                    queue.Enqueue(node.left);
                }
            }

            if (i < values.Length)
            {
                var rightVal = values[i++];
                if (rightVal != null)
                {
                    node.right = new TreeNode(rightVal.Value);
                    queue.Enqueue(node.right);
                }
            }
        }

        return root;
    }

    [Fact]
    public void IsSubtree_MatchingSubtree_ReturnsTrue()
    {
        var root = BuildTree(new int?[] { 3, 4, 5, 1, 2 });
        var subRoot = BuildTree(new int?[] { 4, 1, 2 });
        var sol = new Solution();

        Assert.True(sol.IsSubtree(root, subRoot));
    }

    [Fact]
    public void IsSubtree_SameValuesButExtraNode_ReturnsFalse()
    {
        var root = BuildTree(new int?[] { 3, 4, 5, 1, 2, null, null, null, null, 0 });
        var subRoot = BuildTree(new int?[] { 4, 1, 2 });
        var sol = new Solution();

        Assert.False(sol.IsSubtree(root, subRoot));
    }

    [Fact]
    public void IsSubtree_NullSubRoot_ReturnsTrue()
    {
        var root = BuildTree(new int?[] { 1, 2, 3 });
        var sol = new Solution();

        Assert.True(sol.IsSubtree(root, null));
    }

    [Fact]
    public void IsSubtree_NullRootAndNonNullSubRoot_ReturnsFalse()
    {
        var subRoot = new TreeNode(1);
        var sol = new Solution();

        Assert.False(sol.IsSubtree(null, subRoot));
    }
}
