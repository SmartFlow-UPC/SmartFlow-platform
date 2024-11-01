using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;
using SmartFlow_Platform.SmartFlow.Domain.Repositories;

namespace SmartFlow_Platform.SmartFlow.Application.Internal.CommandServices;
    
public class RegistroCommandService
{
    private readonly IRegistroRepository _registroRepository;

    public RegistroCommandService(IRegistroRepository registroRepository)
    {
        _registroRepository = registroRepository;
    }

    public async Task AddRegistroAsync(Registro registro)
    {
        await _registroRepository.AddAsync(registro);
    }

    public async Task UpdateRegistroAsync(Registro registro)
    {
        await _registroRepository.UpdateAsync(registro);
    }

    public async Task DeleteRegistroAsync(int id)
    {
        await _registroRepository.DeleteAsync(id);
    }
}
