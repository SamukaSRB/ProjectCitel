﻿using ApiSrbWeb.Model;
using Microsoft.EntityFrameworkCore;


namespace ApiSrbWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }      
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Category>().Property(c => c.CategoryName).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.CategoryDescription).HasMaxLength(150).IsRequired();

            modelBuilder.Entity<Product>().HasKey(c => c.ProductId);
            modelBuilder.Entity<Product>().Property(c => c.ProductEan).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(c => c.ProductName).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(c => c.ProductDescription).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Product>().Property(c => c.ProductPrice).HasPrecision(14,2).IsRequired();
            modelBuilder.Entity<Product>().Property(c => c.ProductStock).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(c => c.ProductImageUrl).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne<Category>(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(c => c.CategoryId);
        }

    }
}
