using AssetTracking.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetTracking.EntityFramework;

internal class AssetsContext: DbContext
{
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Office> Offices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=assets.db;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Asset>()
            .HasOne(a => a.Category)
            .WithMany(c => c.Assets)
            .HasForeignKey(a => a.CategoryId);

        modelBuilder.Entity<Asset>()
            .HasOne(a => a.Office)
            .WithMany(o => o.Assets)
            .HasForeignKey(a => a.OfficeId);

        modelBuilder.Entity<Office>().HasData(new List<Office>
        {
            new Office
            {
                OfficeId = 1,
                Country = "Spain",
                Currency = "EUR"
            },
            new Office
            {
                OfficeId = 2,
                Country = "Sweden",
                Currency = "SEK"
            },
            new Office
            {
                OfficeId = 3,
                Country = "USA",
                Currency = "USD"
            }
        });

        modelBuilder.Entity<Category>().HasData(new List<Category>
        {
            new Category
            {
                CategoryId = 1,
                Name = "Phone",
            },
            new Category
            {
                CategoryId = 2,
                Name = "Computer"
            }
        });

        modelBuilder.Entity<Asset>().HasData(new List<Asset>
        {
            new Asset
            {
                AssetId = 1,
                CategoryId = 1,
                OfficeId = 1,
                Brand = "iPhone",
                Model = "8",
                PurchaseDate = new DateOnly(2021, 10, 13),
                Price = 970

            },
            new Asset
            {
                AssetId = 2,
                CategoryId = 1,
                OfficeId = 1,
                Brand = "iPhone",
                Model = "11",
                PurchaseDate = new DateOnly(2021, 10, 12),
                Price = 990

            },
            new Asset
            {
                AssetId = 3,
                CategoryId = 1,
                OfficeId = 2,
                Brand = "iPhone",
                Model = "X",
                PurchaseDate = new DateOnly(2021, 10, 11),
                Price = 1245

            },
            new Asset
            {
                AssetId = 4,
                CategoryId = 1,
                OfficeId = 2,
                Brand = "Motorola",
                Model = "Razr",
                PurchaseDate = new DateOnly(2021, 10, 10),
                Price = 970

            },
            new Asset
            {
                AssetId = 5,
                CategoryId = 2,
                OfficeId = 1,
                Brand = "HP",
                Model = "Elitebook",
                PurchaseDate = new DateOnly(2021, 7, 13),
                Price = 1423

            },
            new Asset
            {
                AssetId = 6,
                CategoryId = 2,
                OfficeId = 2,
                Brand = "HP",
                Model = "Dragonfly",
                PurchaseDate = new DateOnly(2021, 7, 12),
                Price = 588

            },
            new Asset
            {
                AssetId = 7,
                CategoryId = 2,
                OfficeId = 3,
                Brand = "Asus",
                Model = "W234",
                PurchaseDate = new DateOnly(2021, 7, 11),
                Price = 1200

            },
            new Asset
            {
                AssetId = 8,
                CategoryId = 2,
                OfficeId = 3,
                Brand = "Lenovo",
                Model = "Yoga 730",
                PurchaseDate = new DateOnly(2021, 7, 10),
                Price = 835

            },
            new Asset
            {
                AssetId = 9,
                CategoryId = 2,
                OfficeId = 3,
                Brand = "Lenovo",
                Model = "Yoga 530",
                PurchaseDate = new DateOnly(2021, 7, 9),
                Price = 1030
            }
        });
    }
}
