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
    public partial class CtlIngresosDiarios : UserControl
    {
        public CtlIngresosDiarios()
        {
            InitializeComponent();
        }  

        private void CtlIngresosDiarios_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        public void CargarDatos()
        {
            string query = $"SELECT * FROM PLANILLA";
            DataTable datos = SqlServerHelper.EjecutarConsulta(query);
            dgvIngresosDiarios.DataSource = datos;            
        }
    }
}
