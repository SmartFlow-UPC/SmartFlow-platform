namespace SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;

public class Alarmas
{
    public int Id { get; set; }
    public string Dispositivo { get; set; }
    public string Tipo { get; set; }
    public string Valor { get; set; }
    public string Umbral { get; set; }
    public string Fecha { get; set; }
    public string Estado { get; set; }
}
