# Valid Parentheses:

This directory contains an implementation of the "Valid Parentheses" problem in C#. The implementation uses a stack to validate bracket matching and maintain a temporal complexity of `O(n)`.

## Problem description

Given a string `s` containing just the characters `'('`, `')'`, `'{'`, `'}'`, `'['` and `']'`, determine if the input string is valid.

An input string is valid if:

1. Open brackets must be closed by the same type of brackets.
2. Open brackets must be closed in the correct order.
3. Every close bracket has a corresponding open bracket of the same type.

- Example 1:

```
Input: s = "()"
Output: true
```

- Example 2:

```
Input: s = "()[]{}"
Output: true
```

- Example 3:

```
Input: s = "(]"
Output: false
```

## Solution:

A stack is the natural structure for nested matching:

1. Push every opening bracket onto the stack
2. For a closing bracket, the top of the stack must be the matching opening bracket; then pop it
3. If the stack is empty when a closer appears, or types do not match, return `false`
4. At the end the stack must be empty

Let's go through `s = "({[()]})"`:

1. Push `(`, `{`, `[`
2. See `(` → push
3. See `)` → matches top `(` → pop
4. See `]` → matches top `[` → pop
5. See `}` → matches top `{` → pop
6. See `)` → matches top `(` → pop
7. Stack empty → `true`

## Implementations:

### C# :

```csharp
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
```

1. `public class Solution` : Define a public class called `Solution`.

2. `public bool IsValid(string s)` : Define a public method that returns whether the bracket string is valid.

3. `Stack<char> stack = new Stack<char>();` : Create an empty stack for opening brackets.

4. Push opening brackets as they appear.

5. For closing brackets: reject if the stack is empty or the top does not match; otherwise pop.

6. `return stack.Count == 0;` : Valid only if every opening bracket was closed.
