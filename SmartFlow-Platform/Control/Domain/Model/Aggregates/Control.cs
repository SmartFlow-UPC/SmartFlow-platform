namespace SmartFlow_Platform.Control.Domain.Model.Aggregates;

public class Control
{
    public int Id { get; private set; }
    public string Producto { get; private set; }
    public int Cantidad { get; private set; }
    public double Peso { get; private set; }
    public double Precio { get; private set; }

    public Control(string producto, int cantidad, double peso, double precio)
    {
        Producto = producto;
        Cantidad = cantidad;
        Peso = peso;
        Precio = precio;
    }

    public void Update(string producto, int cantidad, double peso, double precio)
    {
        Producto = producto;
        Cantidad = cantidad;
        Peso = peso;
        Precio = precio;
    }
}