namespace aqaframework.DataObjects;

public class User
{
    public string email;
    public string password;

    public User(string email, string password)
    {
        this.email = email;
        this.password = password;
    }

    public User()
    {
        email = "defaultemail@dot.com";
        password = "defaultpassword";
    }
}