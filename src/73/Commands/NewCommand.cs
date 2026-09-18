using System;
using System.IO;
using Spectre.Console;
using LeetCode73.Core;
using LeetCode73.UI;

namespace LeetCode73.Commands;

public static class NewCommand
{
    public static int Execute(string problemName, string? outputLocation = null, bool force = false)
    {
        var problem = ProblemResolver.Resolve(problemName);
        if (problem == null)
        {
            AnsiConsole.MarkupLine($"[bold red]Error:[/] Problem not found: '[yellow]{Markup.Escape(problemName)}[/]'.");
            AnsiConsole.MarkupLine("[grey]Run [cyan]73 list[/] to view all available problems.[/]");
            return 1;
        }

        string targetPath;
        if (!string.IsNullOrWhiteSpace(outputLocation))
        {
            if (Directory.Exists(outputLocation))
            {
                targetPath = Path.Combine(outputLocation, problem.SolutionFileName);
            }
            else
            {
                targetPath = outputLocation;
            }
        }
        else
        {
            targetPath = Path.Combine(Directory.GetCurrentDirectory(), problem.SolutionFileName);
        }

        targetPath = Path.GetFullPath(targetPath);

        if (File.Exists(targetPath) && !force)
        {
            AnsiConsole.MarkupLine($"[bold yellow]Warning:[/] File already exists: [white]{targetPath}[/]");
            AnsiConsole.MarkupLine("[grey]Use [cyan]--force[/] to overwrite it.[/]");
            return 1;
        }

        var dir = Path.GetDirectoryName(targetPath);
        if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        var template = ResourceProvider.GenerateBoilerplate(problem);
        File.WriteAllText(targetPath, template);

        ConsoleFormatter.RenderNewFileCreated(problem, targetPath);
        return 0;
    }
}
