using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramaJunta
{
    public partial class FrmLogin : Form
    {
        private AuthService _authService;

        public FrmLogin()
        {
            InitializeComponent();

            _authService = new AuthService();
            this.AcceptButton = btnLogin; // Permite iniciar sesión con Enter
        }
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text.Trim();
            string password = txtContrasena.Text.Trim(); // En un sistema real, aquí no se usaría trim directamente

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lbl1.Text = "Por favor, ingrese usuario y contraseña.";
                lbl1.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (_authService.AuthenticateUser(username, password))
            {
                // Oculta el formulario de login
                this.Hide();

                // Crea e muestra el formulario principal
                FrmPrincipal mainForm = new FrmPrincipal();
                mainForm.Show(); // Muestra el formulario principal sin bloquear el hilo
                                 // mainForm.ShowDialog(); // Si quieres que MainForm bloquee el resto de la aplicación hasta que se cierre

                // Puedes cerrar el formulario de login si ya no lo necesitas
                // this.Close(); // Opcional: si quieres cerrar el login, asegúrate de que tu aplicación no se cierre si es el único formulario abierto.
                // Lo más común es cerrar el login después de abrir el main form.
            }
            else
            {
                lbl1.Text = "Usuario o contraseña incorrectos.";
                lbl1.ForeColor = System.Drawing.Color.Red;
                txtContrasena.Clear(); // Limpia el campo de contraseña
                txtUsuario.Focus(); // Pone el foco en el usuario para un nuevo intento
            }
        }
    }
}
