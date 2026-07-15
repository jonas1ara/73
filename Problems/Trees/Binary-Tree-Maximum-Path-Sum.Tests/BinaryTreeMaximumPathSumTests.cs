public class BinaryTreeMaximumPathSumTests
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
    public void MaxPathSum_SimpleTree_ReturnsSumThroughRoot()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { 1, 2, 3 });

        var result = sol.MaxPathSum(root!);

        Assert.Equal(6, result);
    }

    [Fact]
    public void MaxPathSum_WithNegativeRoot_IgnoresRoot()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { -10, 9, 20, null, null, 15, 7 });

        var result = sol.MaxPathSum(root!);

        Assert.Equal(42, result);
    }

    [Fact]
    public void MaxPathSum_SingleNode_ReturnsNodeValue()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { 5 });

        var result = sol.MaxPathSum(root!);

        Assert.Equal(5, result);
    }

    [Fact]
    public void MaxPathSum_AllNegativeValues_ReturnsLeastNegative()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { -3, -2, -1 });

        var result = sol.MaxPathSum(root!);

        Assert.Equal(-1, result);
    }
}
