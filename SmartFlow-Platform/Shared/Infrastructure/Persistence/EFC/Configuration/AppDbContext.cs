using Microsoft.EntityFrameworkCore;
using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;

namespace SmartFlow_Platform;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Registro> Registro { get; set; }
    public DbSet<Control> Control { get; set; }
    public DbSet<Consumos> Consumos { get; set; }
    public DbSet<Alarmas> Alarmas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}