using System;
using System.Collections.Generic;

bool IsValid(string s)
{
    var stack = new Stack<char>();
    foreach (var ch in s)
    {
        if (ch == '(' || ch == '[' || ch == '{')
            stack.Push(ch);
        else if (ch == ')' || ch == ']' || ch == '}')
        {
            if (stack.Count <= 0) return false;
            var lastCh = stack.Peek();

            if ((ch == ')' && lastCh == '(') ||
                (ch == ']' && lastCh == '[') ||
                (ch == '}' && lastCh == '{'))
                stack.Pop();
            else
                return false;
        }
    }

    return stack.Count == 0;
}


string s = "()[]{}";
Console.WriteLine("Input: " + s);

Console.WriteLine(IsValid(s));