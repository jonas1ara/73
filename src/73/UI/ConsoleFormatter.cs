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
                "[grey]Ejecuta y prueba problemas de LeetCode en C# instantáneamente con zero-boilerplate.[/]\n\n" +
                "[bold yellow]Comandos principales:[/] \n" +
                "  [green]73 <archivo.cs>[/]        Prueba un archivo de solución\n" +
                "  [green]73 test <problema>[/]      Prueba un problema por nombre o número\n" +
                "  [green]73 new <problema>[/]       Genera una plantilla limpia de solución\n" +
                "  [green]73 list[/]                 Lista los 76 problemas por categoría\n" +
                "  [green]73 info <problema>[/]      Muestra la descripción y restricciones del problema\n\n" +
                "[grey]Ejemplo:[/] [cyan]73 two.cs[/] [grey]o[/] [cyan]73 test Two-Sum[/]"))
            .Header("[bold white]Bienvenido[/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Cyan1);

        AnsiConsole.Write(panel);
        AnsiConsole.WriteLine();
    }

    public static void RenderHeader(Problem problem, string? filePath)
    {
        var grid = new Grid();
        grid.AddColumn();
        grid.AddRow(new Markup($"[bold]Problema:[/] [white]{problem.FormattedNumber} - {problem.Title}[/] {problem.DifficultyMarkup}"));
        if (!string.IsNullOrWhiteSpace(filePath))
        {
            grid.AddRow(new Markup($"[bold]Archivo:[/]  [grey]{Path.GetFileName(filePath)}[/] [dim]({filePath})[/]"));
        }
        else
        {
            grid.AddRow(new Markup($"[bold]Archivo:[/]  [grey]Solución de referencia ({problem.SolutionFileName})[/]"));
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

        AnsiConsole.MarkupLine($"  [green]✔ Compilación exitosa en {result.CompilationMs:F0}ms[/]\n");

        foreach (var tc in result.TestCases)
        {
            var icon = tc.Passed ? "[green]✔ PASSED[/]" : $"[red]✖ {tc.Verdict}[/]";
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

    private static void RenderCompileErrors(TestExecutionResult result)
    {
        AnsiConsole.MarkupLine("  [yellow]⚠ Falló la compilación:[/]\n");

        var table = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.Yellow)
            .AddColumn(new TableColumn("[bold]Línea:Col[/]").Centered())
            .AddColumn(new TableColumn("[bold]Código[/]").Centered())
            .AddColumn(new TableColumn("[bold]Mensaje[/]"));

        foreach (var diag in result.CompilationDiagnostics)
        {
            table.AddRow(
                $"[yellow]{diag.Line}:{diag.Column}[/]",
                $"[grey]{diag.Code}[/]",
                $"[white]{Markup.Escape(diag.Message)}[/]");
        }

        AnsiConsole.Write(table);
        AnsiConsole.WriteLine();

        var panel = new Panel(new Markup("[bold red]ESTADO:  ⚠ COMPILE ERROR[/]\n[grey]Por favor corrige los errores sintácticos indicados arriba.[/]"))
            .Border(BoxBorder.Square)
            .BorderColor(Color.Red);
        AnsiConsole.Write(panel);
    }

    private static void RenderFailures(List<TestCaseResult> failures)
    {
        var table = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.Red)
            .Title("[bold red]Detalle de Errores[/]")
            .AddColumn(new TableColumn("[bold]Caso[/]").Centered())
            .AddColumn(new TableColumn("[bold]Entrada / Prueba[/]"))
            .AddColumn(new TableColumn("[bold]Esperado[/]"))
            .AddColumn(new TableColumn("[bold]Obtenido[/]"));

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
            TestVerdict.Accepted => ("[bold green]✔ ACCEPTED[/]", Color.Green),
            TestVerdict.WrongAnswer => ("[bold red]✖ WRONG ANSWER[/]", Color.Red),
            TestVerdict.TimeLimitExceeded => ("[bold yellow]⏱ TIME LIMIT EXCEEDED[/]", Color.Yellow),
            TestVerdict.RuntimeError => ("[bold red]✖ RUNTIME ERROR[/]", Color.Red),
            _ => ("[bold yellow]⚠ COMPILE ERROR[/]", Color.Yellow)
        };

        var grid = new Grid();
        grid.AddColumn(new GridColumn().Width(12));
        grid.AddColumn();

        grid.AddRow("[bold]ESTADO:[/]", statusMarkup);
        grid.AddRow("[bold]TIEMPO:[/]", $"[white]{result.TotalExecutionMs:F1} ms total[/] [grey]({result.CompilationMs:F0} ms compilación)[/]");
        grid.AddRow("[bold]CASOS:[/]", $"[white]{result.PassedCount}/{result.TotalCount} pasados[/]");

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
            ? "Catálogo de los 76 Problemas de LeetCode"
            : $"Problemas en Categoría: {categoryFilter}";

        var table = new Table()
            .Border(TableBorder.Rounded)
            .Title($"[bold cyan]{title}[/]")
            .AddColumn(new TableColumn("[bold]# [/]").Centered())
            .AddColumn(new TableColumn("[bold]Título[/]"))
            .AddColumn(new TableColumn("[bold]Categoría[/]"))
            .AddColumn(new TableColumn("[bold]Dificultad[/]").Centered())
            .AddColumn(new TableColumn("[bold]Método / Clase Esperada[/]"));

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
                methodOrClass);
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine($"\n[grey]Total de problemas: [white]{list.Count}[/][/]\n");
    }

    public static void RenderProblemInfo(Problem problem, string? markdownContent)
    {
        var grid = new Grid();
        grid.AddColumn();
        grid.AddRow(new Markup($"[bold cyan]{problem.FormattedNumber} - {problem.Title}[/]"));
        grid.AddRow(new Markup($"[bold]Categoría:[/]  [white]{problem.Category}[/]  |  [bold]Dificultad:[/] {problem.DifficultyMarkup}"));
        grid.AddRow(new Markup($"[bold]Método:[/]     [yellow]{(problem.ExpectedClass == "Solution" ? problem.ExpectedMethod : problem.ExpectedClass)}[/]"));
        grid.AddRow(new Markup($"[bold]Plantilla:[/]  [grey]73 new {problem.Slug.ToLowerInvariant()}[/]"));

        var headerPanel = new Panel(grid)
            .Header("[bold white]Información del Problema[/]")
            .Border(BoxBorder.Double)
            .BorderColor(Color.Cyan1);

        AnsiConsole.Write(headerPanel);
        AnsiConsole.WriteLine();

        if (string.IsNullOrWhiteSpace(markdownContent))
        {
            AnsiConsole.MarkupLine("[grey]No se encontró descripción detallada para este problema.[/]");
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
                $"[green]✔ Archivo de solución creado exitosamente:[/] [bold white]{targetPath}[/]\n\n" +
                $"[bold]Problema:[/]  [cyan]{problem.FormattedNumber} - {problem.Title}[/] {problem.DifficultyMarkup}\n" +
                $"[bold]Prueba con:[/] [bold yellow]73 {Path.GetFileName(targetPath)}[/]\n"))
            .Header("[bold green] Plantilla Generada [/]")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Green);

        AnsiConsole.Write(panel);
        AnsiConsole.WriteLine();
    }
}
