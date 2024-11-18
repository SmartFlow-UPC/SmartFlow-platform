using Microsoft.EntityFrameworkCore;
using SmartFlow_Platform.Control.Domain.Repositories;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SmartFlow_Platform.Control.Infrastructure.Repositories;

using Domain.Model.Aggregates;

public class ControlRepository : IControlRepository
{
    private readonly AppDbContext _context;

    public ControlRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Control?> GetByIdAsync(int id)
    {
        return await _context.Controles.FindAsync(id);
    }

    public async Task<IEnumerable<Control>> GetAllAsync()
    {
        return await _context.Controles.ToListAsync();
    }

    public async Task AddAsync(Control control)
    {
        await _context.Controles.AddAsync(control);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Control control)
    {
        _context.Controles.Update(control);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var control = await GetByIdAsync(id);
        if (control != null)
        {
            _context.Controles.Remove(control);
            await _context.SaveChangesAsync();
        }
    }
}