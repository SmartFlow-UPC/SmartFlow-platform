using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;
using SmartFlow_Platform.SmartFlow.Domain.Repositories;

namespace SmartFlow_Platform.SmartFlow.Application.Internal.CommandServices;

public class AlarmasCommandService
{
    private readonly IAlarmasRepository _alarmasRepository;

    public AlarmasCommandService(IAlarmasRepository alarmasRepository)
    {
        _alarmasRepository = alarmasRepository;
    }

    public async Task AddAlarmasAsync(Alarmas alarmas)
    {
        await _alarmasRepository.AddAsync(alarmas);
    }

    public async Task UpdateAlarmasAsync(Alarmas alarmas)
    {
        await _alarmasRepository.UpdateAsync(alarmas);
    }

    public async Task DeleteAlarmasAsync(int id)
    {
        await _alarmasRepository.DeleteAsync(id);
    }
    
}

