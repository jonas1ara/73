public class MaximumDepthOfBinaryTreeTests
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
    public void MaxDepth_BalancedShapeExample_ReturnsThree()
    {
        var root = BuildTree(new int?[] { 3, 9, 20, null, null, 15, 7 });
        var sol = new Solution();

        Assert.Equal(3, sol.MaxDepth(root));
    }

    [Fact]
    public void MaxDepth_RightSkewedExample_ReturnsTwo()
    {
        var root = BuildTree(new int?[] { 1, null, 2 });
        var sol = new Solution();

        Assert.Equal(2, sol.MaxDepth(root));
    }

    [Fact]
    public void MaxDepth_EmptyTree_ReturnsZero()
    {
        var sol = new Solution();

        Assert.Equal(0, sol.MaxDepth(null));
    }

    [Fact]
    public void MaxDepth_SingleNode_ReturnsOne()
    {
        var root = new TreeNode(1);
        var sol = new Solution();

        Assert.Equal(1, sol.MaxDepth(root));
    }
}
