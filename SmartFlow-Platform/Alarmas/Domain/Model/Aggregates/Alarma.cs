namespace SmartFlow_Platform.Alarmas.Domain.Model.Aggregates;

public class Alarma
{
    public int Id { get; private set; }
    public string Dispositivo { get; private set; }
    public string Tipo { get; private set; }
    public int Valor { get; private set; }
    public int Umbral { get; private set; }
    public DateTime Fecha { get; private set; }
    public string Estado { get; private set; }

    public Alarma(string dispositivo, string tipo, int valor, int umbral, DateTime fecha, string estado)
    {
        Dispositivo = dispositivo;
        Tipo = tipo;
        Valor = valor;
        Umbral = umbral;
        Fecha = fecha;
        Estado = estado;
    }

    public void Update(string dispositivo, string tipo, int valor, int umbral, DateTime fecha, string estado)
    {
        Dispositivo = dispositivo;
        Tipo = tipo;
        Valor = valor;
        Umbral = umbral;
        Fecha = fecha;
        Estado = estado;
    }
}