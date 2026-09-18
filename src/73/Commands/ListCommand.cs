using System;
using System.Linq;
using Spectre.Console;
using LeetCode73.Core;
using LeetCode73.UI;

namespace LeetCode73.Commands;

public static class ListCommand
{
    public static int Execute(string? category = null)
    {
        if (string.IsNullOrWhiteSpace(category))
        {
            ConsoleFormatter.RenderProblemList(ProblemRegistry.All);
            return 0;
        }

        var matchingCategory = ProblemRegistry.GetCategories().FirstOrDefault(c =>
            string.Equals(c, category, StringComparison.OrdinalIgnoreCase) ||
            c.Contains(category, StringComparison.OrdinalIgnoreCase) ||
            c.Replace("-", "").Contains(category.Replace("-", ""), StringComparison.OrdinalIgnoreCase));

        if (matchingCategory == null)
        {
            AnsiConsole.MarkupLine($"[bold red]Error:[/] Categoría no encontrada: '[yellow]{Markup.Escape(category)}[/]'.");
            AnsiConsole.MarkupLine("[bold]Categorías válidas:[/] " + string.Join(", ", ProblemRegistry.GetCategories().Select(c => $"[cyan]{c}[/]")));
            return 1;
        }

        var problems = ProblemRegistry.GetByCategory(matchingCategory);
        ConsoleFormatter.RenderProblemList(problems, matchingCategory);
        return 0;
    }
}
