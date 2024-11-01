using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;
using SmartFlow_Platform.SmartFlow.Domain.Repositories;

namespace SmartFlow_Platform.SmartFlow.Application.Internal.QueryServices;

public class RegistroQueryService
{
    private readonly IRegistroRepository _registroRepository;

    public RegistroQueryService(IRegistroRepository registroRepository)
    {
        _registroRepository = registroRepository;
    }

    public async Task<Registro> GetRegistroByIdAsync(int id)
    {
        return await _registroRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Registro>> GetAllRegistroAsync()
    {
        return await _registroRepository.GetAllAsync();
    }
}
