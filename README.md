# dotnet-purge

A dotnet CLI tool

Recursively purges all folders that end with `*bin` or `*obj`, effectively clearing all .NET build artifacts.

## Hot to use

```powershell
dotnet purge                  # Searches for `*bin` and `*obj` from current directory
dotnet purge .                # Same
dotnet purge path/to/project  # Searches in `path/to/project`

# Also
dotnet-purge
```

## How to install from source

```powershell
# pwsh
git clone https://github.com/Ilia-Kosenkov/dotnet-purge
cd dotnet-purge
dotnet publish
dotnet tool install -g dotnet-purge --add-source .\nupkg\
```
