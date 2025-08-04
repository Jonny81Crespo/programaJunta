using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProgramaJunta
{
    public partial class FrmBusqueda : Form
    {
        private DataTable datosOriginales;

        public FrmBusqueda()
        {
            InitializeComponent();
        }
        private void FrmBusqueda_Load(object sender, EventArgs e)
        {
            CargarDatos();

        }
        private void CargarDatos()
        {
            datosOriginales = SqlServerHelper.EjecutarConsulta("SELECT * FROM MEDIDORES");
            dataGridView1.DataSource = datosOriginales;
            //Insert o update
            //string nombre = "Juan";
            // SQLiteHelper.EjecutarComando($"INSERT INTO PLANILLA (Nombre) VALUES ('{nombre}')");

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Solo números
            }
        }

        private void AplicarFiltros()
        {
            string nombreFiltro = txtSearch.Text.Trim().Replace("'", "''");
            string idFiltro = txtId.Text.Trim();

            List<string> condiciones = new List<string>();

            if (!string.IsNullOrEmpty(nombreFiltro))
            {
                condiciones.Add($"NOMBRES_APELLIDOS LIKE '%{nombreFiltro}%'");
            }

            if (!string.IsNullOrEmpty(idFiltro) && System.Text.RegularExpressions.Regex.IsMatch(idFiltro, @"^\d+$"))
            {
                condiciones.Add($"Convert(ID, 'System.String') LIKE '%{idFiltro}%'");
            }

            if (chbActivos.Checked)
            {
                condiciones.Add("activo = 1");
            }

            if (chbInactivos.Checked)
            {
                condiciones.Add("activo = 0");
            }

            // Solo aplicar filtro por fecha si la fecha es diferente a la actual (o una fecha por defecto si prefieres)
            if (dateFecha.Enabled)
            {
                // Filtro por fecha seleccionada en el DateTimePicker                
                string fechaString = dateFecha.Value.ToString("dd/MM/yyyy");
                condiciones.Add($"fecha = '{fechaString}'"); // Si usas DataTable, usa comillas simples
            }


            string filtroFinal = string.Join(" AND ", condiciones);

            DataView dv = datosOriginales.DefaultView;
            dv.RowFilter = filtroFinal;

            if (!chbFecha.Checked)
            {
                // ✅ Verificar si hay resultados. Si no, quitar el filtro para mostrar todo.
                if (dv.Count == 0)
                {
                    dv.RowFilter = ""; // Esto quita el filtro y muestra todo de nuevo
                }
            }

            dataGridView1.DataSource = dv;
        }

        private void chbActivo_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {

            AplicarFiltros();

        }

        private void chnInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void chbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFecha.Checked)
            {
                dateFecha.Enabled = true;
                AplicarFiltros();
            }
            else
            {
                dateFecha.Enabled = false;
                AplicarFiltros();
            }
        }

        public delegate void UsuarioSeleccionadoHandler(DataRow filaUsuario);
        public event UsuarioSeleccionadoHandler UsuarioSeleccionado;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView fila = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                // Disparar el evento
                UsuarioSeleccionado?.Invoke(fila.Row);

                this.Close();
            }
        }
    }
}
