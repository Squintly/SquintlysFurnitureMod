$namespaces = Get-ChildItem -Recurse -Filter "*.cs" |
    Select-String -Pattern "^namespace\s+([\w.]+)" |
    ForEach-Object { $_.Matches.Groups[1].Value } |
    Sort-Object -Unique

$lines = $namespaces | ForEach-Object { "global using $_;"}
$lines | Set-Content "GlobalUsings.cs"