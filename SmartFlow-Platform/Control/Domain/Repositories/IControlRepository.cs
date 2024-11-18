namespace SmartFlow_Platform.Control.Domain.Repositories;

using Model.Aggregates;

public interface IControlRepository
{
    Task<Control?> GetByIdAsync(int id);
    Task<IEnumerable<Control>> GetAllAsync();
    Task AddAsync(Control control);
    Task UpdateAsync(Control control);
    Task DeleteAsync(int id);
}