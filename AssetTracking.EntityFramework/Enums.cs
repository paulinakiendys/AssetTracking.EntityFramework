using System.ComponentModel;

namespace AssetTracking.EntityFramework;

internal class Enums
{
    internal enum MenuOptions
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
        [Description("Add an office")]
        AddOffice,
        [Description("Delete an office")]
        DeleteOffice,
        [Description("Update an office")]
        UpdateOffice,
        [Description("View all offices")]
        ShowAllOffices,
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
        [Description("Quit")]
        Quit
    }

}
