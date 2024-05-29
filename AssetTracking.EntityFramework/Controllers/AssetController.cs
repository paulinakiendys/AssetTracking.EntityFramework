using AssetTracking.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetTracking.EntityFramework.Controllers;

internal class AssetController
{
    internal static void AddAsset(Asset asset)
    {
        using var db = new AssetsContext();
        db.Add(asset);
        db.SaveChanges();
    }

    internal static void DeleteAsset(Asset asset)
    {
        using var db = new AssetsContext();
        db.Remove(asset);
        db.SaveChanges();
    }


    internal static Asset GetAssetById(int id)
    {
        using var db = new AssetsContext();
        var asset = db.Assets
            .Include(a => a.Category)
            .Include(a => a.Office)
            .SingleOrDefault(a => a.AssetId == id);
        return asset;
    }

    internal static List<Asset> GetAssets()
    {
        using var db = new AssetsContext();
        var assets = db.Assets
            .Include(a => a.Category)
            .Include(a => a.Office)
            .ToList();
        return assets;
    }

    internal static void UpdateAsset(Asset asset)
    {
        using var db = new AssetsContext();
        db.Update(asset);
        db.SaveChanges();
    }
}
