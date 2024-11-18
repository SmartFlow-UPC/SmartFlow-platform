using Microsoft.EntityFrameworkCore;
using SmartFlow_Platform.Consumos.Domain.Model.Aggregates;
using SmartFlow_Platform.Consumos.Domain.Repositories;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SmartFlow_Platform.Consumos.Infrastructure.Repositories;

public class ConsumoRepository : IConsumoRepository
{
    private readonly AppDbContext _context;

    public ConsumoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Consumo?> GetByIdAsync(int id)
    {
        return await _context.Consumos.FindAsync(id);
    }

    public async Task<IEnumerable<Consumo>> GetAllAsync()
    {
        return await _context.Consumos.ToListAsync();
    }

    public async Task AddAsync(Consumo consumo)
    {
        await _context.Consumos.AddAsync(consumo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Consumo consumo)
    {
        _context.Consumos.Update(consumo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var consumo = await GetByIdAsync(id);
        if (consumo != null)
        {
            _context.Consumos.Remove(consumo);
            await _context.SaveChangesAsync();
        }
    }
}