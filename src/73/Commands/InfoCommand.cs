using System;
using Spectre.Console;
using LeetCode73.Core;
using LeetCode73.UI;

namespace LeetCode73.Commands;

public static class InfoCommand
{
    public static int Execute(string problemName)
    {
        var problem = ProblemResolver.Resolve(problemName);
        if (problem == null)
        {
            AnsiConsole.MarkupLine($"[bold red]Error:[/] Problem not found: '[yellow]{Markup.Escape(problemName)}[/]'.");
            AnsiConsole.MarkupLine("[grey]Run [cyan]73 list[/] to view all available problems.[/]");
            return 1;
        }

        var readme = ResourceProvider.GetReadme(problem);
        ConsoleFormatter.RenderProblemInfo(problem, readme);
        return 0;
    }
}
