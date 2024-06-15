using Cw11.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Cw11.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<AppUser> Users { get; set; }
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=APBDCw11;User Id=sa;Password=MyPass@word;Encrypt=False;");
    }
}