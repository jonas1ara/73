public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}


public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
            return null;

        Swap(ref root.left, ref root.right);
        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }

    private void Swap<T>(ref T x, ref T y)
    {
        T temp = x;
        x = y;
        y = temp;
    }
}

class Program
{
    static void Main()
    {
        // Crear un árbol de ejemplo
        TreeNode root = new TreeNode(1,
            new TreeNode(2, new TreeNode(4), new TreeNode(5)),
            new TreeNode(3, new TreeNode(6), new TreeNode(7)));

        // Mostrar el árbol original
        Console.WriteLine("Árbol original:");
        PrintTree(root);

        // Invertir el árbol
        Solution solution = new Solution();
        TreeNode invertedRoot = solution.InvertTree(root);

        // Mostrar el árbol invertido
        Console.WriteLine("\nÁrbol invertido:");
        PrintTree(invertedRoot);
    }

    static void PrintTree(TreeNode root)
    {
        if (root == null)
            return;

        PrintTree(root.left);
        Console.Write(root.val + " ");
        PrintTree(root.right);
    }
}
