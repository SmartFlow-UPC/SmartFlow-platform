namespace SmartFlow_Platform.Alarmas.Interfaces.REST.Resources;

public record UpdateAlarmaResource(int Id, string Dispositivo, string Tipo, int Valor, int Umbral, DateTime Fecha, string Estado);
