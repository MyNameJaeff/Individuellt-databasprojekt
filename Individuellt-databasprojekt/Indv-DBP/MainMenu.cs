namespace Indv_DBP;

//using Microsoft.Data.SqlClient;
using Spectre.Console;

public class MainMenu
{
    
    private static void AwaitInput()
    {
        AnsiConsole.MarkupLine("[bold]Press any key to continue...[/]");
        Console.ReadKey();
    }
    
    //public static async Task Menu(SqlConnection sqlConnection)
    public static async Task Menu()
    {
        while (true)
        {
            Console.Clear();
            //AnsiConsole.MarkupLine($"[bold underline rgb(190,40,0)]Database:[/] {sqlConnection.Database}");

            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold underline rgb(190,40,0)]Main Menu[/]")
                    .AddChoices("Get Teachers by Department", "Get Students info", "Get Active Courses", "Update student", "[red]Exit[/]")
            );

            switch (selection)
            {
                case "Get Teachers by Department":
                    AnsiConsole.MarkupLine("Not implemented yet.");
                    AwaitInput();
                    break;

                case "Get Students info":
                    AnsiConsole.MarkupLine("Not implemented yet.");
                    AwaitInput();
                    break;

                case "Get Active Courses":
                    AnsiConsole.MarkupLine("Not implemented yet.");
                    AwaitInput();
                    break;

                case "Update student":
                    AnsiConsole.MarkupLine("Not implemented yet.");
                    AwaitInput();
                    break;

                case "[red]Back[/]":
                    Console.Clear();
                    return;

                case "[red]Exit[/]":
                    AnsiConsole.MarkupLine("[green]Goodbye![/]");
                    //await sqlConnection.DisposeAsync();
                    return;

                default:
                    AnsiConsole.MarkupLine("[red]Invalid option, please try again.[/]");
                    break;
            }
        }
    }
}