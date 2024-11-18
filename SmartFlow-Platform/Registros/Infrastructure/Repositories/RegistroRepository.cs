using Microsoft.EntityFrameworkCore;
using SmartFlow_Platform.Registros.Domain.Model.Aggregates;
using SmartFlow_Platform.Registros.Domain.Repositories;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SmartFlow_Platform.Registros.Infrastructure.Repositories;

public class RegistroRepository : IRegistroRepository
{
    private readonly AppDbContext _context;

    public RegistroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Registro?> GetByIdAsync(int id)
    {
        return await _context.Registros.FindAsync(id);
    }

    public async Task<IEnumerable<Registro>> GetAllAsync()
    {
        return await _context.Registros.ToListAsync();
    }

    public async Task AddAsync(Registro registro)
    {
        await _context.Registros.AddAsync(registro);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Registro registro)
    {
        _context.Registros.Update(registro);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var registro = await GetByIdAsync(id);
        if (registro != null)
        {
            _context.Registros.Remove(registro);
            await _context.SaveChangesAsync();
        }
    }
}