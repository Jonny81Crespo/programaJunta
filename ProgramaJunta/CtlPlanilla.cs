using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramaJunta
{
    public partial class CtlPlanilla : UserControl
    {
        private DataTable datosPlanilla;

        public CtlPlanilla()
        {
            InitializeComponent();
        }


        private void CtlPlantilla_Load(object sender, EventArgs e)
        {
            CargarNumeroPlanilla();
            LlenarComboBoxUsuarios();
            // Seleccionar el mes actual (DateTime.Now.Month es 1 a 12, pero ComboBox usa 0 a 11)
            cbxConsumoMes.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void CargarNumeroPlanilla()
        {

            string query = "SELECT " +
               "ISNULL(MAX(NUMERO_SECUENCIA), 0) + 1 AS NUMERO_SECUENCIA, " +
               "FORMAT(ISNULL(MAX(NUMERO_FACTURA), 0) + 1,'0000000000') AS NUMERO_FACTURA " +
               "FROM PLANILLA;";

            DataTable resultado = SqlServerHelper.EjecutarConsulta(query);

            if (resultado.Rows.Count > 0)
            {
                DataRow fila = resultado.Rows[0];

                // Asignar resultados a los TextBox
                txtNumPlanilla.Text = fila["NUMERO_SECUENCIA"].ToString();
                txtNumFactura.Text = fila["NUMERO_FACTURA"].ToString();
            }
        }

        private void txtNumMedidor_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                CargarNumeroPlanilla();
                CargarDatos();
                string numeroMedidor = txtNumMedidor.Text.Trim();
                string consumoMesStr = string.Empty; // Variable para almacenar el nombre del mes

                if (cbxConsumoMes.SelectedItem != null)
                {
                    if (cbxConsumoMes.SelectedItem is DataRowView)
                    {
                        DataRowView selectedRow = cbxConsumoMes.SelectedItem as DataRowView;
                        consumoMesStr = selectedRow["NombreColumnaMes"].ToString(); // Reemplaza "NombreColumnaMes"
                    }
                    else
                    {
                        consumoMesStr = cbxConsumoMes.SelectedItem.ToString();
                    }
                }

                string checkQuery = $"SELECT COUNT(*) FROM PLANILLA WHERE NUMERO_MEDIDOR = N'{numeroMedidor}' AND CONSUMO_MES = N'{consumoMesStr}'" +
                    $"AND YEAR(FECHA_EMISION) = YEAR(GETDATE());";

                try
                {
                    // Ejecutar la consulta para verificar duplicados
                    DataTable result = SqlServerHelper.EjecutarConsulta(checkQuery); // Asumo que EjecutarConsulta devuelve un DataTable

                    if (result != null && result.Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(result.Rows[0][0]);
                        if (count > 0)
                        {
                            MessageBox.Show(
                                $"Ya existe un registro para el Medidor: '{numeroMedidor}' y el Mes de Consumo: '{consumoMesStr}'.\n" +
                                "No se puede guardar ni modificar un registro duplicado.",
                                "Registro Duplicado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return; // Detiene la ejecución del método para no intentar guardar
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar duplicados: " + ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Detiene la ejecución si hay un error al verificar
                }

                if (chbTotalPlanillas.Checked)
                {
                    chbTotalPlanillas.Enabled = false;
                    chbEncerarTotal.Enabled = true;
                    TotalPlanillas();
                }
                cbxFormaPago.Enabled = true;
                e.Handled = true;
                e.SuppressKeyPress = true; // Evita el sonido del Enter
            }
        }

        private void MostrarDatosSector(int idSector)
        {
            string query = $@"SELECT SECTOR FROM SECTORES WHERE CODIGO = {idSector};";

            DataTable resultado = SqlServerHelper.EjecutarConsulta(query);

            if (resultado.Rows.Count > 0)
            {
                DataRow fila = resultado.Rows[0];

                txtSector.Text = fila["SECTOR"].ToString();
            }
            else
            {
                txtSector.Text = "";
            }
        }

        private void MostrarDatosConsumo(int idMedidor)
        {
            string query = $@"SELECT TOP 1 fecha, LECTURA_ACTUAL, LECTURA_ANTERIOR, METROS_CONSUMO 
                            FROM consumo WHERE Numero_medidor = '{idMedidor}' ORDER BY fecha DESC; ";

            DataTable resultado = SqlServerHelper.EjecutarConsulta(query);

            if (resultado.Rows.Count > 0)
            {
                DataRow fila = resultado.Rows[0];

                txtLecturaAnterior.Text = fila["LECTURA_ANTERIOR"].ToString();
                txtLecturaActual.Text = fila["LECTURA_ACTUAL"].ToString();
                txtConsumom3.Text = fila["METROS_CONSUMO"].ToString();
            }
            else
            {
                txtSector.Text = "";
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
            string idMedidor = fila["NUMERO_MEDIDOR"].ToString();
            txtNumMedidor.Text = idMedidor; // Si quieres que también seleccione en el combo

            CargarDatos();
            cbxFormaPago.Enabled = true;
        }

        private void CargarDatos()
        {

            string IDSeleccionado = txtNumMedidor.Text;
            string query = $"select CODIGO_USUARIO, NOMBRES_APELLIDOS,SECTOR,NUMERO_CONEXION,TERCERA_EDAD,CAPACIDAD_DIFERENTE from MEDIDORES where Numero_medidor = '{IDSeleccionado}'";

            DataTable resultado = SqlServerHelper.EjecutarConsulta(query);

            if (resultado.Rows.Count > 0)
            {
                DataRow fila = resultado.Rows[0];

                // Mapeo: columna => textbox
                var mapeoTextBox = new Dictionary<string, System.Windows.Forms.TextBox>
        {
            { "CODIGO_USUARIO", txtCodigoUsuario },
            { "NOMBRES_APELLIDOS", txtNombresApellidos },
            { "NUMERO_CONEXION", txtNumConexion }

        };

                foreach (var par in mapeoTextBox)
                {
                    par.Value.Text = fila[par.Key]?.ToString() ?? "";
                }
                chbTercerEdad.Checked = Convert.ToInt32(fila["TERCERA_EDAD"]) == 1;
                chbCDiferente.Checked = Convert.ToInt32(fila["CAPACIDAD_DIFERENTE"]) == 1;

                MostrarDatosSector(Convert.ToInt32(fila["SECTOR"]));
                MostrarDatosConsumo(Convert.ToInt32(IDSeleccionado));
                LlenarDetallePlantilla(IDSeleccionado);


            }
            else
            {
                txtCodigoUsuario.Clear();
                txtNombresApellidos.Clear();
                txtSector.Clear();
                txtNumConexion.Clear();
                chbTercerEdad.Checked = false;
                chbCDiferente.Checked = false;
                MessageBox.Show("No se encuentra medidor");

            }

        }



        public void LlenarDetallePlantilla(string numeroMedidor)
        {
            // Query para seleccionar el último consumo y los datos del medidor asociado
            string query = $@"
            SELECT TOP 1
                C.TOTAL_BASICO,
                C.EXCEDENTES,
                C.TOTAL,
                C.DEUDA_TOTAL,
                C.MORA_TOTAL,
                C.SUSPENSION_SERVICIO,
                C.REINSTALACION_SERVICIO,
                C.FONDO_SOLIDARIO,
                M.CAPACIDAD_DIFERENTE,
                M.TERCERA_EDAD
            FROM
                CONSUMO AS C
            INNER JOIN
                MEDIDORES AS M ON C.NUMERO_MEDIDOR = M.NUMERO_MEDIDOR
            WHERE
                C.NUMERO_MEDIDOR = {numeroMedidor}
            ORDER BY
                C.FECHA DESC; -- Asumo que FECHA es la columna de fecha de registro en CONSUMO
        ";

            DataTable dt = SqlServerHelper.EjecutarConsulta(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Función auxiliar para obtener decimal de DataRow con seguridad
                Func<object, decimal> GetDecimalValue = (value) =>
                {
                    if (value != DBNull.Value)
                    {
                        return Convert.ToDecimal(value);
                    }
                    return 0m; // Default a 0.00 si es DBNull
                };

                // Asigna los valores a los TextBoxes
                txtBasico.Text = GetDecimalValue(row["TOTAL_BASICO"]).ToString("N2", CultureInfo.CurrentCulture);
                txtExcedente.Text = GetDecimalValue(row["EXCEDENTES"]).ToString("N2", CultureInfo.CurrentCulture);
                txtImporteActual.Text = GetDecimalValue(row["TOTAL"]).ToString("N2", CultureInfo.CurrentCulture); // Asumiendo que TOTAL es el "Importante Actual"
                txtDeudaPendiente.Text = GetDecimalValue(row["DEUDA_TOTAL"]).ToString("N2", CultureInfo.CurrentCulture);
                txtMora.Text = GetDecimalValue(row["MORA_TOTAL"]).ToString("N2", CultureInfo.CurrentCulture);
                txtSuspension.Text = GetDecimalValue(row["SUSPENSION_SERVICIO"]).ToString("N2", CultureInfo.CurrentCulture);
                txtReinstalacion.Text = GetDecimalValue(row["REINSTALACION_SERVICIO"]).ToString("N2", CultureInfo.CurrentCulture);
                txtFondoSolidario.Text = GetDecimalValue(row["FONDO_SOLIDARIO"]).ToString("N2", CultureInfo.CurrentCulture);

                // Campos que no vienen de la DB en el INSERT pero pueden existir o ser fijos
                // Inicialízalos a 0.00 si no los obtienes de la BD para que la suma funcione
                if (txtDerechoIns != null) txtDerechoIns.Text = "0.00";
                if (txtConexDom != null) txtConexDom.Text = "0.00";
                if (txtMultas != null) txtMultas.Text = "0.00";
                if (txtOtros != null) txtOtros.Text = "0.00";


                // Lógica para el descuento del 50%
                int capacidadDiferente = GetDecimalValue(row["CAPACIDAD_DIFERENTE"]) == 1 ? 1 : 0;
                int terceraEdad = GetDecimalValue(row["TERCERA_EDAD"]) == 1 ? 1 : 0;

                decimal totalBasico = GetDecimalValue(row["TOTAL_BASICO"]);
                decimal descuento = 0m;

                // Si CAPACIDAD_DIFERENTE es 1 O TERCERA_EDAD es 1, aplicar descuento
                if (capacidadDiferente == 1 || terceraEdad == 1)
                {
                    descuento = totalBasico / 2m; // La mitad del total_basico
                }

                txtDescuento.Text = descuento.ToString("N2", CultureInfo.CurrentCulture);
            }
            else
            {
                // Si no se encontraron datos, limpiar los TextBoxes
                LimpiarTextBoxes();
            }
            CalcularTotalAPagar(); // Llama al método del formulario para sumar todo

        }

        public void CalcularTotalAPagar()
        {
            decimal total = 0m;

            // Función auxiliar para parsear el texto de un TextBox a decimal
            // Retorna 0 si el texto no es un número válido.
            Func<System.Windows.Forms.TextBox, decimal> parseTextBoxValue = (textBox) =>
            {
                if (textBox != null && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    decimal value;
                    // Usamos NumberStyles.Any para permitir formatos con comas, puntos, etc.
                    // y CultureInfo.InvariantCulture para una interpretación consistente.
                    if (decimal.TryParse(textBox.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out value))
                    {
                        return value;
                    }
                    if (decimal.TryParse(textBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
                    {
                        return value;
                    }
                }
                return 0; // Si el TextBox es nulo, está vacío o no es un número válido
            };

            // Sumar los valores
            total += parseTextBoxValue(txtBasico);
            total += parseTextBoxValue(txtExcedente);
            // Puedes decidir si quieres incluir txtImportanteActual en esta suma.
            // Si txtImportanteActual es el campo "Total" de la BD, y TotalACobrar es la suma final,
            // no deberías sumar txtImportanteActual aquí, sino los componentes.
            // total += parseTextBoxValue(txtImportanteActual); 
            total += parseTextBoxValue(txtDeudaPendiente);
            total += parseTextBoxValue(txtMora);
            total += parseTextBoxValue(txtSuspension);
            total += parseTextBoxValue(txtReinstalacion);
            total += parseTextBoxValue(txtFondoSolidario);
            total += parseTextBoxValue(txtDerechoIns);
            total += parseTextBoxValue(txtConexDom);
            total += parseTextBoxValue(txtMultas);
            total += parseTextBoxValue(txtOtros);

            // Restar el descuento
            total -= parseTextBoxValue(txtDescuento);

            txtTotalACobrar.Text = total.ToString("N2", CultureInfo.CurrentCulture);

        }





        public void LlenarComboBoxUsuarios()
        {
            // Limpia cualquier elemento existente en el ComboBox para empezar desde cero            
            cbxResponsable.Items.Clear();

            try
            {
                string query = "SELECT USUARIO FROM usuarios"; // La consulta SQL para obtener los usuarios

                // Llama a tu método existente para obtener los datos en un DataTable
                // Asegúrate de reemplazar 'UtilidadDeBaseDeDatos' con el nombre real de tu clase
                DataTable usuariosTable = SqlServerHelper.EjecutarConsulta(query);

                // Verifica si el DataTable contiene filas
                if (usuariosTable != null && usuariosTable.Rows.Count > 0)
                {
                    // Establece la propiedad DisplayMember a la columna que deseas mostrar en el ComboBox
                    cbxResponsable.DisplayMember = "USUARIO";

                    // Opcionalmente, si tu consulta selecciona también un ID (ej. SELECT ID_USUARIO, USUARIO FROM usuarios),
                    // puedes usar ValueMember para almacenar ese valor subyacente.
                    // comboBox.ValueMember = "ID_USUARIO"; 

                    // Vincula el DataTable directamente al ComboBox
                    cbxResponsable.DataSource = usuariosTable;
                }
                else
                {
                    // Muestra un mensaje si no se encontraron usuarios
                    MessageBox.Show("No se encontraron usuarios en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Captura y muestra cualquier error que ocurra durante el proceso
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControlesPago(bool habilitar)
        {
            // Campos de Cantidad y Vuelto
            txtCantidadRecibida.Enabled = habilitar;

            // Campos de Cuotas
            txtCuota1.Enabled = habilitar;
            chbCanCuota1.Enabled = habilitar;
            txtCuota2.Enabled = habilitar;
            chbCanCuota2.Enabled = habilitar;

            // Campo de Responsable y Total Planilla
            cbxResponsable.Enabled = habilitar;
            txtTotalPlanilla.Enabled = habilitar;

            // Controles de Cancelado
            rdSi.Enabled = habilitar;
            rdNo.Enabled = habilitar;
            chbTotalPlanillas.Enabled = habilitar;
            //txtTotalPlanillas.Enabled = habilitar;// El campo de texto al lado del checkbox de "Total Planillas"

            // CheckBox de Encerar Total
            //chbEncerarTotal.Enabled = habilitar;
            decimal TotalAPagar = decimal.Parse(txtTotalACobrar.Text);
            txtTotalPlanilla.Text = TotalAPagar.ToString();

            // Si deshabilitamos, también podrías querer limpiar los valores o reiniciarlos
            if (!habilitar)
            {
                txtCantidadRecibida.Text = "0"; // O String.Empty
                txtVuelto.Text = "0";
                txtCuota1.Text = "0";
                chbCanCuota1.Checked = false;
                txtCuota2.Text = "0";
                chbCanCuota2.Checked = false;
                cbxResponsable.SelectedIndex = -1; // Deseleccionar cualquier item
                txtTotalPlanilla.Text = "0";
                rdSi.Checked = false;
                rdNo.Checked = false;
                chbEncerarTotal.Checked = false;
            }
        }

        private void cbxFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si hay un elemento seleccionado (SelectedIndex es 0 o mayor)
            if (cbxFormaPago.SelectedIndex > -1)
            {
                ConfigurarControlesPago(true); // Habilita todos los controles de pago
            }
            else
            {
                ConfigurarControlesPago(false); // Deshabilita y limpia los controles de pago
            }
        }

        private void txtCantidadRecibida_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtener el TextBox que disparó el evento
            TextBox currentTextBox = sender as TextBox;

            // --- Parte 1: Manejar el reemplazo de '.' por ',' ---
            // Si la tecla presionada es el punto '.'
            if (e.KeyChar == '.')
            {
                // Cancelar la pulsación original del punto
                e.Handled = true;

                // Si ya hay una coma en el texto, no agregar otra
                if (currentTextBox.Text.Contains(","))
                {
                    // No hacer nada, ya hay una coma
                    return;
                }
                else
                {
                    // Insertar la coma en la posición actual del cursor
                    int selectionStart = currentTextBox.SelectionStart;
                    currentTextBox.Text = currentTextBox.Text.Insert(selectionStart, ",");
                    currentTextBox.SelectionStart = selectionStart + 1; // Mover el cursor después de la coma
                    return; // Salir después de manejar el punto
                }
            }

            // --- Parte 2: Restricciones generales de entrada (solo números y coma) ---
            // Permitir solo números, la coma como separador decimal y teclas de control (como Backspace, Delete)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true; // Ignora la tecla si no es un número, control o coma
            }

            // Solo permitir una coma decimal (después de haber manejado el caso del punto)
            if ((e.KeyChar == ',') && (currentTextBox.Text.IndexOf(',') > -1))
            {
                e.Handled = true; // Ignora si ya hay una coma
            }


            // --- Parte 3: Lógica al presionar Enter ---
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Suprime el sonido de "ding" al presionar Enter

                // La validación y el cálculo deben hacerse con la cultura correcta
                // Usaremos la cultura de Ecuador para el parseo
                CultureInfo culturaEcuador = new CultureInfo("es-EC");

                decimal cantidadRecibida;
                decimal totalAPagar;

                // Intentar parsear usando la cultura de Ecuador (coma como separador decimal)
                if (decimal.TryParse(currentTextBox.Text, NumberStyles.Any, culturaEcuador, out cantidadRecibida) &&
                    decimal.TryParse(txtTotalACobrar.Text, NumberStyles.Any, culturaEcuador, out totalAPagar)) // Asegúrate de que txtTotal también use la misma cultura
                {
                    if (cantidadRecibida < totalAPagar)
                    {
                        MessageBox.Show("La Cantidad Recibida es menor que el Total a Pagar. Por favor, ajuste el monto.", "Pago Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    this.SelectNextControl((Control)sender, true, true, true, true); // Mueve el foco al siguiente control

                    decimal Vuelto = cantidadRecibida - totalAPagar;

                    // Si el vuelto es negativo, mostrar 0.00
                    decimal vueltoFinal = Math.Max(0, Vuelto);

                    // Mostrar el vuelto formateado con dos decimales, usando la cultura de Ecuador (coma)
                    txtVuelto.Text = vueltoFinal.ToString("N2", culturaEcuador);
                }
                else if (!string.IsNullOrEmpty(currentTextBox.Text) && !decimal.TryParse(currentTextBox.Text, NumberStyles.Any, culturaEcuador, out cantidadRecibida))
                {
                    MessageBox.Show("Por favor, ingrese un valor numérico válido para la Cantidad Recibida (use la coma ',' como separador decimal).", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    currentTextBox.Focus();
                    currentTextBox.SelectAll();
                }
            }

        }

        private void rdSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSi.Checked)
            {
                guardarToolStripMenuItem.Enabled = true;
            }
        }

        private void rdNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNo.Checked)
            {
                guardarToolStripMenuItem.Enabled = false;
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Validar datos críticos
            if (string.IsNullOrWhiteSpace(txtNombresApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtTotalACobrar.Text))
            {
                MessageBox.Show("Los campos 'Nombres y Apellidos' y 'Total a Cobrar' son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cultura para la entrada del usuario (coma como decimal)
            CultureInfo culturaEcuador = new CultureInfo("es-EC");
            // Cultura para la salida a SQL (punto como decimal, formato de fecha estándar)
            CultureInfo culturaSQL = CultureInfo.InvariantCulture;

            try
            {
                // 2. Recopilar y parsear todos los datos del formulario de manera segura
                // (Esta parte sigue siendo igual, se parsea la entrada del usuario)

                // --- Campos de Datos de Usuarios ---
                string numeroFactura = txtNumFactura.Text.Trim();
                int numeroPlanilla = 0; if (!int.TryParse(txtNumPlanilla.Text, out numeroPlanilla)) numeroPlanilla = 0;
                string numeroMedidor = txtNumMedidor.Text.Trim();
                int numeroConexion = 0; if (!int.TryParse(txtNumConexion.Text, out numeroConexion)) numeroConexion = 0;
                string codigoUsuario = txtCodigoUsuario.Text.Trim();
                string usuarioNombre = txtNombresApellidos.Text.Trim();
                string sector = txtSector.Text.Trim();
                DateTime fechaEmision = DateTime.Now; // O el valor de tu control DateTimePicker
                DateTime fechaPago = dtpFechaCobro.Value; // Asumo dtpFechaCobro
                string consumoMes = cbxConsumoMes.SelectedItem.ToString();
                int consumoMetros = 0; if (!int.TryParse(txtConsumom3.Text, out consumoMetros)) consumoMetros = 0;
                // ... (resto de campos de usuario/medidor) ...

                // --- Campos de Detalle de la Planilla ---
                decimal basico = 0; if (!decimal.TryParse(txtBasico.Text, NumberStyles.Any, culturaEcuador, out basico)) basico = 0;
                decimal excedente = 0; if (!decimal.TryParse(txtExcedente.Text, NumberStyles.Any, culturaEcuador, out excedente)) excedente = 0;
                decimal importeActual = 0; if (!decimal.TryParse(txtImporteActual.Text, NumberStyles.Any, culturaEcuador, out importeActual)) importeActual = 0;
                decimal deudaPendiente = 0; if (!decimal.TryParse(txtDeudaPendiente.Text, NumberStyles.Any, culturaEcuador, out deudaPendiente)) deudaPendiente = 0;
                int mesesPendientes = 0; if (!int.TryParse(txtMesesMora.Text, out mesesPendientes)) mesesPendientes = 0;
                decimal recargoMora = 0; if (!decimal.TryParse(txtMora.Text, NumberStyles.Any, culturaEcuador, out recargoMora)) recargoMora = 0;
                decimal multas = 0; if (!decimal.TryParse(txtMultas.Text, NumberStyles.Any, culturaEcuador, out multas)) multas = 0;
                decimal derechoInstalacion = 0; if (!decimal.TryParse(txtDerechoIns.Text, NumberStyles.Any, culturaEcuador, out derechoInstalacion)) derechoInstalacion = 0;
                decimal conexionDomiciliaria = 0; if (!decimal.TryParse(txtConexDom.Text, NumberStyles.Any, culturaEcuador, out conexionDomiciliaria)) conexionDomiciliaria = 0;
                decimal otros = 0; if (!decimal.TryParse(txtOtros.Text, NumberStyles.Any, culturaEcuador, out otros)) otros = 0;
                decimal fondoSolidario = 0; if (!decimal.TryParse(txtFondoSolidario.Text, NumberStyles.Any, culturaEcuador, out fondoSolidario)) fondoSolidario = 0;
                decimal suspensionServicio = 0; if (!decimal.TryParse(txtSuspension.Text, NumberStyles.Any, culturaEcuador, out suspensionServicio)) suspensionServicio = 0;
                decimal reinstalacionServicio = 0; if (!decimal.TryParse(txtReinstalacion.Text, NumberStyles.Any, culturaEcuador, out reinstalacionServicio)) reinstalacionServicio = 0;
                decimal totalMes = 0; if (!decimal.TryParse(txtTotalACobrar.Text, NumberStyles.Any, culturaEcuador, out totalMes)) totalMes = 0;
                decimal valorDescuento = 0; if (!decimal.TryParse(txtDescuento.Text, NumberStyles.Any, culturaEcuador, out valorDescuento)) valorDescuento = 0;

                // --- Campos de Pago ---
                int pagoEfectivo = 0;
                int pagoCheque = 0;
                string banco = null;
                string numeroCheque = null;

                if (cbxFormaPago.SelectedItem != null)
                {
                    string selectedFormaPago = cbxFormaPago.SelectedItem.ToString();
                    if (selectedFormaPago.Equals("Efectivo", StringComparison.OrdinalIgnoreCase))
                    {
                        pagoEfectivo = 1;
                    }
                    else if (selectedFormaPago.Equals("Cheque", StringComparison.OrdinalIgnoreCase))
                    {
                        pagoCheque = 1;
                        // banco = txtBanco.Text;
                        // numeroCheque = txtNumeroCheque.Text;
                    }
                }
                string responsable = null; // Inicializar como null o string.Empty

                if (cbxResponsable.SelectedItem != null)
                {
                    // Castear SelectedItem a DataRowView
                    DataRowView selectedRow = cbxResponsable.SelectedItem as DataRowView;

                    if (selectedRow != null)
                    {
                        // Acceder al valor de la columna que contiene el nombre.
                        // Reemplaza "nombreResponsable" con el nombre real de la columna en tu DataTable
                        // que contiene el nombre del responsable (el mismo que usaste para DisplayMember).
                        responsable = selectedRow["USUARIO"].ToString();
                    }
                }
                decimal cuotaCreditoUno = 0; if (!decimal.TryParse(txtCuota1.Text, NumberStyles.Any, culturaEcuador, out cuotaCreditoUno)) cuotaCreditoUno = 0;
                decimal cuotaCreditoDos = 0; if (!decimal.TryParse(txtCuota2.Text, NumberStyles.Any, culturaEcuador, out cuotaCreditoDos)) cuotaCreditoDos = 0;
                string terceraEdadStr = chbTercerEdad.Checked ? "Si" : "No"; // Ya la tienes definida arriba, usar esa
                string capacidadDiferenteStr = chbCDiferente.Checked ? "Si" : "No"; // Ya la tienes definida arriba, usar esa
                string descuentoCincuentaStr = "No"; // Según tu INSERT original, es 'No'
                bool direccionEducacionBool = false; // BIT NOT NULL


                // 3. Construir la consulta SQL CONCATENANDO LOS VALORES
                // ¡IMPORTANTE! Aquí se formatea TODO para que SQL Server lo entienda.
                // Esto reintroduce el riesgo de SQL Injection.
                // Para fechas: 'YYYY-MM-DD HH:mm:ss.fff' (formato ISO 8601)
                // Para decimales: Usar CultureInfo.InvariantCulture para el punto decimal
                // Para strings: 'N' + 'cadena' para NVARCHAR

                string query = $@"
                INSERT INTO PLANILLA (
                    NUMERO_SECUENCIA, NUMERO_MEDIDOR, NUMERO_CONEXION, USUARIO, CONSUMO_MES,
                    FECHA_EMISION, FECHA_PAGO, CONSUMO_METROS, BASICO, EXCEDENTE,
                    IMPORTE_ACTUAL, DEUDA_PENDIENTE, MESES_PENDIENTES, RECARGO_MORA, MULTAS,
                    DERECHO_INSTALACION, CONEXION_DOMICILIARIA, OTROS, TOTAL_MES, PAGO_EFECTIVO,
                    PAGO_CHEQUE, BANCO, NUMERO_CHEQUE, RESPONSABLE, NUMERO_FACTURA,
                    FONDO_SOLIDARIO, DIRECCION_EDUCACION, SUSPENSION_SERVICIO, REINSTALACION_SERVICIO,
                    CUOTA_CREDITO_UNO, CUOTA_CREDITO_DOS, VALOR_DESCUENTO, TERCERA_EDAD,
                    CAPACIDAD_DIFERENTE, DESCUENTO_CINCUENTA
                )
                VALUES (
                    (SELECT ISNULL(MAX(NUMERO_SECUENCIA), 0) + 1 FROM PLANILLA),
                    N'{numeroMedidor}', {numeroConexion}, N'{usuarioNombre}', N'{consumoMes.ToString(culturaSQL)}',
                    '{fechaEmision.ToString("yyyy-MM-dd HH:mm:ss.fff", culturaSQL)}', -- Formato ISO 8601 para datetime
                    '{fechaPago.ToString("yyyy-MM-dd HH:mm:ss.fff", culturaSQL)}',     -- Formato ISO 8601 para datetime
                    {consumoMetros}, {basico.ToString(culturaSQL)}, {excedente.ToString(culturaSQL)},
                    {importeActual.ToString(culturaSQL)}, {deudaPendiente.ToString(culturaSQL)}, {mesesPendientes},
                    {recargoMora.ToString(culturaSQL)}, {multas.ToString(culturaSQL)},
                    {derechoInstalacion.ToString(culturaSQL)}, {conexionDomiciliaria.ToString(culturaSQL)},
                    {otros.ToString(culturaSQL)}, {totalMes.ToString(culturaSQL)}, {pagoEfectivo},
                    {pagoCheque}, 
                    {(string.IsNullOrEmpty(banco) ? "NULL" : $"N'{banco}'")},
                    {(string.IsNullOrEmpty(numeroCheque) ? "NULL" : $"N'{numeroCheque}'")},
                    {(string.IsNullOrEmpty(responsable) ? "NULL" : $"N'{responsable}'")},
                    N'{numeroFactura}', {fondoSolidario.ToString(culturaSQL)},
                    {(direccionEducacionBool ? 1 : 0)}, -- bit se convierte a 1 o 0
                    {suspensionServicio.ToString(culturaSQL)}, {reinstalacionServicio.ToString(culturaSQL)},
                    {(cuotaCreditoUno == 0 ? "NULL" : cuotaCreditoUno.ToString(culturaSQL))},
                    {(cuotaCreditoDos == 0 ? "NULL" : cuotaCreditoDos.ToString(culturaSQL))},
                    {valorDescuento.ToString(culturaSQL)}, N'{terceraEdadStr}',
                    N'{capacidadDiferenteStr}', N'{descuentoCincuentaStr}'
                );";

                // 4. Llamar a tu método existente para ejecutar la consulta
                // Asegúrate de reemplazar 'DatabaseHelper' con el nombre real de tu clase de utilidades
                int filasAfectadas = SqlServerHelper.EjecutarComando(query); // <-- Aquí ya no se pasan los parámetros

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Registro guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Opcional: Limpiar los campos o actualizar la vista
                    LimpiarTextBoxes();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el registro: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Puedes imprimir la query para depuración:
                // Console.WriteLine(query);
            }

        }


        // Método auxiliar para limpiar o inicializar los TextBoxes
        private void LimpiarTextBoxes()
        {
            txtNumPlanilla.Text = "";
            txtNumMedidor.Text = "";
            txtCodigoUsuario.Text = "";
            txtNombresApellidos.Text = "";
            txtSector.Text = "";
            txtNumConexion.Text = "";
            txtLecturaAnterior.Text = "";
            txtConsumom3.Text = "";
            chbTercerEdad.Checked = false;
            chbCDiferente.Checked = false;

            txtBasico.Text = "0.00";
            txtExcedente.Text = "0.00";
            txtImporteActual.Text = "0.00";
            txtDeudaPendiente.Text = "0.00";
            txtMora.Text = "0.00";
            txtSuspension.Text = "0.00";
            txtReinstalacion.Text = "0.00";
            txtFondoSolidario.Text = "0.00";
            txtDerechoIns.Text = "0.00"; // Asumiendo que existe
            txtConexDom.Text = "0.00"; // Asumiendo que existe
            txtMultas.Text = "0.00"; // Asumiendo que existe
            txtOtros.Text = "0.00"; // Asumiendo que existe
            txtDescuento.Text = "0.00"; // Asumiendo que existe
            txtTotalACobrar.Text = "0.00";

            cbxFormaPago.SelectedIndex = -1;
            rdSi.Checked = false;
            rdNo.Checked = true;
        }

        private void imprimirReciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string numeroMedidor = txtNumMedidor.Text.Trim();

            if (string.IsNullOrWhiteSpace(numeroMedidor) || numeroMedidor == "0")
            {
                MessageBox.Show("Por favor, ingrese un número de medidor válido antes de generar el recibo.", "Medidor Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Recopilar todos los datos del recibo (MISMA LÓGICA QUE YA TIENES)
            // ... (Tu código existente para recopilar todos los valores de los TextBoxes, ComboBoxes, etc.) ...
            string codigoUsuario = txtCodigoUsuario.Text;
            string nombresApellidos = txtNombresApellidos.Text;
            string fechaCobro = dtpFechaCobro.Value.ToString("dd/MM/yyyy");
            string fechaEmision = DateTime.Now.ToString("dd/MM/yyyy");
            string mesConsumo = "";
            if (cbxConsumoMes.SelectedItem is DataRowView)
            {
                mesConsumo = ((DataRowView)cbxConsumoMes.SelectedItem)["NombreColumnaMes"].ToString();
            }
            else if (cbxConsumoMes.SelectedItem != null)
            {
                mesConsumo = cbxConsumoMes.SelectedItem.ToString();
            }

            CultureInfo culturaEcuador = new CultureInfo("es-EC");
            CultureInfo culturaLocal = CultureInfo.CurrentCulture;

            decimal basico = 0; decimal.TryParse(txtBasico.Text, NumberStyles.Any, culturaEcuador, out basico);
            decimal excedente = 0; decimal.TryParse(txtExcedente.Text, NumberStyles.Any, culturaEcuador, out excedente);
            decimal importeActual = 0; decimal.TryParse(txtImporteActual.Text, NumberStyles.Any, culturaEcuador, out importeActual);
            decimal deudaPendiente = 0; decimal.TryParse(txtDeudaPendiente.Text, NumberStyles.Any, culturaEcuador, out deudaPendiente);
            decimal recargoMora = 0; decimal.TryParse(txtMora.Text, NumberStyles.Any, culturaEcuador, out recargoMora);
            decimal fondoSolidario = 0; decimal.TryParse(txtFondoSolidario.Text, NumberStyles.Any, culturaEcuador, out fondoSolidario);
            decimal derechoInstalacion = 0; decimal.TryParse(txtDerechoIns.Text, NumberStyles.Any, culturaEcuador, out derechoInstalacion);
            decimal conexionDomiciliaria = 0; decimal.TryParse(txtConexDom.Text, NumberStyles.Any, culturaEcuador, out conexionDomiciliaria);
            decimal multas = 0; decimal.TryParse(txtMultas.Text, NumberStyles.Any, culturaEcuador, out multas);
            decimal otros = 0; decimal.TryParse(txtOtros.Text, NumberStyles.Any, culturaEcuador, out otros);
            decimal suspensionServicio = 0; decimal.TryParse(txtSuspension.Text, NumberStyles.Any, culturaEcuador, out suspensionServicio);
            decimal reinstalacion = 0; decimal.TryParse(txtReinstalacion.Text, NumberStyles.Any, culturaEcuador, out reinstalacion);
            decimal totalAPagar = 0; decimal.TryParse(txtTotalACobrar.Text, NumberStyles.Any, culturaEcuador, out totalAPagar);
            decimal valorDescuento = 0; decimal.TryParse(txtDescuento.Text, NumberStyles.Any, culturaEcuador, out valorDescuento);

            string responsable = "";
            if (cbxResponsable.SelectedItem is DataRowView)
            {
                responsable = ((DataRowView)cbxResponsable.SelectedItem)["USUARIO"].ToString();
            }
            else if (cbxResponsable.SelectedItem != null)
            {
                responsable = cbxResponsable.SelectedItem.ToString();
            }

            string numeroFactura = txtNumFactura.Text;


            // 2. Construir la cadena de impresión con comandos ESC/POS (MISMA LÓGICA QUE YA TIENES)
            // Este StringBuilder contendrá todo el texto y comandos que irían a la impresora
            StringBuilder sbImpresora = new StringBuilder();

            sbImpresora.Append("\x1B\x40"); // Inicializar la impresora
            sbImpresora.Append("\x1B\x61\x01"); // Centrar texto
            sbImpresora.Append("\x1B\x21\x20"); // Tamaño de fuente doble altura y ancho (para la impresora)

            sbImpresora.Append("JUNTA ADMINISTRADORA DE AGUA\n");
            sbImpresora.Append("POTABLE QUINDILIG\n");
            sbImpresora.Append("\n");

            sbImpresora.Append("\x1B\x21\x00"); // Restaurar fuente normal (para la impresora)
            sbImpresora.Append("\x1B\x61\x00"); // Alinear a la izquierda (para la impresora)

            sbImpresora.Append("No. Planilla: " + txtNumPlanilla.Text + "\n");
            sbImpresora.Append("No. Medidor: " + numeroMedidor + "\n");
            sbImpresora.Append("Codigo Usuario: " + codigoUsuario + "\n");
            sbImpresora.Append("Nombres y Apellidos: " + nombresApellidos + "\n");
            sbImpresora.Append("Consumo de: " + mesConsumo + "\n");
            sbImpresora.Append("Lectura Anterior: " + txtLecturaAnterior.Text + "\n");
            sbImpresora.Append("Lectura Actual: " + txtLecturaActual.Text + "\n");
            sbImpresora.Append("Consumo m3: " + txtConsumom3.Text + "\n");
            sbImpresora.Append("Fecha Cobro: " + fechaCobro + "\n");
            sbImpresora.Append("Fecha Emision: " + fechaEmision + "\n");
            sbImpresora.Append("----------------------------------------\n");
            sbImpresora.Append("DETALLE DE LA PLANILLA\n");
            sbImpresora.Append("----------------------------------------\n");

            sbImpresora.Append(string.Format("Basico:{0,25:N2}\n", basico));
            sbImpresora.Append(string.Format("Excedente:{0,22:N2}\n", excedente));
            sbImpresora.Append(string.Format("Importe Actual:{0,17:N2}\n", importeActual));
            sbImpresora.Append(string.Format("Deuda Pendiente:{0,16:N2}\n", deudaPendiente));
            sbImpresora.Append(string.Format("Recargo por Mora:{0,15:N2}\n", recargoMora));
            sbImpresora.Append(string.Format("Fondo Solidario:{0,16:N2}\n", fondoSolidario));
            sbImpresora.Append(string.Format("Derecho de Instalacion:{0,9:N2}\n", derechoInstalacion));
            sbImpresora.Append(string.Format("Conexion Domiciliaria:{0,8:N2}\n", conexionDomiciliaria));
            sbImpresora.Append(string.Format("Multas:{0,25:N2}\n", multas));
            sbImpresora.Append(string.Format("Otros:{0,26:N2}\n", otros));
            sbImpresora.Append(string.Format("Suspension del Servicio:{0,8:N2}\n", suspensionServicio));
            sbImpresora.Append(string.Format("Reinstalacion:{0,17:N2}\n", reinstalacion));
            sbImpresora.Append(string.Format("Valor Descuento:{0,16:N2}\n", valorDescuento));

            sbImpresora.Append("----------------------------------------\n");
            sbImpresora.Append(string.Format("TOTAL A PAGAR:{0,16:N2}\n", totalAPagar));
            sbImpresora.Append("----------------------------------------\n");

            sbImpresora.Append("Cuotas Credito\n");
            sbImpresora.Append(string.Format("Cuota 1:{0,24:N2}\n", decimal.Parse(txtCuota1.Text, NumberStyles.Any, culturaEcuador)));
            sbImpresora.Append(string.Format("Cuota 2:{0,24:N2}\n", decimal.Parse(txtCuota2.Text, NumberStyles.Any, culturaEcuador)));

            sbImpresora.Append("Recaudador (a): " + responsable + "\n");
            sbImpresora.Append("Numero Factura: " + numeroFactura + "\n");
            sbImpresora.Append("\n\n");

            // 3. Crear la cadena para la VISTA PREVIA (sin comandos ESC/POS)
            string reciboParaVistaPrevia = sbImpresora.ToString();


            // Regex para eliminar comandos ESC/POS
            // Un comando ESC/POS generalmente comienza con ESC (0x1B) o GS (0x1D)
            // y le siguen uno o más bytes. Esto es una simplificación, ya que los comandos pueden ser complejos.
            // Aquí intentamos quitar:
            // - \x1B (ESC) seguido de cualquier número de caracteres no-espacio hasta un salto de línea o otro ESC
            // - \x1D (GS) seguido de cualquier número de caracteres no-espacio hasta un salto de línea o otro ESC
            // Esto es una simplificación, un parser más robusto sería complejo.
            // Para los comandos que has usado, esto debería ser suficiente.
            reciboParaVistaPrevia = Regex.Replace(reciboParaVistaPrevia, @"[\x1B\x1D][^\x1B\x1D\n]*", "");
            // Regex.Replace(input, @"\x1B\x21.", ""); // Elimina ESC ! y el siguiente byte
            // Regex.Replace(input, @"\x1B\x61.", ""); // Elimina ESC a y el siguiente byte
            // Regex.Replace(input, @"\x1B\x40", "");  // Elimina ESC @
            // Regex.Replace(input, @"\x1D\x56\x41.", ""); // Elimina GS V A y el siguiente byte (corte)


            // 4. Crear y mostrar la ventana de vista previa
            // Pasa 'this' (una referencia a la instancia actual de TuFormulario) al constructor
            FormVistaPreviaRecibo vistaPreviaForm = new FormVistaPreviaRecibo(reciboParaVistaPrevia);
            vistaPreviaForm.ShowDialog(); // Muestra la ventana de forma modal


            // 4. Preguntar al usuario si desea imprimir (OPCIONAL, si no tienes botón de imprimir en la vista previa)
            DialogResult dialogResult = MessageBox.Show("¿Desea imprimir este recibo ahora?", "Confirmar Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // Si el usuario confirma, entonces envía el texto a la impresora
                // (La misma lógica de impresión que tenías antes)
                try
                {
                    // Ejemplo para puerto serie (ajusta "COM1" y parámetros):
                    using (SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One))
                    {
                        serialPort.Open();
                        // Asegúrate de añadir el comando de corte aquí antes de imprimir
                        byte[] printBytes = Encoding.UTF8.GetBytes(reciboParaVistaPrevia + "\x1D\x56\x41\x00");
                        serialPort.Write(printBytes, 0, printBytes.Length);
                        serialPort.Close();
                        MessageBox.Show("Recibo enviado a la impresora.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Acceso denegado al puerto serie. Asegúrate de que no esté en uso por otra aplicación.", "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("El puerto serie ya está abierto o no existe.", "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al imprimir el recibo: " + ex.Message, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        decimal totalPlanillasAcumulado = 0;

        private void chbTotalPlanillas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTotalPlanillas.Checked)
            {
                chbEncerarTotal.Enabled = true;
                TotalPlanillas();
            }
            else
            {
                chbEncerarTotal.Enabled = false;
                totalPlanillasAcumulado = 0;
                txtTotalPlanillas.Text = string.Empty;
            }
        }
        private void TotalPlanillas()
        {

            decimal valorPlanillaActual = decimal.Parse(txtTotalACobrar.Text);
            totalPlanillasAcumulado += valorPlanillaActual;
            txtTotalPlanillas.Text = totalPlanillasAcumulado.ToString("N2"); // Formatear a 2 decimales

        }

        private void chbEncerarTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEncerarTotal.Checked)
            {

                // Si el total ya se ha mostrado en txtTotalPlanillas al agregar,
                // aquí simplemente confirmamos y reiniciamos.
                // txtTotalPlanillas.Text = totalPlanillasAcumulado.ToString("N2"); // Esto ya debería estar mostrando el acumulado si se agregaron planillas

                MessageBox.Show($"El total de todas las planillas es: {totalPlanillasAcumulado.ToString("N2")}", "Total Final", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Resetear el acumulador y el campo de total de planillas
                totalPlanillasAcumulado = 0;
                txtTotalPlanillas.Text = "0.00"; // O "" si prefieres que esté vacío

                // Deshabilitar chbEncerarTotal si no hay nada que encerar
                chbEncerarTotal.Enabled = false;
                chbTotalPlanillas.Enabled = true;
            }
        }
    }
}
