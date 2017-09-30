# NovaTemplates

Use the templates by cloning them and then run `dotnet new --install [PathToTemplate]`, for example:

```
dotnet new --install ./GitHub/NovaTemplates/ConsoleTemplate
```

Run `dotnet new --list` to see if the template was properly installed.

Create a new project by running `dotnet new [TemplateName]`:

```
dotnet new scconsole
```

An optional output directory can be added at the same time, the project will take the same name as the directory:

```
dotnet new scconsole -o MyConsoleApp
```

You will now have a `MyConsoleApp.csproj` project inside a `MyConsoleApp` directory.
