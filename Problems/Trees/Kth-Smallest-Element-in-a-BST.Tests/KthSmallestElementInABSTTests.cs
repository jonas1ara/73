public class KthSmallestElementInABSTTests
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
    public void KthSmallest_FirstExample_ReturnsSmallestValue()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { 3, 1, 4, null, 2 });

        var result = sol.KthSmallest(root!, 1);

        Assert.Equal(1, result);
    }

    [Fact]
    public void KthSmallest_SecondExample_ReturnsThirdSmallestValue()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });

        var result = sol.KthSmallest(root!, 3);

        Assert.Equal(3, result);
    }

    [Fact]
    public void KthSmallest_SingleNode_ReturnsNodeValue()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { 1 });

        var result = sol.KthSmallest(root!, 1);

        Assert.Equal(1, result);
    }

    [Fact]
    public void KthSmallest_LastElement_ReturnsLargestValue()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });

        var result = sol.KthSmallest(root!, 6);

        Assert.Equal(6, result);
    }
}
