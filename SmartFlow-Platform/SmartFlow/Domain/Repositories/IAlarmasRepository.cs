using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;

namespace SmartFlow_Platform.SmartFlow.Domain.Repositories;
public interface IAlarmasRepository
{
    Task<Alarmas> GetByIdAsync(int id);
    Task<IEnumerable<Alarmas>> GetAllAsync();
    Task AddAsync(Alarmas alarmas);
    Task UpdateAsync(Alarmas alarmas);
    Task DeleteAsync(int id);
}
