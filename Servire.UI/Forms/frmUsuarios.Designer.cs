namespace Servire.UI.Forms
{
    partial class frmUsuarios
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
            pnlFiltros = new FlowLayoutPanel();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblRolFiltro = new Label();
            cboRolFiltro = new ComboBox();
            lblTotal = new Label();
            dgvUsuarios = new DataGridView();
            ColId = new DataGridViewTextBoxColumn();
            ColUserName = new DataGridViewTextBoxColumn();
            ColNombre = new DataGridViewTextBoxColumn();
            ColRol = new DataGridViewTextBoxColumn();
            ColActivo = new DataGridViewTextBoxColumn();
            ColDNI = new DataGridViewTextBoxColumn();
            ColUltimoAcceso = new DataGridViewTextBoxColumn();
            pnlBotones = new FlowLayoutPanel();
            btnNuevo = new Button();
            btnEditar = new Button();
            btnActivar = new Button();
            btnDesactivar = new Button();
            btnResetPassword = new Button();
            btnCerrar = new Button();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFiltros
            // 
            pnlFiltros.Controls.Add(lblBuscar);
            pnlFiltros.Controls.Add(txtBuscar);
            pnlFiltros.Controls.Add(lblRolFiltro);
            pnlFiltros.Controls.Add(cboRolFiltro);
            pnlFiltros.Controls.Add(lblTotal);
            pnlFiltros.Controls.Add(pnlBotones);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 0);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(8);
            pnlFiltros.Size = new Size(1043, 93);
            pnlFiltros.TabIndex = 0;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(11, 8);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(52, 20);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(69, 11);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(220, 27);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblRolFiltro
            // 
            lblRolFiltro.AutoSize = true;
            lblRolFiltro.Location = new Point(295, 8);
            lblRolFiltro.Name = "lblRolFiltro";
            lblRolFiltro.Size = new Size(31, 20);
            lblRolFiltro.TabIndex = 2;
            lblRolFiltro.Text = "Rol";
            // 
            // cboRolFiltro
            // 
            cboRolFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRolFiltro.FormattingEnabled = true;
            cboRolFiltro.Location = new Point(332, 11);
            cboRolFiltro.Name = "cboRolFiltro";
            cboRolFiltro.Size = new Size(140, 28);
            cboRolFiltro.TabIndex = 3;
            cboRolFiltro.SelectedIndexChanged += cboRolFiltro_SelectedIndexChanged;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(478, 8);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(57, 20);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total: 0";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { ColId, ColUserName, ColNombre, ColRol, ColActivo, ColDNI, ColUltimoAcceso });
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(0, 93);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(1043, 357);
            dgvUsuarios.TabIndex = 1;
            // 
            // ColId
            // 
            ColId.DataPropertyName = "Id";
            ColId.HeaderText = "Id";
            ColId.MinimumWidth = 6;
            ColId.Name = "ColId";
            ColId.ReadOnly = true;
            // 
            // ColUserName
            // 
            ColUserName.HeaderText = "Usuario";
            ColUserName.MinimumWidth = 6;
            ColUserName.Name = "ColUserName";
            ColUserName.ReadOnly = true;
            // 
            // ColNombre
            // 
            ColNombre.DataPropertyName = "Nombre";
            ColNombre.FillWeight = 180F;
            ColNombre.HeaderText = "Nombre";
            ColNombre.MinimumWidth = 6;
            ColNombre.Name = "ColNombre";
            ColNombre.ReadOnly = true;
            // 
            // ColRol
            // 
            ColRol.DataPropertyName = "Rol";
            ColRol.FillWeight = 90F;
            ColRol.HeaderText = "Rol";
            ColRol.MinimumWidth = 6;
            ColRol.Name = "ColRol";
            ColRol.ReadOnly = true;
            // 
            // ColActivo
            // 
            ColActivo.DataPropertyName = "Activo";
            ColActivo.FillWeight = 70F;
            ColActivo.HeaderText = "Activo";
            ColActivo.MinimumWidth = 6;
            ColActivo.Name = "ColActivo";
            ColActivo.ReadOnly = true;
            // 
            // ColDNI
            // 
            ColDNI.DataPropertyName = "Dni";
            ColDNI.FillWeight = 110F;
            ColDNI.HeaderText = "DNI";
            ColDNI.MinimumWidth = 6;
            ColDNI.Name = "ColDNI";
            ColDNI.ReadOnly = true;
            // 
            // ColUltimoAcceso
            // 
            ColUltimoAcceso.DataPropertyName = "UltimoAcceso";
            ColUltimoAcceso.FillWeight = 140F;
            ColUltimoAcceso.HeaderText = "Ultimo Acceso";
            ColUltimoAcceso.MinimumWidth = 6;
            ColUltimoAcceso.Name = "ColUltimoAcceso";
            ColUltimoAcceso.ReadOnly = true;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnEditar);
            pnlBotones.Controls.Add(btnNuevo);
            pnlBotones.Controls.Add(btnCerrar);
            pnlBotones.Controls.Add(btnResetPassword);
            pnlBotones.Controls.Add(btnDesactivar);
            pnlBotones.Controls.Add(btnActivar);
            pnlBotones.Location = new Point(541, 11);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Padding = new Padding(8);
            pnlBotones.Size = new Size(451, 87);
            pnlBotones.TabIndex = 5;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(111, 11);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(11, 11);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnActivar
            // 
            btnActivar.Location = new Point(279, 46);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(94, 29);
            btnActivar.TabIndex = 2;
            btnActivar.Text = "Activar";
            btnActivar.UseVisualStyleBackColor = true;
            btnActivar.Click += btnActivar_Click;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Location = new Point(179, 46);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(94, 29);
            btnDesactivar.TabIndex = 3;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = true;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Location = new Point(11, 46);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(162, 29);
            btnResetPassword.TabIndex = 4;
            btnResetPassword.Text = "Reiniciar contraseña";
            btnResetPassword.UseVisualStyleBackColor = true;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCerrar.Location = new Point(211, 11);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(94, 29);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.TextAlign = ContentAlignment.BottomRight;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 450);
            Controls.Add(dgvUsuarios);
            Controls.Add(pnlFiltros);
            Name = "frmUsuarios";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Usuarios";
            Load += frmUsuarios_Load;
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlFiltros;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Label lblRolFiltro;
        private ComboBox cboRolFiltro;
        private Label lblTotal;
        private DataGridView dgvUsuarios;
        private DataGridViewTextBoxColumn ColId;
        private DataGridViewTextBoxColumn ColUserName;
        private DataGridViewTextBoxColumn ColNombre;
        private DataGridViewTextBoxColumn ColRol;
        private DataGridViewTextBoxColumn ColActivo;
        private DataGridViewTextBoxColumn ColDNI;
        private DataGridViewTextBoxColumn ColUltimoAcceso;
        private FlowLayoutPanel pnlBotones;
        private Button btnEditar;
        private Button btnNuevo;
        private Button btnDesactivar;
        private Button btnActivar;
        private Button btnCerrar;
        private Button btnResetPassword;
    }
}