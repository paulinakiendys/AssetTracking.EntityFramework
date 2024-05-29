namespace AssetTracking.EntityFramework.Models.DTOs;

internal class MonthlyReportDTO
{
    public string Month { get; set; }
    public int TotalValue { get; set; }
    public int TotalQuantity { get; set; }
}
