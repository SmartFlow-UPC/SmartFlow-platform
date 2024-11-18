namespace SmartFlow_Platform.Consumos.Domain.Model.Commands;

public record UpdateConsumoCommand(int Id, string Aparato, int Cantidad, int PotenciaWatts);
