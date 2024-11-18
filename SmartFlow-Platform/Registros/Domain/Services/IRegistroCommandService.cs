using SmartFlow_Platform.Registros.Domain.Model.Aggregates;
using SmartFlow_Platform.Registros.Domain.Model.Commands;

namespace SmartFlow_Platform.Registros.Domain.Services;

public interface IRegistroCommandService
{
    Task<Registro?> Handle(CreateRegistroCommand command);
    Task<Registro?> Handle(UpdateRegistroCommand command);
    Task<bool> Handle(DeleteRegistroCommand command);
}