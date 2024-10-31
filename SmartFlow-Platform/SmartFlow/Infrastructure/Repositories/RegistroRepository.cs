using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;
using SmartFlow_Platform.SmartFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace SmartFlow_Platform.SmartFlow.Infrastructure.Repositories;

public class RegistroRepository : IRegistroRepository
{
    private readonly AppDbContext _context;

    public RegistroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Registro> GetByIdAsync(int id) => await _context.Registro.FindAsync(id);

    public async Task<IEnumerable<Registro>> GetAllAsync() => await _context.Registro.ToListAsync();

    public async Task AddAsync(Registro registro) 
    {
        await _context.Registro.AddAsync(registro);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Registro registro) 
    {
        _context.Registro.Update(registro);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) 
    {
        var registro = await GetByIdAsync(id);
        if (registro != null) _context.Registro.Remove(registro);
        await _context.SaveChangesAsync();
    }
}