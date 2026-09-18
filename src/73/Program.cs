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
        var rootCommand = new RootCommand("73 CLI - Herramienta interactiva para resolver y probar problemas de LeetCode en C#");

        // Optional default argument for 73 <archivo.cs> or 73 <problema>
        var targetArg = new Argument<string?>("target", () => null, "Archivo de solución (.cs) o identificador de problema a probar");
        rootCommand.AddArgument(targetArg);

        // Subcommand: test [problema]
        var testCmd = new Command("test", "Ejecuta los tests de un problema específico");
        var testTargetArg = new Argument<string?>("problema", () => null, "Nombre, slug, número o archivo del problema");
        var timeoutOpt = new Option<int>(new[] { "--timeout", "-t" }, () => 3000, "Tiempo límite en milisegundos por test");
        testCmd.AddArgument(testTargetArg);
        testCmd.AddOption(timeoutOpt);
        testCmd.SetHandler((target, timeout) =>
        {
            Environment.ExitCode = TestCommand.Execute(target, timeout);
        }, testTargetArg, timeoutOpt);

        // Subcommand: new <problema>
        var newCmd = new Command("new", "Crea una plantilla limpia para resolver un problema con la firma de LeetCode");
        var newTargetArg = new Argument<string>("problema", "Nombre, slug o número del problema");
        var outOpt = new Option<string?>(new[] { "--out", "-o" }, () => null, "Ruta o directorio de salida del archivo generado");
        var forceOpt = new Option<bool>(new[] { "--force", "-f" }, () => false, "Sobrescribir si el archivo ya existe");
        newCmd.AddArgument(newTargetArg);
        newCmd.AddOption(outOpt);
        newCmd.AddOption(forceOpt);
        newCmd.SetHandler((problem, outPath, force) =>
        {
            Environment.ExitCode = NewCommand.Execute(problem, outPath, force);
        }, newTargetArg, outOpt, forceOpt);

        // Subcommand: list [categoria]
        var listCmd = new Command("list", "Muestra la lista de los 76 problemas organizados por categoría");
        var catArg = new Argument<string?>("categoria", () => null, "Filtrar por categoría (opcional)");
        listCmd.AddArgument(catArg);
        listCmd.SetHandler((cat) =>
        {
            Environment.ExitCode = ListCommand.Execute(cat);
        }, catArg);

        // Subcommand: info <problema>
        var infoCmd = new Command("info", "Muestra la descripción, ejemplos y restricciones de un problema");
        var infoTargetArg = new Argument<string>("problema", "Nombre, slug o número del problema");
        infoCmd.AddArgument(infoTargetArg);
        infoCmd.SetHandler((problem) =>
        {
            Environment.ExitCode = InfoCommand.Execute(problem);
        }, infoTargetArg);

        // Add subcommands
        rootCommand.AddCommand(testCmd);
        rootCommand.AddCommand(newCmd);
        rootCommand.AddCommand(listCmd);
        rootCommand.AddCommand(infoCmd);

        // Root handler: 73 or 73 <archivo.cs>
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
