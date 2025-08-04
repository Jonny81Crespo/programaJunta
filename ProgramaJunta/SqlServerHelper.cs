using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public static class SqlServerHelper
{
    // Elimina 'readonly' para que se pueda asignar después.
    private static string cadenaConexion; // <--- Ya no se inicializa aquí.

    // Nuevo método para establecer la cadena de conexión externamente.
    public static void SetConnectionString(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString), "La cadena de conexión no puede ser nula o vacía.");
        }
        cadenaConexion = connectionString;
    }

    /// <summary>
    /// Ejecuta una consulta SELECT y devuelve un DataTable con los resultados.
    /// </summary>
    public static DataTable EjecutarConsulta(string query)
    {
        // Es buena práctica verificar que la cadena de conexión ya haya sido establecida.
        if (string.IsNullOrEmpty(cadenaConexion))
        {
            throw new InvalidOperationException("La cadena de conexión no ha sido establecida. Llame a SqlServerHelper.SetConnectionString() primero.");
        }

        using (SqlConnection conn = new SqlConnection(cadenaConexion))
        {
            conn.Open();
            using (SqlDataAdapter adaptador = new SqlDataAdapter(query, conn))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
        }
    }

    /// <summary>
    /// Ejecuta una consulta INSERT, UPDATE o DELETE.
    /// </summary>
    public static int EjecutarComando(string query)
    {
        // Es buena práctica verificar que la cadena de conexión ya haya sido establecida.
        if (string.IsNullOrEmpty(cadenaConexion))
        {
            throw new InvalidOperationException("La cadena de conexión no ha sido establecida. Llame a SqlServerHelper.SetConnectionString() primero.");
        }

        using (SqlConnection conn = new SqlConnection(cadenaConexion))
        {
            conn.Open();
            using (SqlCommand comando = new SqlCommand(query, conn))
            {
                return comando.ExecuteNonQuery();
            }
        }
    }
}
