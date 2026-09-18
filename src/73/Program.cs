using System;
using System.CommandLine;
using System.Threading.Tasks;
using LeetCode73.Commands;
using LeetCode73.UI;

namespace LeetCode73;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var rootCommand = new RootCommand("73 CLI - Interactive tool to solve and test LeetCode problems in C#");

        // Optional default argument for 73 <file.cs> or 73 <problem>
        var targetArg = new Argument<string?>("target", () => null, "Solution file (.cs) or problem identifier to test");
        rootCommand.AddArgument(targetArg);

        // Subcommand: test [problem]
        var testCmd = new Command("test", "Run tests for a specific problem");
        var testTargetArg = new Argument<string?>("problem", () => null, "Problem name, slug, number, or solution file");
        var timeoutOpt = new Option<int>(new[] { "--timeout", "-t" }, () => 3000, "Execution timeout in milliseconds per test");
        var benchOpt = new Option<bool>(new[] { "--bench", "-b" }, () => false, "Run comparative benchmark against reference solution");
        testCmd.AddArgument(testTargetArg);
        testCmd.AddOption(timeoutOpt);
        testCmd.AddOption(benchOpt);
        testCmd.SetHandler((target, timeout, bench) =>
        {
            Environment.ExitCode = TestCommand.Execute(target, timeout, bench);
        }, testTargetArg, timeoutOpt, benchOpt);

        // Subcommand: bench [problem]
        var benchCmd = new Command("bench", "Benchmark and compare your solution against the optimal reference solution");
        var benchTargetArg = new Argument<string?>("problem", () => null, "Problem name, slug, number, or solution file");
        var iterOpt = new Option<int>(new[] { "--iterations", "-i" }, () => 1000, "Number of benchmark iterations");
        benchCmd.AddArgument(benchTargetArg);
        benchCmd.AddOption(iterOpt);
        benchCmd.SetHandler((target, iter) =>
        {
            Environment.ExitCode = BenchCommand.Execute(target, iter);
        }, benchTargetArg, iterOpt);

        // Subcommand: new <problem>
        var newCmd = new Command("new", "Generate a clean boilerplate template with the exact LeetCode signature");
        var newTargetArg = new Argument<string>("problem", "Problem name, slug, or number");
        var outOpt = new Option<string?>(new[] { "--out", "-o" }, () => null, "Output file path or directory for the generated file");
        var forceOpt = new Option<bool>(new[] { "--force", "-f" }, () => false, "Overwrite existing file if present");
        newCmd.AddArgument(newTargetArg);
        newCmd.AddOption(outOpt);
        newCmd.AddOption(forceOpt);
        newCmd.SetHandler((problem, outPath, force) =>
        {
            Environment.ExitCode = NewCommand.Execute(problem, outPath, force);
        }, newTargetArg, outOpt, forceOpt);

        // Subcommand: list [category]
        var listCmd = new Command("list", "Display the list of 76 problems organized by category");
        var catArg = new Argument<string?>("category", () => null, "Filter by category (optional)");
        listCmd.AddArgument(catArg);
        listCmd.SetHandler((cat) =>
        {
            Environment.ExitCode = ListCommand.Execute(cat);
        }, catArg);

        // Subcommand: info <problem>
        var infoCmd = new Command("info", "Display description, examples, and constraints for a problem");
        var infoTargetArg = new Argument<string>("problem", "Problem name, slug, or number");
        infoCmd.AddArgument(infoTargetArg);
        infoCmd.SetHandler((problem) =>
        {
            Environment.ExitCode = InfoCommand.Execute(problem);
        }, infoTargetArg);

        // Add subcommands
        rootCommand.AddCommand(testCmd);
        rootCommand.AddCommand(benchCmd);
        rootCommand.AddCommand(newCmd);
        rootCommand.AddCommand(listCmd);
        rootCommand.AddCommand(infoCmd);

        // Root handler: 73 or 73 <file.cs>
        rootCommand.SetHandler((target) =>
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                ConsoleFormatter.RenderBanner();
                Environment.ExitCode = 0;
                return;
            }

            Environment.ExitCode = TestCommand.Execute(target);
        }, targetArg);

        return await rootCommand.InvokeAsync(args);
    }
}
