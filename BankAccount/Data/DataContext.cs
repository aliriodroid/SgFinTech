using Microsoft.EntityFrameworkCore;

namespace BankAccount.Data;

public class DataContext:DbContext
{
    public DataContext(){}

    public DataContext(DbContextOptions<DataContext> options ){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }
    
    public DbSet<Entities.BankAccount> BankAccounts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Entities.BankAccount>(entity =>
        {
            entity.Property(p => p.UserId).IsRequired();
            entity.Property(p => p.Currency).IsRequired();
            entity.Property(p => p.Amount).HasDefaultValue(0);
            entity.Property(p => p.Cbu).IsRequired();
            entity.Property(p => p.Status).IsRequired();
            entity.Property(p => p.CreatedAt).HasDefaultValue(DateTime.Now);
            entity.Property(p => p.UpdatedAt).IsRequired(false);
            entity.Property(p => p.DeletedAt).IsRequired(false);
        });

    }
    
}