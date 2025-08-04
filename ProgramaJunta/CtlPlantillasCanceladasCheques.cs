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
    public partial class CtlPlantillasCanceladasCheques : UserControl
    {
        public CtlPlantillasCanceladasCheques()
        {
            InitializeComponent();
        }
        private void CtlPlantillasCanceladasCheques_Load(object sender, EventArgs e)
        {
            CargarNombreUsuario();

        }


        private void CargarNombreUsuario()
        {        
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}