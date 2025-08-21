using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06Repaso.Models;

namespace TP06Repaso.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult VerTareas()
    {
        List<Tarea> tareas = BD.VerTareas(int.Parse(HttpContext.Session.GetString("Usuario")));
        ViewBag.Tareas = tareas;
        ViewBag.Usuario = BD.GetUsuario(int.Parse(HttpContext.Session.GetString("Usuario")));
        return View();
    }

    public IActionResult VerTarea(int id)
    {
        Tarea tarea = BD.VerTarea(id);
        ViewBag.Tarea = tarea;
        return View();
    }

    [HttpPost]
    public IActionResult AgregarTarea(string titulo, string descripcion, DateTime fecha)
    {
        BD.AgregarTarea(new Tarea(titulo, descripcion, fecha, false, int.Parse(HttpContext.Session.GetString("Usuario"))));
        return RedirectToAction("VerTareas");
    }

    public IActionResult irAgregarTarea()
    {
        return View("AgregarTarea");
    }

    public IActionResult EliminarTarea(int id)
    {
        int eliminado = BD.EliminarTarea(id);
        return RedirectToAction("VerTareas");
    }

    public IActionResult FinalizarTarea(int idTarea)
    {
        BD.FinalizarTarea(idTarea);
        return RedirectToAction("VerTarea", new { id = idTarea });
    }

    public IActionResult ModificarTarea(string titulo, string descripcion, DateTime fecha, int idTarea)
    {
        BD.ActualizarTarea(new Tarea(titulo, descripcion, fecha, false, int.Parse(HttpContext.Session.GetString("Usuario"))), idTarea);
        return RedirectToAction("VerTarea", new { id = idTarea });
    }
}
