using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaJunta
{
    public static class MedidorService
    {
        public static DataTable ObtenerDatosMedidor(string numeroConexion)
        {
            // IMPORTANTE: sanitiza el input si es necesario
            string query = $@"
            SELECT NUMERO_MEDIDOR, CODIGO_USUARIO, NOMBRES_APELLIDOS, TELEFONO, 
                   SECTOR, NUMERO_CONEXION, FECHA, LECTURA_INICIAL, 
                   INSTITUCION, FECHA_NACIMIENTO, CAPACIDAD_DIFERENTE, TERCERA_EDAD 
            FROM MEDIDORES 
            WHERE NUMERO_MEDIDOR = '{numeroConexion}'";

            return SqlServerHelper.EjecutarConsulta(query); // Usa tu helper
        }
    }
}
