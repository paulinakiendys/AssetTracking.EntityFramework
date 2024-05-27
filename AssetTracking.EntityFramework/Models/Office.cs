using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AssetTracking.EntityFramework.Models;

[Index(nameof(Country), IsUnique = true)]
internal class Office
{
    [Key]
    public int OfficeId { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string Currency {  get; set; }

    public List<Asset> Assets { get; set; }
}
