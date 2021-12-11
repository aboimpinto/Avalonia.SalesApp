using Microsoft.EntityFrameworkCore;
using SalesApp.Model;

namespace SalesApp.DbAccess;

public class SalesDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=SalesApp.db");
}
