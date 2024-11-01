using SmartFlow_Platform.Shared.Domain.Repositories;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}