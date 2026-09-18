# 73 CLI

The interactive command-line companion to practice, test, and master the 73 most useful LeetCode problems in C# with zero boilerplate, instant feedback, and comparative benchmarking.

---

## Features

- **Zero Boilerplate:** Write only `public class Solution { ... }` (the exact LeetCode snippet). No `.csproj`, no `Program.cs`, no `Main()`.
- **In-Memory Roslyn Execution (< 100 ms):** Code is compiled dynamically in memory using `Microsoft.CodeAnalysis.CSharp` for instant feedback.
- **Smart Problem Resolver:** Automatically detects which problem you are testing by directory location, fuzzy filename (`two.cs`), or AST method signature inspection (`TwoSum(...)`).
- **Target Complexity Display:** Displays theoretical Big-O targets (`O(N) Time | O(N) Space`) in execution headers and problem info.
- **Comparative Benchmarking & Scalability Analysis:** `73 bench <problem>` tests your solution against the optimal reference solution across 1,000 iterations and large-scale stress tests ($N \ge 10,000$).
- **Rich Terminal UI:** Clear panels, progress indicators, comparative diff tables, and benchmark matrices powered by `Spectre.Console`.
- **100% Self-Contained:** All 76 problem test suites, templates, and problem notes are embedded directly into the DLL.

---

## Installation

Install globally as a .NET Tool from [NuGet](https://www.nuget.org/packages/73):

```bash
dotnet tool install -g 73
```

To update to the latest version:

```bash
dotnet tool update -g 73
```

> **Note for Windows PowerShell:** Because bare numbers are parsed as integer literals, invoke the tool as `73.exe` (e.g. `73.exe two.cs`) or `& 73`. In CMD, Git Bash, macOS, and Linux, you can run `73` directly.

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

Or run tests directly by problem name or number:

```bash
73 test 1
```

### 3. Benchmark against the optimal reference solution

Compare execution time, heap memory allocations, and scalability:

```bash
73 bench two.cs
```

Or with the test command:

```bash
73 test two.cs --bench
```

---

## Commands Reference

| Command | Description | Example |
| :--- | :--- | :--- |
| `73 <file.cs>` | Test your solution file (auto-detects problem by path, name, or AST method signature). | `73 two.cs` |
| `73 test [problem]` | Run tests for a problem by name, slug, or number. Use `--bench` to compare against reference. | `73 test Two-Sum --bench` |
| `73 bench [problem]` | Benchmark and compare your solution against the optimal reference solution with scalability stress tests. | `73 bench Two-Sum` |
| `73 new <problem>` | Create a clean boilerplate file ready to code. | `73 new two-sum` |
| `73 list [category]` | List all 76 problems categorized by topic with difficulty and target complexity. | `73 list trees` |
| `73 info <problem>` | View problem description, examples, constraints, and algorithmic trade-offs directly in terminal. | `73 info two-sum` |

---

## License

This project is licensed under the [MIT License](https://github.com/jonas1ara/73/blob/main/LICENSE).
