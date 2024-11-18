using Microsoft.EntityFrameworkCore;
using SmartFlow_Platform.Control.Application.Internal.CommandServices;
using SmartFlow_Platform.Control.Application.Internal.QueryServices;
using SmartFlow_Platform.Control.Domain.Repositories;
using SmartFlow_Platform.Control.Domain.Services;
using SmartFlow_Platform.Control.Infrastructure.Repositories;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using SmartFlow_Platform.Shared.Domain.Repositories;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using SmartFlow_Platform.User.Application.Internal.CommandServices;
using SmartFlow_Platform.User.Application.Internal.QueryServices;
using SmartFlow_Platform.User.Domain.Repositories;
using SmartFlow_Platform.User.Domain.Services;
using SmartFlow_Platform.User.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();

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

// Registrar servicios de autorización si es necesario
builder.Services.AddAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();