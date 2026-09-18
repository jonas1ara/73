using System;
using LeetCode73.Core;

namespace LeetCode73.Runner;

public record BenchmarkItemResult(
    string Name,
    string SourceDescription,
    string TimeComplexity,
    string SpaceComplexity,
    double ElapsedMicroseconds,
    long AllocatedBytes,
    double? LargeScaleElapsedMs = null,
    bool Passed = true,
    string? Error = null);

public record BenchmarkReport(
    Problem Problem,
    BenchmarkItemResult UserResult,
    BenchmarkItemResult ReferenceResult,
    int Iterations,
    string SummaryNote);
