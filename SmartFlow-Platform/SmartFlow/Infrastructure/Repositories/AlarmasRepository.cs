using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;
using SmartFlow_Platform.SmartFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SmartFlow_Platform.SmartFlow.Infrastructure.Repositories;

public class AlarmasRepository : IAlarmasRepository
{
    private readonly AppDbContext _context;

    public AlarmasRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Alarmas> GetByIdAsync(int id) => await _context.Alarmas.FindAsync(id);

    public async Task<IEnumerable<Alarmas>> GetAllAsync() => await _context.Alarmas.ToListAsync();
    
    public async Task AddAsync(Alarmas alarmas) 
    {
        await _context.Alarmas.AddAsync(alarmas);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Alarmas alarmas) 
    {
        _context.Alarmas.Update(alarmas);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) 
    {
        var alarmas = await GetByIdAsync(id);
        if (alarmas != null) _context.Alarmas.Remove(alarmas);
        await _context.SaveChangesAsync();
    }
}

