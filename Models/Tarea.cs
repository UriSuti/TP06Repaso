namespace TP06Repaso.Models;

public class Tarea 
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Descripcion { get; private set; }
    public DateTime Fecha { get; private set; }
    public bool Finalizada { get; private set; }
    public string Username { get; private set; }

    public Tarea (int Id, string Titulo, string Descripcion, DateTime Fecha, bool Finalizada, int IdUsuario)
    {
        this.Id = Id;
        this.Titulo = Titulo;
        this.Descripcion = Descripcion;
        this.Fecha = Fecha;
        this.Finalizada = Finalizada;
        this.IdUsuario = IdUsuario;
    }
}