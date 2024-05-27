using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetTracking.EntityFramework.Models;

[Index(nameof(Model), IsUnique = true)]

internal class Asset
{
    [Key]
    public int AssetId { get; set; }

    [Required]
    public string Brand { get; set; }

    [Required]
    public string Model { get; set; }

    [Required]
    public DateOnly PurchaseDate { get; set; }

    [Required]
    public int Price { get; set; }

    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }

    public int OfficeId { get; set; }

    [ForeignKey(nameof(OfficeId))]
    public Office Office { get; set; }
}
