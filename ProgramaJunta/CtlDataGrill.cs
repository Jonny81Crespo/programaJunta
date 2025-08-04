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
    public partial class CtlDataGrill : UserControl
    {
        private DataTable datosFondosMes;
        private string tablaActual = "";

        public CtlDataGrill()
        {
            InitializeComponent();
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaFinal.Value >= dtpFechaInicial.Value)
            {
                FiltrarPorFechas();
            }
            else
            {
                MessageBox.Show("La fecha final no puede ser menor que la inicial.");
            }

        }

        private void FiltrarPorFechas()
        {

            string fechaInicio = dtpFechaInicial.Value.ToString("yyyy-MM-dd");
            string fechaFin = dtpFechaFinal.Value.ToString("yyyy-MM-dd");
            string query = "";

            switch (tablaActual)
            {
                case ("FONDO_MES"):
                    query = $"SELECT * FROM FONDO_MES WHERE Fecha_Pago >= '{fechaInicio}' AND Fecha_Pago <= '{fechaFin}';";
                    break;

                case ("NUEVOS_INGRESOS"):
                    query = $"SELECT * FROM NUEVOS_INGRESOS WHERE FECHA_INGRESO >= '{fechaInicio}' AND FECHA_INGRESO <= '{fechaFin}';";
                    break;
                    
                default:
                    MessageBox.Show("Error al llamar formulario");
                    break;
            }

            datosFondosMes = SqlServerHelper.EjecutarConsulta(query);
            dgvFondoMes.DataSource = datosFondosMes;         
                
            
        }

        public void CargarDatos(string nombreTabla)
        {
            string query = $"SELECT * FROM {nombreTabla}";
            DataTable datos = SqlServerHelper.EjecutarConsulta(query);
            dgvFondoMes.DataSource = datos;
            tablaActual = nombreTabla;
        }       
    }
}
