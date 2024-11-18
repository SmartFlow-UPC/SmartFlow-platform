namespace SmartFlow_Platform.Control.Domain.Model.Commands;

public record CreateControlCommand(string Producto, int Cantidad, double Peso, double Precio);
