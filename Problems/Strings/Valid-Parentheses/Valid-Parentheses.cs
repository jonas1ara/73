using System;
using System.Collections.Generic;

// Using a stack - Time O(n)
public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            else if (stack.Count == 0 || (c == ')' && stack.Peek() != '(') || (c == '}' && stack.Peek() != '{')
                || (c == ']' && stack.Peek() != '['))
            {
                return false;
            }
            else
            {
                stack.Pop();
            }
        }
        return stack.Count == 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string input = "({[()]})"; 
        Console.WriteLine("Input: s =" + input);

        Solution sol = new Solution();
        bool isValid = sol.IsValid(input);

        Console.WriteLine("Output: " + isValid);
    }
}
