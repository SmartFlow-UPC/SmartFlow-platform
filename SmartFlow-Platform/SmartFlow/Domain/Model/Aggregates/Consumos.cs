namespace SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;

public class Consumos
{
    public int Id { get; set; }
    public string Aparato { get; set; }
    public string Cantidad { get; set; }
    public string Potencia_watts { get; set; }
    public string Potencia_total { get; set; }
    public string Encendido { get; set; }
    public string Status { get; set; }
}
