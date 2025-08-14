//dotnet add package Microsoft.AspNetCore.Session
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
            string query = "SELECT Id FROM Usuarios WHERE Username = @pUsuario AND Password = @pPassword";
            user = connection.QueryFirstOrDefault<Usuario>(query, new { pUsuario = usuario, pPassword = password });
        }
        return user;
    }

    public static void Registro(Usuario usuario)
    {
        string query = "INSERT INTO Usuarios (Username, Password, Nombre, Apellido, Foto, UltimoLogin) VALUES (@pId, @pUsername, @pPassword, @pNombre, @pApellido, @pFoto, @pUltimoLogin)";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { pUsername = usuario.Username, pPassword = usuario.Password, pNombre = usuario.Nombre, pApellido = usuario.Apellido, pFoto = usuario.Foto, pUltimoLogin = usuario.UltimoLogin });
        }
    }

    public static void AgregarTarea(Tarea tarea)
    {
        string query = "INSERT INTO Tareas (Titulo, Descripcion, Fecha, Finalizada, IdUsername) VALUES (@pId, @pTitulo, @pDescripcion, @pFecha, @pFinalizada, @pUsername)";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { pTitulo = tarea.Titulo, pDescripcion = tarea.Descripcion, pFecha = tarea.Fecha, @pFinalizada = tarea.Finalizada, @pUsername = tarea.IdUsuario });
        }
    }

    public static int EliminarTarea(int id)
    {
        string query = "DELETE FROM Tareas WHERE Id = @pId";
        int registrosAfectados = 0;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            registrosAfectados = connection.Execute(query, new { pId = id });
        }
        return registrosAfectados;
    }

    public static Tarea VerTarea(int id)
    {
        Tarea tarea = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Id FROM Tareas WHERE Id = @pId";
            tarea = connection.QueryFirstOrDefault<Tarea>(query, new { pId = id });
        }
        return tarea;
    }

    public static List<Tarea> VerTareas(int idUsuario)
    {
        List<Tarea> tareas = new List<Tarea>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tareas WHERE IdUsername = @pIdUsuario";
            tareas = connection.Query<Tarea>(query, new { pIdUsuario = idUsuario }).ToList();
        }
        return tareas;
    }

    public static void FinalizarTarea(int id)
    {
        string query = "UPDATE Tareas SET Finalizada = 1 WHERE Id = @pId";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { pId = id });
        }
    }

    public static void ActualizarTarea(Tarea tarea)
    {
        string query = "UPDATE Tareas SET Titulo = @pTitulo, Descripcion = @pDescripcion, Fecha = @pFecha, Finalizada = @pFinalizada WHERE Titulo = @pTitulo";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { pTitulo = tarea.Titulo, pDescripcion = tarea.Descripcion, pFecha = tarea.Fecha, pFinalizada = tarea.Finalizada });
        }
    }

    public static int GetId(string username, string password)
    {
        int id;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Id FROM Usuarios WHERE Username = @pUsername AND Password = @pPassword";
            id = connection.QueryFirstOrDefault<int>(query, new { @pUsername = username, @pPassword = password });
        }
        return id;
    }
}