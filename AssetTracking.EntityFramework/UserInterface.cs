using AssetTracking.EntityFramework.Controllers;
using AssetTracking.EntityFramework.Models;
using AssetTracking.EntityFramework.Services;
using Spectre.Console;
using static AssetTracking.EntityFramework.Enums;

namespace AssetTracking.EntityFramework;

static internal class UserInterface
{
    
    
    static internal void MainMenu()
    {
 
        var isAppRunning = true;
        while (isAppRunning)
        {
            Console.Clear();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                    .Title("Select an option:")
                    .UseConverter(opt => EnumExtensions.GetEnumDescription(opt))
                    .AddChoices(Enum.GetValues(typeof(MenuOptions)).Cast<MenuOptions>()));

            switch (option)
            {
                case MenuOptions.AddCategory:
                    CategoryService.AddCategory();
                    break;
                case MenuOptions.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case MenuOptions.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case MenuOptions.ShowAllCategories:
                    CategoryService.ShowAllCategories();
                    break;
                case MenuOptions.AddOffice:
                    OfficeService.AddOffice();
                    break;
                case MenuOptions.DeleteOffice:
                    OfficeService.DeleteOffice();
                    break;
                case MenuOptions.UpdateOffice:
                    OfficeService.UpdateOffice();
                    break;
                case MenuOptions.ShowAllOffices:
                    OfficeService.ShowAllOffices();
                    break;
                case MenuOptions.AddAsset:
                    AssetService.AddAsset();
                    break;
                case MenuOptions.DeleteAsset:
                    AssetService.DeleteAsset();
                    break;
                case MenuOptions.UpdateAsset:
                    AssetService.UpdateAsset();
                    break;
                case MenuOptions.ShowAsset:
                    AssetService.ShowAsset();
                    break;
                case MenuOptions.ShowAllAssets:
                    AssetService.ShowAllAssets();
                    break;
                case MenuOptions.Quit:
                    AssetController.Quit();
                    isAppRunning = false;
                    break;
            }
        }

    }
    static internal void DisplayCategoriesTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var category in categories)
        {
            table.AddRow(
                category.CategoryId.ToString(),
                category.Name);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to go to main menu");
        Console.ReadLine();
        Console.Clear();
    }

    static internal void DisplayOfficesTable(List<Office> offices)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Country");
        table.AddColumn("Currency");

        foreach (var office in offices)
        {
            table.AddRow(
                office.OfficeId.ToString(),
                office.Country,
                office.Currency);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to go to main menu");
        Console.ReadLine();
        Console.Clear();
    }

    static internal void DisplayAssetsTable(List<Asset> assets)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Category");
        table.AddColumn("Brand");
        table.AddColumn("Office");
        table.AddColumn("Model");
        table.AddColumn("Purchase date");
        table.AddColumn("Price in USD");
        table.AddColumn("Currency");
        table.AddColumn("Local price today");

        foreach (var asset in assets)
        {
            string color = "white";
            if (today >= asset.PurchaseDate.AddYears(3).AddMonths(-6) && today <= asset.PurchaseDate.AddYears(3).AddMonths(-3))
            {
                color = "yellow";
            }
            if (today >= asset.PurchaseDate.AddYears(3).AddMonths(-3))
            {
                color = "red";
            }

            double usdToSek = 10.635816;
            double usdToEur = 0.92290012;
            double localPriceToday = asset.Price;
            if (asset.Office.Currency == "EUR")
            {
                localPriceToday = asset.Price * usdToEur;
            } else if (asset.Office.Currency == "SEK")
            {
                localPriceToday = asset.Price * usdToSek;
            }

            table.AddRow(
                $"[{color}]{asset.AssetId}[/]",
                $"[{color}]{asset.Category.Name}[/]",
                $"[{color}]{asset.Brand}[/]",
                $"[{color}]{asset.Office.Country}[/]",
                $"[{color}]{asset.Model}[/]",
                $"[{color}]{asset.PurchaseDate}[/]",
                $"[{color}]{asset.Price}[/]",
                $"[{color}]{asset.Office.Currency}[/]",
                $"[{color}]{localPriceToday}[/]"
            );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to go to main menu");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void DisplayAssetTable(Asset asset)
    {
        double usdToSek = 10.635816;
        double usdToEur = 0.92290012;
        double localPriceToday = asset.Price;
        if (asset.Office.Currency == "EUR")
        {
            localPriceToday = asset.Price * usdToEur;
        }
        else if (asset.Office.Currency == "SEK")
        {
            localPriceToday = asset.Price * usdToSek;
        }

        var panel = new Panel(@$"Id: {asset.AssetId}
Category: {asset.Category.Name}
Brand: {asset.Brand} 
Model: {asset.Model}
Office: {asset.Office.Country}
Purchase date: {asset.PurchaseDate}
Price in USD: {asset.Price}
Currency: {asset.Office.Currency}
Local price today: {localPriceToday}");

        panel.Header = new PanelHeader("Asset information");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Enter any key to go to main menu");
        Console.ReadLine();
        Console.Clear();
    }
}
