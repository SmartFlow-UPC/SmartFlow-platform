using SmartFlow_Platform.Alarmas.Domain.Model.Commands;
using SmartFlow_Platform.Alarmas.Interfaces.REST.Resources;

namespace SmartFlow_Platform.Alarmas.Interfaces.REST.Transform;

public static class UpdateAlarmaCommandFromResourceAssembler
{
    public static UpdateAlarmaCommand ToCommandFromResource(int id, UpdateAlarmaResource resource) =>
        new UpdateAlarmaCommand(id, resource.Dispositivo, resource.Tipo, resource.Valor, resource.Umbral, resource.Fecha, resource.Estado);
}