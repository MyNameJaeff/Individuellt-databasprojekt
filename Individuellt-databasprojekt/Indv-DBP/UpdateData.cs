using Indv_DBP.Data;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace Indv_DBP
{
    internal class UpdateData
    {

        public void UpdateStudent()
        {
            using (var context = new SchoolContext())
            {
                // Hämta alla elever och visa dem med ID och namn
                var students = context.Students
                    .Include(s => s.Person)  // Inkludera Person-tabellen för att visa namn
                    .ToList();

                // Skapa en lista av studenter att visa i AnsiConsole
                var studentChoices = students.Select(s => new
                {
                    StudentId = s.StudentId,
                    FullName = $"{s.Person.FirstName} {s.Person.LastName}"
                }).ToList();

                // Använd AnsiConsole för att visa en lista och låta användaren välja en student
                var selectedStudentId = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Välj en elev att uppdatera:")
                        .AddChoices(studentChoices.Select(s => s.FullName).ToArray())
                );

                // Hämta den valda elevens ID
                var studentToUpdate = studentChoices.FirstOrDefault(s => s.FullName == selectedStudentId);

                if (studentToUpdate != null)
                {
                    var student = context.Students
                        .Include(s => s.Person)
                        .FirstOrDefault(s => s.StudentId == studentToUpdate.StudentId);

                    if (student != null)
                    {
                        // Fråga användaren vad de vill uppdatera
                        string newFirstName = AnsiConsole.Ask<string>("Nytt förnamn (tryck Enter för att behålla nuvarande):", student.Person.FirstName);
                        string newLastName = AnsiConsole.Ask<string>("Nytt efternamn (tryck Enter för att behålla nuvarande):", student.Person.LastName);
                        var newStartDateString = AnsiConsole.Ask<string>("Nytt startdatum (yyyy-mm-dd, tryck Enter för att behålla nuvarande):", student.Person.StartDate.ToString());
                        DateOnly newStartDate;
                        if (!DateOnly.TryParse(newStartDateString, out newStartDate))
                        {
                            newStartDate = student.Person.StartDate;
                        }

                        // Uppdatera elevens information
                        if (!string.IsNullOrEmpty(newFirstName))
                            student.Person.FirstName = newFirstName;
                        if (!string.IsNullOrEmpty(newLastName))
                            student.Person.LastName = newLastName;
                        student.Person.StartDate = newStartDate;

                        // Spara ändringarna
                        context.SaveChanges();
                        AnsiConsole.MarkupLine("[green]Elevens information har uppdaterats.[/]");
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[red]Eleven hittades inte i databasen.[/]");
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Ingen elev valdes.[/]");
                }
            }
        }


    }
}
