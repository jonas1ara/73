<#
.SYNOPSIS
    Updates all .csproj files in the repo from net8.0 to net10.0 and optionally builds to verify.
.PARAMETER From
    Source target framework (default: net8.0)
.PARAMETER To
    Destination target framework (default: net10.0)
.PARAMETER SkipBuild
    If specified, does not run "dotnet build" at the end.
.EXAMPLE
    ./Update-DotNetTargetFramework.ps1
    ./Update-DotNetTargetFramework.ps1 -SkipBuild
#>
param(
    [string]$From = "net8.0",
    [string]$To = "net10.0",
    [switch]$SkipBuild
)
$ErrorActionPreference = "Stop"
$repoRoot = $PSScriptRoot
Set-Location $repoRoot
$csprojFiles = Get-ChildItem -Path $repoRoot -Filter "*.csproj" -Recurse |
    Where-Object { $_.FullName -notmatch '\\(bin|obj)\\' }
if ($csprojFiles.Count -eq 0) {
    Write-Host "No .csproj files were found." -ForegroundColor Yellow
    return
}
Write-Host "Found $($csprojFiles.Count) .csproj files." -ForegroundColor Cyan
$pattern = "<TargetFramework>$From</TargetFramework>"
$replacement = "<TargetFramework>$To</TargetFramework>"
$updated = 0
$skipped = 0
foreach ($file in $csprojFiles) {
    $content = Get-Content -Path $file.FullName -Raw
    if ($content -match [regex]::Escape($pattern)) {
        $newContent = $content -replace [regex]::Escape($pattern), $replacement
        Set-Content -Path $file.FullName -Value $newContent -NoNewline
        Write-Host "  Updated: $($file.FullName.Substring($repoRoot.Length + 1))" -ForegroundColor Green
        $updated++
    }
    else {
        Write-Host "  No changes (does not match $From): $($file.FullName.Substring($repoRoot.Length + 1))" -ForegroundColor DarkYellow
        $skipped++
    }
}
Write-Host ""
Write-Host "Summary: $updated updated, $skipped skipped." -ForegroundColor Cyan
if (-not $SkipBuild) {
    Write-Host ""
    Write-Host "Building the solution to verify..." -ForegroundColor Cyan
    $sln = Get-ChildItem -Path $repoRoot -Filter "*.sln" | Select-Object -First 1
    if ($sln) {
        dotnet build $sln.FullName
    }
    else {
        Write-Host "No .sln file found, building each .csproj individually." -ForegroundColor Yellow
        foreach ($file in $csprojFiles) {
            dotnet build $file.FullName
        }
    }
}
