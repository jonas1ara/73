using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Sdk;
using LeetCode73.Core;

namespace LeetCode73.Runner;

public static class RoslynRunner
{
    private static readonly Lazy<List<MetadataReference>> _references = new(InitializeReferences);

    private static List<MetadataReference> InitializeReferences()
    {
        var refs = new List<MetadataReference>();

        // 1. Current AppDomain loaded assemblies
        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (!asm.IsDynamic && !string.IsNullOrWhiteSpace(asm.Location) && File.Exists(asm.Location))
            {
                try
                {
                    refs.Add(MetadataReference.CreateFromFile(asm.Location));
                }
                catch { }
            }
        }

        // 2. Runtime folder core assemblies (System*.dll)
        var runtimeDir = Path.GetDirectoryName(typeof(object).Assembly.Location);
        if (runtimeDir != null && Directory.Exists(runtimeDir))
        {
            foreach (var dll in Directory.GetFiles(runtimeDir, "System*.dll"))
            {
                try
                {
                    using var stream = File.OpenRead(dll);
                    using var peReader = new PEReader(stream);
                    if (peReader.HasMetadata)
                    {
                        refs.Add(MetadataReference.CreateFromFile(dll));
                    }
                }
                catch { }
            }
        }

        // 3. Ensure xUnit assemblies are present
        void EnsureRef(Type type)
        {
            var loc = type.Assembly.Location;
            if (!string.IsNullOrEmpty(loc) && refs.All(r => (r as PortableExecutableReference)?.FilePath != loc))
            {
                refs.Add(MetadataReference.CreateFromFile(loc));
            }
        }

        EnsureRef(typeof(Assert));
        EnsureRef(typeof(FactAttribute));
        EnsureRef(typeof(InlineDataAttribute));
        EnsureRef(typeof(MemberDataAttribute));

        return refs;
    }

    public static TestExecutionResult Execute(Problem problem, string userCode, string? filePath = null, int timeoutMs = 3000)
    {
        var result = new TestExecutionResult
        {
            Problem = problem,
            FilePath = filePath
        };

        var testSource = ResourceProvider.GetTestSource(problem);
        if (string.IsNullOrWhiteSpace(testSource))
        {
            result.OverallVerdict = TestVerdict.CompileError;
            result.CompilationDiagnostics.Add(new CompilationDiagnostic(
                0, 0, "73_ERR_NO_TESTS", $"No test suite found for problem '{problem.Title}'", "Error"));
            return result;
        }

        // Check declared classes in user code
        var userTree = CSharpSyntaxTree.ParseText(userCode, path: filePath ?? "Solution.cs");
        var userRoot = userTree.GetCompilationUnitRoot();
        var declaredClasses = userRoot.DescendantNodes()
            .OfType<ClassDeclarationSyntax>()
            .Select(c => c.Identifier.Text)
            .ToHashSet();

        // Prepare global usings
        var globalUsings = @"
global using System;
global using System.Collections;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using Xunit;
";

        // Build helper sources if not declared in user code
        var helperSb = new StringBuilder();
        if (!declaredClasses.Contains("ListNode") && (testSource.Contains("ListNode") || userCode.Contains("ListNode")))
            helperSb.AppendLine(CommonHelpers.ListNodeSource);
        if (!declaredClasses.Contains("TreeNode") && (testSource.Contains("TreeNode") || userCode.Contains("TreeNode")))
            helperSb.AppendLine(CommonHelpers.TreeNodeSource);
        if (!declaredClasses.Contains("Node") && (testSource.Contains("Node") || userCode.Contains("Node")))
            helperSb.AppendLine(CommonHelpers.NodeSource);
        if (!declaredClasses.Contains("Interval") && (testSource.Contains("Interval") || userCode.Contains("Interval")))
            helperSb.AppendLine(CommonHelpers.IntervalSource);
        if (!declaredClasses.Contains("TrieNode") && (testSource.Contains("TrieNode") || userCode.Contains("TrieNode")))
            helperSb.AppendLine(CommonHelpers.TrieNodeSource);

        var syntaxTrees = new List<SyntaxTree>
        {
            CSharpSyntaxTree.ParseText(globalUsings, path: "GlobalUsings.cs"),
            userTree,
            CSharpSyntaxTree.ParseText(testSource, path: problem.TestFileName)
        };

        if (helperSb.Length > 0)
        {
            syntaxTrees.Add(CSharpSyntaxTree.ParseText(helperSb.ToString(), path: "Helpers.cs"));
        }

        var compSw = Stopwatch.StartNew();
        var compilation = CSharpCompilation.Create(
            "LeetCode73_Run_" + Guid.NewGuid().ToString("N"),
            syntaxTrees,
            _references.Value,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        using var ms = new MemoryStream();
        var emitResult = compilation.Emit(ms);
        compSw.Stop();
        result.CompilationMs = compSw.Elapsed.TotalMilliseconds;

        if (!emitResult.Success)
        {
            result.Compiled = false;
            result.OverallVerdict = TestVerdict.CompileError;

            foreach (var diag in emitResult.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error))
            {
                var lineSpan = diag.Location.GetLineSpan();
                result.CompilationDiagnostics.Add(new CompilationDiagnostic(
                    lineSpan.StartLinePosition.Line + 1,
                    lineSpan.StartLinePosition.Character + 1,
                    diag.Id,
                    diag.GetMessage(),
                    diag.Severity.ToString()));
            }

            return result;
        }

        result.Compiled = true;
        ms.Seek(0, SeekOrigin.Begin);
        var asm = Assembly.Load(ms.ToArray());

        // Find test type
        var testType = asm.GetTypes().FirstOrDefault(t =>
            t.Name.EndsWith("Tests", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(t.Name, Path.GetFileNameWithoutExtension(problem.TestFileName), StringComparison.OrdinalIgnoreCase));

        if (testType == null)
        {
            result.OverallVerdict = TestVerdict.CompileError;
            result.CompilationDiagnostics.Add(new CompilationDiagnostic(
                0, 0, "73_ERR_NO_TEST_CLASS", $"Could not locate test class in '{problem.TestFileName}'", "Error"));
            return result;
        }

        // Run test cases
        RunTestClass(testType, result, timeoutMs);
        return result;
    }

    private static void RunTestClass(Type testType, TestExecutionResult result, int timeoutMs)
    {
        var testMethods = testType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.GetCustomAttribute<FactAttribute>() != null || m.GetCustomAttribute<TheoryAttribute>() != null)
            .ToList();

        var totalSw = Stopwatch.StartNew();
        int caseIndex = 1;

        foreach (var method in testMethods)
        {
            var isTheory = method.GetCustomAttribute<TheoryAttribute>() != null;

            if (isTheory)
            {
                var testCases = ExtractTheoryData(method, testType);
                var parameters = method.GetParameters();

                foreach (var args in testCases)
                {
                    var caseResult = ExecuteSingleTestCase(testType, method, args, parameters, caseIndex++, timeoutMs);
                    result.TestCases.Add(caseResult);
                }
            }
            else
            {
                // [Fact]
                var caseResult = ExecuteSingleTestCase(testType, method, Array.Empty<object?>(), Array.Empty<ParameterInfo>(), caseIndex++, timeoutMs);
                result.TestCases.Add(caseResult);
            }
        }

        totalSw.Stop();
        result.TotalExecutionMs = totalSw.Elapsed.TotalMilliseconds;

        // Determine overall verdict
        if (result.TestCases.Any(t => t.Verdict == TestVerdict.TimeLimitExceeded))
            result.OverallVerdict = TestVerdict.TimeLimitExceeded;
        else if (result.TestCases.Any(t => t.Verdict == TestVerdict.RuntimeError))
            result.OverallVerdict = TestVerdict.RuntimeError;
        else if (result.TestCases.Any(t => t.Verdict == TestVerdict.WrongAnswer))
            result.OverallVerdict = TestVerdict.WrongAnswer;
        else
            result.OverallVerdict = TestVerdict.Accepted;
    }

    private static List<object?[]> ExtractTheoryData(MethodInfo method, Type testType)
    {
        var results = new List<object?[]>();

        // 1. InlineData
        var inlineAttrs = method.GetCustomAttributes<InlineDataAttribute>();
        foreach (var attr in inlineAttrs)
        {
            results.Add(attr.GetData(method).FirstOrDefault() ?? Array.Empty<object?>());
        }

        // 2. MemberData
        var memberAttrs = method.GetCustomAttributes<MemberDataAttribute>();
        foreach (var attr in memberAttrs)
        {
            var memberName = attr.MemberName;
            var member = testType.GetMember(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).FirstOrDefault();
            if (member is MethodInfo methodMember)
            {
                var val = methodMember.Invoke(null, null);
                if (val is IEnumerable enumerable)
                {
                    foreach (var item in enumerable)
                    {
                        if (item is object[] row) results.Add(row);
                    }
                }
            }
            else if (member is PropertyInfo propMember)
            {
                var val = propMember.GetValue(null);
                if (val is IEnumerable enumerable)
                {
                    foreach (var item in enumerable)
                    {
                        if (item is object[] row) results.Add(row);
                    }
                }
            }
            else if (member is FieldInfo fieldMember)
            {
                var val = fieldMember.GetValue(null);
                if (val is IEnumerable enumerable)
                {
                    foreach (var item in enumerable)
                    {
                        if (item is object[] row) results.Add(row);
                    }
                }
            }
        }

        return results;
    }

    private static TestCaseResult ExecuteSingleTestCase(
        Type testType,
        MethodInfo method,
        object?[] args,
        ParameterInfo[] parameters,
        int index,
        int timeoutMs)
    {
        // Format input and expected displays
        string inputDisplay = "";
        string expectedDisplay = "";

        if (parameters.Length > 0 && args.Length > 0)
        {
            var inputParts = new List<string>();
            for (int i = 0; i < parameters.Length && i < args.Length; i++)
            {
                var param = parameters[i];
                var arg = args[i];
                if (i == parameters.Length - 1 && param.Name?.StartsWith("expected", StringComparison.OrdinalIgnoreCase) == true)
                {
                    expectedDisplay = CommonHelpers.FormatValue(arg);
                }
                else
                {
                    inputParts.Add($"{param.Name} = {CommonHelpers.FormatValue(arg)}");
                }
            }
            inputDisplay = string.Join(", ", inputParts);
        }
        else
        {
            inputDisplay = HumanizeMethodName(method.Name);
        }

        var sw = Stopwatch.StartNew();
        Exception? caughtException = null;

        try
        {
            var task = Task.Run(() =>
            {
                var instance = Activator.CreateInstance(testType);
                method.Invoke(instance, args);
            });

            bool completed = task.Wait(timeoutMs);
            sw.Stop();

            if (!completed)
            {
                return new TestCaseResult(
                    Index: index,
                    TestName: method.Name,
                    InputDisplay: inputDisplay,
                    ExpectedDisplay: expectedDisplay,
                    ActualDisplay: "Time Limit Exceeded (> " + timeoutMs + "ms)",
                    Passed: false,
                    ElapsedMs: sw.Elapsed.TotalMilliseconds,
                    ErrorMessage: $"Execution timed out after {timeoutMs} ms",
                    Verdict: TestVerdict.TimeLimitExceeded);
            }

            if (task.Exception != null)
            {
                caughtException = task.Exception.InnerException ?? task.Exception;
            }
        }
        catch (AggregateException ae)
        {
            sw.Stop();
            caughtException = ae.InnerExceptions.FirstOrDefault() ?? ae;
        }
        catch (Exception ex)
        {
            sw.Stop();
            caughtException = ex;
        }

        if (caughtException == null)
        {
            return new TestCaseResult(
                Index: index,
                TestName: method.Name,
                InputDisplay: inputDisplay,
                ExpectedDisplay: expectedDisplay,
                ActualDisplay: expectedDisplay,
                Passed: true,
                ElapsedMs: sw.Elapsed.TotalMilliseconds,
                ErrorMessage: null,
                Verdict: TestVerdict.Accepted);
        }

        // Check if assertion failure or runtime exception
        if (caughtException is TargetInvocationException tie && tie.InnerException != null)
            caughtException = tie.InnerException;

        if (caughtException is XunitException xunitEx)
        {
            string message = xunitEx.Message;
            string actual = message;
            string expected = expectedDisplay;

            var expProp = xunitEx.GetType().GetProperty("Expected") ?? xunitEx.GetType().GetProperty("FormattedExpectedValue");
            var actProp = xunitEx.GetType().GetProperty("Actual") ?? xunitEx.GetType().GetProperty("FormattedActualValue");

            if (expProp != null)
                expected = expProp.GetValue(xunitEx)?.ToString() ?? expected;
            if (actProp != null)
                actual = actProp.GetValue(xunitEx)?.ToString() ?? actual;

            if (actual == message && message.Contains("Expected:") && message.Contains("Actual:"))
            {
                var match = Regex.Match(message, @"Expected:\s*(.*?)\s*Actual:\s*(.*)", RegexOptions.Singleline);
                if (match.Success)
                {
                    expected = match.Groups[1].Value.Trim();
                    actual = match.Groups[2].Value.Trim();
                }
            }

            return new TestCaseResult(
                Index: index,
                TestName: method.Name,
                InputDisplay: inputDisplay,
                ExpectedDisplay: expected,
                ActualDisplay: actual,
                Passed: false,
                ElapsedMs: sw.Elapsed.TotalMilliseconds,
                ErrorMessage: xunitEx.Message,
                Verdict: TestVerdict.WrongAnswer);
        }

        // Runtime Exception
        var cleanStack = CleanStackTrace(caughtException);
        return new TestCaseResult(
            Index: index,
            TestName: method.Name,
            InputDisplay: inputDisplay,
            ExpectedDisplay: expectedDisplay,
            ActualDisplay: $"{caughtException.GetType().Name}: {caughtException.Message}",
            Passed: false,
            ElapsedMs: sw.Elapsed.TotalMilliseconds,
            ErrorMessage: $"{caughtException.GetType().Name}: {caughtException.Message}\n{cleanStack}",
            Verdict: TestVerdict.RuntimeError);
    }

    private static string HumanizeMethodName(string name)
    {
        // e.g. InvertTree_BalancedTree_MirrorsAllLevels -> Invert Tree: Balanced Tree Mirrors All Levels
        var parts = name.Split('_');
        return string.Join(" : ", parts);
    }

    private static string CleanStackTrace(Exception ex)
    {
        if (string.IsNullOrWhiteSpace(ex.StackTrace)) return "";
        var lines = ex.StackTrace.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var filtered = lines.Where(l => !l.Contains("System.Reflection") && !l.Contains("System.RuntimeMethodHandle") && !l.Contains("RoslynRunner"));
        return string.Join(Environment.NewLine, filtered);
    }

    public static (Assembly? Assembly, List<string> Errors) CompileSolutionOnly(string sourceCode, Problem problem)
    {
        var globalUsings = @"
global using System;
global using System.Collections;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
";
        var userTree = CSharpSyntaxTree.ParseText(sourceCode, path: "Solution.cs");
        var userRoot = userTree.GetCompilationUnitRoot();
        var declaredClasses = userRoot.DescendantNodes()
            .OfType<ClassDeclarationSyntax>()
            .Select(c => c.Identifier.Text)
            .ToHashSet();

        var helperSb = new StringBuilder();
        if (!declaredClasses.Contains("ListNode") && sourceCode.Contains("ListNode"))
            helperSb.AppendLine(CommonHelpers.ListNodeSource);
        if (!declaredClasses.Contains("TreeNode") && sourceCode.Contains("TreeNode"))
            helperSb.AppendLine(CommonHelpers.TreeNodeSource);
        if (!declaredClasses.Contains("Node") && sourceCode.Contains("Node"))
            helperSb.AppendLine(CommonHelpers.NodeSource);
        if (!declaredClasses.Contains("Interval") && sourceCode.Contains("Interval"))
            helperSb.AppendLine(CommonHelpers.IntervalSource);
        if (!declaredClasses.Contains("TrieNode") && sourceCode.Contains("TrieNode"))
            helperSb.AppendLine(CommonHelpers.TrieNodeSource);

        var syntaxTrees = new List<SyntaxTree>
        {
            CSharpSyntaxTree.ParseText(globalUsings, path: "GlobalUsings.cs"),
            userTree
        };
        if (helperSb.Length > 0)
            syntaxTrees.Add(CSharpSyntaxTree.ParseText(helperSb.ToString(), path: "Helpers.cs"));

        var compilation = CSharpCompilation.Create(
            "LeetCode73_Sol_" + Guid.NewGuid().ToString("N"),
            syntaxTrees,
            _references.Value,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, optimizationLevel: OptimizationLevel.Release));

        using var ms = new MemoryStream();
        var emitResult = compilation.Emit(ms);
        if (!emitResult.Success)
        {
            var errors = emitResult.Diagnostics
                .Where(d => d.Severity == DiagnosticSeverity.Error)
                .Select(d => d.GetMessage())
                .ToList();
            return (null, errors);
        }

        ms.Seek(0, SeekOrigin.Begin);
        var asm = Assembly.Load(ms.ToArray());
        return (asm, new List<string>());
    }
}
