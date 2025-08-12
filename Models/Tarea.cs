namespace TP06Repaso.Models;

public class Tarea 
{
    public string titulo { get; private set; }
    public string descripcion { get; private set; }
    public DateTime fecha { get; private set; }
    public bool finalizada { get; private set; }
    public string username { get; private set; }

    public Tarea (string titulo, string descripcion, DateTime fecha, bool finalizada, string username)
    {
        this.titulo = titulo;
        this.descripcion = descripcion;
        this.fecha = fecha;
        this.finalizada = finalizada;
        this.username = username;
    }
}