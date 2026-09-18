using System;

namespace LeetCode73.Commands;

public static class BenchCommand
{
    public static int Execute(string? target, int iterations = 1000)
    {
        return TestCommand.Execute(target, timeoutMs: 5000, benchmark: true, iterations: iterations);
    }
}
