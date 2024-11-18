using Microsoft.EntityFrameworkCore;

namespace SmartFlow_Platform.User.Infrastructure;

using Domain.Model.Aggregates;

public class MySqlDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        base.OnModelCreating(modelBuilder);
    }
}