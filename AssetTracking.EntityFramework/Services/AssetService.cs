using AssetTracking.EntityFramework.Controllers;
using AssetTracking.EntityFramework.Models;
using Spectre.Console;

namespace AssetTracking.EntityFramework.Services;

internal class AssetService
{
    internal static void AddAsset()
    {
        var asset = new Asset();
        asset.CategoryId = CategoryService.GetCategoryOptionInput().CategoryId;
        asset.Brand = AnsiConsole.Ask<string>("Enter a [green]brand[/]:");
        asset.Model = AnsiConsole.Ask<string>("Enter a [green]model[/]:");
        asset.PurchaseDate = AnsiConsole.Ask<DateOnly>("Enter a [green]purchase date[/]:");
        asset.Price = AnsiConsole.Ask<int>("Enter a [green]price in USD[/]:");
        asset.OfficeId = OfficeService.GetOfficeOptionInput().OfficeId;
        AssetController.AddAsset(asset);
    }
    internal static void DeleteAsset()
    {
        var asset = GetAssetOptionInput();
        AssetController.DeleteAsset(asset);
    }

    internal static void UpdateAsset()
    {
        var asset = GetAssetOptionInput();

        asset.Category = AnsiConsole.Confirm("Do you want to update the [green]category[/]?")
           ? CategoryService.GetCategoryOptionInput()
           : asset.Category;
        asset.Brand = AnsiConsole.Confirm("Do you want to update the [green]brand[/]?")
            ? AnsiConsole.Ask<string>("Enter a new [green]brand[/]:")
            : asset.Brand;
        asset.Model = AnsiConsole.Confirm("Do you want to update the [green]model[/]?")
            ? AnsiConsole.Ask<string>("Enter a new [green]model[/]:")
            : asset.Model;
        asset.PurchaseDate = AnsiConsole.Confirm("Do you want to update the [green]purchase date[/]?")
            ? AnsiConsole.Ask<DateOnly>("Enter a new [green]purchase date[/]:")
            : asset.PurchaseDate;
        asset.Price = AnsiConsole.Confirm("Do you want to update the [green]price in USD[/]?")
            ? AnsiConsole.Ask<int>("Enter a new [green]price in USD[/]:")
            : asset.Price;
        asset.Office = AnsiConsole.Confirm("Do you want to update the [green]office[/]?")
           ? OfficeService.GetOfficeOptionInput()
           : asset.Office;
        AssetController.UpdateAsset(asset);
    }

    internal static void ShowAsset()
    {
        var asset = GetAssetOptionInput();
        UserInterface.DisplayAssetPanel(asset);
    }

    internal static void ShowAllAssets()
    {
        var assets = AssetController.GetAssets()
            .OrderBy(a => a.Office.Country)
            .ThenBy(a => a.PurchaseDate)
            .ToList();
        UserInterface.DisplayAssetsTable(assets);
    }
    static private Asset GetAssetOptionInput()
    {
        var assets = AssetController.GetAssets();
        var assetsArray = assets.Select(a => a.Model).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Select an asset:")
            .AddChoices(assetsArray));
        var id = assets.Single(a => a.Model == option).AssetId;
        var asset = AssetController.GetAssetById(id);
        return asset;
    }
}
