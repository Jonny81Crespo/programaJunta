using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ProgramaJunta
{
    public partial class FormVistaPreviaRecibo : Form
    {
        public FormVistaPreviaRecibo()
        {
            InitializeComponent();
        }
        public FormVistaPreviaRecibo(string reciboTexto)
        {
            InitializeComponent();
            // Asigna el texto generado al RichTextBox (asumo que se llama richTextBox1)
            richTextBox1.Text = reciboTexto;

            // Opcional: Asegurarse de que el RichTextBox sea solo de lectura
            richTextBox1.ReadOnly = true;
        }

        // Si agregaste un botón "Imprimir" en esta ventana de vista previa
        private void btnImprimirDesdeVistaPrevia_Click(object sender, EventArgs e)
        {
            // Aquí puedes colocar la lógica de impresión del recibo.
            // Podrías pasar el mismo 'reciboTexto' a un método de impresión
            // que realice la conexión al puerto serie/red.
            // O podrías hacer que este formulario reciba el objeto sb directamente.

            // Por simplicidad, llamaremos a la lógica de impresión que ya tienes.
            // Tendrás que hacer que esa lógica sea accesible desde aquí,
            // quizás haciendo el método de impresión en el formulario principal 'public static'
            // o pasando una referencia al formulario principal (menos recomendable).

            // LA MEJOR MANERA:
            // Pasa el mismo string de recibo a una función global o del DatabaseHelper
            // que se encargue de la impresión.

            // Ejemplo (asumiendo que tienes un método estático de impresión en DatabaseHelper):
            // DatabaseHelper.ImprimirReciboDirecto(richTextBox1.Text);
            // MessageBox.Show("Impresión enviada desde la vista previa.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // O, si prefieres que la vista previa solo muestre y la impresión se maneje solo desde el formulario principal:
            MessageBox.Show("Esta es solo una vista previa. Use el botón 'Imprimir' en la ventana principal para imprimir físicamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Si agregaste un botón "Cerrar" en esta ventana
        private void btnCerrarVistaPrevia_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra la ventana de vista previa
        }

    }
}
