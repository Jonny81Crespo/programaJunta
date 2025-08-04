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
    public partial class CtlSectores : UserControl
    {

        private DataTable datosSectores;
        private bool modoEdicion = false; // false = nuevo, true = editar

        public CtlSectores()
        {
            InitializeComponent();
        }


        private void CtlSectores_Load(object sender, EventArgs e)
        {
            CargarSectores();
        }

        private void CargarSectores()
        {
            guardarToolStripMenuItem.Enabled = false;
            datosSectores = SqlServerHelper.EjecutarConsulta("SELECT CODIGO, SECTOR FROM SECTORES");

            cbxCodigoSector.DataSource = datosSectores;
            cbxCodigoSector.DisplayMember = "CODIGO";
            cbxCodigoSector.ValueMember = "SECTOR";
            cbxCodigoSector.SelectedIndex = -1;

            txtNombreSector.Clear();
            txtNombreSector.ReadOnly = true;
            cbxCodigoSector.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cbxCodigoSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCodigoSector.SelectedItem is DataRowView fila)
            {
                txtNombreSector.Text = fila["SECTOR"].ToString();
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable resultado = SqlServerHelper.EjecutarConsulta("SELECT ISNULL(MAX(CODIGO), 0) + 1 as CODIGO FROM SECTORES");

            if (resultado.Rows.Count > 0)
            {
                cbxCodigoSector.DataSource = null;
                cbxCodigoSector.Items.Clear();
                cbxCodigoSector.DropDownStyle = ComboBoxStyle.DropDown;
                cbxCodigoSector.Text = resultado.Rows[0]["CODIGO"].ToString();
            }

            cbxCodigoSector.Enabled = false;
            txtNombreSector.ReadOnly = false;
            txtNombreSector.Clear();

            guardarToolStripMenuItem.Enabled = true;

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreSector.Text))
            {
                MessageBox.Show("El nombre del sector no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = txtNombreSector.Text.Trim().Replace("'", "''");

            if (modoEdicion)
            {
                // Modo editar (UPDATE)
                if (cbxCodigoSector.SelectedItem is DataRowView fila)
                {
                    int codigo = Convert.ToInt32(fila["CODIGO"]);

                    DialogResult confirmacion = MessageBox.Show("¿Deseas guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmacion == DialogResult.Yes)
                    {
                        SqlServerHelper.EjecutarComando($"UPDATE SECTORES SET SECTOR = '{nombre}' WHERE CODIGO = {codigo}");
                        MessageBox.Show("Sector actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                // Modo nuevo (INSERT)
                int nuevoCodigo = Convert.ToInt32(cbxCodigoSector.Text);

                DialogResult confirmacion = MessageBox.Show("¿Deseas agregar este nuevo sector?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    SqlServerHelper.EjecutarComando($"INSERT INTO SECTORES (CODIGO, SECTOR) VALUES ({nuevoCodigo}, '{nombre}')");
                    MessageBox.Show("Nuevo sector agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            modoEdicion = false;
            cbxCodigoSector.Enabled = true;
            txtNombreSector.ReadOnly = true;
            CargarSectores();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Validar si hay un elemento seleccionado
            if (cbxCodigoSector.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona un sector para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cbxCodigoSector.DropDownStyle = ComboBoxStyle.DropDown;
            guardarToolStripMenuItem.Enabled = true;
            modoEdicion = true; // Estamos en modo editar

            cbxCodigoSector.Enabled = true; // Si el código no debe cambiar
            txtNombreSector.ReadOnly = false;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbxCodigoSector.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona un sector para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbxCodigoSector.SelectedItem is DataRowView fila)
            {
                DialogResult confirmacion = MessageBox.Show("¿Deseas eliminar este sector?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmacion != DialogResult.Yes)
                    return;

                int codigo = Convert.ToInt32(fila["CODIGO"]);

                SqlServerHelper.EjecutarComando($"DELETE FROM SECTORES WHERE CODIGO = {codigo}");
                MessageBox.Show("Sector eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarSectores();
            }
        }


        private void txtNombreSector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Opcional: evita el sonido de "ding"
                guardarToolStripMenuItem.PerformClick(); // Simula el click del botón
            }
        }
    }
}
