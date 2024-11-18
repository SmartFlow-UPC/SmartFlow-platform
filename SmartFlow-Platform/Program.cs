using Microsoft.EntityFrameworkCore;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using SmartFlow_Platform.Shared.Domain.Repositories;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using SmartFlow_Platform.User.Application.Internal.CommandServices;
using SmartFlow_Platform.User.Application.Internal.QueryServices;
using SmartFlow_Platform.User.Domain.Repositories;
using SmartFlow_Platform.User.Domain.Services;
using SmartFlow_Platform.User.Infrastructure.Repositories;
using SmartFlow_Platform.Alarmas.Application.Internal.CommandServices;
using SmartFlow_Platform.Alarmas.Application.Internal.QueryServices;
using SmartFlow_Platform.Alarmas.Domain.Repositories;
using SmartFlow_Platform.Alarmas.Domain.Services;
using SmartFlow_Platform.Alarmas.Infrastructure.Repositories;
using SmartFlow_Platform.Consumos.Application.Internal.CommandServices;
using SmartFlow_Platform.Consumos.Application.Internal.QueryServices;
using SmartFlow_Platform.Consumos.Domain.Repositories;
using SmartFlow_Platform.Consumos.Domain.Services;
using SmartFlow_Platform.Consumos.Infrastructure.Repositories;
using SmartFlow_Platform.Control.Application.Internal.CommandServices;
using SmartFlow_Platform.Control.Application.Internal.QueryServices;
using SmartFlow_Platform.Control.Domain.Repositories;
using SmartFlow_Platform.Control.Domain.Services;
using SmartFlow_Platform.Control.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure routing and controllers
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddAuthorization();
builder.Services.AddControllers();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database connection configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString is null)
    throw new Exception("Database connection string is not set.");

builder.Services.AddDbContext<AppDbContext>(
    (DbContextOptionsBuilder options) =>
    {
        options.UseMySql(
            connectionString,
            new MySqlServerVersion(new Version(8, 0, 30)) // Cambia la versión según tu servidor
        );
    });

// Dependency Injection Configuration
// Shared Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// User Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();

// Alarma Services
builder.Services.AddScoped<IAlarmasRepository, AlarmasRepository>();
builder.Services.AddScoped<IAlarmasCommandService, AlarmasCommandService>();
builder.Services.AddScoped<IAlarmasQueryService, AlarmasQueryService>();

// Consumo Services
builder.Services.AddScoped<IConsumoRepository, ConsumoRepository>();
builder.Services.AddScoped<IConsumoCommandService, ConsumoCommandService>();
builder.Services.AddScoped<IConsumoQueryService, ConsumoQueryService>();

// Control Services
builder.Services.AddScoped<IControlRepository, ControlRepository>();
builder.Services.AddScoped<IControlCommandService, ControlCommandService>();
builder.Services.AddScoped<IControlQueryService, ControlQueryService>();

var app = builder.Build();

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
