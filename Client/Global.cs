using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Microsoft.JSInterop;
namespace lda.Client;

public interface IGlobal
{
    public string get_user();
    public string get_jwt();

    public void set_user(string _user);
    public void set_jwt(string _user);

    public void reset_user();
    public void reset_jwt();
}

public class Global : IGlobal
{
    private string user;
    private string jwt;
    
    private IJSInProcessRuntime jsr;

    public Global(IJSInProcessRuntime _jsr)
    {
        jsr = _jsr;

        var _user = jsr.Invoke<string>("sessionStorage.getItem", "user");
        var _jwt = jsr.Invoke<string>("sessionStorage.getItem", "jwt");

        user = String.IsNullOrEmpty(_user) ? String.Empty : _user;
        jwt = String.IsNullOrEmpty(_jwt) ? String.Empty : _jwt;
    }

    public string get_user()
    {
        return user;
    }

    public string get_jwt()
    {
        return jwt;
    }

    public void set_user(string _user)
    {
        user = _user;
    }

    public void set_jwt(string _jwt)
    {
        jwt = _jwt;
    }

    public void reset_user()
    {
        user = String.Empty;
    }

    public void reset_jwt()
    {
        jwt = String.Empty;
    }
}