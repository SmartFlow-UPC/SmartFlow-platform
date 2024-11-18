using SmartFlow_Platform.Alarmas.Domain.Model.Aggregates;
using SmartFlow_Platform.Alarmas.Domain.Model.Commands;

namespace SmartFlow_Platform.Alarmas.Domain.Services;

public interface IAlarmasCommandService
{
    Task<Alarma?> Handle(CreateAlarmaCommand command);
    Task<Alarma?> Handle(UpdateAlarmaCommand command);
    Task<bool> Handle(DeleteAlarmaCommand command);
}