using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiAssigment2.Models
{
    public class ProductStoreContext : DbContext
    {
        public ProductStoreContext(DbContextOptions<ProductStoreContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                            .ToTable("Category")
                            .HasKey(cat => cat.Id);
            modelBuilder.Entity<Category>()
                            .Property(cat => cat.Id)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int")
                            .UseIdentityColumn(1)
                            .IsRequired();
            modelBuilder.Entity<Category>()
                            .Property(cat => cat.CategoryName)
                            .HasColumnName("CategoryName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500)
                            .IsRequired();

            modelBuilder.Entity<Product>()
                            .ToTable("Product")
                            .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
                            .HasOne<Category>(p => p.category)
                            .WithMany(p => p.Products)
                            .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Product>()
                            .Property(p => p.Id)
                            .HasColumnName("ProductId")
                            .HasColumnType("int")
                            .UseIdentityColumn(1)
                            .IsRequired();
            modelBuilder.Entity<Product>()
                            .Property(p => p.ProductName)
                            .HasColumnName("ProductName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(100)
                            .IsRequired();
            modelBuilder.Entity<Product>()
                            .Property(p => p.Manufacture)
                            .HasColumnName("Manufacture")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500)
                            .IsRequired();
            modelBuilder.Entity<Product>()
                            .Property(p => p.CategoryId)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int")
                            .IsRequired();
        }
        public DbSet<Product> products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
    }
}