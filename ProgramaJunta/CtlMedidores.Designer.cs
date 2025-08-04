namespace ProgramaJunta
{
    partial class CtlMedidores
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
            modificarToolStripMenuItem = new ToolStripMenuItem();
            cambioMedidorToolStripMenuItem = new ToolStripMenuItem();
            imprimirReciboToolStripMenuItem = new ToolStripMenuItem();
            buscarToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            txtCodigoUsuario = new TextBox();
            txtNumConexion = new TextBox();
            txtCodigoSector = new TextBox();
            txtTelefono = new TextBox();
            txtNombresApellidos = new TextBox();
            txtMedidor = new TextBox();
            txtLecturaActual = new TextBox();
            txtValorIngreso = new TextBox();
            cbxNombreSector = new ComboBox();
            chbCapacidadDif = new CheckBox();
            chbTercerEdad = new CheckBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            cbxCategoriaUsuario = new ComboBox();
            dtpFecha = new DateTimePicker();
            dtpFechNacimiento = new DateTimePicker();
            cbxId = new ComboBox();
            lblId = new Label();
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { nuevoToolStripMenuItem, guardarToolStripMenuItem, modificarToolStripMenuItem, cambioMedidorToolStripMenuItem, imprimirReciboToolStripMenuItem, buscarToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(777, 24);
            menuStrip1.TabIndex = 1;
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
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.Size = new Size(70, 20);
            modificarToolStripMenuItem.Text = "Modificar";
            modificarToolStripMenuItem.Click += modificarToolStripMenuItem_Click;
            // 
            // cambioMedidorToolStripMenuItem
            // 
            cambioMedidorToolStripMenuItem.Name = "cambioMedidorToolStripMenuItem";
            cambioMedidorToolStripMenuItem.Size = new Size(109, 20);
            cambioMedidorToolStripMenuItem.Text = "Cambio Medidor";
            cambioMedidorToolStripMenuItem.Click += cambioMedidorToolStripMenuItem_Click;
            // 
            // imprimirReciboToolStripMenuItem
            // 
            imprimirReciboToolStripMenuItem.Name = "imprimirReciboToolStripMenuItem";
            imprimirReciboToolStripMenuItem.Size = new Size(104, 20);
            imprimirReciboToolStripMenuItem.Text = "Imprimir Recibo";
            // 
            // buscarToolStripMenuItem
            // 
            buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            buscarToolStripMenuItem.Size = new Size(54, 20);
            buscarToolStripMenuItem.Text = "Buscar";
            buscarToolStripMenuItem.Click += buscarToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(50, 44);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 2;
            label1.Text = "Código de Usuario";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(50, 170);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "Teléfono";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(425, 304);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 4;
            label3.Text = "Fecha de Nacimiento";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(50, 216);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 5;
            label4.Text = "Sector";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(52, 493);
            label7.Name = "label7";
            label7.Size = new Size(83, 15);
            label7.TabIndex = 8;
            label7.Text = "Lectura Actual";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(52, 547);
            label8.Name = "label8";
            label8.Size = new Size(91, 15);
            label8.TabIndex = 9;
            label8.Text = "Valor de Ingreso";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(50, 125);
            label9.Name = "label9";
            label9.Size = new Size(117, 15);
            label9.TabIndex = 10;
            label9.Text = "Nombres y Apellidos";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(50, 260);
            label10.Name = "label10";
            label10.Size = new Size(121, 15);
            label10.TabIndex = 11;
            label10.Text = "Número de Conexión";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(52, 304);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 12;
            label11.Text = "Fecha";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(50, 352);
            label12.Name = "label12";
            label12.Size = new Size(117, 15);
            label12.TabIndex = 13;
            label12.Text = "Categoría de Usuario";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Location = new Point(50, 450);
            label13.Name = "label13";
            label13.Size = new Size(85, 15);
            label13.TabIndex = 14;
            label13.Text = "Nuevo Usuario";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Location = new Point(50, 85);
            label14.Name = "label14";
            label14.Size = new Size(52, 15);
            label14.TabIndex = 15;
            label14.Text = "Medidor";
            // 
            // txtCodigoUsuario
            // 
            txtCodigoUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtCodigoUsuario.Enabled = false;
            txtCodigoUsuario.Location = new Point(180, 36);
            txtCodigoUsuario.Name = "txtCodigoUsuario";
            txtCodigoUsuario.Size = new Size(101, 23);
            txtCodigoUsuario.TabIndex = 16;
            // 
            // txtNumConexion
            // 
            txtNumConexion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNumConexion.Enabled = false;
            txtNumConexion.Location = new Point(180, 252);
            txtNumConexion.Name = "txtNumConexion";
            txtNumConexion.Size = new Size(101, 23);
            txtNumConexion.TabIndex = 19;
            // 
            // txtCodigoSector
            // 
            txtCodigoSector.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtCodigoSector.Enabled = false;
            txtCodigoSector.Location = new Point(180, 208);
            txtCodigoSector.Name = "txtCodigoSector";
            txtCodigoSector.Size = new Size(59, 23);
            txtCodigoSector.TabIndex = 20;
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtTelefono.Enabled = false;
            txtTelefono.Location = new Point(180, 162);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(101, 23);
            txtTelefono.TabIndex = 21;
            // 
            // txtNombresApellidos
            // 
            txtNombresApellidos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNombresApellidos.Enabled = false;
            txtNombresApellidos.Location = new Point(180, 117);
            txtNombresApellidos.Name = "txtNombresApellidos";
            txtNombresApellidos.Size = new Size(547, 23);
            txtNombresApellidos.TabIndex = 22;
            // 
            // txtMedidor
            // 
            txtMedidor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMedidor.Enabled = false;
            txtMedidor.Location = new Point(180, 77);
            txtMedidor.Name = "txtMedidor";
            txtMedidor.Size = new Size(101, 23);
            txtMedidor.TabIndex = 23;
            // 
            // txtLecturaActual
            // 
            txtLecturaActual.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLecturaActual.Enabled = false;
            txtLecturaActual.Location = new Point(180, 490);
            txtLecturaActual.Name = "txtLecturaActual";
            txtLecturaActual.Size = new Size(101, 23);
            txtLecturaActual.TabIndex = 24;
            txtLecturaActual.Text = "0";
            // 
            // txtValorIngreso
            // 
            txtValorIngreso.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtValorIngreso.Enabled = false;
            txtValorIngreso.Location = new Point(180, 544);
            txtValorIngreso.Name = "txtValorIngreso";
            txtValorIngreso.Size = new Size(101, 23);
            txtValorIngreso.TabIndex = 25;
            txtValorIngreso.Text = "700";
            // 
            // cbxNombreSector
            // 
            cbxNombreSector.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbxNombreSector.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxNombreSector.Enabled = false;
            cbxNombreSector.FormattingEnabled = true;
            cbxNombreSector.Location = new Point(261, 208);
            cbxNombreSector.Name = "cbxNombreSector";
            cbxNombreSector.Size = new Size(233, 23);
            cbxNombreSector.TabIndex = 26;
            cbxNombreSector.SelectedIndexChanged += cbxNombreSector_SelectedIndexChanged;
            // 
            // chbCapacidadDif
            // 
            chbCapacidadDif.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            chbCapacidadDif.AutoSize = true;
            chbCapacidadDif.CheckAlign = ContentAlignment.MiddleRight;
            chbCapacidadDif.Enabled = false;
            chbCapacidadDif.Location = new Point(180, 402);
            chbCapacidadDif.Name = "chbCapacidadDif";
            chbCapacidadDif.Size = new Size(15, 14);
            chbCapacidadDif.TabIndex = 27;
            chbCapacidadDif.UseVisualStyleBackColor = true;
            // 
            // chbTercerEdad
            // 
            chbTercerEdad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chbTercerEdad.AutoSize = true;
            chbTercerEdad.CheckAlign = ContentAlignment.MiddleRight;
            chbTercerEdad.Enabled = false;
            chbTercerEdad.Location = new Point(358, 402);
            chbTercerEdad.Name = "chbTercerEdad";
            chbTercerEdad.Size = new Size(15, 14);
            chbTercerEdad.TabIndex = 28;
            chbTercerEdad.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            radioButton1.AutoSize = true;
            radioButton1.Enabled = false;
            radioButton1.Location = new Point(197, 446);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(41, 19);
            radioButton1.TabIndex = 30;
            radioButton1.TabStop = true;
            radioButton1.Text = "No";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            radioButton2.AutoSize = true;
            radioButton2.Enabled = false;
            radioButton2.Location = new Point(295, 446);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(34, 19);
            radioButton2.TabIndex = 31;
            radioButton2.TabStop = true;
            radioButton2.Text = "Sí";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // cbxCategoriaUsuario
            // 
            cbxCategoriaUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cbxCategoriaUsuario.Enabled = false;
            cbxCategoriaUsuario.FormattingEnabled = true;
            cbxCategoriaUsuario.Items.AddRange(new object[] { "INSTITUCIÓN", "ABONADO" });
            cbxCategoriaUsuario.Location = new Point(180, 344);
            cbxCategoriaUsuario.Name = "cbxCategoriaUsuario";
            cbxCategoriaUsuario.Size = new Size(101, 23);
            cbxCategoriaUsuario.TabIndex = 32;
            // 
            // dtpFecha
            // 
            dtpFecha.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dtpFecha.CustomFormat = "dd/MMMM/yyyy";
            dtpFecha.Enabled = false;
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(180, 298);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(177, 23);
            dtpFecha.TabIndex = 33;
            dtpFecha.Value = new DateTime(2025, 7, 19, 0, 0, 0, 0);
            // 
            // dtpFechNacimiento
            // 
            dtpFechNacimiento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dtpFechNacimiento.CustomFormat = "dd/MMMM/yyyy";
            dtpFechNacimiento.Enabled = false;
            dtpFechNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechNacimiento.Location = new Point(550, 300);
            dtpFechNacimiento.Name = "dtpFechNacimiento";
            dtpFechNacimiento.Size = new Size(177, 23);
            dtpFechNacimiento.TabIndex = 34;
            // 
            // cbxId
            // 
            cbxId.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cbxId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxId.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxId.FormattingEnabled = true;
            cbxId.Location = new Point(514, 36);
            cbxId.Name = "cbxId";
            cbxId.Size = new Size(213, 23);
            cbxId.TabIndex = 35;
            cbxId.SelectedIndexChanged += cbxId_SelectedIndexChanged;
            cbxId.KeyDown += cbxId_KeyDown;
            // 
            // lblId
            // 
            lblId.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblId.AutoSize = true;
            lblId.Location = new Point(428, 44);
            lblId.Name = "lblId";
            lblId.Size = new Size(66, 15);
            lblId.TabIndex = 36;
            lblId.Text = "ID Personal";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbxId);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dtpFechNacimiento);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dtpFecha);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(cbxCategoriaUsuario);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(chbTercerEdad);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(chbCapacidadDif);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(cbxNombreSector);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(txtValorIngreso);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(txtLecturaActual);
            panel1.Controls.Add(txtCodigoUsuario);
            panel1.Controls.Add(txtMedidor);
            panel1.Controls.Add(txtNumConexion);
            panel1.Controls.Add(txtNombresApellidos);
            panel1.Controls.Add(txtCodigoSector);
            panel1.Controls.Add(txtTelefono);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(777, 620);
            panel1.TabIndex = 37;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(279, 401);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 38;
            label6.Text = "Tercera Edad";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 401);
            label5.Name = "label5";
            label5.Size = new Size(114, 15);
            label5.TabIndex = 37;
            label5.Text = "Capacidad Diferente";
            // 
            // CtlMedidores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Name = "CtlMedidores";
            Size = new Size(777, 644);
            Load += CtlMedidores_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem nuevoToolStripMenuItem;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem;
        private ToolStripMenuItem cambioMedidorToolStripMenuItem;
        private ToolStripMenuItem imprimirReciboToolStripMenuItem;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox txtCodigoUsuario;
        private TextBox txtNumConexion;
        private TextBox txtCodigoSector;
        private TextBox txtTelefono;
        private TextBox txtNombresApellidos;
        private TextBox txtMedidor;
        private TextBox txtLecturaActual;
        private TextBox txtValorIngreso;
        private ComboBox cbxNombreSector;
        private CheckBox chbCapacidadDif;
        private CheckBox chbTercerEdad;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private ComboBox cbxCategoriaUsuario;
        private DateTimePicker dtpFecha;
        private DateTimePicker dtpFechNacimiento;
        private ComboBox cbxId;
        private Label lblId;
        private Panel panel1;
        private ToolStripMenuItem buscarToolStripMenuItem;
        private Label label6;
        private Label label5;
    }
}
