namespace lda.Server;
using System.Security.Cryptography;
using System.Text;

public class User
{
    public string Email { get; }
    public User(string email)
    {
        Email = email;
    }
}
public interface IUserDatabase
{
    Task<User> AuthenticateUser(string email, string password);
    Task<User> AddUser(string email, string password);
}
public class UserDatabase : IUserDatabase
{
    private readonly IWebHostEnvironment env;
    public UserDatabase(IWebHostEnvironment env) => this.env = env;

    private static string email = "aaa@gmail.com";
    private static string password = "bbb";
    
    public async Task<User> AuthenticateUser(string _email, string _password)
    {
        if (email != _email || password != _password) return null;
        else return new User(email);
    }
    public async Task<User> AddUser(string _email, string _password)
    {
        email = _email;
        password = _password;

        return new User(email);
    }
}