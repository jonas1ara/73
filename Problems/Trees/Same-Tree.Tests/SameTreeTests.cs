public class SameTreeTests
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
    public void IsSameTree_IdenticalTrees_ReturnsTrue()
    {
        var p = BuildTree(new int?[] { 1, 2, 3 });
        var q = BuildTree(new int?[] { 1, 2, 3 });
        var sol = new Solution();

        Assert.True(sol.IsSameTree(p, q));
    }

    [Fact]
    public void IsSameTree_DifferentShape_ReturnsFalse()
    {
        var p = BuildTree(new int?[] { 1, 2 });
        var q = BuildTree(new int?[] { 1, null, 2 });
        var sol = new Solution();

        Assert.False(sol.IsSameTree(p, q));
    }

    [Fact]
    public void IsSameTree_DifferentValues_ReturnsFalse()
    {
        var p = BuildTree(new int?[] { 1, 2, 1 });
        var q = BuildTree(new int?[] { 1, 1, 2 });
        var sol = new Solution();

        Assert.False(sol.IsSameTree(p, q));
    }

    [Fact]
    public void IsSameTree_BothNull_ReturnsTrue()
    {
        var sol = new Solution();

        Assert.True(sol.IsSameTree(null, null));
    }
}
