﻿// <auto-generated />
using System;
using AssetTracking.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssetTracking.EntityFramework.Migrations
{
    [DbContext(typeof(AssetsContext))]
    partial class AssetsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AssetTracking.EntityFramework.Models.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateOnly>("PurchaseDate")
                        .HasColumnType("date");

                    b.HasKey("AssetId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Model")
                        .IsUnique();

                    b.HasIndex("OfficeId");

                    b.ToTable("Assets");

                    b.HasData(
                        new
                        {
                            AssetId = 1,
                            Brand = "iPhone",
                            CategoryId = 1,
                            Model = "8",
                            OfficeId = 1,
                            Price = 970,
                            PurchaseDate = new DateOnly(2021, 10, 13)
                        },
                        new
                        {
                            AssetId = 2,
                            Brand = "iPhone",
                            CategoryId = 1,
                            Model = "11",
                            OfficeId = 1,
                            Price = 990,
                            PurchaseDate = new DateOnly(2021, 10, 12)
                        },
                        new
                        {
                            AssetId = 3,
                            Brand = "iPhone",
                            CategoryId = 1,
                            Model = "X",
                            OfficeId = 2,
                            Price = 1245,
                            PurchaseDate = new DateOnly(2021, 10, 11)
                        },
                        new
                        {
                            AssetId = 4,
                            Brand = "Motorola",
                            CategoryId = 1,
                            Model = "Razr",
                            OfficeId = 2,
                            Price = 970,
                            PurchaseDate = new DateOnly(2021, 10, 10)
                        },
                        new
                        {
                            AssetId = 5,
                            Brand = "HP",
                            CategoryId = 2,
                            Model = "Elitebook",
                            OfficeId = 1,
                            Price = 1423,
                            PurchaseDate = new DateOnly(2021, 7, 13)
                        },
                        new
                        {
                            AssetId = 6,
                            Brand = "HP",
                            CategoryId = 2,
                            Model = "Dragonfly",
                            OfficeId = 2,
                            Price = 588,
                            PurchaseDate = new DateOnly(2021, 7, 12)
                        },
                        new
                        {
                            AssetId = 7,
                            Brand = "Asus",
                            CategoryId = 2,
                            Model = "W234",
                            OfficeId = 3,
                            Price = 1200,
                            PurchaseDate = new DateOnly(2021, 7, 11)
                        },
                        new
                        {
                            AssetId = 8,
                            Brand = "Lenovo",
                            CategoryId = 2,
                            Model = "Yoga 730",
                            OfficeId = 3,
                            Price = 835,
                            PurchaseDate = new DateOnly(2021, 7, 10)
                        },
                        new
                        {
                            AssetId = 9,
                            Brand = "Lenovo",
                            CategoryId = 2,
                            Model = "Yoga 530",
                            OfficeId = 3,
                            Price = 1030,
                            PurchaseDate = new DateOnly(2021, 7, 9)
                        });
                });

            modelBuilder.Entity("AssetTracking.EntityFramework.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Phone"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Computer"
                        });
                });

            modelBuilder.Entity("AssetTracking.EntityFramework.Models.Office", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfficeId"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfficeId");

                    b.HasIndex("Country")
                        .IsUnique();

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            OfficeId = 1,
                            Country = "Spain",
                            Currency = "EUR"
                        },
                        new
                        {
                            OfficeId = 2,
                            Country = "Sweden",
                            Currency = "SEK"
                        },
                        new
                        {
                            OfficeId = 3,
                            Country = "USA",
                            Currency = "USD"
                        });
                });

            modelBuilder.Entity("AssetTracking.EntityFramework.Models.Asset", b =>
                {
                    b.HasOne("AssetTracking.EntityFramework.Models.Category", "Category")
                        .WithMany("Assets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetTracking.EntityFramework.Models.Office", "Office")
                        .WithMany("Assets")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("AssetTracking.EntityFramework.Models.Category", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("AssetTracking.EntityFramework.Models.Office", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
