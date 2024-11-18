namespace SmartFlow_Platform.Control.Domain.Model.Commands;

public record UpdateControlCommand(int Id, string Producto, int Cantidad, double Peso, double Precio);
