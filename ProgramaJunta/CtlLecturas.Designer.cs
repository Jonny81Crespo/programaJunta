namespace ProgramaJunta
{
    partial class CtlLecturas
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            nuevoToolStripMenuItem = new ToolStripMenuItem();
            guardarToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            búsqedaDeMdidoresToolStripMenuItem = new ToolStripMenuItem();
            cambioMedidorToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            txtSector = new TextBox();
            txtNombreApellidos = new TextBox();
            cbxMedidor = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            chkRevisionMedidor = new CheckBox();
            panel3 = new Panel();
            dtpMesConsumo = new DateTimePicker();
            dtpFechaLectura = new DateTimePicker();
            txtLecturaActual = new TextBox();
            txtMetrosConsumidos = new TextBox();
            txtLecturaAnterior = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            panel4 = new Panel();
            txtObservaciones = new TextBox();
            label10 = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { nuevoToolStripMenuItem, guardarToolStripMenuItem, eliminarToolStripMenuItem, búsqedaDeMdidoresToolStripMenuItem, cambioMedidorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(928, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // nuevoToolStripMenuItem
            // 
            nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            nuevoToolStripMenuItem.Size = new Size(54, 20);
            nuevoToolStripMenuItem.Text = "Nuevo";
            nuevoToolStripMenuItem.Click += nuevoToolStripMenuItem_Click;
            // 
            // guardarToolStripMenuItem
            // 
            guardarToolStripMenuItem.Enabled = false;
            guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            guardarToolStripMenuItem.Size = new Size(61, 20);
            guardarToolStripMenuItem.Text = "Guardar";
            guardarToolStripMenuItem.Click += guardarToolStripMenuItem_Click;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(104, 20);
            eliminarToolStripMenuItem.Text = "Eliminar Lectura";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // búsqedaDeMdidoresToolStripMenuItem
            // 
            búsqedaDeMdidoresToolStripMenuItem.Name = "búsqedaDeMdidoresToolStripMenuItem";
            búsqedaDeMdidoresToolStripMenuItem.Size = new Size(133, 20);
            búsqedaDeMdidoresToolStripMenuItem.Text = "Imprimir Notificación";
            // 
            // cambioMedidorToolStripMenuItem
            // 
            cambioMedidorToolStripMenuItem.Name = "cambioMedidorToolStripMenuItem";
            cambioMedidorToolStripMenuItem.Size = new Size(54, 20);
            cambioMedidorToolStripMenuItem.Text = "Buscar";
            cambioMedidorToolStripMenuItem.Click += cambioMedidorToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(txtSector);
            panel1.Controls.Add(txtNombreApellidos);
            panel1.Controls.Add(cbxMedidor);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(138, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(679, 178);
            panel1.TabIndex = 6;
            // 
            // txtSector
            // 
            txtSector.Enabled = false;
            txtSector.Location = new Point(156, 127);
            txtSector.Name = "txtSector";
            txtSector.Size = new Size(507, 23);
            txtSector.TabIndex = 11;
            // 
            // txtNombreApellidos
            // 
            txtNombreApellidos.Enabled = false;
            txtNombreApellidos.Location = new Point(156, 76);
            txtNombreApellidos.Name = "txtNombreApellidos";
            txtNombreApellidos.Size = new Size(507, 23);
            txtNombreApellidos.TabIndex = 10;
            // 
            // cbxMedidor
            // 
            cbxMedidor.FormattingEnabled = true;
            cbxMedidor.Location = new Point(156, 21);
            cbxMedidor.Name = "cbxMedidor";
            cbxMedidor.Size = new Size(158, 23);
            cbxMedidor.TabIndex = 9;
            cbxMedidor.SelectedIndexChanged += cbxMedidor_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 127);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 8;
            label3.Text = "Sector";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 79);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 7;
            label2.Text = "Nombres y Apellidos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 29);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 6;
            label1.Text = "Número de Medidor";
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(chkRevisionMedidor);
            panel2.Location = new Point(138, 251);
            panel2.Name = "panel2";
            panel2.Size = new Size(274, 51);
            panel2.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 20);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 9;
            label4.Text = "Revisión Medidor";
            // 
            // chkRevisionMedidor
            // 
            chkRevisionMedidor.AutoSize = true;
            chkRevisionMedidor.CheckAlign = ContentAlignment.MiddleRight;
            chkRevisionMedidor.Enabled = false;
            chkRevisionMedidor.Location = new Point(132, 21);
            chkRevisionMedidor.Name = "chkRevisionMedidor";
            chkRevisionMedidor.Size = new Size(15, 14);
            chkRevisionMedidor.TabIndex = 8;
            chkRevisionMedidor.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(dtpMesConsumo);
            panel3.Controls.Add(dtpFechaLectura);
            panel3.Controls.Add(txtLecturaActual);
            panel3.Controls.Add(txtMetrosConsumidos);
            panel3.Controls.Add(txtLecturaAnterior);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Location = new Point(138, 334);
            panel3.Name = "panel3";
            panel3.Size = new Size(679, 124);
            panel3.TabIndex = 7;
            // 
            // dtpMesConsumo
            // 
            dtpMesConsumo.CustomFormat = "MMMM";
            dtpMesConsumo.Enabled = false;
            dtpMesConsumo.Format = DateTimePickerFormat.Custom;
            dtpMesConsumo.Location = new Point(488, 14);
            dtpMesConsumo.Name = "dtpMesConsumo";
            dtpMesConsumo.Size = new Size(175, 23);
            dtpMesConsumo.TabIndex = 19;
            dtpMesConsumo.Value = new DateTime(2025, 7, 27, 0, 0, 0, 0);
            // 
            // dtpFechaLectura
            // 
            dtpFechaLectura.Enabled = false;
            dtpFechaLectura.Format = DateTimePickerFormat.Short;
            dtpFechaLectura.Location = new Point(156, 14);
            dtpFechaLectura.Name = "dtpFechaLectura";
            dtpFechaLectura.Size = new Size(158, 23);
            dtpFechaLectura.TabIndex = 18;
            dtpFechaLectura.Value = new DateTime(2025, 7, 27, 0, 0, 0, 0);
            // 
            // txtLecturaActual
            // 
            txtLecturaActual.Enabled = false;
            txtLecturaActual.Location = new Point(488, 53);
            txtLecturaActual.Name = "txtLecturaActual";
            txtLecturaActual.Size = new Size(175, 23);
            txtLecturaActual.TabIndex = 17;
            txtLecturaActual.TextChanged += txtLecturaActual_TextChanged;
            txtLecturaActual.KeyPress += txtLecturaActual_KeyPress;
            // 
            // txtMetrosConsumidos
            // 
            txtMetrosConsumidos.Enabled = false;
            txtMetrosConsumidos.Location = new Point(156, 88);
            txtMetrosConsumidos.Name = "txtMetrosConsumidos";
            txtMetrosConsumidos.Size = new Size(158, 23);
            txtMetrosConsumidos.TabIndex = 15;
            // 
            // txtLecturaAnterior
            // 
            txtLecturaAnterior.Enabled = false;
            txtLecturaAnterior.Location = new Point(156, 50);
            txtLecturaAnterior.Name = "txtLecturaAnterior";
            txtLecturaAnterior.Size = new Size(158, 23);
            txtLecturaAnterior.TabIndex = 14;
            txtLecturaAnterior.KeyPress += txtLecturaAnterior_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(370, 14);
            label9.Name = "label9";
            label9.Size = new Size(100, 15);
            label9.TabIndex = 11;
            label9.Text = "Mes de Consumo";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(370, 53);
            label8.Name = "label8";
            label8.Size = new Size(83, 15);
            label8.TabIndex = 10;
            label8.Text = "Lectura Actual";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 53);
            label7.Name = "label7";
            label7.Size = new Size(92, 15);
            label7.TabIndex = 9;
            label7.Text = "Lectura Anterior";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 91);
            label6.Name = "label6";
            label6.Size = new Size(114, 15);
            label6.TabIndex = 8;
            label6.Text = "Metros Consumidos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 14);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 7;
            label5.Text = "Fecha de Lectura";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtObservaciones);
            panel4.Controls.Add(label10);
            panel4.Location = new Point(138, 490);
            panel4.Name = "panel4";
            panel4.Size = new Size(679, 59);
            panel4.TabIndex = 8;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Enabled = false;
            txtObservaciones.Location = new Point(156, 19);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(507, 23);
            txtObservaciones.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(11, 22);
            label10.Name = "label10";
            label10.Size = new Size(84, 15);
            label10.TabIndex = 7;
            label10.Text = "Observaciones";
            // 
            // CtlLecturas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Name = "CtlLecturas";
            Size = new Size(928, 572);
            Load += CtlLecturas_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem nuevoToolStripMenuItem;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private ToolStripMenuItem cambioMedidorToolStripMenuItem;
        private ToolStripMenuItem búsqedaDeMdidoresToolStripMenuItem;
        private Panel panel1;
        private TextBox txtSector;
        private TextBox txtNombreApellidos;
        private ComboBox cbxMedidor;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private CheckBox chkRevisionMedidor;
        private Panel panel3;
        private TextBox txtLecturaActual;
        private TextBox txtMetrosConsumidos;
        private TextBox txtLecturaAnterior;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Panel panel4;
        private TextBox txtObservaciones;
        private Label label10;
        private DateTimePicker dtpFechaLectura;
        private DateTimePicker dtpMesConsumo;
        private Label label4;
    }
}
