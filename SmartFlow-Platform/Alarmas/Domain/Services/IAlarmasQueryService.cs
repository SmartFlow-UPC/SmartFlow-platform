using SmartFlow_Platform.Alarmas.Domain.Model.Aggregates;
using SmartFlow_Platform.Alarmas.Domain.Model.Queries;

namespace SmartFlow_Platform.Alarmas.Domain.Services;

public interface IAlarmasQueryService
{
    Task<IEnumerable<Alarma>> Handle(GetAllAlarmasQuery query);
    Task<Alarma?> Handle(GetAlarmaByIdQuery query);
}