namespace TP06Repaso.Models;

public class Tarea 
{
    public string Titulo { get; private set; }
    public string Descripcion { get; private set; }
    public DateTime Fecha { get; private set; }
    public bool Finalizada { get; private set; }
    public int IdUsuario { get; private set; }

    public Tarea (string Titulo, string Descripcion, DateTime Fecha, bool Finalizada, int IdUsuario)
    {
        this.Titulo = Titulo;
        this.Descripcion = Descripcion;
        this.Fecha = Fecha;
        this.Finalizada = Finalizada;
        this.IdUsuario = IdUsuario;
    }

    public int getId () { return BD.GetIdTarea(new Tarea(this.Titulo, this.Descripcion, this.Fecha, this.Finalizada, this.IdUsuario)); }
}