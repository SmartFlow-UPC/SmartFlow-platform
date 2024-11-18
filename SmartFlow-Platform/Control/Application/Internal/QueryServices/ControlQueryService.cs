using SmartFlow_Platform.Control.Domain.Model.Queries;
using SmartFlow_Platform.Control.Domain.Repositories;
using SmartFlow_Platform.Control.Domain.Services;

namespace SmartFlow_Platform.Control.Application.Internal.QueryServices;

using Domain.Model.Aggregates;

public class ControlQueryService : IControlQueryService
{
    private readonly IControlRepository _repository;

    public ControlQueryService(IControlRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Control>> Handle(GetAllControlesQuery query)
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Control?> Handle(GetControlByIdQuery query)
    {
        return await _repository.GetByIdAsync(query.Id);
    }
}