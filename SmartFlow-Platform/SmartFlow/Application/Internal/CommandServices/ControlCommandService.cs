using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;
using SmartFlow_Platform.SmartFlow.Domain.Repositories;

namespace SmartFlow_Platform.SmartFlow.Application.Internal.CommandServices;

public class ControlCommandService
{
    private readonly IControlRepository _controlRepository;

    public ControlCommandService(IControlRepository controlRepository)
    {
        _controlRepository = controlRepository;
    }

    public async Task AddControlAsync(Control control) => await _controlRepository.AddAsync(control);
    
    public async Task UpdateControlAsync(Control control) => await _controlRepository.UpdateAsync(control);
    
    public async Task DeleteControlAsync(int id) => await _controlRepository.DeleteAsync(id);
}
