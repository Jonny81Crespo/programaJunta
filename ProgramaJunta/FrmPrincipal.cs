using AutoUpdaterDotNET;

using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProgramaJunta
{
    public partial class FrmPrincipal : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        FrmBusqueda frmBusqueda;


        public FrmPrincipal()
        {
            InitializeComponent();

            //Imgane de Fondo Pantalla Principal
            /* Image originalImage = (Image)Properties.Resources.overhead_view_.Clone();
             originalImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
             this.BackgroundImage = originalImage;
             this.BackgroundImageLayout = ImageLayout.Stretch;*/
        }

        private void MostrarUserControl(UserControl uc)
        {
            uc.AutoSize = true;
            uc.Dock = DockStyle.Fill;
            uc.Margin = new Padding(0);

            pnlControlUser.Controls.Clear();      // Limpia lo anterior           
            pnlControlUser.Controls.Add(uc);     // Agrega el nuevo control
        }



        private void sectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(new CtlSectores());
        }

        private void medidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(new CtlMedidores());
        }

        private void lecturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(new CtlLecturas());
        }

        private void otrosIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(new CtlOtrosIngresos());
        }

        private void plantillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(new CtlPlanilla());
        }

        private void gastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(new CtlGastos());
        }

        private void cambiosMedidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(new CtlPlantillasCanceladasCheques());
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBusqueda == null || frmBusqueda.IsDisposed)
            {
                frmBusqueda = new FrmBusqueda();
                frmBusqueda.Show();
            }
            else
            {
                frmBusqueda.BringToFront();
            }
        }

        private void ingresoMensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(new CtlIngresosMensual());
        }

        CtlDataGrill controlConsulta = new CtlDataGrill();

        private void MostrarConsulta(string tabla)
        {
            controlConsulta.CargarDatos(tabla);
            pnlControlUser.Controls.Clear();
            controlConsulta.Dock = DockStyle.Fill;
            pnlControlUser.Controls.Add(controlConsulta);
        }


        private void fondoSolidarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarConsulta("FONDO_MES");
        }

        private void nuevosUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarConsulta("NUEVOS_INGRESOS");
        }

        private void plantillasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MostrarConsulta("PLANILLA");
        }

        private void otrosIngresosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MostrarConsulta("OTROS_INGRESOS");
        }

        private void gastosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MostrarConsulta("INGRESOS_GASTOS");
        }

        private void ingresosDiariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarUserControl(new CtlIngresosDiarios());
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Verificar actualizaciones al cargar el formulario principal
            AutoUpdater.Start("https://jonny81crespo.github.io/ProgramaJunta/ProgramaJunta/actualizacion.xml");
            // pnlControlUser.BackColor = Color.FromArgb(200, 90, 183, 219);

        }

        private void pnlControlUser_Paint(object sender, PaintEventArgs e)
        {
            //AplicarBordesRedondeados(pnlControlUser, 10);
        }

        private GraphicsPath GetRoundRect(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);                     // Esquina superior izquierda
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);     // Esquina superior derecha
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // Esquina inferior derecha
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);     // Esquina inferior izquierda

            path.CloseFigure();

            return path;
        }

        // Método para aplicar borde redondeado a un panel (ejemplo con pnlPrincipal)
        private void AplicarBordesRedondeados(Panel panel, int radio)
        {
            // var path = GetRoundRect(new Rectangle(0, 0, panel.Width, panel.Height), radio);
            // panel.Region = new Region(path);
        }

        private  void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Ruta donde está actualmente tu base de datos LocalDB (en ApplicationData)
            // Reutiliza la lógica de DatabaseManager para obtener la ruta
            string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MiAppFacturacionJuntaDeAgua");
            string sourceMdfPath = Path.Combine(appDataFolder, "DBAguaGestion.mdf");
            string sourceLdfPath = Path.Combine(appDataFolder, "DBAguaGestion_log.ldf");

            // *************** IMPORTANTE ***************
            // Define la carpeta de destino en Google Drive
            // Esto asume que el usuario tiene la aplicación Google Drive Desktop instalada
            // y que ha configurado una carpeta de sincronización local.
            // NECESITARÁS SABER LA RUTA EXACTA DE SU CARPETA DE GOOGLE DRIVE.
            // Esto a menudo es C:\Users\[TuUsuario]\Google Drive (o My Drive)
            string googleDriveRoot = @"F:\Mi unidad";               
            string destinationFolder = Path.Combine(googleDriveRoot, "CopiasDeSeguridadDBAguaGestion"); // Una subcarpeta para tus backups

            if (!Directory.Exists(googleDriveRoot))
            {
                MessageBox.Show("Parece que la carpeta de Google Drive no está instalada o la ruta es incorrecta en este equipo.\n" +
                                "Asegúrate de tener Google Drive Desktop y de que la ruta 'Google Drive' exista en tu perfil de usuario.",
                                "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            string destinationMdfPath = Path.Combine(destinationFolder, $"DBAguaGestion_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.mdf");
            string destinationLdfPath = Path.Combine(destinationFolder, $"DBAguaGestion_Backup_{DateTime.Now:yyyyMMdd_HHmmss}_log.ldf");

            DialogResult result = MessageBox.Show("¿Desea crear una copia de seguridad de la base de datos y guardarla en Google Drive?\n" +
                                                  "Esto detendrá la base de datos por un momento.",
                                                  "Confirmar Sincronización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                btnSincronizar.Enabled = false; // Deshabilitar el botón durante la operación
                Cursor.Current = Cursors.WaitCursor; // Cambiar el cursor a espera

                // 1. Detener la instancia de LocalDB
                // Asume que la instancia es (localdb)\mssqllocaldb
                // Importante: Esto podría afectar a otras aplicaciones que usen la misma instancia.
                MessageBox.Show("Deteniendo la base de datos local para la copia de seguridad...", "Proceso de Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await RunLocalDbCommand("stop", "mssqllocaldb"); // Espera a que el comando se complete

                // Esperar un momento para asegurar que los archivos estén liberados (opcional, pero útil)
                await Task.Delay(1000);

                // 2. Copiar los archivos MDF y LDF
                if (File.Exists(sourceMdfPath))
                {
                    File.Copy(sourceMdfPath, destinationMdfPath, true); // true para sobrescribir si el nombre es el mismo
                    MessageBox.Show($"Copia de seguridad del MDF creada en:\n{destinationMdfPath}", "Backup Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo MDF de la base de datos local.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (File.Exists(sourceLdfPath))
                {
                    File.Copy(sourceLdfPath, destinationLdfPath, true);
                    MessageBox.Show($"Copia de seguridad del LDF creada en:\n{destinationLdfPath}", "Backup Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // El LDF podría no existir si la DB es muy nueva o fue creada sin muchas transacciones
                    // MessageBox.Show("Advertencia: No se encontró el archivo LDF de la base de datos local.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // 3. Reiniciar la instancia de LocalDB
                MessageBox.Show("Reiniciando la base de datos local...", "Proceso de Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await RunLocalDbCommand("start", "mssqllocaldb");

                MessageBox.Show("Base de datos copiada exitosamente a Google Drive y la base de datos local ha sido reiniciada.", "Sincronización Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al sincronizar la base de datos: {ex.Message}\n" +
                                "Asegúrate de que Google Drive Desktop esté instalado y la ruta sea correcta.\n" +
                                "Si la base de datos no se reinicia, por favor, reinicia la aplicación.",
                                "Error de Sincronización", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Intentar reiniciar LocalDB incluso si hubo un error de copia
                try
                {
                    await RunLocalDbCommand("start", "mssqllocaldb");
                }
                catch (Exception restartEx)
                {
                    MessageBox.Show($"Error adicional al intentar reiniciar LocalDB: {restartEx.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                btnSincronizar.Enabled = true; // Habilitar el botón de nuevo
                Cursor.Current = Cursors.Default; // Restaurar el cursor
            }
        }
        private async Task RunLocalDbCommand(string command, string instanceName)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "sqllocaldb.exe",
                Arguments = $"{command} {instanceName}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                if (process != null)
                {
                    // Espera a que el proceso termine
                    await Task.Run(() => process.WaitForExit());
                    string output = process.StandardOutput.ReadToEnd();
                    // Opcional: Loggear la salida de sqllocaldb para depuración
                    // Console.WriteLine($"sqllocaldb {command} output: {output}");
                    if (process.ExitCode != 0)
                    {
                        // Algunos comandos como stop pueden retornar 0 incluso si la instancia no existe
                        // Pero para start, un código de salida distinto de 0 es un error.
                        // string error = process.StandardError.ReadToEnd(); // StandardError podría no estar redirigido si no hay errores
                        // if (!string.IsNullOrEmpty(error)) throw new Exception(error);
                        if (output.Contains("Error")) // Una forma rudimentaria de detectar errores de la salida
                        {
                            throw new Exception($"Comando sqllocaldb '{command} {instanceName}' falló: {output}");
                        }
                    }
                }
            }
        }
    }
}
