namespace SmartFlow_Platform.Consumos.Interfaces.REST.Resources;
 
public record ConsumoResource(int Id, string Aparato, int Cantidad, int PotenciaWatts, int PotenciaTotal);