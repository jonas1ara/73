using System.Collections.Generic;
using System.Linq;
using LeetCode73.Core;

namespace LeetCode73.Runner;

public enum TestVerdict
{
    Accepted,
    WrongAnswer,
    CompileError,
    RuntimeError,
    TimeLimitExceeded
}

public record CompilationDiagnostic(
    int Line,
    int Column,
    string Code,
    string Message,
    string Severity);

public record TestCaseResult(
    int Index,
    string TestName,
    string InputDisplay,
    string ExpectedDisplay,
    string ActualDisplay,
    bool Passed,
    double ElapsedMs,
    string? ErrorMessage,
    TestVerdict Verdict);

public class TestExecutionResult
{
    public required Problem Problem { get; set; }
    public string? FilePath { get; set; }
    public bool Compiled { get; set; }
    public double CompilationMs { get; set; }
    public List<CompilationDiagnostic> CompilationDiagnostics { get; set; } = new();
    public List<TestCaseResult> TestCases { get; set; } = new();
    public double TotalExecutionMs { get; set; }
    public TestVerdict OverallVerdict { get; set; }

    public int PassedCount => TestCases.Count(t => t.Passed);
    public int TotalCount => TestCases.Count;
}
