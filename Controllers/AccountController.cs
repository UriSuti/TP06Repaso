using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06Repaso.Models;

namespace TP06Repaso.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        Usuario usuario = BD.Login(username, password);
        if (usuario is null)
        {
            ViewBag.Mensaje = "No se encuentra esa cuenta, por favor, ingrese los datos de vuelta.";
            return View("Login");
        }
        else
        {
            HttpContext.Session.SetString("Usuario", BD.GetId(username, password).ToString());
            return View("Index2");
        }
    }

    [HttpPost]
    public IActionResult Registro(string username, string password, string nombre, string apellido, string foto, DateTime ultimoLogin)
    {
        BD.Registro(new Usuario(username, password, nombre, apellido, foto, ultimoLogin));
        HttpContext.Session.SetString("Usuario", BD.GetId(username, password).ToString());
        return View("Index2");
    }
}