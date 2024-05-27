using AssetTracking.EntityFramework.Models;

namespace AssetTracking.EntityFramework.Controllers;

internal class OfficeController
{
    internal static void AddOffice(Office office)
    {
        using var db = new AssetsContext();
        db.Add(office);
        db.SaveChanges();
    }

    internal static void DeleteOffice(Office office)
    {
        using var db = new AssetsContext();
        db.Remove(office);
        db.SaveChanges();
    }

    internal static List<Office> GetOffices()
    {
        using var db = new AssetsContext();
        var offices = db.Offices.ToList();
        return offices;
    }

    internal static void UpdateOffice(Office office)
    {
        using var db = new AssetsContext();
        db.Update(office);
        db.SaveChanges();
    }
}
