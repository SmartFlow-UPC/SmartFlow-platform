using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;
using SmartFlow_Platform.SmartFlow.Domain.Repositories;

namespace SmartFlow_Platform.SmartFlow.Application.Internal.QueryServices;

public class ControlQueryService
{
    private readonly IControlRepository _controlRepository;

    public ControlQueryService(IControlRepository controlRepository)
    {
        _controlRepository = controlRepository;
    }

    public async Task<Control> GetControlByIdAsync(int id) => await _controlRepository.GetByIdAsync(id);
    
    public async Task<IEnumerable<Control>> GetAllControlAsync() => await _controlRepository.GetAllAsync();
}
