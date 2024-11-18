using SmartFlow_Platform.Alarmas.Domain.Model.Aggregates;

namespace SmartFlow_Platform.Alarmas.Domain.Repositories;

public interface IAlarmasRepository
{
    Task<Alarma?> GetByIdAsync(int id);
    Task<IEnumerable<Alarma>> GetAllAsync();
    Task AddAsync(Alarma alarma);
    Task UpdateAsync(Alarma alarma);
    Task DeleteAsync(int id);
}