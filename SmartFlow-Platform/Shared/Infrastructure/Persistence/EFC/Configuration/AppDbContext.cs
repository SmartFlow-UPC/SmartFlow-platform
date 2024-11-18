using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using SmartFlow_Platform.Consumos.Domain.Model.Aggregates;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

using User.Domain.Model.Aggregates;
using SmartFlow_Platform.Alarmas.Domain.Model.Aggregates;

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

        builder.Entity<Alarma>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Dispositivo).IsRequired().HasMaxLength(255);
            entity.Property(a => a.Tipo).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Valor).IsRequired();
            entity.Property(a => a.Umbral).IsRequired();
            entity.Property(a => a.Fecha).IsRequired();
            entity.Property(a => a.Estado).IsRequired().HasMaxLength(50);
        });

        // Use snake_case naming convention for database objects
        builder.UseSnakeCaseNamingConvention();
    }

    // DbSet for User
    public DbSet<User> Users { get; set; }

    // DbSet for Alarma
    public DbSet<Alarma> Alarmas { get; set; }
    
    // DbSet for Consumos
    public DbSet<Consumo> Consumos { get; set; }
}
