using Microsoft.EntityFrameworkCore;
using MiniProjectCW2122;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectCW2122
{
    internal class MyDbContext : DbContext
    {
        // Change "YOUR_LOCAL_DB" and "NAME" to fit your project
        //string connectionString = "Data Source=(localdb)\\YOUR_LOCAL_DB;Initial Catalog=NAME;Integrated Security=True";
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Assets;Integrated Security=True";

        public DbSet<Asset> Assets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            // Seeding the database for first use/testing
            ModelBuilder.Entity<Asset>().HasData(
    new Asset { Id = 1, Type = "Computer", Brand = "Dell", Model = "XPS 13", Office = "SWE", PurchaseDate = new DateTime(2021, 03, 14), Cost = 199, Currency = "SEK", LocalCost = 1999 },
    new Asset { Id = 2, Type = "Mobiles", Brand = "Apple", Model = "iPhone 12", Office = "USA", PurchaseDate = new DateTime(2023, 05, 22), Cost = 999, Currency = "USD", LocalCost = 999 },
    new Asset { Id = 3, Type = "Computer", Brand = "HP", Model = "Spectre x360", Office = "UK", PurchaseDate = new DateTime(2022, 11, 10), Cost = 1500, Currency = "EUR", LocalCost = 1500 },
    new Asset { Id = 4, Type = "Mobiles", Brand = "Samsung", Model = "Galaxy S21", Office = "UK", PurchaseDate = new DateTime(2021, 08, 15), Cost = 850, Currency = "GBP", LocalCost = 850 },
    new Asset { Id = 5, Type = "Computer", Brand = "Apple", Model = "MacBook Pro", Office = "SWE", PurchaseDate = new DateTime(2021, 09, 05), Cost = 2500, Currency = "CAD", LocalCost = 2500 },
    new Asset { Id = 6, Type = "Mobiles", Brand = "OnePlus", Model = "9 Pro", Office = "USA", PurchaseDate = new DateTime(2021, 12, 30), Cost = 650, Currency = "INR", LocalCost = 48000 },
    new Asset { Id = 7, Type = "Computer", Brand = "Lenovo", Model = "ThinkPad X1", Office = "UK", PurchaseDate = new DateTime(2024, 02, 18), Cost = 2200, Currency = "AUD", LocalCost = 2200 },
    new Asset { Id = 8, Type = "Mobiles", Brand = "Google", Model = "Pixel 5", Office = "SWE", PurchaseDate = new DateTime(2021, 04, 12), Cost = 700, Currency = "JPY", LocalCost = 77000 }
);
        }
    }
}
