namespace TP06Repaso.Models;

public class Usuario
{
    public string username { get; private set; }
    public string password { get; private set; }
    public string nombre { get; private set; }
    public string apellido { get; private set; }
    public string foto { get; private set; }
    public DateTime ultimoLogin { get; private set; }

    public Usuario(string username, string password, string nombre, string apellido, string foto, DateTime ultimoLogin)
    {
        this.username = username;
        this.password = password;
        this.nombre = nombre;
        this.apellido = apellido;
        this.foto = foto;
        this.ultimoLogin = ultimoLogin;
    }
}