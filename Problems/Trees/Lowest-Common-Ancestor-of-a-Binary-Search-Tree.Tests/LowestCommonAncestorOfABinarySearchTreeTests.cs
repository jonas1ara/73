public class LowestCommonAncestorOfABinarySearchTreeTests
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

    private static TreeNode? Find(TreeNode? root, int val)
    {
        if (root == null)
            return null;
        if (root.val == val)
            return root;
        return Find(root.left, val) ?? Find(root.right, val);
    }

    [Fact]
    public void LowestCommonAncestor_NodesSplitAtRoot_ReturnsRoot()
    {
        var root = BuildTree(new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 });
        var sol = new Solution();

        var result = sol.LowestCommonAncestor(root, Find(root, 2), Find(root, 8));

        Assert.Equal(6, result.val);
    }

    [Fact]
    public void LowestCommonAncestor_OneNodeIsAncestorOfOther_ReturnsThatNode()
    {
        var root = BuildTree(new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 });
        var sol = new Solution();

        var result = sol.LowestCommonAncestor(root, Find(root, 2), Find(root, 4));

        Assert.Equal(2, result.val);
    }

    [Fact]
    public void LowestCommonAncestor_TwoNodeTree_ReturnsRoot()
    {
        var root = BuildTree(new int?[] { 1, 0 });
        var sol = new Solution();

        var result = sol.LowestCommonAncestor(root, Find(root, 1), Find(root, 0));

        Assert.Equal(1, result.val);
    }
}
