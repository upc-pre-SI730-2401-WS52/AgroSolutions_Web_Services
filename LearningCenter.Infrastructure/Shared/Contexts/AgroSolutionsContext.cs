using Domain;
using LearningCenter.Domain.IAM.Queries;
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

    public DbSet<Crop> Crops { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<Adviser> Advisers { get; set; }
    public DbSet<Finance> Finances { get; set; }
    public DbSet<PendingCollections> PendingCollectionsCollections { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Pending> Pendings { get; set; }

    public DbSet<Employee> Employees { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=12345678;Database=agro_solutions;",
                serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Finance>().ToTable("Finance");

        builder.Entity<PendingCollections>().ToTable("PendingCollection");

        //builder.Entity<Finance>().HasKey(p => p.Id);
        //builder.Entity<Finance>().Property(p => p.Name).IsRequired().HasMaxLength(25);
        builder.Entity<Crop>().ToTable("Crop");
        builder.Entity<Calendar>().ToTable("Calendar");
        builder.Entity<Adviser>().ToTable("Adviser");

        builder.Entity<User>().ToTable("User");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(p => p.DniOrRuc).IsRequired();
        builder.Entity<User>().Property(p => p.CompanyName).IsRequired();
        builder.Entity<User>().Property(p => p.EmailAddress).IsRequired();
        builder.Entity<User>().Property(p => p.Phone).IsRequired().HasMaxLength(12);
        builder.Entity<User>().Property(p => p.Role).IsRequired().HasMaxLength(20);
        builder.Entity<User>().Property(p => p.PasswordHashed).IsRequired();
        builder.Entity<User>().Property(p => p.ConfirmPassword).IsRequired();
        builder.Entity<User>().Property(p => p.CreateDate).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Entity<User>().Property(p => p.IsActive).IsRequired().HasDefaultValue(true);

        builder.Entity<Pending>().ToTable("Pending");
        builder.Entity<Pending>().HasKey(p => p.Id);
        builder.Entity<Pending>().Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Entity<Pending>().Property(p => p.Description).IsRequired().HasMaxLength(50);
        builder.Entity<Pending>().Property(p => p.DueDate).IsRequired();
        builder.Entity<Pending>().Property(p => p.AssignedTo).IsRequired().HasMaxLength(20);
        builder.Entity<Pending>().Property(p => p.Priority).IsRequired().HasMaxLength(20);
        builder.Entity<Pending>().Property(p => p.Category).IsRequired().HasMaxLength(20);
        builder.Entity<Pending>().Property(p => p.State).IsRequired();
        builder.Entity<Pending>().Property(p => p.CreateDate).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Entity<Pending>().Property(p => p.IsActive).IsRequired().HasDefaultValue(true);
        
        builder.Entity<Employee>().ToTable("Employee");
        builder.Entity<Employee>().HasKey(p => p.Id);
        builder.Entity<Employee>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Employee>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
        builder.Entity<Employee>().Property(p => p.Age).IsRequired();
        builder.Entity<Employee>().Property(p => p.Dni).IsRequired().HasMaxLength(8);
        builder.Entity<Employee>().Property(p => p.Job).IsRequired().HasMaxLength(10);
        builder.Entity<Employee>().Property(p => p.Salary).IsRequired();
        builder.Entity<Employee>().Property(p => p.Phone).IsRequired().HasMaxLength(10);
        builder.Entity<Employee>().Property(p => p.PhotoUrl).IsRequired();
        builder.Entity<Employee>().Property(p => p.TeamId).IsRequired();
        builder.Entity<Employee>().Property(p => p.CreateDate).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Entity<Employee>().Property(p => p.IsActive).IsRequired().HasDefaultValue(true);

    }
}