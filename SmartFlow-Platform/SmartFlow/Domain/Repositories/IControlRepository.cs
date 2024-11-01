using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;

namespace SmartFlow_Platform.SmartFlow.Domain.Repositories;

public interface IControlRepository
{
    Task<Control> GetByIdAsync(int id);
    Task<IEnumerable<Control>> GetAllAsync();
    Task AddAsync(Control control);
    Task UpdateAsync(Control control);
    Task DeleteAsync(int id);
}
