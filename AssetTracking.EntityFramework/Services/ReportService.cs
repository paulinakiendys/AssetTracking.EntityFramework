using AssetTracking.EntityFramework.Controllers;
using AssetTracking.EntityFramework.Models.DTOs;
using System.Globalization;

namespace AssetTracking.EntityFramework.Services;

internal class ReportService
{
    internal static void CreateMonthlyReport()
    {
        var assets = AssetController.GetAssets();
        var report = assets.GroupBy(a => new
        {
            a.PurchaseDate.Month,
            a.PurchaseDate.Year,
        }).
        Select(group => new MonthlyReportDTO
        {
            Month = $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(group.Key.Month)} {group.Key.Year}",
            TotalValue = group.Sum(a => a.Price),
            TotalQuantity = group.Count()
        }).ToList();

        UserInterface.ShowReportByMonth(report);
    }
}
