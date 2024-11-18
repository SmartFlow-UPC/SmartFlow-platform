using SmartFlow_Platform.Consumos.Domain.Model.Commands;
using SmartFlow_Platform.Consumos.Interfaces.REST.Resources;

namespace SmartFlow_Platform.Consumos.Interfaces.REST.Transform;

public static class CreateConsumoCommandFromResourceAssembler
{
    public static CreateConsumoCommand ToCommandFromResource(CreateConsumoResource resource) =>
        new CreateConsumoCommand(resource.Aparato, resource.Cantidad, resource.PotenciaWatts);
}