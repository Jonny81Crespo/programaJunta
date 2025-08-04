namespace ProgramaJunta
{
    partial class CtlIngresosMensual
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
            label3 = new Label();
            txtMes = new TextBox();
            txtValor = new TextBox();
            txtAno = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(120, 122);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 0;
            label1.Text = "Mes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 165);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 1;
            label2.Text = "Año";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(120, 230);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 2;
            label3.Text = "Valor";
            // 
            // txtMes
            // 
            txtMes.Location = new Point(261, 115);
            txtMes.Name = "txtMes";
            txtMes.Size = new Size(100, 23);
            txtMes.TabIndex = 3;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(261, 222);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(100, 23);
            txtValor.TabIndex = 4;
            // 
            // txtAno
            // 
            txtAno.Location = new Point(261, 165);
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(100, 23);
            txtAno.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(261, 375);
            button1.Name = "button1";
            button1.Size = new Size(104, 34);
            button1.TabIndex = 6;
            button1.Text = "Consultar";
            button1.UseVisualStyleBackColor = true;
            // 
            // CtlIngresosMensual
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(txtAno);
            Controls.Add(txtValor);
            Controls.Add(txtMes);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CtlIngresosMensual";
            Size = new Size(957, 595);
            Load += CtlIngresosMensual_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtMes;
        private TextBox txtValor;
        private TextBox txtAno;
        private Button button1;
    }
}
