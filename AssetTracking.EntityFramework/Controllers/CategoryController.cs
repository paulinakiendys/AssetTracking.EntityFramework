using AssetTracking.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetTracking.EntityFramework.Controllers;

internal class CategoryController
{
    internal static void AddCategory(Category category)
    {
        using var db = new AssetsContext();
        db.Add(category);
        db.SaveChanges();
    }

    internal static void DeleteCategory(Category category)
    {
        using var db = new AssetsContext();
        db.Remove(category);
        db.SaveChanges();
    }

    internal static List<Category> GetCategories()
    {
        using var db = new AssetsContext();
        var categories = db.Categories
            .Include(c => c.Assets)
            .ThenInclude(a => a.Office)
            .ToList();
        return categories;
    }

    internal static void UpdateCategory(Category category)
    {
        using var db = new AssetsContext();
        db.Update(category);
        db.SaveChanges();
    }
}
