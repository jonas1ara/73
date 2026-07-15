public class SerializeAndDeserializeBinaryTreeTests
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

    private static bool AreEqual(TreeNode? a, TreeNode? b)
    {
        if (a == null && b == null)
            return true;
        if (a == null || b == null)
            return false;
        return a.val == b.val && AreEqual(a.left, b.left) && AreEqual(a.right, b.right);
    }

    [Fact]
    public void SerializeDeserialize_TwoLevelExample_RoundTripsToSameTree()
    {
        var root = BuildTree(new int?[] { 1, 2, 3, null, null, 4, 5 });
        var codec = new Codec();

        var result = codec.deserialize(codec.serialize(root));

        Assert.True(AreEqual(root, result));
    }

    [Fact]
    public void SerializeDeserialize_EmptyTree_RoundTripsToNull()
    {
        var codec = new Codec();

        var result = codec.deserialize(codec.serialize(null));

        Assert.Null(result);
    }

    [Fact]
    public void SerializeDeserialize_SingleNode_RoundTripsToSameTree()
    {
        var root = new TreeNode(42);
        var codec = new Codec();

        var result = codec.deserialize(codec.serialize(root));

        Assert.True(AreEqual(root, result));
    }
}
