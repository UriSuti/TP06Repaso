namespace TP06Repaso.Models;

public class Usuario
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public string Foto { get; private set; }

    public Usuario(string Username, string Password, string Nombre, string Apellido, string Foto)
    {
        this.Username = Username;
        this.Password = Password;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Foto = Foto;
    }
}