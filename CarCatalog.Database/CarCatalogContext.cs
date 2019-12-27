using CarCatalog.Database.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarCatalog.Database
{
    public class CarCatalogContext : DbContext
    {
        static int instance = 0;
        public CarCatalogContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
            Debug.WriteLine(instance++);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(en =>
            {
                en.HasOne(c => c.Engine)
                    .WithMany(e => e.Cars)
                    .HasForeignKey(c => c.EngineId);

                en.HasOne(c => c.Category)
                    .WithMany(c => c.Cars)
                    .HasForeignKey(c => c.CategoryId);

                en.HasOne(c => c.Catalog)
                    .WithMany(c => c.Cars)
                    .HasForeignKey(c => c.CatalogId);
            });
            modelBuilder.Entity<Catalog>(en =>
                en.HasOne(c => c.User)
                .WithMany(u => u.Catalogs)
                .HasForeignKey(c => c.UserId));

            modelBuilder.Entity<User>().HasData(CarCatalogInitializer.SeedUsers());
            modelBuilder.Entity<Catalog>().HasData(CarCatalogInitializer.SeedCatalogs());
            modelBuilder.Entity<Category>().HasData(CarCatalogInitializer.SeedCategories());
            modelBuilder.Entity<Engine>().HasData(CarCatalogInitializer.SeedEngines());
            modelBuilder.Entity<Car>().HasData(CarCatalogInitializer.SeedCars());
        }
    }
}
