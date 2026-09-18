using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode73.Core;

public static class CommonHelpers
{
    public const string ListNodeSource = @"
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
";

    public const string TreeNodeSource = @"
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
";

    public const string NodeSource = @"
public class Node
{
    public int val;
    public System.Collections.Generic.IList<Node> neighbors;
    public Node()
    {
        val = 0;
        neighbors = new System.Collections.Generic.List<Node>();
    }
    public Node(int _val)
    {
        val = _val;
        neighbors = new System.Collections.Generic.List<Node>();
    }
    public Node(int _val, System.Collections.Generic.List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}
";

    public const string IntervalSource = @"
public class Interval
{
    public int start, end;
    public Interval(int start = 0, int end = 0)
    {
        this.start = start;
        this.end = end;
    }
}
";

    public const string TrieNodeSource = @"
public class TrieNode
{
    public bool isWord;
    public TrieNode[] children = new TrieNode[26];
}
";

    public static string FormatValue(object? value)
    {
        if (value == null) return "null";

        if (value is string s)
            return $"\"{s}\"";

        if (value is bool b)
            return b ? "true" : "false";

        if (value is char c)
            return $"'{c}'";

        // Array or list
        if (value is IEnumerable enumerable and not string)
        {
            var items = new List<string>();
            foreach (var item in enumerable)
            {
                items.Add(FormatValue(item));
            }
            return "[" + string.Join(", ", items) + "]";
        }

        // Try reflection for ListNode if needed
        var type = value.GetType();
        if (type.Name == "ListNode")
        {
            var values = new List<string>();
            object? curr = value;
            int count = 0;
            while (curr != null && count++ < 50)
            {
                var valField = curr.GetType().GetField("val");
                var nextField = curr.GetType().GetField("next");
                values.Add(valField?.GetValue(curr)?.ToString() ?? "null");
                curr = nextField?.GetValue(curr);
            }
            if (count >= 50) values.Add("...");
            return "[" + string.Join(", ", values) + "]";
        }

        // Try reflection for TreeNode if needed
        if (type.Name == "TreeNode")
        {
            var values = new List<string>();
            var queue = new Queue<object?>();
            queue.Enqueue(value);
            while (queue.Count > 0 && values.Count < 50)
            {
                var node = queue.Dequeue();
                if (node == null)
                {
                    values.Add("null");
                    continue;
                }
                var valField = node.GetType().GetField("val");
                var leftField = node.GetType().GetField("left");
                var rightField = node.GetType().GetField("right");
                values.Add(valField?.GetValue(node)?.ToString() ?? "null");
                queue.Enqueue(leftField?.GetValue(node));
                queue.Enqueue(rightField?.GetValue(node));
            }
            while (values.Count > 0 && values[^1] == "null")
                values.RemoveAt(values.Count - 1);
            return "[" + string.Join(", ", values) + "]";
        }

        return value.ToString() ?? "null";
    }
}
