namespace Servire.UI.Forms
{
    partial class frmHome
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
            menuStrip1 = new MenuStrip();
            menuArchivo = new ToolStripMenuItem();
            menuSalir = new ToolStripMenuItem();
            menuAdmin = new ToolStripMenuItem();
            menuUsuarios = new ToolStripMenuItem();
            menuUsuariosToolStripMenuItem = new ToolStripMenuItem();
            menuBitacora = new ToolStripMenuItem();
            MenuStock = new ToolStripMenuItem();
            menuProductos = new ToolStripMenuItem();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            statusStrip1 = new StatusStrip();
            lblSesion = new ToolStripStatusLabel();
            pnlContenedorPrincipal = new Panel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuArchivo, menuAdmin, menuUsuarios, menuBitacora, MenuStock, menuProductos });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(938, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuArchivo
            // 
            menuArchivo.DropDownItems.AddRange(new ToolStripItem[] { menuSalir });
            menuArchivo.Name = "menuArchivo";
            menuArchivo.Size = new Size(73, 24);
            menuArchivo.Text = "Archivo";
            // 
            // menuSalir
            // 
            menuSalir.Name = "menuSalir";
            menuSalir.Size = new Size(121, 26);
            menuSalir.Text = "Salir";
            menuSalir.Click += menuSalir_Click;
            // 
            // menuAdmin
            // 
            menuAdmin.Name = "menuAdmin";
            menuAdmin.Size = new Size(123, 24);
            menuAdmin.Text = "Administración";
            // 
            // menuUsuarios
            // 
            menuUsuarios.DropDownItems.AddRange(new ToolStripItem[] { menuUsuariosToolStripMenuItem });
            menuUsuarios.Name = "menuUsuarios";
            menuUsuarios.Size = new Size(79, 24);
            menuUsuarios.Text = "Usuarios";
            menuUsuarios.Click += menuUsuarios_Click;
            // 
            // menuUsuariosToolStripMenuItem
            // 
            menuUsuariosToolStripMenuItem.Name = "menuUsuariosToolStripMenuItem";
            menuUsuariosToolStripMenuItem.Size = new Size(224, 26);
            menuUsuariosToolStripMenuItem.Text = "Menu Usuarios";
            menuUsuariosToolStripMenuItem.Click += menuUsuarios_Click;
            // 
            // menuBitacora
            // 
            menuBitacora.Name = "menuBitacora";
            menuBitacora.Size = new Size(130, 24);
            menuBitacora.Text = "Bitácora/Errores";
            menuBitacora.Click += menuBitacora_Click;
            // 
            // MenuStock
            // 
            MenuStock.Name = "MenuStock";
            MenuStock.Size = new Size(59, 24);
            MenuStock.Text = "Stock";
            MenuStock.Click += menuStock_Click;
            // 
            // menuProductos
            // 
            menuProductos.Name = "menuProductos";
            menuProductos.Size = new Size(89, 24);
            menuProductos.Text = "Productos";
            menuProductos.Click += menuProductos_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblSesion });
            statusStrip1.Location = new Point(0, 424);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(938, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblSesion
            // 
            lblSesion.Name = "lblSesion";
            lblSesion.Size = new Size(52, 20);
            lblSesion.Text = "Sesión";
            // 
            // pnlContenedorPrincipal
            // 
            pnlContenedorPrincipal.Dock = DockStyle.Fill;
            pnlContenedorPrincipal.Location = new Point(0, 28);
            pnlContenedorPrincipal.Name = "pnlContenedorPrincipal";
            pnlContenedorPrincipal.Size = new Size(938, 396);
            pnlContenedorPrincipal.TabIndex = 2;
            // 
            // frmHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 450);
            Controls.Add(pnlContenedorPrincipal);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Servire-Home";
            Load += frmHome_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private ToolStripMenuItem menuArchivo;
        private ToolStripMenuItem menuSalir;
        private ToolStripMenuItem menuAdmin;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblSesion;
        private ToolStripMenuItem menuUsuarios;
        private ToolStripMenuItem menuUsuariosToolStripMenuItem;
        private ToolStripMenuItem menuBitacora;
        private ToolStripMenuItem MenuStock;
        private Panel pnlContenedorPrincipal;
        private ToolStripMenuItem menuProductos;
    }
}