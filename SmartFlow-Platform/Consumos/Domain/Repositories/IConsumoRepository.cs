using SmartFlow_Platform.Consumos.Domain.Model.Aggregates;

namespace SmartFlow_Platform.Consumos.Domain.Repositories;

public interface IConsumoRepository
{
    Task<Consumo?> GetByIdAsync(int id);
    Task<IEnumerable<Consumo>> GetAllAsync();
    Task AddAsync(Consumo consumo);
    Task UpdateAsync(Consumo consumo);
    Task DeleteAsync(int id);
}