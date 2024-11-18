using SmartFlow_Platform.Consumos.Domain.Model.Aggregates;
using SmartFlow_Platform.Consumos.Interfaces.REST.Resources;

namespace SmartFlow_Platform.Consumos.Interfaces.REST.Transform;

public static class ConsumoResourceFromEntityAssembler
{
    public static ConsumoResource ToResourceFromEntity(Consumo entity) =>
        new ConsumoResource(entity.Id, entity.Aparato, entity.Cantidad, entity.PotenciaWatts, entity.PotenciaTotal);
}