using AssetTracking.EntityFramework.Controllers;
using AssetTracking.EntityFramework.Models;
using Spectre.Console;

namespace AssetTracking.EntityFramework.Services;

internal class CategoryService
{
    internal static void AddCategory()
    {
        var category = new Category();
        category.Name = AnsiConsole.Ask<string>("Enter a [green]name[/]:");
        CategoryController.AddCategory(category);
    }

    internal static void DeleteCategory()
    {
        var category = GetCategoryOptionInput();
        CategoryController.DeleteCategory(category);
    }

    internal static void UpdateCategory()
    {
        var category = GetCategoryOptionInput();

        category.Name = AnsiConsole.Confirm("Do you want to update the [green]name[/]?")
            ? AnsiConsole.Ask<string>("Enter a new [green]name[/]:")
            : category.Name;
        CategoryController.UpdateCategory(category);
    }

    internal static void ShowAllCategories()
    {
        var categories = CategoryController.GetCategories();
        UserInterface.DisplayCategoriesTable(categories);
    }

    internal static Category GetCategoryOptionInput()
    {
        var categories = CategoryController.GetCategories();
        var categoriesArray = categories.Select(c => c.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Select a category:")
            .AddChoices(categoriesArray));
        var category = categories.Single(c => c.Name == option);
        return category;
    }
}
