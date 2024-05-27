using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AssetTracking.EntityFramework.Models;

[Index(nameof(Name), IsUnique = true)]
internal class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string Name { get; set; }

    public List<Asset> Assets { get; set; }
}
