using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProgramaJunta
{
    public static class DatabaseManager
    {
        private static string _connectionString;
        private static readonly string DbName = "DBAguaGestion";
        private static readonly string DbMdfFileName = "DBAguaGestion.mdf";
        private static readonly string DbLdfFileName = "DBAguaGestion_log.ldf"; // Generalmente se infiere o se genera, pero es bueno tenerlo en cuenta.
        private static readonly string LocalDbInstance = "(LocalDB)\\MSSQLLocalDB";

        public static string GetConnectionString()
        {
            // Si la cadena de conexión ya ha sido determinada, la devolvemos.
            if (!string.IsNullOrEmpty(_connectionString))
            {
                return _connectionString;
            }

            // --- Definir rutas de los archivos de la base de datos ---
            // Directorio donde el usuario guardará la base de datos
            // Asegúrate de que "FacturacionJuntaDeAgua" sea un nombre de aplicación único y descriptivo.
            string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MiAppFacturacionJuntaDeAgua");
            string userDbMdfPath = Path.Combine(appDataFolder, DbMdfFileName);
            string userDbLdfPath = Path.Combine(appDataFolder, DbLdfFileName); // La ruta del LDF es importante

            // Rutas de los archivos MDF/LDF que vienen con la instalación de la aplicación
            string installedDbMdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbMdfFileName);
            string installedDbLdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbLdfFileName);

            // --- Asegurar que el directorio de usuario exista y copiar archivos si es la primera vez ---
            if (!Directory.Exists(appDataFolder))
            {
                Directory.CreateDirectory(appDataFolder);
            }

            if (!File.Exists(userDbMdfPath))
            {
                MessageBox.Show("Configurando la base de datos por primera vez. Esto puede tardar unos segundos.", "Inicializando Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    // Verificar que los archivos estén en la carpeta de instalación
                    if (!File.Exists(installedDbMdfPath) || !File.Exists(installedDbLdfPath))
                    {
                        throw new FileNotFoundException(
                            "Los archivos de base de datos iniciales (.mdf/.ldf) no se encontraron en la carpeta de instalación de la aplicación.\n" +
                            "Asegúrese de haberlos incluido en el instalador.");
                    }

                    // Copiar los archivos a la carpeta de datos del usuario
                    File.Copy(installedDbMdfPath, userDbMdfPath, true);
                    File.Copy(installedDbLdfPath, userDbLdfPath, true); // Asegúrate de copiar el LDF también

                    MessageBox.Show("Base de datos copiada a la carpeta de datos de usuario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error crítico al copiar la base de datos inicial: {ex.Message}\n" +
                                    "La aplicación no podrá funcionar sin la base de datos. Por favor, contacte al soporte.",
                                    "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1); // Sale de la aplicación si no se puede copiar
                }
            }

            // --- Intentar conectar a la base de datos existente o adjuntarla si no lo está ---
            // La cadena de conexión inicial intentará conectarse a la base de datos por nombre.
            string initialConnectionString = $"Data Source={LocalDbInstance};Initial Catalog={DbName};Integrated Security=True;Connect Timeout=15";

            try
            {
                using (SqlConnection connection = new SqlConnection(initialConnectionString))
                {
                    connection.Open();
                    // Si llegamos aquí, la base de datos ya está adjunta y accesible por su nombre.
                    _connectionString = initialConnectionString; // Guardamos esta cadena para futuras conexiones
                }
            }
            catch (SqlException ex)
            {
                // Si la base de datos no está disponible (ej. error 4060: "Cannot open database 'DBAguaGestion' requested by the login. The login failed.")
                // o si no existe (otros errores), procedemos a intentar adjuntarla.
                // Para LocalDB, el 4060 es común si la DB no está adjunta.
                // Considera también 18456 (Login failed for user) si hay problemas de permisos, aunque con Integrated Security es menos probable.

                MessageBox.Show($"La base de datos '{DbName}' no se encontró adjunta en LocalDB. Intentando adjuntarla ahora.",
                                "Configuración de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Intentar adjuntar la base de datos
                // La cadena de conexión para adjuntar debe apuntar a la base de datos 'master'
                string masterConnectionString = $"Data Source={LocalDbInstance};Initial Catalog=master;Integrated Security=True;Connect Timeout=30";

                try
                {
                    using (SqlConnection masterConn = new SqlConnection(masterConnectionString))
                    {
                        masterConn.Open();

                        // Comando para adjuntar la base de datos
                        string attachCommand = $@"
                        IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{DbName}')
                        BEGIN
                            CREATE DATABASE [{DbName}]
                            ON (FILENAME = '{userDbMdfPath}')
                            FOR ATTACH;
                        END";
                        // El LDF se gestiona automáticamente por SQL Server al adjuntar el MDF.
                        // No necesitas especificar el LDF aquí a menos que tengas un caso muy específico y quieras controlar su ubicación.
                        // FOR ATTACH intentará encontrar el LDF en la misma ruta o crearlo si no existe y es compatible.

                        using (SqlCommand attachCmd = new SqlCommand(attachCommand, masterConn))
                        {
                            attachCmd.ExecuteNonQuery();
                            MessageBox.Show("Base de datos adjuntada exitosamente a LocalDB.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    // Si la adjunción fue exitosa, la cadena de conexión ahora es la que apunta a la base de datos por su nombre.
                    _connectionString = initialConnectionString;
                }
                catch (SqlException attachEx)
                {
                    // Error 1802: Already attached
                    // Error 5173: Attach database failed for database 'DBAguaGestion'. An unexpected error occurred while trying to open file 'userDbMdfPath'.
                    // Este último puede ocurrir si el MDF está dañado o ya está en uso por otra instancia/proceso.
                    if (attachEx.Number == 1802) // DB ya está adjunta o ya existe (aunque nuestro IF NOT EXISTS debería evitarlo)
                    {
                        MessageBox.Show($"Advertencia: La base de datos '{DbName}' ya estaba adjunta o existe. Continuando...", "Advertencia DB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _connectionString = initialConnectionString; // Asumimos que ya está bien
                    }
                    else
                    {
                        MessageBox.Show($"Error crítico al adjuntar la base de datos a LocalDB: {attachEx.Message}\n" +
                                        "La aplicación no podrá funcionar. Por favor, contacte al soporte.",
                                        "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }
                }
                catch (Exception generalEx)
                {
                    MessageBox.Show($"Advertencia general al intentar adjuntar la base de datos: {generalEx.Message}", "Advertencia DB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Environment.Exit(1); // Si hay un error genérico y no podemos adjuntar, salir.
                }
            }
            catch (Exception generalEx)
            {
                MessageBox.Show($"Error inesperado al obtener la cadena de conexión: {generalEx.Message}", "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            // Al final, _connectionString debe contener la cadena para conectar a la base de datos por su nombre.
            return _connectionString;
        }
    }
}
