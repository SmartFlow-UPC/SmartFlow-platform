using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;
using SmartFlow_Platform.SmartFlow.Domain.Repositories;

namespace SmartFlow_Platform.SmartFlow.Application.Internal.QueryServices;

public class AlarmasQueryService
{
    private readonly IAlarmasRepository _alarmasRepository;

    public AlarmasQueryService(IAlarmasRepository alarmasRepository)
    {
        _alarmasRepository = alarmasRepository;
    }

    public async Task<Alarmas> GetAlarmasByIdAsync(int id)
    {
        return await _alarmasRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Alarmas>> GetAllAlarmasAsync()
    {
        return await _alarmasRepository.GetAllAsync();
    }
    
}
