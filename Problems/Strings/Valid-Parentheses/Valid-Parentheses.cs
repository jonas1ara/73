using System;
using System.Collections.Generic;

public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s) {
            if (c == '(' || c == '{' || c == '[') {
                stack.Push(c);
            } else if (stack.Count == 0 || (c == ')' && stack.Peek() != '(') || (c == '}' && stack.Peek() != '{')
                || (c == ']' && stack.Peek() != '[')) {
                return false;
            } else {
                stack.Pop();
            }
        }
        return stack.Count == 0;
    }

    public static void Main(string[] args) {
        Solution solution = new Solution();
        string input = "({[()]})"; // Cambia la cadena de entrada según tus necesidades

        bool isValid = solution.IsValid(input);

        if (isValid) {
            Console.WriteLine("La cadena es válida.");
        } else {
            Console.WriteLine("La cadena no es válida.");
        }
    }
}
