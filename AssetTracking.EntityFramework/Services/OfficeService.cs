using AssetTracking.EntityFramework.Controllers;
using AssetTracking.EntityFramework.Models;
using Spectre.Console;

namespace AssetTracking.EntityFramework.Services;

internal class OfficeService
{
    internal static void AddOffice()
    {
        var office = new Office();
        office.Country = AnsiConsole.Ask<string>("Enter a [green]country[/]:");
        office.Currency = AnsiConsole.Ask<string>("Enter a [green]currency[/]:");
        OfficeController.AddOffice(office);
    }

    internal static void DeleteOffice()
    {
        var office = GetOfficeOptionInput();
        OfficeController.DeleteOffice(office);
    }

    internal static void UpdateOffice()
    {
        var office = GetOfficeOptionInput();

        office.Country = AnsiConsole.Confirm("Do you want to update the [green]country[/]?")
            ? AnsiConsole.Ask<string>("Enter a new [green]country[/]:")
            : office.Country;
        office.Currency = AnsiConsole.Confirm("Do you want to update the [green]currency[/]?")
            ? AnsiConsole.Ask<string>("Enter a new [green]currency[/]:")
            : office.Currency;
        OfficeController.UpdateOffice(office);
    }

    internal static void ShowAllOffices()
    {
        var offices = OfficeController.GetOffices();
        UserInterface.DisplayOfficesTable(offices);
    }

    internal static Office GetOfficeOptionInput()
    {
        var offices = OfficeController.GetOffices();
        var officesArray = offices.Select(c => c.Country).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Select an office:")
            .AddChoices(officesArray));
        var office = offices.Single(c => c.Country == option);
        return office;
    }

}
