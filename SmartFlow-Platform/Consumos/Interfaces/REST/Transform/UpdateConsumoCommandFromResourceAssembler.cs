using SmartFlow_Platform.Consumos.Domain.Model.Commands;
using SmartFlow_Platform.Consumos.Interfaces.REST.Resources;

namespace SmartFlow_Platform.Consumos.Interfaces.REST.Transform;

public static class UpdateConsumoCommandFromResourceAssembler
{
    public static UpdateConsumoCommand ToCommandFromResource(UpdateConsumoResource resource) =>
        new UpdateConsumoCommand(resource.Id, resource.Aparato, resource.Cantidad, resource.PotenciaWatts);
}