using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;
using SmartFlow_Platform.SmartFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SmartFlow_Platform.SmartFlow.Infrastructure.Repositories;

public class ControlRepository
{
    private readonly AppDbContext _context;

    public ControlRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Control> GetByIdAsync(int id) => await _context.Control.FindAsync(id);
    
    public async Task<IEnumerable<Control>> GetAllAsync() => await _context.Control.ToListAsync();

    public async Task AddAsync(Control control) 
    {
        await _context.Control.AddAsync(control);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Control control) 
    {
        _context.Control.Update(control);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) 
    {
        var control = await GetByIdAsync(id);
        if (control != null) _context.Control.Remove(control);
        await _context.SaveChangesAsync();
    }
}