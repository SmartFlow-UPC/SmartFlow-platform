namespace SmartFlow_Platform.Consumos.Domain.Model.Commands;

public record CreateConsumoCommand(string Aparato, int Cantidad, int PotenciaWatts);
