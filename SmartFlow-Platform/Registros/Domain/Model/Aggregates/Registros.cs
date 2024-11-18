namespace SmartFlow_Platform.Registros.Domain.Model.Aggregates;

public class Registro
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool Alto { get; private set; }
    public string Status { get; private set; }

    public Registro(string title, string description, bool alto, string status)
    {
        Title = title;
        Description = description;
        Alto = alto;
        Status = status;
    }

    public void Update(string title, string description, bool alto, string status)
    {
        Title = title;
        Description = description;
        Alto = alto;
        Status = status;
    }
}