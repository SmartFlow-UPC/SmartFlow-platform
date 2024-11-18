using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using SmartFlow_Platform.Registros.Domain.Model.Aggregates;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

using User.Domain.Model.Aggregates;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configuration for User entity
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.Entity<User>().Property(u => u.Password).IsRequired();

        // Configura las convenciones de nombres en snake_case
        builder.UseSnakeCaseNamingConvention();
    }

    // Add DbSet for User
    public DbSet<User> Users { get; set; }
    public DbSet<Registro> Registros { get; set; }

}