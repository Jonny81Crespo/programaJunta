namespace ProgramaJunta
{
    partial class FrmBusqueda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtSearch = new TextBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            txtId = new TextBox();
            chbActivos = new CheckBox();
            chbInactivos = new CheckBox();
            dateFecha = new DateTimePicker();
            chbFecha = new CheckBox();
            lblprueba = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 35);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombres y Apellidos";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(163, 32);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(595, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 153);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(762, 285);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 4;
            label2.Text = "Buscar Por ID";
            // 
            // txtId
            // 
            txtId.Location = new Point(163, 78);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 5;
            txtId.TextChanged += txtId_TextChanged;
            txtId.KeyPress += txtId_KeyPress;
            // 
            // chbActivos
            // 
            chbActivos.AutoSize = true;
            chbActivos.Location = new Point(12, 128);
            chbActivos.Name = "chbActivos";
            chbActivos.Size = new Size(65, 19);
            chbActivos.TabIndex = 6;
            chbActivos.Text = "Activos";
            chbActivos.UseVisualStyleBackColor = true;
            chbActivos.CheckedChanged += chbActivo_CheckedChanged;
            // 
            // chbInactivos
            // 
            chbInactivos.AutoSize = true;
            chbInactivos.Location = new Point(117, 128);
            chbInactivos.Name = "chbInactivos";
            chbInactivos.Size = new Size(73, 19);
            chbInactivos.TabIndex = 7;
            chbInactivos.Text = "Inactivos";
            chbInactivos.UseVisualStyleBackColor = true;
            chbInactivos.CheckedChanged += chnInactivos_CheckedChanged;
            // 
            // dateFecha
            // 
            dateFecha.CustomFormat = "dd MMMM yyyy";
            dateFecha.Enabled = false;
            dateFecha.Format = DateTimePickerFormat.Custom;
            dateFecha.Location = new Point(579, 113);
            dateFecha.Name = "dateFecha";
            dateFecha.Size = new Size(179, 23);
            dateFecha.TabIndex = 8;
            dateFecha.ValueChanged += dateFecha_ValueChanged;
            // 
            // chbFecha
            // 
            chbFecha.AutoSize = true;
            chbFecha.Location = new Point(579, 82);
            chbFecha.Name = "chbFecha";
            chbFecha.Size = new Size(107, 19);
            chbFecha.TabIndex = 10;
            chbFecha.Text = "Filtar Por Fecha";
            chbFecha.UseVisualStyleBackColor = true;
            chbFecha.CheckedChanged += chbFecha_CheckedChanged;
            // 
            // lblprueba
            // 
            lblprueba.AutoSize = true;
            lblprueba.Location = new Point(446, 101);
            lblprueba.Name = "lblprueba";
            lblprueba.Size = new Size(38, 15);
            lblprueba.TabIndex = 11;
            lblprueba.Text = "label3";
            // 
            // FrmBusqueda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblprueba);
            Controls.Add(chbFecha);
            Controls.Add(dateFecha);
            Controls.Add(chbInactivos);
            Controls.Add(chbActivos);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "FrmBusqueda";
            Text = "FrmBusqueda";
            Load += FrmBusqueda_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private DataGridView dataGridView1;
        private Label label2;
        private TextBox txtId;
        private CheckBox chbActivos;
        private CheckBox chbInactivos;
        private DateTimePicker dateFecha;
        private CheckBox chbFecha;
        private Label lblprueba;
    }
}