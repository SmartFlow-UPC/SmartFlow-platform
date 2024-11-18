using SmartFlow_Platform.Alarmas.Domain.Model.Commands;
using SmartFlow_Platform.Alarmas.Interfaces.REST.Resources;

namespace SmartFlow_Platform.Alarmas.Interfaces.REST.Transform;

public static class CreateAlarmaCommandFromResourceAssembler
{
    public static CreateAlarmaCommand ToCommandFromResource(CreateAlarmaResource resource) =>
        new CreateAlarmaCommand(resource.Dispositivo, resource.Tipo, resource.Valor, resource.Umbral, resource.Fecha, resource.Estado);
}