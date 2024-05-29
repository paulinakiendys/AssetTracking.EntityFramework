using System.ComponentModel;

namespace AssetTracking.EntityFramework;

internal class Enums
{
    internal enum MainMenuOptions
    {
        [Description("Manage categories")]
        ManageCategories,
        [Description("Manage offices")]
        ManageOffices,
        [Description("Manage assets")]
        ManageAssets,
        [Description("Generate monthly report")]
        GenerateReport,
        [Description("Quit")]
        Quit
    }

    internal enum CategoryMenuOptions
    {
        [Description("Add a category")]
        AddCategory,
        [Description("Delete a category")]
        DeleteCategory,
        [Description("Update a category")]
        UpdateCategory,
        [Description("View a specific category")]
        ShowCategory,
        [Description("View all categories")]
        ShowAllCategories,
        [Description("Go back")]
        GoBack
    }

    internal enum OfficeMenuOptions
    {
        [Description("Add an office")]
        AddOffice,
        [Description("Delete an office")]
        DeleteOffice,
        [Description("Update an office")]
        UpdateOffice,
        [Description("View a specific office")]
        ShowOffice,
        [Description("View all offices")]
        ShowAllOffices,
        [Description("Go back")]
        GoBack
    }

    internal enum AssetMenuOptions
    {
        [Description("Add an asset")]
        AddAsset,
        [Description("Delete an asset")]
        DeleteAsset,
        [Description("Update an asset")]
        UpdateAsset,
        [Description("View a specific asset")]
        ShowAsset,
        [Description("View all assets")]
        ShowAllAssets,
        [Description("Go back")]
        GoBack
    }

}
