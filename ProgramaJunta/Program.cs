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
                // Captura cualquier error que pueda ocurrir durante la inicializaci�n de la DB o la conexi�n.
                MessageBox.Show($"Un error cr�tico ha ocurrido durante la inicializaci�n de la aplicaci�n:\n{ex.Message}", "Error de Inicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1); // Salir de la aplicaci�n si no se puede iniciar correctamente
            }
        }   
    }
}