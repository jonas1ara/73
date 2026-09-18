using System;
using System.IO;
using Spectre.Console;
using LeetCode73.Core;
using LeetCode73.Runner;
using LeetCode73.UI;

namespace LeetCode73.Commands;

public static class TestCommand
{
    public static int Execute(string? target, int timeoutMs = 3000)
    {
        string? filePath = null;
        string? sourceCode = null;
        Problem? problem = null;

        // 1. If target is an existing file path
        if (!string.IsNullOrWhiteSpace(target) && File.Exists(target))
        {
            filePath = Path.GetFullPath(target);
            sourceCode = File.ReadAllText(filePath);
            problem = ProblemResolver.Resolve(filePath, sourceCode);
        }
        else
        {
            // 2. Try resolving target as a problem name/slug/number
            if (!string.IsNullOrWhiteSpace(target))
            {
                problem = ProblemResolver.Resolve(target);
            }

            // 3. If target is empty or not resolved yet, check current working directory
            if (problem == null)
            {
                problem = ProblemResolver.Resolve(Directory.GetCurrentDirectory());
            }

            // 4. Look for a solution file locally
            if (problem != null)
            {
                var candidates = new[]
                {
                    Path.Combine(Directory.GetCurrentDirectory(), $"{problem.Slug}.cs"),
                    Path.Combine(Directory.GetCurrentDirectory(), "Solution.cs"),
                    Path.Combine(Directory.GetCurrentDirectory(), problem.SolutionFileName),
                    Path.Combine(Directory.GetCurrentDirectory(), problem.RelativePath, problem.SolutionFileName)
                };

                foreach (var candidate in candidates)
                {
                    if (File.Exists(candidate))
                    {
                        filePath = Path.GetFullPath(candidate);
                        sourceCode = File.ReadAllText(filePath);
                        break;
                    }
                }

                // If still no local file found, check reference template/solution
                if (sourceCode == null)
                {
                    sourceCode = ResourceProvider.GetSolutionTemplate(problem);
                }
            }
        }

        if (problem == null)
        {
            AnsiConsole.MarkupLine($"[bold red]Error:[/] No se pudo identificar el problema correspondiente a '[yellow]{Markup.Escape(target ?? "")}[/]'.");
            AnsiConsole.MarkupLine("[grey]Prueba pasando un archivo .cs válido (ej. [cyan]73 two.cs[/]), o el nombre de un problema (ej. [cyan]73 test Two-Sum[/]).[/]");
            AnsiConsole.MarkupLine("[grey]Ejecuta [cyan]73 list[/] para ver los 76 problemas disponibles.[/]");
            return 1;
        }

        if (string.IsNullOrWhiteSpace(sourceCode))
        {
            AnsiConsole.MarkupLine($"[bold red]Error:[/] No se encontró código de solución para el problema [cyan]{problem.Title}[/].");
            AnsiConsole.MarkupLine($"[grey]Crea uno ejecutando: [cyan]73 new {problem.Slug.ToLowerInvariant()}[/][/]");
            return 1;
        }

        // Render header
        ConsoleFormatter.RenderHeader(problem, filePath);

        // Run tests with Roslyn
        var result = RoslynRunner.Execute(problem, sourceCode, filePath, timeoutMs);

        // Render execution results
        ConsoleFormatter.RenderExecutionResult(result);

        return result.OverallVerdict == TestVerdict.Accepted ? 0 : 1;
    }
}
