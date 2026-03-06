namespace Lab5.Infrastructure.Persistence.Sessions;

public class AdminPassword
{
    public string Password { get; }

    public AdminPassword(string password)
    {
        Password = password;
    }

    public AdminPassword()
    {
        Password = "admin";
    }
}