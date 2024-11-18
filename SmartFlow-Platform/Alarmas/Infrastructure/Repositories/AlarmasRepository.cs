using Microsoft.EntityFrameworkCore;
using SmartFlow_Platform.Alarmas.Domain.Model.Aggregates;
using SmartFlow_Platform.Alarmas.Domain.Repositories;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SmartFlow_Platform.Alarmas.Infrastructure.Repositories;

public class AlarmasRepository : IAlarmasRepository
{
    private readonly AppDbContext _context;

    public AlarmasRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Alarma?> GetByIdAsync(int id)
    {
        return await _context.Alarmas.FindAsync(id);
    }

    public async Task<IEnumerable<Alarma>> GetAllAsync()
    {
        return await _context.Alarmas.ToListAsync();
    }

    public async Task AddAsync(Alarma alarma)
    {
        await _context.Alarmas.AddAsync(alarma);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Alarma alarma)
    {
        _context.Alarmas.Update(alarma);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var alarma = await GetByIdAsync(id);
        if (alarma != null)
        {
            _context.Alarmas.Remove(alarma);
            await _context.SaveChangesAsync();
        }
    }
}