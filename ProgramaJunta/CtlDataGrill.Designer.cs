namespace ProgramaJunta
{
    partial class CtlDataGrill
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
            label1 = new Label();
            label2 = new Label();
            dtpFechaInicial = new DateTimePicker();
            dtpFechaFinal = new DateTimePicker();
            dgvFondoMes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvFondoMes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 107);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "Fecha Inicial";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(525, 94);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 1;
            label2.Text = "Fecha Final";
            // 
            // dtpFechaInicial
            // 
            dtpFechaInicial.Location = new Point(191, 92);
            dtpFechaInicial.Name = "dtpFechaInicial";
            dtpFechaInicial.Size = new Size(200, 23);
            dtpFechaInicial.TabIndex = 2;
            dtpFechaInicial.Value = new DateTime(2025, 6, 28, 0, 0, 0, 0);
            // 
            // dtpFechaFinal
            // 
            dtpFechaFinal.Location = new Point(647, 101);
            dtpFechaFinal.Name = "dtpFechaFinal";
            dtpFechaFinal.Size = new Size(200, 23);
            dtpFechaFinal.TabIndex = 3;
            dtpFechaFinal.Value = new DateTime(2025, 6, 28, 0, 0, 0, 0);
            dtpFechaFinal.ValueChanged += dtpFechaFinal_ValueChanged;
            // 
            // dgvFondoMes
            // 
            dgvFondoMes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFondoMes.Location = new Point(20, 148);
            dgvFondoMes.Name = "dgvFondoMes";
            dgvFondoMes.Size = new Size(881, 466);
            dgvFondoMes.TabIndex = 4;
            // 
            // CtlDataGrill
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvFondoMes);
            Controls.Add(dtpFechaFinal);
            Controls.Add(dtpFechaInicial);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CtlDataGrill";
            Size = new Size(929, 631);
            ((System.ComponentModel.ISupportInitialize)dgvFondoMes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpFechaInicial;
        private DateTimePicker dtpFechaFinal;
        private DataGridView dgvFondoMes;
    }
}
