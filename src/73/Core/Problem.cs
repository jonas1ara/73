namespace LeetCode73.Core;

public record Problem(
    int Number,
    string Id,
    string Title,
    string Slug,
    string Category,
    string Difficulty,
    string ExpectedClass,
    string ExpectedMethod,
    string MethodSignature,
    string TestFileName,
    string SolutionFileName,
    string RelativePath,
    string[] Aliases)
{
    public string FormattedNumber => $"#{Id}";

    public string DifficultyMarkup => Difficulty.ToLowerInvariant() switch
    {
        "easy" => "[green]Easy[/]",
        "medium" => "[yellow]Medium[/]",
        "hard" => "[red]Hard[/]",
        _ => Difficulty
    };

    public string DifficultyColor => Difficulty.ToLowerInvariant() switch
    {
        "easy" => "green",
        "medium" => "yellow",
        "hard" => "red",
        _ => "white"
    };
}
