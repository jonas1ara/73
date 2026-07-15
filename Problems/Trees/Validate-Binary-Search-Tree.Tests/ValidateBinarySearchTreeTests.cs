public class ValidateBinarySearchTreeTests
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
    public void IsValidBST_ValidExample_ReturnsTrue()
    {
        var root = BuildTree(new int?[] { 2, 1, 3 });
        var sol = new Solution();

        Assert.True(sol.IsValidBST(root));
    }

    [Fact]
    public void IsValidBST_RightSubtreeViolatesOrdering_ReturnsFalse()
    {
        var root = BuildTree(new int?[] { 5, 1, 4, null, null, 3, 6 });
        var sol = new Solution();

        Assert.False(sol.IsValidBST(root));
    }

    [Fact]
    public void IsValidBST_EmptyTree_ReturnsTrue()
    {
        var sol = new Solution();

        Assert.True(sol.IsValidBST(null));
    }

    [Fact]
    public void IsValidBST_SingleNode_ReturnsTrue()
    {
        var root = new TreeNode(1);
        var sol = new Solution();

        Assert.True(sol.IsValidBST(root));
    }

    // Bug: `prev` is an instance field that is never reset, so reusing the same
    // Solution instance for a second, independently-valid tree can leak state
    // from the first call and produce a wrong result.
    [Fact]
    public void IsValidBST_ReusedSolutionInstanceOnSecondValidTree_ReturnsTrue()
    {
        var sol = new Solution();
        sol.IsValidBST(new TreeNode(5));

        var secondTree = BuildTree(new int?[] { 10, 1, 20 });

        Assert.True(sol.IsValidBST(secondTree));
    }
}
