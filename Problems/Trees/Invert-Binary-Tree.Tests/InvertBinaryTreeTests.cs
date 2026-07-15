public class InvertBinaryTreeTests
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
    public void InvertTree_BalancedTree_MirrorsAllLevels()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { 4, 2, 7, 1, 3, 6, 9 });

        var result = sol.InvertTree(root!);

        Assert.Equal(new int?[] { 4, 7, 2, 9, 6, 3, 1 }, ToLevelOrderArray(result));
    }

    [Fact]
    public void InvertTree_SmallTree_SwapsChildren()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { 2, 1, 3 });

        var result = sol.InvertTree(root!);

        Assert.Equal(new int?[] { 2, 3, 1 }, ToLevelOrderArray(result));
    }

    [Fact]
    public void InvertTree_EmptyTree_ReturnsNull()
    {
        var sol = new Solution();

        var result = sol.InvertTree(null!);

        Assert.Null(result);
    }

    [Fact]
    public void InvertTree_SingleNode_ReturnsSameNode()
    {
        var sol = new Solution();
        var root = BuildTree(new int?[] { 1 });

        var result = sol.InvertTree(root!);

        Assert.Equal(new int?[] { 1 }, ToLevelOrderArray(result));
    }
}
