namespace SmartFlow_Platform.Alarmas.Domain.Model.Commands;

public record CreateAlarmaCommand(string Dispositivo, string Tipo, int Valor, int Umbral, DateTime Fecha, string Estado);
