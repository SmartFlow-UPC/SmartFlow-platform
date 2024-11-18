using SmartFlow_Platform.Consumos.Domain.Model.Aggregates;
using SmartFlow_Platform.Consumos.Domain.Model.Commands;

namespace SmartFlow_Platform.Consumos.Domain.Services;

public interface IConsumoCommandService
{
    Task<Consumo?> Handle(CreateConsumoCommand command);
    Task<Consumo?> Handle(UpdateConsumoCommand command);
    Task<bool> Handle(DeleteConsumoCommand command);
}