using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ProgramaJunta
{
    public partial class CtlLecturas : UserControl
    {
        private DataTable datosMedidores;
        private bool cargandoCombo;
        int lecturaAnterior = 0;
        int lecturaActual = 0;
        int metrosConsumidos = 0;

        public CtlLecturas()
        {
            InitializeComponent();
        }

        private void CtlLecturas_Load(object sender, EventArgs e)
        {
            CargarNumMedidor();
        }

        private void CargarNumMedidor()
        {
            cargandoCombo = true;
            datosMedidores = SqlServerHelper.EjecutarConsulta("SELECT Numero_medidor FROM MEDIDORES");
            cbxMedidor.DataSource = datosMedidores;
            cbxMedidor.DisplayMember = "Numero_medidor";
            cbxMedidor.ValueMember = "Numero_medidor";

            cargandoCombo = false;
            cbxMedidor.SelectedIndex = -1;

        }

        private void cambioMedidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBusqueda frmBusqueda = new FrmBusqueda();

            frmBusqueda.UsuarioSeleccionado += FrmBuscarUsuario_UsuarioSeleccionado;
            frmBusqueda.ShowDialog();

        }

        private void FrmBuscarUsuario_UsuarioSeleccionado(DataRow fila)
        {
            string idMedidor = fila["NUMERO_MEDIDOR"].ToString();
            cbxMedidor.SelectedValue = idMedidor; // Si quieres que también seleccione en el combo

            MostrarDatosConsumo(idMedidor);
        }


        private void cbxMedidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMedidor.SelectedValue != null /*&& int.TryParse(cbxMedidor.SelectedValue.ToString(), out int id)*/)
            {
                string IDSeleccionado = cbxMedidor.SelectedValue?.ToString();

                MostrarDatosConsumo(IDSeleccionado);
                txtLecturaActual.Enabled = false;
                txtObservaciones.Enabled = false;
                guardarToolStripMenuItem.Enabled = false;
            }
        }

        private void MostrarDatosConsumo(string IDSeleccionado)
        {
            if (cbxMedidor.SelectedItem == null) return;
            {

                string query = $"SELECT TOP 1 NOMBRE_USUARIO, CONSUMO_MES, Fecha, LECTURA_ANTERIOR,LECTURA_ACTUAL,METROS_CONSUMO,REVISION_MEDIDOR, OBSERVACIONES " +
                    $"FROM CONSUMO WHERE Numero_medidor = '{IDSeleccionado}' ORDER BY CONSUMO_MES DESC;";
                DataTable resultado = SqlServerHelper.EjecutarConsulta(query);

                if (resultado.Rows.Count > 0)
                {
                    DataRow fila = resultado.Rows[0];

                    // Mapeo: columna => textbox
                    var mapeoTextBox = new Dictionary<string, System.Windows.Forms.TextBox>
                     {
                    { "NOMBRE_USUARIO", txtNombreApellidos },
                    { "LECTURA_ANTERIOR", txtLecturaAnterior },
                    { "LECTURA_ACTUAL", txtLecturaActual },
                    { "METROS_CONSUMO", txtMetrosConsumidos },
                    { "OBSERVACIONES", txtObservaciones }
                     };

                    foreach (var par in mapeoTextBox)
                    {
                        par.Value.Text = fila[par.Key]?.ToString() ?? "";
                    }

                    if (DateTime.TryParse(fila["CONSUMO_MES"]?.ToString(), out DateTime mes))
                    {
                        dtpMesConsumo.Value = mes;
                    }
                    else
                    {
                        dtpMesConsumo.Value = DateTime.Now;

                    }

                    if (DateTime.TryParse(fila["FECHA"]?.ToString(), out DateTime fecha))
                    {
                        dtpFechaLectura.Value = fecha;
                    }
                    else
                    {
                        dtpFechaLectura.Value = DateTime.Now;

                    }

                    chkRevisionMedidor.Checked = Convert.ToBoolean(fila["REVISION_MEDIDOR"]);

                    MostrarDatosSector(IDSeleccionado);

                }
            }
        }

        private void MostrarDatosSector(string idMedidor)
        {
            string query = $@"SELECT S.CODIGO, S.SECTOR
        FROM MEDIDORES M LEFT JOIN SECTORES S ON M.SECTOR = S.CODIGO WHERE M.Numero_medidor = {idMedidor};";

            DataTable resultado = SqlServerHelper.EjecutarConsulta(query);

            if (resultado.Rows.Count > 0)
            {
                DataRow fila = resultado.Rows[0];

                txtSector.Text = fila["SECTOR"].ToString();
            }
            else
            {
                MessageBox.Show("Medidor no encontrado.");
            }
        }

        private void txtLecturaAnterior_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla
            }
        }

        private void txtLecturaActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla
            }
        }

        private void txtLecturaActual_TextChanged(object sender, EventArgs e)
        {
            // Convertir el texto de los TextBox a enteros
            int.TryParse(txtLecturaAnterior.Text, out lecturaAnterior);
            int.TryParse(txtLecturaActual.Text, out lecturaActual);


            metrosConsumidos = lecturaActual - lecturaAnterior;

            metrosConsumidos = Math.Max(0, metrosConsumidos);
            txtMetrosConsumidos.Text = metrosConsumidos.ToString();

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbxMedidor.SelectedIndex == -1 || cbxMedidor.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un medidor antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxMedidor.Focus(); // Lleva el foco al ComboBox
                return;
            }

            string IDSeleccionado = cbxMedidor.SelectedValue?.ToString();

            string query = $@" SELECT 1 FROM CONSUMO WHERE NUMERO_MEDIDOR = '{IDSeleccionado}'
                        AND FORMAT(Fecha, 'yyyyMM') = FORMAT(GETDATE(), 'yyyyMM')";

            DataTable resultado = SqlServerHelper.EjecutarConsulta(query);

            if (resultado.Rows.Count > 0)
            {
                MessageBox.Show("Ya existe un registro para este medidor en el mes actual. No se puede añadir otro.");
            }
            else
            {
                if (cbxMedidor.SelectedValue != null /*&& int.TryParse(cbxMedidor.SelectedValue.ToString(), out int id)*/)
                {



                    if (cbxMedidor.SelectedItem == null) return;
                    {
                        query = $"SELECT TOP 1 NOMBRE_USUARIO, CONSUMO_MES, Fecha, LECTURA_ANTERIOR,LECTURA_ACTUAL,METROS_CONSUMO,REVISION_MEDIDOR, OBSERVACIONES " +
                        $"FROM CONSUMO WHERE Numero_medidor = '{IDSeleccionado}' " +
                        $"AND FORMAT(Fecha, 'yyyyMM') < FORMAT(GETDATE(), 'yyyyMM')" +
                        $"ORDER BY CONSUMO_MES DESC;";

                        resultado = SqlServerHelper.EjecutarConsulta(query);

                        if (resultado.Rows.Count > 0)
                        {

                            DataRow fila = resultado.Rows[0];

                            // Mapeo: columna => textbox
                            var mapeoTextBox = new Dictionary<string, System.Windows.Forms.TextBox>
                     {
                    { "NOMBRE_USUARIO", txtNombreApellidos },
                    { "LECTURA_ACTUAL", txtLecturaAnterior },
                    { "OBSERVACIONES", txtObservaciones }
                     };
                            txtLecturaActual.Enabled = true;
                            txtObservaciones.Enabled = true;
                            txtLecturaActual.Text = "0";

                            foreach (var par in mapeoTextBox)
                            {
                                par.Value.Text = fila[par.Key]?.ToString() ?? "";
                            }

                            if (DateTime.TryParse(fila["CONSUMO_MES"]?.ToString(), out DateTime mes))
                            {
                                dtpMesConsumo.Value = mes;
                            }
                            else
                            {
                                dtpMesConsumo.Value = DateTime.Now;

                            }

                            if (DateTime.TryParse(fila["FECHA"]?.ToString(), out DateTime fecha))
                            {
                                dtpFechaLectura.Value = fecha;
                            }
                            else
                            {
                                dtpFechaLectura.Value = DateTime.Now;

                            }


                            txtMetrosConsumidos.Text = "0";

                            chkRevisionMedidor.Checked = Convert.ToBoolean(fila["REVISION_MEDIDOR"]);

                            MostrarDatosSector(IDSeleccionado);
                            guardarToolStripMenuItem.Enabled = true;

                        }
                    }
                }
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lecturaAnterior = int.Parse(txtLecturaAnterior.Text);
            int lecturaActual = int.Parse(txtLecturaActual.Text);


                if (lecturaActual < lecturaAnterior)
                {
                    MessageBox.Show("La lectura actual no puede ser menor que la lectura anterior.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLecturaActual.Focus();
                    return; // O puedes detener algún proceso si es parte de un botón
                }
            
            string IDSeleccionado = cbxMedidor.SelectedValue?.ToString();
            DataTable datos = MedidorService.ObtenerDatosMedidor(IDSeleccionado);


            if (datos.Rows.Count > 0)
            {
                DataRow fila = datos.Rows[0];

                //bool esBeneficiario = Convert.ToBoolean(fila["CAPACIDAD_DIFERENTE"]) || Convert.ToBoolean(fila["TERCERA_EDAD"]);

                decimal metros = Convert.ToDecimal(txtMetrosConsumidos.Text);
                decimal totalBasico = 0m, excedentes = 0m, totalFinal = 0m;

               /* if (esBeneficiario)
                {
                    DataTable valoresEspeciales = SqlServerHelper.EjecutarConsulta("SELECT CONSUMO_BASICO, EXCEDENTE_UNO, EXCEDENTE_DOS, EXCEDENTE_TRES, EXCEDENTE_CUATRO, " +
               "VALOR_BASICO, VALOR_UNO, VALOR_DOS, VALOR_TRES, VALOR_CUATRO " +
               "FROM DBAguaGestion.dbo.VALORES_ESPECIALES WHERE ID = 1");

                    if (valoresEspeciales.Rows.Count > 0)
                    {
                        CalcularValoresEspeciales(metros, valoresEspeciales.Rows[0], out totalBasico, out excedentes, out totalFinal);
                    }
                }
                else {*/

                    DataTable valores = SqlServerHelper.EjecutarConsulta("SELECT CONSUMO_BASICO, EXCEDENTE_UNO, EXCEDENTE_DOS, EXCEDENTE_TRES, EXCEDENTE_CUATRO, " +
                 "VALOR_BASICO, VALOR_UNO, VALOR_DOS, VALOR_TRES, VALOR_CUATRO " +
                 "FROM DBAguaGestion.dbo.VALORES WHERE ID = 1");

                    if (valores.Rows.Count > 0)
                    {
                        CalcularValoresDinamico(metros, valores.Rows[0], out totalBasico, out excedentes, out totalFinal);                    
                    }
               // }
                string query = $@"
INSERT INTO CONSUMO
(
    [NUMERO_MEDIDOR], [NOMBRE_USUARIO], [CONSUMO_MES], [FECHA], [LECTURA_ANTERIOR], [LECTURA_ACTUAL], [METROS_CONSUMO],
    [ESTADO_COBRO], [TOTAL_BASICO], [EXCEDENTES], [ESTADO_REFERENCIA], [OBSERVACIONES], [FONDO_SOLIDARIO], [REINSTALACION],
    [TOTAL], [MORA_ACTUAL], [MORA_ANTERIOR], [MORA_TOTAL], [DEUDA_ANTERIOR], [DEUDA_ACTUAL], [DEUDA_TOTAL], [DEUDA_NETA_ANTERIOR],
    [DEUDA_NETA_ACTUAL], [DEUDA_NETA_TOTAL], [INSTITUCION], [SUSPENSION], [SUSPENSION_SERVICIO], [REINSTALACION_SERVICIO], [REVISION_MEDIDOR]
)
VALUES
(
   '{cbxMedidor.Text}',
    '{txtNombreApellidos.Text}',
    '{DateTime.Now:yyyy-MM-dd}',
    '{DateTime.Now:yyyy-MM-dd}',
    {txtLecturaAnterior.Text},
    {txtLecturaActual.Text},
    {txtMetrosConsumidos.Text},
    0, -- ESTADO_COBRO
    {totalBasico.ToString(CultureInfo.InvariantCulture)},
    {excedentes.ToString(CultureInfo.InvariantCulture)},
    0, -- ESTADO_REFERENCIA
    N'', -- OBSERVACIONES (vacío)
    0, -- FONDO_SOLIDARIO
    0, -- REINSTALACION
    {totalFinal.ToString(CultureInfo.InvariantCulture)}, -- TOTAL
    0.0000, -- MORA_ACTUAL
    0.0000, -- MORA_ANTERIOR
    0.0000, -- MORA_TOTAL
    0.0000, -- DEUDA_ANTERIOR
    0.0000, -- DEUDA_ACTUAL
    0.0000, -- DEUDA_TOTAL
    0.0000, -- DEUDA_NETA_ANTERIOR
    0.0000, -- DEUDA_NETA_ACTUAL
    0.0000, -- DEUDA_NETA_TOTAL
    0, -- INSTITUCION (asumo int)
    0, -- SUSPENSION
    0.0000, -- SUSPENSION_SERVICIO
    0.0000, -- REINSTALACION_SERVICIO
    {(chkRevisionMedidor.Checked ? 1 : 0)} -- REVISION_MEDIDOR
   )";

          try
          {
              int result = SqlServerHelper.EjecutarComando(query);
              txtLecturaActual.Enabled = false;
              txtObservaciones.Enabled=false;
              guardarToolStripMenuItem.Enabled = false;
              ResetFormulario();
              MessageBox.Show("Registro insertado correctamente.");               
          }
          catch (Exception ex)
          {
              MessageBox.Show("Error al insertar: " + ex.Message);
          }
            }
            else
            {
                MessageBox.Show("No se encontraron datos.");
            }

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbxMedidor.SelectedIndex == -1 || cbxMedidor.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un medidor antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxMedidor.Focus(); // Lleva el foco al ComboBox
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Estás seguro de eliminar el registro del mes actual?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                string IDSeleccionado = cbxMedidor.SelectedValue?.ToString();
                string queryEliminar = $@"
        DELETE FROM CONSUMO
        WHERE NUMERO_MEDIDOR = '{IDSeleccionado}'
          AND FORMAT(Fecha, 'yyyyMM') = FORMAT(GETDATE(), 'yyyyMM')";

                int filasAfectadas = SqlServerHelper.EjecutarComando(queryEliminar);

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Registro eliminado correctamente.");
                    ResetFormulario();
                }
                else
                {
                    MessageBox.Show("No hay un registro del mes actual para eliminar.");
                }
            }
        }

     


        private void CalcularValoresDinamico(decimal metrosConsumidos, DataRow filaValores,
                                     out decimal totalBasico, out decimal excedentes, out decimal totalFinal)
        {
            int tramo1 = Convert.ToInt32(filaValores["CONSUMO_BASICO"]);
            int tramo2 = Convert.ToInt32(filaValores["EXCEDENTE_UNO"]);
            int tramo3 = Convert.ToInt32(filaValores["EXCEDENTE_DOS"]);
            int tramo4 = Convert.ToInt32(filaValores["EXCEDENTE_TRES"]);

            decimal valorBasico = Convert.ToDecimal(filaValores["VALOR_BASICO"]);
            decimal valorUno = Convert.ToDecimal(filaValores["VALOR_UNO"]);
            decimal valorDos = Convert.ToDecimal(filaValores["VALOR_DOS"]);
            decimal valorTres = Convert.ToDecimal(filaValores["VALOR_TRES"]);
            decimal valorCuatro = Convert.ToDecimal(filaValores["VALOR_CUATRO"]);

            totalBasico = valorBasico;
            excedentes = 0;

            if (metrosConsumidos <= tramo1)
            {
                // Solo básico
            }
            else if (metrosConsumidos <= tramo2)
            {
                excedentes = (metrosConsumidos - tramo1) * valorUno;
            }
            else if (metrosConsumidos <= tramo3)
            {
                excedentes = (tramo2 - tramo1) * valorUno +
                             (metrosConsumidos - tramo2) * valorDos;
            }
            else if (metrosConsumidos <= tramo4)
            {
                excedentes = (tramo2 - tramo1) * valorUno +
                             (tramo3 - tramo2) * valorDos +
                             (metrosConsumidos - tramo3) * valorTres;
            }
            else
            {
                excedentes = (tramo2 - tramo1) * valorUno +
                             (tramo3 - tramo2) * valorDos +
                             (tramo4 - tramo3) * valorTres +
                             (metrosConsumidos - tramo4) * valorCuatro;
            }

            excedentes = Math.Round(excedentes, 2);
            totalFinal = Math.Round(totalBasico + excedentes, 2);
        }

        private void CalcularValoresEspeciales(decimal metrosConsumidos, DataRow filaValores,
                                       out decimal totalBasico, out decimal excedentes, out decimal totalFinal)
        {
            int tramo1 = Convert.ToInt32(filaValores["CONSUMO_BASICO"]);
            int tramo2 = Convert.ToInt32(filaValores["EXCEDENTE_UNO"]);
            int tramo3 = Convert.ToInt32(filaValores["EXCEDENTE_DOS"]);
            int tramo4 = Convert.ToInt32(filaValores["EXCEDENTE_TRES"]);

            decimal valorBasico = Convert.ToDecimal(filaValores["VALOR_BASICO"]);
            decimal valorUno = Convert.ToDecimal(filaValores["VALOR_UNO"]);
            decimal valorDos = Convert.ToDecimal(filaValores["VALOR_DOS"]);
            decimal valorTres = Convert.ToDecimal(filaValores["VALOR_TRES"]);
            decimal valorCuatro = Convert.ToDecimal(filaValores["VALOR_CUATRO"]);

            totalBasico = valorBasico;
            excedentes = 0;

            if (metrosConsumidos <= tramo1)
            {
                // Solo básico
            }
            else if (metrosConsumidos <= tramo2)
            {
                excedentes = (metrosConsumidos - tramo1) * valorUno;
            }
            else if (metrosConsumidos <= tramo3)
            {
                excedentes = (tramo2 - tramo1) * valorUno +
                             (metrosConsumidos - tramo2) * valorDos;
            }
            else if (metrosConsumidos <= tramo4)
            {
                excedentes = (tramo2 - tramo1) * valorUno +
                             (tramo3 - tramo2) * valorDos +
                             (metrosConsumidos - tramo3) * valorTres;
            }
            else
            {
                excedentes = (tramo2 - tramo1) * valorUno +
                             (tramo3 - tramo2) * valorDos +
                             (tramo4 - tramo3) * valorTres +
                             (metrosConsumidos - tramo4) * valorCuatro;
            }

            excedentes = Math.Round(excedentes, 2);
            totalFinal = Math.Round(totalBasico + excedentes, 2);
        }


        private void ResetFormulario()
        {
            // Limpiar TextBox            
            txtNombreApellidos.Clear();
            txtSector.Clear();
            txtLecturaAnterior.Clear();
            txtLecturaActual.Clear();
            txtMetrosConsumidos.Clear();
            txtObservaciones.Clear();

            // Reiniciar ComboBox
            cbxMedidor.SelectedIndex = -1;
            chkRevisionMedidor.Checked = false;

            // Reiniciar DateTimePickers (a la fecha actual)
            dtpMesConsumo.Value = DateTime.Now;
            dtpFechaLectura.Value = DateTime.Now;

            // Opcional: desactivar botones si estás controlando flujo
            guardarToolStripMenuItem.Enabled = false;            
                       
            
        }
    }
}
