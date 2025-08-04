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
    public partial class CtlIngresosMensual : UserControl
    {
        public CtlIngresosMensual()
        {
            InitializeComponent();
        }

        private void CtlIngresosMensual_Load(object sender, EventArgs e)
        {
            txtMes.Text = DateTime.Now.ToString("MMMM").ToUpper();
            txtAno.Text = DateTime.Now.Year.ToString();
        }
    }
}
