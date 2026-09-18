# 73 CLI

The interactive command-line companion to practice, test, and master the 73 most useful LeetCode problems in C# with zero boilerplate and immediate feedback.

---

## Features

- **Zero Boilerplate:** Write only `public class Solution { ... }` (the exact LeetCode snippet). No `.csproj`, no `Program.cs`, no `Main()`.
- **In-Memory Roslyn Execution (< 100 ms):** Code is compiled dynamically in memory using `Microsoft.CodeAnalysis.CSharp` for instant feedback.
- **Rich Terminal UI:** Clear panels, progress indicators, and comparative diff tables powered by `Spectre.Console`.
- **Smart Problem Resolver:** Automatically detects which problem you are testing by directory location, fuzzy filename (`two.cs`), or AST method signature inspection (`TwoSum(...)`).
- **100% Self-Contained:** All 76 problem test suites, templates, and problem notes are embedded. Works in any directory.

---

## Installation

Install globally as a .NET Tool:

```bash
dotnet tool install -g 73
```

To update to the latest version:

```bash
dotnet tool update -g 73
```

---

## Quickstart

### 1. Generate a boilerplate solution

```bash
73 new two-sum
```

Creates `Two-Sum.cs` with the exact LeetCode method signature:

```csharp
using System;
using System.Collections.Generic;

// Problem: #0001 - Two Sum [Easy]
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        throw new NotImplementedException();
    }
}
```

### 2. Solve and test immediately

Run `73` pointing to your file:

```bash
73 Two-Sum.cs
```

Or run tests directly by problem name:

```bash
73 test Two-Sum
```

---

## Commands Reference

| Command | Description | Example |
| :--- | :--- | :--- |
| `73 <file.cs>` | Test your solution file (auto-detects problem by path, name, or AST method signature). | `73 two.cs` |
| `73 test [problem]` | Run tests for a problem by name, slug, or number. | `73 test Two-Sum` |
| `73 new <problem>` | Create a clean boilerplate file ready to code. | `73 new two-sum` |
| `73 list [category]` | List all 76 problems categorized by topic with difficulty and method names. | `73 list trees` |
| `73 info <problem>` | View problem description, examples, and constraints directly in terminal. | `73 info two-sum` |

---

## License

This project is licensed under the [MIT License](https://github.com/jonas1ara/73/blob/main/LICENSE).
