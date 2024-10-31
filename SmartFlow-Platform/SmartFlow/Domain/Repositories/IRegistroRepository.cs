using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;

namespace SmartFlow_Platform.SmartFlow.Domain.Repositories;
public interface IRegistroRepository
{
    Task<Registro> GetByIdAsync(int id);
    Task<IEnumerable<Registro>> GetAllAsync();
    Task AddAsync(Registro registro);
    Task UpdateAsync(Registro registro);
    Task DeleteAsync(int id);
}
