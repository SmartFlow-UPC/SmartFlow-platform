namespace SmartFlow_Platform.Alarmas.Interfaces.REST.Resources;

public record AlarmaResource(int Id, string Dispositivo, string Tipo, int Valor, int Umbral, DateTime Fecha, string Estado);
