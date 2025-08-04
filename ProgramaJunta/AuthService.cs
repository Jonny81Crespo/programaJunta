using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaJunta
{

    internal class AuthService
    {
    

        public bool AuthenticateUser(string username, string password)
        {

            string caseSensitiveCollation = "SQL_Latin1_General_CP1_CS_AS"; // O Latin1_General_CS_AS, etc.

            string query = $"SELECT Usuario FROM Usuarios " +
                 $"WHERE Usuario = '{username}' COLLATE {caseSensitiveCollation} " +
                 $"AND Clave = '{password}' COLLATE {caseSensitiveCollation};";


            try
            {
                // Llama al método EjecutarConsulta de tu clase DatabaseHelper
                // Asumiendo que DatabaseHelper.EjecutarConsulta es un método estático y público.
                DataTable result = SqlServerHelper.EjecutarConsulta(query);

                // Si el DataTable tiene al menos una fila, significa que se encontró el usuario y contraseña
                return result != null && result.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                // Manejo de errores: Puedes registrar el error para depuración
                Console.WriteLine("Error de autenticación: " + ex.Message);
                // En un entorno de usuario, es mejor mostrar un mensaje genérico como "Error de conexión"
                return false;
            }
        }
    }
}
