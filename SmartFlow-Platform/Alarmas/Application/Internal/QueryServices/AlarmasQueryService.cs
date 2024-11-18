using SmartFlow_Platform.Alarmas.Domain.Model.Aggregates;
using SmartFlow_Platform.Alarmas.Domain.Model.Queries;
using SmartFlow_Platform.Alarmas.Domain.Repositories;
using SmartFlow_Platform.Alarmas.Domain.Services;

namespace SmartFlow_Platform.Alarmas.Application.Internal.QueryServices;

public class AlarmasQueryService : IAlarmasQueryService
{
    private readonly IAlarmasRepository _repository;

    public AlarmasQueryService(IAlarmasRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Alarma>> Handle(GetAllAlarmasQuery query)
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Alarma?> Handle(GetAlarmaByIdQuery query)
    {
        return await _repository.GetByIdAsync(query.Id);
    }
}