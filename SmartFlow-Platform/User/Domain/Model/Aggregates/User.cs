namespace SmartFlow_Platform.User.Domain.Model.Aggregates;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public User(string name, string lastName, string email, string password)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public void Update(string name, string lastName, string email)
    {
        Name = name;
        LastName = lastName;
        Email = email;
    }
}