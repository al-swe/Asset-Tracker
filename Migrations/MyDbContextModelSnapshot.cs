﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniProjectCW2122;

#nullable disable

namespace MiniProjectCW2122.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiniProjectCW2122.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LocalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Office")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Assets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Dell",
                            Cost = 199m,
                            Currency = "SEK",
                            LocalCost = 1999m,
                            Model = "XPS 13",
                            Office = "SWE",
                            PurchaseDate = new DateTime(2021, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Computer"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Apple",
                            Cost = 999m,
                            Currency = "USD",
                            LocalCost = 999m,
                            Model = "iPhone 12",
                            Office = "USA",
                            PurchaseDate = new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Mobiles"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "HP",
                            Cost = 1500m,
                            Currency = "EUR",
                            LocalCost = 1500m,
                            Model = "Spectre x360",
                            Office = "UK",
                            PurchaseDate = new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Computer"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Samsung",
                            Cost = 850m,
                            Currency = "GBP",
                            LocalCost = 850m,
                            Model = "Galaxy S21",
                            Office = "UK",
                            PurchaseDate = new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Mobiles"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Apple",
                            Cost = 2500m,
                            Currency = "CAD",
                            LocalCost = 2500m,
                            Model = "MacBook Pro",
                            Office = "SWE",
                            PurchaseDate = new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Computer"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "OnePlus",
                            Cost = 650m,
                            Currency = "INR",
                            LocalCost = 48000m,
                            Model = "9 Pro",
                            Office = "USA",
                            PurchaseDate = new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Mobiles"
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Lenovo",
                            Cost = 2200m,
                            Currency = "AUD",
                            LocalCost = 2200m,
                            Model = "ThinkPad X1",
                            Office = "UK",
                            PurchaseDate = new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Computer"
                        },
                        new
                        {
                            Id = 8,
                            Brand = "Google",
                            Cost = 700m,
                            Currency = "JPY",
                            LocalCost = 77000m,
                            Model = "Pixel 5",
                            Office = "SWE",
                            PurchaseDate = new DateTime(2021, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Mobiles"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
