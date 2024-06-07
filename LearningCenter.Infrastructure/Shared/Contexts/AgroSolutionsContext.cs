using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Contexts;

public class AgroSolutionsContext : DbContext
{
    public AgroSolutionsContext()
    {
    }

    public AgroSolutionsContext(DbContextOptions<AgroSolutionsContext> options) : base(options)
    {
    }

    public DbSet<Finance> Finances { get; set; }
    public DbSet<PendingCollections> PendingCollectionsCollections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=12345678;Database=agro_solutions_ws52;",
                serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Finance>().ToTable("Finance");
        builder.Entity<Finance>().ToTable("PendingCollections");
        //builder.Entity<Finance>().HasKey(p => p.Id);
        //builder.Entity<Finance>().Property(p => p.Name).IsRequired().HasMaxLength(25);
    }
}