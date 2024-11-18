using SmartFlow_Platform.Registros.Domain.Model.Aggregates;
using SmartFlow_Platform.Registros.Domain.Model.Queries;
using SmartFlow_Platform.Registros.Domain.Repositories;
using SmartFlow_Platform.Registros.Domain.Services;

namespace SmartFlow_Platform.Registros.Application.Internal.QueryServices;

public class RegistroQueryService : IRegistroQueryService
{
    private readonly IRegistroRepository _repository;

    public RegistroQueryService(IRegistroRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Registro>> Handle(GetAllRegistrosQuery query)
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Registro?> Handle(GetRegistroByIdQuery query)
    {
        return await _repository.GetByIdAsync(query.Id);
    }
}