using System.Data;

namespace ProgramaJunta
{
    public partial class CtlMedidores : UserControl
    {

        private DataTable datosUsuarios;
        private DataTable datosSectores;
        private bool comboCargado = false;
        private bool cargandoCombo = true;
        private string idActual = "";
        private string medidorOriginal = "";
        private string modoActual = ""; // Puede ser "CAMBIO" o "MODIFICACION"


        public CtlMedidores()
        {
            InitializeComponent();
        }

        private void CtlMedidores_Load(object sender, EventArgs e)
        {
            CargarSectores();
            CargarUsuario();
        }

        private void cbxId_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxId.SelectedValue != null && int.TryParse(cbxId.SelectedValue.ToString(), out int id))
            {
                string IDSeleccionado = cbxId.SelectedValue?.ToString();
                idActual = IDSeleccionado;
                MostrarDatosMedidor(IDSeleccionado);
            }

        }

        private void CargarUsuario()
        {
            datosUsuarios = SqlServerHelper.EjecutarConsulta("SELECT CODIGO_USUARIO FROM MEDIDORES");
            cbxId.DataSource = datosUsuarios;
            cbxId.DisplayMember = "CODIGO_USUARIO";
            cbxId.ValueMember = "CODIGO_USUARIO";

            comboCargado = true;
        }

        private void CargarSectores()
        {
            cargandoCombo = true;
            datosSectores = SqlServerHelper.EjecutarConsulta("SELECT CODIGO,SECTOR FROM SECTORES");
            cbxNombreSector.DataSource = datosSectores;
            cbxNombreSector.DisplayMember = "SECTOR";
            cbxNombreSector.ValueMember = "CODIGO";

            cargandoCombo = false;
            cbxNombreSector.SelectedIndex = -1;
        }


        private void cbxId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string textoIngresado = cbxId.Text.Trim();
                ValidarNumeroMedidor(textoIngresado);
                e.Handled = true;
                e.SuppressKeyPress = true; // Evita el sonido del Enter
            }
        }

        private void ValidarNumeroMedidor(string numero)
        {
            if (!comboCargado || string.IsNullOrEmpty(numero)) return;

            // Reemplaza 'datosOriginalesCombo' con tu tabla si usas otro nombre
            DataTable datosCombo = (DataTable)cbxId.DataSource;

            DataRow[] coincidencias = datosCombo.Select($"CODIGO_USUARIO = '{numero}'");

            if (coincidencias.Length > 0)
            {
                cbxId.SelectedValue = numero;
            }
            else
            {
                MessageBox.Show("No existe ese usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MostrarDatosSector(string idMedidor)
        {
            string query = $@"SELECT S.CODIGO, S.SECTOR
        FROM MEDIDORES M LEFT JOIN SECTORES S ON M.SECTOR = S.CODIGO WHERE M.CODIGO_USUARIO = {idMedidor};";

            DataTable resultado = SqlServerHelper.EjecutarConsulta(query);

            if (resultado.Rows.Count > 0)
            {
                DataRow fila = resultado.Rows[0];

                txtCodigoSector.Text = fila["CODIGO"].ToString();
                cbxNombreSector.SelectedValue = fila["CODIGO"];
            }
            else
            {
                MessageBox.Show("Medidor no encontrado.");
            }
        }

        private void cbxNombreSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargandoCombo && cbxNombreSector.SelectedValue != null)
            {
                txtCodigoSector.Text = cbxNombreSector.SelectedValue.ToString();
            }
        }

        private void MostrarDatosMedidor(string IDSeleccionado)
        {
            if (!comboCargado || cbxId.SelectedItem == null) return;
            {

                // Consulta para traer el nombre (o cualquier otro campo)
                string query = $"SELECT TOP 1 Codigo_Usuario, Numero_medidor, NOMBRES_APELLIDOS, TELEFONO, NUMERO_CONEXION, Fecha, FECHA_NACIMIENTO, " +
                    $"CAPACIDAD_DIFERENTE, TERCERA_EDAD, INSTITUCION FROM MEDIDORES WHERE CODIGO_USUARIO = '{IDSeleccionado}';";

                DataTable resultado = SqlServerHelper.EjecutarConsulta(query);

                if (resultado.Rows.Count > 0)
                {
                    DataRow fila = resultado.Rows[0];

                    // Mapeo: columna => textbox
                    var mapeoTextBox = new Dictionary<string, TextBox>
        {
            { "Numero_medidor", txtMedidor },
            { "NOMBRES_APELLIDOS", txtNombresApellidos },
            { "TELEFONO", txtTelefono },
            { "NUMERO_CONEXION", txtNumConexion },
            { "Codigo_Usuario", txtCodigoUsuario }
        };

                    medidorOriginal = fila["Numero_medidor"].ToString();

                    foreach (var par in mapeoTextBox)
                    {
                        par.Value.Text = fila[par.Key]?.ToString() ?? "";
                    }

                    int tipo = Convert.ToInt32(fila["INSTITUCION"]);
                    cbxCategoriaUsuario.SelectedIndex = tipo == 1 ? 0 : 1;

                    if (DateTime.TryParse(fila["FECHA"]?.ToString(), out DateTime fecha))
                    {
                        dtpFecha.Value = fecha;
                    }
                    else
                    {
                        dtpFecha.Value = DateTime.Now;

                    }

                    if (DateTime.TryParse(fila["FECHA_NACIMIENTO"]?.ToString(), out DateTime fecha_nacimiento))
                    {
                        dtpFechNacimiento.Value = fecha_nacimiento;
                    }
                    else
                    {
                        dtpFechNacimiento.Value = new DateTime(2999, 12, 31);
                    }

                    chbCapacidadDif.Checked = fila["CAPACIDAD_DIFERENTE"]?.ToString() == "VERDADERO";

                    chbTercerEdad.Checked = fila["TERCERA_EDAD"]?.ToString() == "VERDADERO";

                    MostrarDatosSector(IDSeleccionado);

                }
            }
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmBusqueda frmBusqueda = new FrmBusqueda();

            frmBusqueda.UsuarioSeleccionado += FrmBuscarUsuario_UsuarioSeleccionado;
            frmBusqueda.ShowDialog();

        }

        private void FrmBuscarUsuario_UsuarioSeleccionado(DataRow fila)
        {
            string idMedidor = fila["CODIGO_USUARIO"].ToString();
            cbxId.SelectedValue = idMedidor; // Si quieres que también seleccione en el combo

            MostrarDatosMedidor(idMedidor);
        }

        private void cambioMedidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idActual) || idActual == "0")
            {
                MessageBox.Show("No hay ningún registro seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            modoActual = "CAMBIO";
            txtMedidor.Enabled = true;
            txtCodigoUsuario.Enabled = false;
            txtNombresApellidos.Enabled = false;
            txtTelefono.Enabled = false;
            cbxCategoriaUsuario.Enabled = false;
            cbxNombreSector.Enabled = false;
            txtNumConexion.Enabled = false;
            dtpFecha.Enabled = false;
            dtpFechNacimiento.Enabled = false;
            chbCapacidadDif.Enabled = false;
            chbTercerEdad.Enabled = false;
            guardarToolStripMenuItem.Enabled = true;
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idActual) || idActual == "0")
            {
                MessageBox.Show("No hay ningún registro seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codigoUsuario = txtCodigoUsuario.Text.Trim();

            if (string.IsNullOrEmpty(codigoUsuario))
            {
                MessageBox.Show("Debe ingresar o seleccionar un Código de Usuario antes de modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el código existe en la base de datos
            string query = $"SELECT COUNT(*) FROM MEDIDORES WHERE CODIGO_USUARIO = '{codigoUsuario}'";
            DataTable resultado = SqlServerHelper.EjecutarConsulta(query);

            int existe = Convert.ToInt32(resultado.Rows[0][0]);

            if (existe == 0)
            {
                MessageBox.Show("El código de usuario no existe. Verifique e intente nuevamente.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("¿Estás seguro de modificar los datos del medidor?", "Confirmar modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                modoActual = "MODIFICACION";
                txtMedidor.Enabled = false;

                // Habilitar los demás campos para modificación                
                txtCodigoUsuario.Enabled = true;
                txtNombresApellidos.Enabled = true;
                txtTelefono.Enabled = true;
                cbxCategoriaUsuario.Enabled = true;
                cbxNombreSector.Enabled = true;
                txtNumConexion.Enabled = true;
                dtpFecha.Enabled = true;
                dtpFechNacimiento.Enabled = true;
                chbCapacidadDif.Enabled = true;
                chbTercerEdad.Enabled = true;

                // agrega aquí los demás campos que quieras permitir modificar

                guardarToolStripMenuItem.Enabled = true;
            }
        }



        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Validación de edad mínima
            DateTime fechaNacimiento = dtpFechNacimiento.Value;
            int edad = DateTime.Today.Year - fechaNacimiento.Year;

            if (fechaNacimiento > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            if (edad < 18)
            {
                MessageBox.Show("El usuario debe tener al menos 18 años para registrarse.", "Edad no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (modoActual)
            {
                case "CAMBIO":
                    string nuevoMedidor = txtMedidor.Text.Trim();

                    if (nuevoMedidor != medidorOriginal)
                    {
                        // Guardar en histórico
                        string insertHist = $@"
                        INSERT INTO MEDIDORES_CAMBIADOS (NUMERO_MEDIDOR, MedidorAnterior, MedidorNuevo, FECHA_INGRESO, INSTITUCION)
                        VALUES ('{idActual}', '{medidorOriginal}', '{nuevoMedidor}', date('now'),'1')";
                        SqlServerHelper.EjecutarComando(insertHist);

                        // Actualizar medidor
                        string updateMedidor = $"UPDATE medidores SET NUMERO_MEDIDOR = '{nuevoMedidor}' WHERE CODIGO_USUARIO = '{idActual}'";
                        SqlServerHelper.EjecutarComando(updateMedidor);

                        MessageBox.Show("Medidor actualizado y cambio registrado.");
                        txtMedidor.Enabled = false;
                        guardarToolStripMenuItem.Enabled = false;
                        medidorOriginal = nuevoMedidor;
                    }
                    else
                    {
                        MessageBox.Show("No se realizaron cambios.");
                    }
                    txtMedidor.Enabled = false;
                    guardarToolStripMenuItem.Enabled = false;
                    medidorOriginal = nuevoMedidor;
                    break;

                case "MODIFICACION":
                    string nombre = txtNombresApellidos.Text.Trim();
                    string CodigoUsuario = txtCodigoUsuario.Text.Trim();
                    string Telefono = txtTelefono.Text.Trim();
                    string NumConexion = txtNumConexion.Text.Trim();
                    int CategoriaUsuario = cbxCategoriaUsuario.SelectedIndex;
                    // Agrega los demás campos que necesites

                    string update = $@" UPDATE MEDIDORES SET 
                                CODIGO_USUARIO = '{CodigoUsuario}',
                                NOMBRES_APELLIDOS = '{nombre}',
                                TELEFONO = '{Telefono}',
                                INSTITUCION = '{CategoriaUsuario}',
                                NUMERO_CONEXION = '{NumConexion}'
                                WHERE CODIGO_USUARIO = '{idActual}'";

                    SqlServerHelper.EjecutarConsulta(update);
                    MessageBox.Show("Datos del medidor actualizados correctamente.");

                    // Deshabilitar campos
                    txtNombresApellidos.Enabled = false;
                    // Habilitar los demás campos para modificación                
                    txtCodigoUsuario.Enabled = false;
                    txtTelefono.Enabled = false;
                    cbxCategoriaUsuario.Enabled = false;
                    txtNumConexion.Enabled = false;
                    guardarToolStripMenuItem.Enabled = false;
                    break;

                case "NUEVO":
                    string codigo = txtCodigoUsuario.Text.Trim();
                    string nombre1 = txtNombresApellidos.Text.Trim();
                    string telefono = txtTelefono.Text.Trim();
                    string lectura = txtLecturaActual.Text.Trim();
                    string categoria = cbxCategoriaUsuario.SelectedIndex == 1 ? "1" : "0";
                    string sector = cbxNombreSector.SelectedValue?.ToString() ?? "0";
                    string numConexion = txtNumConexion.Text.Trim();
                    string medidor = txtMedidor.Text.Trim();
                    string CapacidadDif = chbCapacidadDif.Checked ? "1" : "0";
                    string TercerEdad = chbTercerEdad.Checked ? "1" : "0";
                    string nacimiento = dtpFechNacimiento.Value.ToString("yyyy-MM-dd");
                    string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
                    if (string.IsNullOrWhiteSpace(nombre1) || string.IsNullOrWhiteSpace(medidor))
                    {
                        MessageBox.Show("Por favor llena todos los campos obligatorios.");
                        return;
                    }
                    string insert = $@"INSERT INTO MEDIDORES 
                        (CODIGO_USUARIO, NOMBRES_APELLIDOS, TELEFONO, INSTITUCION, SECTOR, NUMERO_CONEXION, NUMERO_MEDIDOR, LECTURA_INICIAL, 
                            FECHA_NACIMIENTO,FECHA, CAPACIDAD_DIFERENTE, TERCERA_EDAD) 
                        VALUES ('{codigo}', '{nombre1}', '{telefono}', '{categoria}', '{sector}', '{numConexion}', '{medidor}', '{lectura}', 
                            '{nacimiento}','{fecha}','{CapacidadDif}','{TercerEdad}')";

                    SqlServerHelper.EjecutarComando(insert);
                    MessageBox.Show("Registro guardado correctamente.");
                    break;

                default:
                    MessageBox.Show("No se realizaron cambios.");
                    break;
            }
            modoActual = "";
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modoActual = "NUEVO";
            // Limpiar todos los campos del formulario
            txtNombresApellidos.Text = "";
            txtTelefono.Text = "";
            cbxCategoriaUsuario.SelectedIndex = -1;
            txtNumConexion.Text = "";
            txtMedidor.Text = "";
            dtpFecha.Value = DateTime.Now;
            dtpFechNacimiento.Value = DateTime.Now;

            var resultado = SqlServerHelper.EjecutarConsulta("SELECT IFNULL(MAX(CODIGO_USUARIO), 0) + 1 AS NuevoCodigo FROM MEDIDORES");
            if (resultado.Rows.Count > 0)
            {
                txtCodigoUsuario.Text = resultado.Rows[0]["NuevoCodigo"].ToString();
            }

            // Habilitar todos los campos excepto el medidor
            txtNombresApellidos.Enabled = true;
            txtCodigoUsuario.Enabled = false; // El código lo genera el sistema
            txtTelefono.Enabled = true;
            cbxCategoriaUsuario.Enabled = true;
            txtNumConexion.Enabled = true;
            txtMedidor.Enabled = true;
            cbxNombreSector.Enabled = true;
            dtpFecha.Enabled = true;
            dtpFechNacimiento.Enabled = true;
            chbCapacidadDif.Enabled = true;
            chbTercerEdad.Enabled = true;

            // Activar el botón guardar
            guardarToolStripMenuItem.Enabled = true;

            // Limpiar el idActual porque es un nuevo registro

        }
    }
}
