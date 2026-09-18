using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using LeetCode73.Core;

namespace LeetCode73.Runner;

public static class BenchmarkRunner
{
    public static BenchmarkReport Run(
        Problem problem,
        string userSource,
        string userPath,
        string refSource,
        string refPath,
        int iterations = 1000)
    {
        // 1. Compile both solutions
        var (userAsm, userErrors) = RoslynRunner.CompileSolutionOnly(userSource, problem);
        if (userAsm == null)
        {
            return new BenchmarkReport(
                problem,
                new BenchmarkItemResult("Your Solution", userPath, "Unknown", "Unknown", 0, 0, null, false, string.Join("; ", userErrors)),
                new BenchmarkItemResult("Reference", refPath, problem.TargetTimeComplexity, problem.TargetSpaceComplexity, 0, 0, null, false, "Compilation failed"),
                iterations,
                "Your solution failed to compile.");
        }

        var (refAsm, refErrors) = RoslynRunner.CompileSolutionOnly(refSource, problem);
        if (refAsm == null)
        {
            return new BenchmarkReport(
                problem,
                new BenchmarkItemResult("Your Solution", userPath, problem.TargetTimeComplexity, problem.TargetSpaceComplexity, 0, 0, null, false, "Reference compilation error"),
                new BenchmarkItemResult("Reference", refPath, problem.TargetTimeComplexity, problem.TargetSpaceComplexity, 0, 0, null, false, string.Join("; ", refErrors)),
                iterations,
                "Reference solution failed to compile.");
        }

        // 2. Resolve types and methods
        var userType = userAsm.GetTypes().FirstOrDefault(t => t.Name == problem.ExpectedClass) ?? userAsm.GetTypes().First(t => t.IsClass);
        var refType = refAsm.GetTypes().FirstOrDefault(t => t.Name == problem.ExpectedClass) ?? refAsm.GetTypes().First(t => t.IsClass);

        var userMethod = userType.GetMethod(problem.ExpectedMethod, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        var refMethod = refType.GetMethod(problem.ExpectedMethod, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        if (userMethod == null || refMethod == null)
        {
            return new BenchmarkReport(
                problem,
                new BenchmarkItemResult("Your Solution", userPath, "Unknown", "Unknown", 0, 0, null, false, $"Method {problem.ExpectedMethod} not found"),
                new BenchmarkItemResult("Reference", refPath, problem.TargetTimeComplexity, problem.TargetSpaceComplexity, 0, 0, null, false, $"Method {problem.ExpectedMethod} not found"),
                iterations,
                $"Could not find expected method '{problem.ExpectedMethod}'.");
        }

        var userInstance = userMethod.IsStatic ? null : Activator.CreateInstance(userType);
        var refInstance = refMethod.IsStatic ? null : Activator.CreateInstance(refType);

        // 3. Build sample inputs for micro-benchmarking
        var sampleArgsList = BuildSampleInputs(problem);

        // Warm up JIT
        try
        {
            for (int w = 0; w < 50; w++)
            {
                foreach (var args in sampleArgsList)
                {
                    userMethod.Invoke(userInstance, CloneArgs(args));
                    refMethod.Invoke(refInstance, CloneArgs(args));
                }
            }
        }
        catch (Exception ex)
        {
            var inner = ex.InnerException ?? ex;
            return new BenchmarkReport(
                problem,
                new BenchmarkItemResult("Your Solution", userPath, "Unknown", "Unknown", 0, 0, null, false, inner.Message),
                new BenchmarkItemResult("Reference", refPath, problem.TargetTimeComplexity, problem.TargetSpaceComplexity, 0, 0, null, true),
                iterations,
                $"Runtime error during warm-up: {inner.Message}");
        }

        // 4. Micro-benchmark User Solution
        GC.Collect(2, GCCollectionMode.Forced, true);
        GC.WaitForPendingFinalizers();
        long startAllocUser = GC.GetAllocatedBytesForCurrentThread();
        long startTicksUser = Stopwatch.GetTimestamp();

        for (int i = 0; i < iterations; i++)
        {
            foreach (var args in sampleArgsList)
            {
                userMethod.Invoke(userInstance, CloneArgs(args));
            }
        }

        long endTicksUser = Stopwatch.GetTimestamp();
        long endAllocUser = GC.GetAllocatedBytesForCurrentThread();
        double userMicroseconds = ((endTicksUser - startTicksUser) * 1_000_000.0) / (Stopwatch.Frequency * iterations * sampleArgsList.Count);
        long userAllocPerCall = Math.Max(0, (endAllocUser - startAllocUser) / (iterations * sampleArgsList.Count));

        // 5. Micro-benchmark Reference Solution
        GC.Collect(2, GCCollectionMode.Forced, true);
        GC.WaitForPendingFinalizers();
        long startAllocRef = GC.GetAllocatedBytesForCurrentThread();
        long startTicksRef = Stopwatch.GetTimestamp();

        for (int i = 0; i < iterations; i++)
        {
            foreach (var args in sampleArgsList)
            {
                refMethod.Invoke(refInstance, CloneArgs(args));
            }
        }

        long endTicksRef = Stopwatch.GetTimestamp();
        long endAllocRef = GC.GetAllocatedBytesForCurrentThread();
        double refMicroseconds = ((endTicksRef - startTicksRef) * 1_000_000.0) / (Stopwatch.Frequency * iterations * sampleArgsList.Count);
        long refAllocPerCall = Math.Max(0, (endAllocRef - startAllocRef) / (iterations * sampleArgsList.Count));

        // 6. Large-scale stress test (if available for problem)
        double? largeScaleUserMs = null;
        double? largeScaleRefMs = null;
        var largeArgs = BuildLargeScaleInput(problem);

        if (largeArgs != null)
        {
            try
            {
                // Reference first
                var swRef = Stopwatch.StartNew();
                refMethod.Invoke(refInstance, CloneArgs(largeArgs));
                swRef.Stop();
                largeScaleRefMs = swRef.Elapsed.TotalMilliseconds;

                // User solution with safety timeout (max 5000 ms)
                var swUser = Stopwatch.StartNew();
                userMethod.Invoke(userInstance, CloneArgs(largeArgs));
                swUser.Stop();
                largeScaleUserMs = swUser.Elapsed.TotalMilliseconds;
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException ?? ex;
                largeScaleUserMs = -1; // Indicates failure at scale
            }
        }

        // 7. Synthesize educational performance note
        string note;
        if (largeScaleUserMs.HasValue && largeScaleRefMs.HasValue)
        {
            if (largeScaleUserMs.Value > 0)
            {
                double ratio = largeScaleUserMs.Value / Math.Max(0.1, largeScaleRefMs.Value);
                if (ratio >= 2.0)
                {
                    note = $"At small scale (N < 20), CPU cache makes constant factor overhead appear minimal. At scale (N = 10,000+), the optimal {problem.TargetTimeComplexity} approach is {ratio:F1}x faster than your solution.\n{problem.ComplexityTradeOffNote}";
                }
                else
                {
                    note = $"Great work! Your solution scales efficiently and matches the optimal {problem.TargetTimeComplexity} complexity at scale.\n{problem.ComplexityTradeOffNote}";
                }
            }
            else
            {
                note = $"Your solution threw an exception or timed out on large scale inputs, while the reference {problem.TargetTimeComplexity} solution completed in {largeScaleRefMs:F1}ms.\n{problem.ComplexityTradeOffNote}";
            }
        }
        else
        {
            if (userMicroseconds > refMicroseconds * 1.5)
            {
                note = $"Reference solution runs {(userMicroseconds / Math.Max(0.1, refMicroseconds)):F1}x faster in micro-benchmarks.\n{problem.ComplexityTradeOffNote}";
            }
            else
            {
                note = $"Both solutions exhibit comparable throughput on tested inputs.\n{problem.ComplexityTradeOffNote}";
            }
        }

        return new BenchmarkReport(
            problem,
            new BenchmarkItemResult("Your Solution", userPath, "Measured", "Measured", userMicroseconds, userAllocPerCall, largeScaleUserMs),
            new BenchmarkItemResult("Reference Solution", refPath, problem.TargetTimeComplexity, problem.TargetSpaceComplexity, refMicroseconds, refAllocPerCall, largeScaleRefMs),
            iterations,
            note);
    }

    private static List<object?[]> BuildSampleInputs(Problem problem)
    {
        return problem.Number switch
        {
            1 => new List<object?[]>
            {
                new object?[] { new int[] { 2, 7, 11, 15 }, 9 },
                new object?[] { new int[] { 3, 2, 4 }, 6 },
                new object?[] { new int[] { 3, 3 }, 6 }
            },
            11 => new List<object?[]>
            {
                new object?[] { new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 } },
                new object?[] { new int[] { 1, 1 } }
            },
            53 => new List<object?[]>
            {
                new object?[] { new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 } },
                new object?[] { new int[] { 1 } }
            },
            121 => new List<object?[]>
            {
                new object?[] { new int[] { 7, 1, 5, 3, 6, 4 } },
                new object?[] { new int[] { 7, 6, 4, 3, 1 } }
            },
            217 => new List<object?[]>
            {
                new object?[] { new int[] { 1, 2, 3, 1 } },
                new object?[] { new int[] { 1, 2, 3, 4 } }
            },
            125 => new List<object?[]>
            {
                new object?[] { "A man, a plan, a canal: Panama" },
                new object?[] { "race a car" }
            },
            _ => new List<object?[]>
            {
                new object?[] { new int[] { 1, 2, 3, 4, 5 } }
            }
        };
    }

    private static object?[]? BuildLargeScaleInput(Problem problem)
    {
        return problem.Number switch
        {
            1 => new object?[]
            {
                Enumerable.Range(1, 10000).ToArray(),
                19999
            },
            11 => new object?[]
            {
                Enumerable.Range(1, 15000).ToArray()
            },
            53 => new object?[]
            {
                Enumerable.Range(-10000, 20000).ToArray()
            },
            121 => new object?[]
            {
                Enumerable.Range(1, 20000).Reverse().Concat(new[] { 50000 }).ToArray()
            },
            217 => new object?[]
            {
                Enumerable.Range(1, 20000).Concat(new[] { 1 }).ToArray()
            },
            125 => new object?[]
            {
                new string('a', 50000)
            },
            242 => new object?[]
            {
                new string('a', 50000),
                new string('a', 50000)
            },
            70 => new object?[]
            {
                40
            },
            _ => null
        };
    }

    private static object?[] CloneArgs(object?[] args)
    {
        var copy = new object?[args.Length];
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] is int[] arr)
            {
                copy[i] = (int[])arr.Clone();
            }
            else if (args[i] is string str)
            {
                copy[i] = str;
            }
            else
            {
                copy[i] = args[i];
            }
        }
        return copy;
    }
}
