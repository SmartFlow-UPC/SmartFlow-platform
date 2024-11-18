using SmartFlow_Platform.Consumos.Domain.Model.Aggregates;
using SmartFlow_Platform.Consumos.Domain.Model.Queries;
using SmartFlow_Platform.Consumos.Domain.Repositories;
using SmartFlow_Platform.Consumos.Domain.Services;

namespace SmartFlow_Platform.Consumos.Application.Internal.QueryServices;

public class ConsumoQueryService : IConsumoQueryService
{
    private readonly IConsumoRepository _repository;

    public ConsumoQueryService(IConsumoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Consumo>> Handle(GetAllConsumosQuery query)
    {
        return await _repository.GetAllAsync();
    }
    
    public async Task<Consumo?> Handle(GetConsumoByIdQuery query)
    {
        return await _repository.GetByIdAsync(query.Id);
    }
}