using SmartFlow_Platform.Consumos.Domain.Model.Aggregates;
using SmartFlow_Platform.Consumos.Domain.Model.Queries;

namespace SmartFlow_Platform.Consumos.Domain.Services;

public interface IConsumoQueryService
{
    Task<IEnumerable<Consumo>> Handle(GetAllConsumosQuery query);
    
    Task<Consumo?> Handle(GetConsumoByIdQuery query);
}