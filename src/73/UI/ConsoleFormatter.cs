using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Spectre.Console;
using LeetCode73.Core;
using LeetCode73.Runner;

namespace LeetCode73.UI;

public static class ConsoleFormatter
{
    public static void RenderBanner()
    {
        AnsiConsole.Write(
            new FigletText("73")
                .Color(Color.Cyan1));

        var panel = new Panel(
            new Markup(
                "[bold cyan]73 CLI[/] - The Sheldon Cooper LeetCode Companion\n" +
                "[grey]Run, test, and benchmark LeetCode problems in C# instantly with zero-boilerplate.[/]\n\n" +
                "[bold yellow]Commands:[/] \n" +
                "  [green]73 <file.cs>[/]           Test a solution file\n" +
                "  [green]73 test <problem>[/]       Run tests for a problem by name or number\n" +
                "  [green]73 bench <problem>[/]      Benchmark your solution against the optimal reference\n" +
                "  [green]73 new <problem>[/]        Generate a clean boilerplate solution\n" +
                "  [green]73 list[/]                 List all 76 problems by category\n" +
                "  [green]73 info <problem>[/]       Show problem description, constraints, and complexity\n\n" +
                "[grey]Example:[/] [cyan]73 two.cs[/] [grey]or[/] [cyan]73 bench two.cs[/]"))
            .Header("[bold white]Welcome[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Cyan1);

        AnsiConsole.Write(panel);
        AnsiConsole.WriteLine();
    }

    public static void RenderHeader(Problem problem, string? filePath)
    {
        var grid = new Grid();
        grid.AddColumn();
        grid.AddRow(new Markup($"[bold]Problem:[/] [white]{problem.FormattedNumber} - {problem.Title}[/] {problem.DifficultyMarkup}"));
        grid.AddRow(new Markup($"[bold]Target:[/]  [yellow]{problem.TargetComplexityDisplay}[/]"));
        if (!string.IsNullOrWhiteSpace(filePath))
        {
            grid.AddRow(new Markup($"[bold]File:[/]    [grey]{Path.GetFileName(filePath)}[/] [dim]({filePath})[/]"));
        }
        else
        {
            grid.AddRow(new Markup($"[bold]File:[/]    [grey]Reference solution ({problem.SolutionFileName})[/]"));
        }

        var panel = new Panel(grid)
            .Header("[bold cyan] 73 CLI [/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Cyan1);

        AnsiConsole.Write(panel);
        AnsiConsole.WriteLine();
    }

    public static void RenderExecutionResult(TestExecutionResult result)
    {
        if (!result.Compiled)
        {
            RenderCompileErrors(result);
            return;
        }

        AnsiConsole.MarkupLine($"  [green]Compilation successful in {result.CompilationMs:F0}ms[/]\n");

        foreach (var tc in result.TestCases)
        {
            var icon = tc.Passed ? "[green]PASS[/]" : $"[red]{tc.Verdict}[/]";
            var time = $"[grey]({tc.ElapsedMs:F1}ms)[/]";

            if (tc.Passed)
            {
                if (!string.IsNullOrWhiteSpace(tc.ExpectedDisplay))
                {
                    AnsiConsole.MarkupLine($"  Test {tc.Index}: [grey]{Markup.Escape(tc.InputDisplay)}[/]   --> [white]{Markup.Escape(tc.ExpectedDisplay)}[/]     {icon} {time}");
                }
                else
                {
                    AnsiConsole.MarkupLine($"  Test {tc.Index}: [white]{Markup.Escape(tc.InputDisplay)}[/]     {icon} {time}");
                }
            }
            else
            {
                AnsiConsole.MarkupLine($"  Test {tc.Index}: [grey]{Markup.Escape(tc.InputDisplay)}[/]     {icon} {time}");
            }
        }

        AnsiConsole.WriteLine();

        // If there are failures, display detailed comparison
        var failedCases = result.TestCases.Where(t => !t.Passed).ToList();
        if (failedCases.Count > 0)
        {
            RenderFailures(failedCases);
        }

        // Summary footer
        RenderSummaryFooter(result);
    }

    public static void RenderBenchmarkReport(BenchmarkReport report)
    {
        var table = new Table()
            .Border(TableBorder.Rounded)
            .Title($"[bold cyan]Benchmark & Scalability Comparison ({report.Iterations:N0} iterations)[/]")
            .AddColumn(new TableColumn("[bold]Implementation[/]"))
            .AddColumn(new TableColumn("[bold]Time Complexity[/]").Centered())
            .AddColumn(new TableColumn("[bold]Space Complexity[/]").Centered())
            .AddColumn(new TableColumn("[bold]Micro-Bench (avg)[/]").RightAligned())
            .AddColumn(new TableColumn("[bold]Allocations[/]").RightAligned())
            .AddColumn(new TableColumn("[bold]Stress Scale (N=10k+)[/]").RightAligned());

        void AddRow(BenchmarkItemResult item, string nameMarkup)
        {
            var timeComp = $"[white]{item.TimeComplexity}[/]";
            var spaceComp = $"[grey]{item.SpaceComplexity}[/]";
            var microTime = item.Passed ? $"[white]{item.ElapsedMicroseconds:F2} μs[/]" : "[red]Error[/]";
            var alloc = item.Passed ? $"[grey]{item.AllocatedBytes:N0} B[/]" : "[red]N/A[/]";
            var scale = item.LargeScaleElapsedMs.HasValue
                ? (item.LargeScaleElapsedMs.Value >= 0 ? $"[yellow]{item.LargeScaleElapsedMs.Value:F1} ms[/]" : "[red]Timeout/Error[/]")
                : "[grey]N/A[/]";

            table.AddRow(nameMarkup, timeComp, spaceComp, microTime, alloc, scale);
        }

        AddRow(report.UserResult, "[bold cyan]Your Solution[/]");
        AddRow(report.ReferenceResult, "[bold green]Reference Solution[/]");

        AnsiConsole.Write(table);
        AnsiConsole.WriteLine();

        var notePanel = new Panel(new Markup($"[bold yellow]Algorithmic Analysis & Scalability Insight:[/] \n[white]{Markup.Escape(report.SummaryNote)}[/]"))
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Yellow);

        AnsiConsole.Write(notePanel);
        AnsiConsole.WriteLine();
    }

    private static void RenderCompileErrors(TestExecutionResult result)
    {
        AnsiConsole.MarkupLine("  [yellow]Compilation failed:[/]\n");

        var table = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.Yellow)
            .AddColumn(new TableColumn("[bold]Line:Col[/]").Centered())
            .AddColumn(new TableColumn("[bold]Code[/]").Centered())
            .AddColumn(new TableColumn("[bold]Message[/]"));

        foreach (var diag in result.CompilationDiagnostics)
        {
            table.AddRow(
                $"[yellow]{diag.Line}:{diag.Column}[/]",
                $"[grey]{diag.Code}[/]",
                $"[white]{Markup.Escape(diag.Message)}[/]");
        }

        AnsiConsole.Write(table);
        AnsiConsole.WriteLine();

        var panel = new Panel(new Markup("[bold red]STATUS:  COMPILE ERROR[/]\n[grey]Please fix the compilation errors listed above.[/]"))
            .Border(BoxBorder.Square)
            .BorderColor(Color.Red);
        AnsiConsole.Write(panel);
    }

    private static void RenderFailures(List<TestCaseResult> failures)
    {
        var table = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.Red)
            .Title("[bold red]Failure Details[/]")
            .AddColumn(new TableColumn("[bold]Case[/]").Centered())
            .AddColumn(new TableColumn("[bold]Input / Test[/]"))
            .AddColumn(new TableColumn("[bold]Expected[/]"))
            .AddColumn(new TableColumn("[bold]Actual[/]"));

        foreach (var f in failures)
        {
            var expected = string.IsNullOrWhiteSpace(f.ExpectedDisplay) ? "[grey]N/A[/]" : $"[green]{Markup.Escape(f.ExpectedDisplay)}[/]";
            var actual = string.IsNullOrWhiteSpace(f.ActualDisplay) ? "[red]Error[/]" : $"[red]{Markup.Escape(f.ActualDisplay)}[/]";

            table.AddRow(
                $"[bold red]#{f.Index}[/]",
                $"[grey]{Markup.Escape(f.InputDisplay)}[/]",
                expected,
                actual);
        }

        AnsiConsole.Write(table);
        AnsiConsole.WriteLine();
    }

    private static void RenderSummaryFooter(TestExecutionResult result)
    {
        var rule = new Rule().RuleStyle("grey");
        AnsiConsole.Write(rule);

        var (statusMarkup, borderColor) = result.OverallVerdict switch
        {
            TestVerdict.Accepted => ("[bold green]ACCEPTED[/]", Color.Green),
            TestVerdict.WrongAnswer => ("[bold red]WRONG ANSWER[/]", Color.Red),
            TestVerdict.TimeLimitExceeded => ("[bold yellow]TIME LIMIT EXCEEDED[/]", Color.Yellow),
            TestVerdict.RuntimeError => ("[bold red]RUNTIME ERROR[/]", Color.Red),
            _ => ("[bold yellow]COMPILE ERROR[/]", Color.Yellow)
        };

        var grid = new Grid();
        grid.AddColumn(new GridColumn().Width(12));
        grid.AddColumn();

        grid.AddRow("[bold]STATUS:[/]", statusMarkup);
        grid.AddRow("[bold]TIME:[/]", $"[white]{result.TotalExecutionMs:F1} ms total[/] [grey]({result.CompilationMs:F0} ms compilation)[/]");
        grid.AddRow("[bold]TESTS:[/]", $"[white]{result.PassedCount}/{result.TotalCount} passed[/]");

        var panel = new Panel(grid)
            .Border(BoxBorder.Rounded)
            .BorderColor(borderColor);

        AnsiConsole.Write(panel);
        AnsiConsole.WriteLine();
    }

    public static void RenderProblemList(IEnumerable<Problem> problems, string? categoryFilter = null)
    {
        var list = problems.ToList();
        var title = string.IsNullOrWhiteSpace(categoryFilter)
            ? "Catalog of 76 LeetCode Problems"
            : $"Problems in Category: {categoryFilter}";

        var table = new Table()
            .Border(TableBorder.Rounded)
            .Title($"[bold cyan]{title}[/]")
            .AddColumn(new TableColumn("[bold]#[/]").Centered())
            .AddColumn(new TableColumn("[bold]Title[/]"))
            .AddColumn(new TableColumn("[bold]Category[/]"))
            .AddColumn(new TableColumn("[bold]Difficulty[/]").Centered())
            .AddColumn(new TableColumn("[bold]Target[/]").Centered())
            .AddColumn(new TableColumn("[bold]Expected Method / Class[/]"));

        foreach (var p in list.OrderBy(p => p.Number))
        {
            var methodOrClass = p.ExpectedClass == "Solution"
                ? $"[grey]Solution.[/][white]{p.ExpectedMethod}[/]"
                : $"[yellow]{p.ExpectedClass}[/]";

            table.AddRow(
                $"[cyan]{p.FormattedNumber}[/]",
                $"[white]{p.Title}[/]",
                $"[grey]{p.Category}[/]",
                p.DifficultyMarkup,
                $"[yellow]{p.TargetTimeComplexity}[/]",
                methodOrClass);
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine($"\n[grey]Total problems: [white]{list.Count}[/][/]\n");
    }

    public static void RenderProblemInfo(Problem problem, string? markdownContent)
    {
        var grid = new Grid();
        grid.AddColumn();
        grid.AddRow(new Markup($"[bold cyan]{problem.FormattedNumber} - {problem.Title}[/]"));
        grid.AddRow(new Markup($"[bold]Category:[/]   [white]{problem.Category}[/]  |  [bold]Difficulty:[/] {problem.DifficultyMarkup}"));
        grid.AddRow(new Markup($"[bold]Target:[/]     [yellow]{problem.TargetComplexityDisplay}[/]"));
        grid.AddRow(new Markup($"[bold]Method:[/]     [yellow]{(problem.ExpectedClass == "Solution" ? problem.ExpectedMethod : problem.ExpectedClass)}[/]"));
        grid.AddRow(new Markup($"[bold]Template:[/]   [grey]73 new {problem.Slug.ToLowerInvariant()}[/]"));

        var headerPanel = new Panel(grid)
            .Header("[bold white]Problem Information[/]")
            .Border(BoxBorder.Double)
            .BorderColor(Color.Cyan1);

        AnsiConsole.Write(headerPanel);
        AnsiConsole.WriteLine();

        if (!string.IsNullOrWhiteSpace(problem.ComplexityTradeOffNote))
        {
            var compPanel = new Panel(new Markup($"[bold yellow]Target Complexity:[/] [white]{problem.TargetComplexityDisplay}[/]\n\n[bold]Scalability & Trade-offs:[/] \n[grey]{Markup.Escape(problem.ComplexityTradeOffNote)}[/]"))
                .Header("[bold yellow] Algorithmic Analysis [/]")
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Yellow);

            AnsiConsole.Write(compPanel);
            AnsiConsole.WriteLine();
        }

        if (string.IsNullOrWhiteSpace(markdownContent))
        {
            AnsiConsole.MarkupLine("[grey]No detailed description found for this problem.[/]");
            return;
        }

        foreach (var line in markdownContent.Split('\n'))
        {
            var trimmed = line.TrimEnd('\r');
            if (trimmed.StartsWith("### "))
            {
                AnsiConsole.MarkupLine($"\n[bold cyan]{Markup.Escape(trimmed[4..])}[/]");
            }
            else if (trimmed.StartsWith("## "))
            {
                AnsiConsole.MarkupLine($"\n[bold yellow]{Markup.Escape(trimmed[3..])}[/]");
            }
            else if (trimmed.StartsWith("# "))
            {
                AnsiConsole.MarkupLine($"\n[bold white]{Markup.Escape(trimmed[2..])}[/]");
            }
            else if (trimmed.StartsWith("```"))
            {
                AnsiConsole.MarkupLine("[grey]────────────────────────────────────────[/]");
            }
            else
            {
                AnsiConsole.WriteLine(trimmed);
            }
        }
        AnsiConsole.WriteLine();
    }

    public static void RenderNewFileCreated(Problem problem, string targetPath)
    {
        var panel = new Panel(
            new Markup(
                $"[green]Solution file created successfully:[/] [bold white]{targetPath}[/]\n\n" +
                $"[bold]Problem:[/]   [cyan]{problem.FormattedNumber} - {problem.Title}[/] {problem.DifficultyMarkup}\n" +
                $"[bold]Target:[/]    [yellow]{problem.TargetComplexityDisplay}[/]\n" +
                $"[bold]Test with:[/] [bold yellow]73 {Path.GetFileName(targetPath)}[/]\n"))
            .Header("[bold green] Template Generated [/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Green);

        AnsiConsole.Write(panel);
        AnsiConsole.WriteLine();
    }
}
