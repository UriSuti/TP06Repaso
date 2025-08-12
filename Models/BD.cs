//dotnet add package Microsoft.AspNetCore.Session
//dotnet add package NewtonSoft.Json
//dotnet add package Microsoft.Data.SqlClient
//dotnet add package Dapper

using Microsoft.Data.SqlClient;
using Dapper;

namespace TP06Repaso.Models;

public static class BD
{
    private static string _connectionString = @"Server=localhost;DataBase=TP06Repaso;IntegratedSecurity=True;TrustServerCertificate=True;";

    public static Usuario Login(string usuario, string password)
    {
        Usuario user = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Username FROM Usuarios WHERE Username = @pUsuario AND Password = @pPassword";
            user = connection.QueryFirstOrDefault<Usuario>(query, new { pUsuario = usuario, pPassword = password });
        }
        return user;
    }

    public static void Registro(Usuario usuario)
    {
        string query = "INSERT INTO Usuarios (Username, Password, Nombre, Apellido, Foto, UltimoLogin) VALUES (@pUsername, @pPassword, @pNombre, @pApellido, @pFoto, @pUltimoLogin)";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { pUsername = usuario.username, pPassword = usuario.password, pNombre = usuario.nombre, pApellido = usuario.apellido, pFoto = usuario.foto, pUltimoLogin = usuario.ultimoLogin });
        }
    }

    public static void AgregarTarea(Tarea tarea)
    {
        string query = "INSERT INTO Tareas (Titulo, Descripcion, Fecha, Finalizada, Username) VALUES (@pTitulo, @pDescripcion, @pFecha, @pFinalizada, @pUsername)";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { pTitulo = tarea.titulo, pDescripcion = tarea.descripcion, pFecha = tarea.fecha, @pFinalizada = tarea.finalizada, @pUsername = tarea.username });
        }
    }
}