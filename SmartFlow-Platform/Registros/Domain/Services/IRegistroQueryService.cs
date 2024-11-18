using SmartFlow_Platform.Registros.Domain.Model.Aggregates;
using SmartFlow_Platform.Registros.Domain.Model.Queries;

namespace SmartFlow_Platform.Registros.Domain.Services;

public interface IRegistroQueryService
{
    Task<IEnumerable<Registro>> Handle(GetAllRegistrosQuery query);
    Task<Registro?> Handle(GetRegistroByIdQuery query);
}