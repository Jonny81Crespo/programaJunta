
namespace ProgramaJunta
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            valoresToolStripMenuItem = new ToolStripMenuItem();
            creaciónDeUsuariosToolStripMenuItem = new ToolStripMenuItem();
            sectoresToolStripMenuItem = new ToolStripMenuItem();
            medidoresToolStripMenuItem = new ToolStripMenuItem();
            lecturasToolStripMenuItem = new ToolStripMenuItem();
            notificacionesToolStripMenuItem = new ToolStripMenuItem();
            plantillasToolStripMenuItem = new ToolStripMenuItem();
            otrosIngresosToolStripMenuItem = new ToolStripMenuItem();
            gastosToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            listadoDeUsuariosToolStripMenuItem = new ToolStripMenuItem();
            plantillasPendientesToolStripMenuItem = new ToolStripMenuItem();
            cambiosMedidoresToolStripMenuItem = new ToolStripMenuItem();
            metrosDeConsumoToolStripMenuItem = new ToolStripMenuItem();
            ingresosYGastosToolStripMenuItem = new ToolStripMenuItem();
            ingresoMensualToolStripMenuItem = new ToolStripMenuItem();
            fondoSolidarioToolStripMenuItem = new ToolStripMenuItem();
            nuevosUsuariosToolStripMenuItem = new ToolStripMenuItem();
            ingresosDiariosToolStripMenuItem = new ToolStripMenuItem();
            plantillasToolStripMenuItem1 = new ToolStripMenuItem();
            otrosIngresosToolStripMenuItem1 = new ToolStripMenuItem();
            gastosToolStripMenuItem1 = new ToolStripMenuItem();
            cambioDeMedidoresToolStripMenuItem = new ToolStripMenuItem();
            reclamosToolStripMenuItem = new ToolStripMenuItem();
            buscarToolStripMenuItem = new ToolStripMenuItem();
            pnlControlUser = new Panel();
            panelCuerpo = new Panel();
            btnSincronizar = new Button();
            panel2 = new Panel();
            button1 = new Button();
            menuStrip1.SuspendLayout();
            panelCuerpo.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AccessibleRole = AccessibleRole.TitleBar;
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.ImeMode = ImeMode.Katakana;
            menuStrip1.Items.AddRange(new ToolStripItem[] { valoresToolStripMenuItem, creaciónDeUsuariosToolStripMenuItem, sectoresToolStripMenuItem, medidoresToolStripMenuItem, lecturasToolStripMenuItem, notificacionesToolStripMenuItem, plantillasToolStripMenuItem, otrosIngresosToolStripMenuItem, gastosToolStripMenuItem, reportesToolStripMenuItem, buscarToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(0);
            menuStrip1.Size = new Size(1016, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // valoresToolStripMenuItem
            // 
            valoresToolStripMenuItem.Enabled = false;
            valoresToolStripMenuItem.Name = "valoresToolStripMenuItem";
            valoresToolStripMenuItem.Size = new Size(56, 40);
            valoresToolStripMenuItem.Text = "Valores";
            // 
            // creaciónDeUsuariosToolStripMenuItem
            // 
            creaciónDeUsuariosToolStripMenuItem.Enabled = false;
            creaciónDeUsuariosToolStripMenuItem.Name = "creaciónDeUsuariosToolStripMenuItem";
            creaciónDeUsuariosToolStripMenuItem.Size = new Size(130, 40);
            creaciónDeUsuariosToolStripMenuItem.Text = "Creación de Usuarios";
            // 
            // sectoresToolStripMenuItem
            // 
            sectoresToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            sectoresToolStripMenuItem.Image = Properties.Resources.location;
            sectoresToolStripMenuItem.Margin = new Padding(3);
            sectoresToolStripMenuItem.Name = "sectoresToolStripMenuItem";
            sectoresToolStripMenuItem.Size = new Size(79, 34);
            sectoresToolStripMenuItem.Text = "Sectores";
            sectoresToolStripMenuItem.Click += sectoresToolStripMenuItem_Click;
            // 
            // medidoresToolStripMenuItem
            // 
            medidoresToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            medidoresToolStripMenuItem.Image = Properties.Resources.speedometer;
            medidoresToolStripMenuItem.Margin = new Padding(3);
            medidoresToolStripMenuItem.Name = "medidoresToolStripMenuItem";
            medidoresToolStripMenuItem.Size = new Size(91, 34);
            medidoresToolStripMenuItem.Text = "Medidores";
            medidoresToolStripMenuItem.Click += medidoresToolStripMenuItem_Click;
            // 
            // lecturasToolStripMenuItem
            // 
            lecturasToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            lecturasToolStripMenuItem.Image = Properties.Resources.book;
            lecturasToolStripMenuItem.Margin = new Padding(3);
            lecturasToolStripMenuItem.Name = "lecturasToolStripMenuItem";
            lecturasToolStripMenuItem.Size = new Size(79, 34);
            lecturasToolStripMenuItem.Text = "Lecturas";
            lecturasToolStripMenuItem.Click += lecturasToolStripMenuItem_Click;
            // 
            // notificacionesToolStripMenuItem
            // 
            notificacionesToolStripMenuItem.BackColor = SystemColors.MenuHighlight;
            notificacionesToolStripMenuItem.ForeColor = SystemColors.ControlText;
            notificacionesToolStripMenuItem.Image = Properties.Resources.notification;
            notificacionesToolStripMenuItem.Margin = new Padding(3);
            notificacionesToolStripMenuItem.Name = "notificacionesToolStripMenuItem";
            notificacionesToolStripMenuItem.Size = new Size(111, 34);
            notificacionesToolStripMenuItem.Text = "Notificaciones";
            // 
            // plantillasToolStripMenuItem
            // 
            plantillasToolStripMenuItem.BackColor = SystemColors.MenuHighlight;
            plantillasToolStripMenuItem.ForeColor = SystemColors.ControlText;
            plantillasToolStripMenuItem.Image = Properties.Resources.templates;
            plantillasToolStripMenuItem.Margin = new Padding(3);
            plantillasToolStripMenuItem.Name = "plantillasToolStripMenuItem";
            plantillasToolStripMenuItem.Size = new Size(78, 34);
            plantillasToolStripMenuItem.Text = "Planillas";
            plantillasToolStripMenuItem.Click += plantillasToolStripMenuItem_Click;
            // 
            // otrosIngresosToolStripMenuItem
            // 
            otrosIngresosToolStripMenuItem.BackColor = SystemColors.MenuHighlight;
            otrosIngresosToolStripMenuItem.ForeColor = SystemColors.ControlText;
            otrosIngresosToolStripMenuItem.Image = Properties.Resources.save_money;
            otrosIngresosToolStripMenuItem.Margin = new Padding(3);
            otrosIngresosToolStripMenuItem.Name = "otrosIngresosToolStripMenuItem";
            otrosIngresosToolStripMenuItem.Size = new Size(111, 34);
            otrosIngresosToolStripMenuItem.Text = "Otros Ingresos";
            otrosIngresosToolStripMenuItem.Click += otrosIngresosToolStripMenuItem_Click;
            // 
            // gastosToolStripMenuItem
            // 
            gastosToolStripMenuItem.BackColor = SystemColors.MenuHighlight;
            gastosToolStripMenuItem.ForeColor = SystemColors.ControlText;
            gastosToolStripMenuItem.Image = Properties.Resources.money;
            gastosToolStripMenuItem.Margin = new Padding(3);
            gastosToolStripMenuItem.Name = "gastosToolStripMenuItem";
            gastosToolStripMenuItem.Size = new Size(70, 34);
            gastosToolStripMenuItem.Text = "Gastos";
            gastosToolStripMenuItem.Click += gastosToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.BackColor = SystemColors.MenuHighlight;
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listadoDeUsuariosToolStripMenuItem, plantillasPendientesToolStripMenuItem, cambiosMedidoresToolStripMenuItem, metrosDeConsumoToolStripMenuItem, ingresosYGastosToolStripMenuItem, cambioDeMedidoresToolStripMenuItem, reclamosToolStripMenuItem });
            reportesToolStripMenuItem.ForeColor = SystemColors.ControlText;
            reportesToolStripMenuItem.Image = Properties.Resources.report;
            reportesToolStripMenuItem.Margin = new Padding(3);
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(81, 34);
            reportesToolStripMenuItem.Text = "Reportes";
            reportesToolStripMenuItem.Click += reportesToolStripMenuItem_Click;
            // 
            // listadoDeUsuariosToolStripMenuItem
            // 
            listadoDeUsuariosToolStripMenuItem.Name = "listadoDeUsuariosToolStripMenuItem";
            listadoDeUsuariosToolStripMenuItem.Size = new Size(191, 22);
            listadoDeUsuariosToolStripMenuItem.Text = "Listado de Usuarios";
            // 
            // plantillasPendientesToolStripMenuItem
            // 
            plantillasPendientesToolStripMenuItem.Name = "plantillasPendientesToolStripMenuItem";
            plantillasPendientesToolStripMenuItem.Size = new Size(191, 22);
            plantillasPendientesToolStripMenuItem.Text = "Plantillas Pendientes";
            // 
            // cambiosMedidoresToolStripMenuItem
            // 
            cambiosMedidoresToolStripMenuItem.Name = "cambiosMedidoresToolStripMenuItem";
            cambiosMedidoresToolStripMenuItem.Size = new Size(191, 22);
            cambiosMedidoresToolStripMenuItem.Text = "Cambios Medidores";
            cambiosMedidoresToolStripMenuItem.Click += cambiosMedidoresToolStripMenuItem_Click;
            // 
            // metrosDeConsumoToolStripMenuItem
            // 
            metrosDeConsumoToolStripMenuItem.Name = "metrosDeConsumoToolStripMenuItem";
            metrosDeConsumoToolStripMenuItem.Size = new Size(191, 22);
            metrosDeConsumoToolStripMenuItem.Text = "Metros de Consumo";
            // 
            // ingresosYGastosToolStripMenuItem
            // 
            ingresosYGastosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ingresoMensualToolStripMenuItem, fondoSolidarioToolStripMenuItem, nuevosUsuariosToolStripMenuItem, ingresosDiariosToolStripMenuItem, plantillasToolStripMenuItem1, otrosIngresosToolStripMenuItem1, gastosToolStripMenuItem1 });
            ingresosYGastosToolStripMenuItem.Name = "ingresosYGastosToolStripMenuItem";
            ingresosYGastosToolStripMenuItem.Size = new Size(191, 22);
            ingresosYGastosToolStripMenuItem.Text = "Ingresos y Gastos";
            // 
            // ingresoMensualToolStripMenuItem
            // 
            ingresoMensualToolStripMenuItem.Name = "ingresoMensualToolStripMenuItem";
            ingresoMensualToolStripMenuItem.Size = new Size(162, 22);
            ingresoMensualToolStripMenuItem.Text = "Ingreso Mensual";
            ingresoMensualToolStripMenuItem.Click += ingresoMensualToolStripMenuItem_Click;
            // 
            // fondoSolidarioToolStripMenuItem
            // 
            fondoSolidarioToolStripMenuItem.Name = "fondoSolidarioToolStripMenuItem";
            fondoSolidarioToolStripMenuItem.Size = new Size(162, 22);
            fondoSolidarioToolStripMenuItem.Text = "Fondo Solidario";
            fondoSolidarioToolStripMenuItem.Click += fondoSolidarioToolStripMenuItem_Click;
            // 
            // nuevosUsuariosToolStripMenuItem
            // 
            nuevosUsuariosToolStripMenuItem.Name = "nuevosUsuariosToolStripMenuItem";
            nuevosUsuariosToolStripMenuItem.Size = new Size(162, 22);
            nuevosUsuariosToolStripMenuItem.Text = "Nuevos Usuarios";
            nuevosUsuariosToolStripMenuItem.Click += nuevosUsuariosToolStripMenuItem_Click;
            // 
            // ingresosDiariosToolStripMenuItem
            // 
            ingresosDiariosToolStripMenuItem.Name = "ingresosDiariosToolStripMenuItem";
            ingresosDiariosToolStripMenuItem.Size = new Size(162, 22);
            ingresosDiariosToolStripMenuItem.Text = "Ingresos Diarios";
            ingresosDiariosToolStripMenuItem.Click += ingresosDiariosToolStripMenuItem_Click;
            // 
            // plantillasToolStripMenuItem1
            // 
            plantillasToolStripMenuItem1.Name = "plantillasToolStripMenuItem1";
            plantillasToolStripMenuItem1.Size = new Size(162, 22);
            plantillasToolStripMenuItem1.Text = "Planillas";
            plantillasToolStripMenuItem1.Click += plantillasToolStripMenuItem1_Click;
            // 
            // otrosIngresosToolStripMenuItem1
            // 
            otrosIngresosToolStripMenuItem1.Name = "otrosIngresosToolStripMenuItem1";
            otrosIngresosToolStripMenuItem1.Size = new Size(162, 22);
            otrosIngresosToolStripMenuItem1.Text = "Otros Ingresos";
            otrosIngresosToolStripMenuItem1.Click += otrosIngresosToolStripMenuItem1_Click;
            // 
            // gastosToolStripMenuItem1
            // 
            gastosToolStripMenuItem1.Name = "gastosToolStripMenuItem1";
            gastosToolStripMenuItem1.Size = new Size(162, 22);
            gastosToolStripMenuItem1.Text = "Gastos";
            gastosToolStripMenuItem1.Click += gastosToolStripMenuItem1_Click;
            // 
            // cambioDeMedidoresToolStripMenuItem
            // 
            cambioDeMedidoresToolStripMenuItem.Name = "cambioDeMedidoresToolStripMenuItem";
            cambioDeMedidoresToolStripMenuItem.Size = new Size(191, 22);
            cambioDeMedidoresToolStripMenuItem.Text = "Cambio de Medidores";
            // 
            // reclamosToolStripMenuItem
            // 
            reclamosToolStripMenuItem.Name = "reclamosToolStripMenuItem";
            reclamosToolStripMenuItem.Size = new Size(191, 22);
            reclamosToolStripMenuItem.Text = "Reclamos";
            // 
            // buscarToolStripMenuItem
            // 
            buscarToolStripMenuItem.BackColor = SystemColors.MenuHighlight;
            buscarToolStripMenuItem.ForeColor = SystemColors.ControlText;
            buscarToolStripMenuItem.Image = Properties.Resources.magnifier;
            buscarToolStripMenuItem.Margin = new Padding(3);
            buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            buscarToolStripMenuItem.Size = new Size(70, 34);
            buscarToolStripMenuItem.Text = "Buscar";
            buscarToolStripMenuItem.Click += buscarToolStripMenuItem_Click;
            // 
            // pnlControlUser
            // 
            pnlControlUser.BackColor = Color.FromArgb(224, 224, 224);
            pnlControlUser.Dock = DockStyle.Fill;
            pnlControlUser.Location = new Point(40, 40);
            pnlControlUser.MinimumSize = new Size(928, 454);
            pnlControlUser.Name = "pnlControlUser";
            pnlControlUser.Size = new Size(936, 454);
            pnlControlUser.TabIndex = 1;
            // 
            // panelCuerpo
            // 
            panelCuerpo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCuerpo.BackColor = Color.Transparent;
            panelCuerpo.Controls.Add(button1);
            panelCuerpo.Controls.Add(btnSincronizar);
            panelCuerpo.Controls.Add(pnlControlUser);
            panelCuerpo.Location = new Point(0, 43);
            panelCuerpo.Name = "panelCuerpo";
            panelCuerpo.Padding = new Padding(40);
            panelCuerpo.Size = new Size(1016, 518);
            panelCuerpo.TabIndex = 2;
            // 
            // btnSincronizar
            // 
            btnSincronizar.Location = new Point(114, 9);
            btnSincronizar.Name = "btnSincronizar";
            btnSincronizar.Size = new Size(75, 23);
            btnSincronizar.TabIndex = 2;
            btnSincronizar.Text = "Sincronizar";
            btnSincronizar.UseVisualStyleBackColor = true;
            btnSincronizar.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(menuStrip1);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1016, 40);
            panel2.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(256, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1016, 561);
            Controls.Add(panel2);
            Controls.Add(panelCuerpo);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(800, 600);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JUNTA ADMINISTRADORA DE AGUA POTABLE GUINDILIG";
            FormClosing += FrmPrincipal_FormClosing;
            Load += FrmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelCuerpo.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }



        #endregion

        private MenuStrip menuStrip1;
        private Panel pnlControlUser;
        private ToolStripMenuItem valoresToolStripMenuItem;
        private ToolStripMenuItem creaciónDeUsuariosToolStripMenuItem;
        private ToolStripMenuItem sectoresToolStripMenuItem;
        private ToolStripMenuItem medidoresToolStripMenuItem;
        private ToolStripMenuItem lecturasToolStripMenuItem;
        private ToolStripMenuItem notificacionesToolStripMenuItem;
        private ToolStripMenuItem plantillasToolStripMenuItem;
        private ToolStripMenuItem otrosIngresosToolStripMenuItem;
        private ToolStripMenuItem gastosToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem listadoDeUsuariosToolStripMenuItem;
        private ToolStripMenuItem plantillasPendientesToolStripMenuItem;
        private ToolStripMenuItem cambiosMedidoresToolStripMenuItem;
        private ToolStripMenuItem metrosDeConsumoToolStripMenuItem;
        private ToolStripMenuItem ingresosYGastosToolStripMenuItem;
        private ToolStripMenuItem ingresoMensualToolStripMenuItem;
        private ToolStripMenuItem fondoSolidarioToolStripMenuItem;
        private ToolStripMenuItem nuevosUsuariosToolStripMenuItem;
        private ToolStripMenuItem ingresosDiariosToolStripMenuItem;
        private ToolStripMenuItem plantillasToolStripMenuItem1;
        private ToolStripMenuItem otrosIngresosToolStripMenuItem1;
        private ToolStripMenuItem gastosToolStripMenuItem1;
        private ToolStripMenuItem cambioDeMedidoresToolStripMenuItem;
        private ToolStripMenuItem reclamosToolStripMenuItem;
        private ToolStripMenuItem buscarToolStripMenuItem;
        private Panel panelCuerpo;
        private Panel panel2;
        private Button btnSincronizar;
        private Button button1;
    }
}
