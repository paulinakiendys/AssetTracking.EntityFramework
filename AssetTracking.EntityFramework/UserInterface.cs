using AssetTracking.EntityFramework.Models;
using AssetTracking.EntityFramework.Models.DTOs;
using AssetTracking.EntityFramework.Services;
using Spectre.Console;
using static AssetTracking.EntityFramework.Enums;

namespace AssetTracking.EntityFramework;

static internal class UserInterface
{
    static internal void CategoriesMenu()
    {
        var isCategoriesMenuRunning = true;
        while (isCategoriesMenuRunning)
        {
            Console.Clear();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<CategoryMenuOptions>()
                    .Title("Select an option:")
                    .UseConverter(opt => EnumExtensions.GetEnumDescription(opt))
                    .AddChoices(Enum.GetValues(typeof(CategoryMenuOptions)).Cast<CategoryMenuOptions>()));

            switch (option)
            {
                case CategoryMenuOptions.AddCategory:
                    CategoryService.AddCategory();
                    break;
                case CategoryMenuOptions.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case CategoryMenuOptions.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case CategoryMenuOptions.ShowCategory:
                    CategoryService.ShowCategory();
                    break;
                case CategoryMenuOptions.ShowAllCategories:
                    CategoryService.ShowAllCategories();
                    break;
                case CategoryMenuOptions.GoBack:
                    isCategoriesMenuRunning = false;
                    break;
            }
        }
    }

    static internal void OfficesMenu()
    {
        var isOfficesMenuRunning = true;
        while (isOfficesMenuRunning)
        {
            Console.Clear();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<OfficeMenuOptions>()
                    .Title("Select an option:")
                    .UseConverter(opt => EnumExtensions.GetEnumDescription(opt))
                    .AddChoices(Enum.GetValues(typeof(OfficeMenuOptions)).Cast<OfficeMenuOptions>()));

            switch (option)
            {
                case OfficeMenuOptions.AddOffice:
                    OfficeService.AddOffice();
                    break;
                case OfficeMenuOptions.DeleteOffice:
                    OfficeService.DeleteOffice();
                    break;
                case OfficeMenuOptions.UpdateOffice:
                    OfficeService.UpdateOffice();
                    break;
                case OfficeMenuOptions.ShowOffice:
                    OfficeService.ShowOffice();
                    break;
                case OfficeMenuOptions.ShowAllOffices:
                    OfficeService.ShowAllOffices();
                    break;
                case OfficeMenuOptions.GoBack:
                    isOfficesMenuRunning = false;
                    break;
            }
        }
    }

    static internal void AssetsMenu()
    {
        var isAssetsMenuRunning = true;
        while (isAssetsMenuRunning)
        {
            Console.Clear();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<AssetMenuOptions>()
                    .Title("Select an option:")
                    .UseConverter(opt => EnumExtensions.GetEnumDescription(opt))
                    .AddChoices(Enum.GetValues(typeof(AssetMenuOptions)).Cast<AssetMenuOptions>()));

            switch (option)
            {
                case AssetMenuOptions.AddAsset:
                    AssetService.AddAsset();
                    break;
                case AssetMenuOptions.DeleteAsset:
                    AssetService.DeleteAsset();
                    break;
                case AssetMenuOptions.UpdateAsset:
                    AssetService.UpdateAsset();
                    break;
                case AssetMenuOptions.ShowAsset:
                    AssetService.ShowAsset();
                    break;
                case AssetMenuOptions.ShowAllAssets:
                    AssetService.ShowAllAssets();
                    break;
                case AssetMenuOptions.GoBack:
                    isAssetsMenuRunning = false;
                    break;
            }
        }
    }

    static internal void MainMenu()
    {
        var isAppRunning = true;
        while (isAppRunning)
        {
            Console.Clear();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptions>()
                    .Title("Select an option:")
                    .UseConverter(opt => EnumExtensions.GetEnumDescription(opt))
                    .AddChoices(Enum.GetValues(typeof(MainMenuOptions)).Cast<MainMenuOptions>()));

            switch (option)
            {
                case MainMenuOptions.ManageCategories:
                    CategoriesMenu();
                    break;
                case MainMenuOptions.ManageOffices:
                    OfficesMenu();
                    break;
                case MainMenuOptions.ManageAssets:
                    AssetsMenu();
                    break;
                case MainMenuOptions.GenerateReport:
                    ReportService.CreateMonthlyReport();
                    break;
                case MainMenuOptions.Quit:
                    Console.WriteLine("Thank you for using this application");
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

        Console.WriteLine("Enter any key to go back");
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

        Console.WriteLine("Enter any key to go back");
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
            }
            else if (asset.Office.Currency == "SEK")
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

        Console.WriteLine("Enter any key to go back");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void DisplayCategoryPanel(Category category)
    {
        var panel = new Panel(@$"Id: {category.CategoryId}
Name: {category.Name}
Number of assets: {category.Assets.Count()}");

        panel.Header = new PanelHeader("Category information");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        DisplayAssetsTable(category.Assets);
    }

    internal static void DisplayOfficePanel(Office office)
    {
        var panel = new Panel(@$"Id: {office.OfficeId}
Country: {office.Country}
Currency: {office.Currency}
Number of assets: {office.Assets.Count()}");

        panel.Header = new PanelHeader("Office information");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        DisplayAssetsTable(office.Assets);
    }

    internal static void DisplayAssetPanel(Asset asset)
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

        Console.WriteLine("Enter any key to go back");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void ShowReportByMonth(List<MonthlyReportDTO> report)
    {
        var table = new Table();
        table.AddColumn("Month");
        table.AddColumn("Total value in USD");
        table.AddColumn("Total quantity");

        foreach (var item in report)
        {
            table.AddRow(
                item.Month,
                item.TotalValue.ToString(),
                item.TotalQuantity.ToString()
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to go back");
        Console.ReadLine();
        Console.Clear();
    }
}
