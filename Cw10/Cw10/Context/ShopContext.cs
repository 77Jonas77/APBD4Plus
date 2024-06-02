using Cw10.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Context;

public class ShopDbContext : DbContext
{
    public DbSet<Role>? Roles { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Account>? Accounts { get; set; }
    public DbSet<ProductCategory>? ProductsCategories { get; set; }
    public DbSet<ShoppingCart>? ShoppingCarts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=TestDbCw10;User Id=sa;Password=MyPass@word;Encrypt=False;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { FK_product = pc.FkProduct, FK_category = pc.FkCategory });

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.FkProduct);

        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.ProductsCategories)
            .HasForeignKey(pc => pc.FkCategory);

        modelBuilder.Entity<ShoppingCart>()
            .HasKey(sc => new { sc.FkAccount, sc.FkProduct });

        modelBuilder.Entity<ShoppingCart>()
            .HasOne(sc => sc.Account)
            .WithMany(a => a.ShoppingCarts)
            .HasForeignKey(sc => sc.FkAccount);

        modelBuilder.Entity<ShoppingCart>()
            .HasOne(sc => sc.Product)
            .WithMany(p => p.ShoppingCarts)
            .HasForeignKey(sc => sc.FkProduct);
    }
}