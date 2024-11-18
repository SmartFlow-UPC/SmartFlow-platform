namespace SmartFlow_Platform.Consumos.Interfaces.REST.Resources;
 
public record UpdateConsumoResource(int Id, string Aparato, int Cantidad, int PotenciaWatts);