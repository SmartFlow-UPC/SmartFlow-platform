namespace SmartFlow_Platform.Consumos.Domain.Model.Aggregates;

public class Consumo
{
    public int Id { get; private set; }
    public string Aparato { get; private set; }
    public int Cantidad { get; private set; }
    public int PotenciaWatts { get; private set; }
    public int PotenciaTotal { get; private set; }

    public Consumo(string aparato, int cantidad, int potenciaWatts)
    {
        Aparato = aparato;
        Cantidad = cantidad;
        PotenciaWatts = potenciaWatts;
        PotenciaTotal = Cantidad * PotenciaWatts;
    }

    public void Update(string aparato, int cantidad, int potenciaWatts)
    {
        Aparato = aparato;
        Cantidad = cantidad;
        PotenciaWatts = potenciaWatts;
        PotenciaTotal = Cantidad * PotenciaWatts;
    }
}