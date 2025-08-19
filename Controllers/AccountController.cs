using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06Repaso.Models;

namespace TP06Repaso.Controllers;

public class AccountController : Controller
{
    private readonly IWebHostEnvironment _env;

    public AccountController(IWebHostEnvironment env)
    {
        _env = env;
    }

    public IActionResult irLogin()
    {
        return View("Login");
    }

    public IActionResult irRegistro()
    {
        return View("Registro");
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        Usuario usuario = BD.Login(username, password);
        if (usuario is null)
        {
            ViewBag.Mensaje = "No se encuentra esa cuenta, por favor, ingrese los datos de vuelta.";
            return View();
        }
        else
        {
            HttpContext.Session.SetString("Usuario", BD.GetId(username, password).ToString());
            return RedirectToAction("VerTareas", "Home");
        }
    }

    [HttpPost]
    public IActionResult Registro(string username, string password, string nombre, string apellido, IFormFile foto)
    {
        string nombreFoto = foto.FileName;
        string rutaCarpeta = Path.Combine(_env.WebRootPath, "imagenes");
        if (!Directory.Exists(rutaCarpeta))
            Directory.CreateDirectory(rutaCarpeta);
        string rutaCompleta = Path.Combine(rutaCarpeta, nombreFoto);
        BD.Registro(new Usuario(username, password, nombre, apellido, rutaCompleta));
        HttpContext.Session.SetString("Usuario", BD.GetId(username, password).ToString());
        return RedirectToAction("VerTareas", "Home");
    }

    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}