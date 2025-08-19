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
        return View();
    }

    public IActionResult VerTarea(int id)
    {
        Tarea tarea = BD.VerTarea(id);
        ViewBag.Tarea = tarea;
        return View();
    }

    public IActionResult AgregarTarea(string titulo, string descripcion, DateTime fecha, bool finalizada)
    {
        BD.AgregarTarea(new Tarea(titulo, descripcion, fecha, false, int.Parse(HttpContext.Session.GetString("Usuario"))));
        return View("VerTarea");
    }

    public IActionResult EliminarTarea(int id)
    {
        int eliminado = BD.EliminarTarea(id);
        return View("VerTareas");
    }

    public IActionResult FinalizarTarea(int id)
    {
        BD.FinalizarTarea(id);
        return View("VerTarea");
    }

    public IActionResult ModificarTarea(string titulo, string descripcion, DateTime fecha, bool finalizada, int id)
    {
        BD.ActualizarTarea(new Tarea(titulo, descripcion, fecha, finalizada, int.Parse(HttpContext.Session.GetString("Usuario"))), id);
        return View("VerTarea");
    }
}
