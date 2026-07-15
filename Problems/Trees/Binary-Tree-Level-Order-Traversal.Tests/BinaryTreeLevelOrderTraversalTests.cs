public class BinaryTreeLevelOrderTraversalTests
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
    public void LevelOrder_BalancedTree_ReturnsLevels()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { 3, 9, 20, null, null, 15, 7 });

        var result = sol.LevelOrder(root!);

        Assert.Equal(new IList<int>[] { new List<int> { 3 }, new List<int> { 9, 20 }, new List<int> { 15, 7 } }, result);
    }

    [Fact]
    public void LevelOrder_SingleNode_ReturnsSingleLevel()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { 1 });

        var result = sol.LevelOrder(root!);

        Assert.Equal(new IList<int>[] { new List<int> { 1 } }, result);
    }

    [Fact]
    public void LevelOrder_EmptyTree_ReturnsEmptyList()
    {
        var sol = new Solution();

        var result = sol.LevelOrder(null!);

        Assert.Empty(result);
    }

    [Fact]
    public void LevelOrder_UnbalancedTree_ReturnsCorrectLevels()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { 1, 2, null, 3, null, 4, null });

        var result = sol.LevelOrder(root!);

        Assert.Equal(new IList<int>[] { new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 } }, result);
    }
}
