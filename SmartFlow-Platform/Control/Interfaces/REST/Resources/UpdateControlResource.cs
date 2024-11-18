namespace SmartFlow_Platform.Control.Interfaces.REST.Resources;
 
public record UpdateControlResource(int Id, string Producto, int Cantidad, double Peso, double Precio);