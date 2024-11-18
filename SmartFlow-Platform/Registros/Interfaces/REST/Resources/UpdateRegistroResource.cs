namespace SmartFlow_Platform.Registros.Interfaces.REST.Resources;

public record UpdateRegistroResource(int Id, string Title, string Description, bool Alto, string Status);
