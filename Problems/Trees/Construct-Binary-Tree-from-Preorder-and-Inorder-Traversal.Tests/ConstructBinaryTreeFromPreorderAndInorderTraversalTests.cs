public class ConstructBinaryTreeFromPreorderAndInorderTraversalTests
{
    private static int?[] ToLevelOrderArray(TreeNode? root)
    {
        var values = new List<int?>();
        var queue = new Queue<TreeNode?>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node == null)
            {
                values.Add(null);
                continue;
            }

            values.Add(node.val);
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        while (values.Count > 0 && values[^1] == null)
            values.RemoveAt(values.Count - 1);

        return values.ToArray();
    }

    [Fact]
    public void BuildTree_StandardCase_ReconstructsTree()
    {
        var sol = new Solution();

        var result = sol.BuildTree(new[] { 3, 9, 20, 15, 7 }, new[] { 9, 3, 15, 20, 7 });

        Assert.Equal(new int?[] { 3, 9, 20, null, null, 15, 7 }, ToLevelOrderArray(result));
    }

    [Fact]
    public void BuildTree_SingleNode_ReturnsSingleNode()
    {
        var sol = new Solution();

        var result = sol.BuildTree(new[] { -1 }, new[] { -1 });

        Assert.Equal(new int?[] { -1 }, ToLevelOrderArray(result));
    }

    [Fact]
    public void BuildTree_LeftSkewedTree_ReconstructsTree()
    {
        var sol = new Solution();

        var result = sol.BuildTree(new[] { 3, 2, 1 }, new[] { 1, 2, 3 });

        Assert.Equal(new int?[] { 3, 2, null, 1 }, ToLevelOrderArray(result));
    }

    [Fact]
    public void BuildTree_EmptyArrays_ReturnsNull()
    {
        var sol = new Solution();

        var result = sol.BuildTree(Array.Empty<int>(), Array.Empty<int>());

        Assert.Null(result);
    }
}
