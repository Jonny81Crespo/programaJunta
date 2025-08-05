using AutoUpdaterDotNET;

namespace ProgramaJunta
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            try
            {
                string finalConnectionString = DatabaseManager.GetConnectionString();
                SqlServerHelper.SetConnectionString(finalConnectionString);

                // Configurar AutoUpdater.NET
                AutoUpdater.Start("https://jonny81crespo.github.io/tu-ProgramaJuntaDeAgua/actualizacion.xml");

                Application.Run(new FrmLogin()); 
            
            }
            catch (Exception ex)
            {
                // Captura cualquier error que pueda ocurrir durante la inicialización de la DB o la conexión.
                MessageBox.Show($"Un error crítico ha ocurrido durante la inicialización de la aplicación:\n{ex.Message}", "Error de Inicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1); // Salir de la aplicación si no se puede iniciar correctamente
            }
        }   
    }
}