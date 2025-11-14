namespace Servire.UI.Forms
{
    partial class ucProveedores
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
            pnlAcciones = new FlowLayoutPanel();
            bntNuevo = new Button();
            btnEditar = new Button();
            btnToggleActivo = new Button();
            btnVolver = new Button();
            pnlFiltros = new FlowLayoutPanel();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblTotal = new Label();
            chkMostrarInactivos = new CheckBox();
            dgvProveedores = new DataGridView();
            ColId = new DataGridViewTextBoxColumn();
            ColNombre = new DataGridViewTextBoxColumn();
            ColCategoria = new DataGridViewTextBoxColumn();
            colContacto = new DataGridViewTextBoxColumn();
            pnlAcciones.SuspendLayout();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            SuspendLayout();
            // 
            // pnlAcciones
            // 
            pnlAcciones.Controls.Add(bntNuevo);
            pnlAcciones.Controls.Add(btnEditar);
            pnlAcciones.Controls.Add(btnToggleActivo);
            pnlAcciones.Controls.Add(btnVolver);
            pnlAcciones.Dock = DockStyle.Top;
            pnlAcciones.Location = new Point(0, 0);
            pnlAcciones.MaximumSize = new Size(0, 40);
            pnlAcciones.MinimumSize = new Size(0, 40);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Padding = new Padding(5);
            pnlAcciones.Size = new Size(636, 40);
            pnlAcciones.TabIndex = 0;
            // 
            // bntNuevo
            // 
            bntNuevo.Location = new Point(8, 8);
            bntNuevo.Name = "bntNuevo";
            bntNuevo.Size = new Size(145, 29);
            bntNuevo.TabIndex = 0;
            bntNuevo.Text = "Nuevo Proveedor";
            bntNuevo.UseVisualStyleBackColor = true;
            bntNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(159, 8);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(134, 29);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar Proveedor";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnToggleActivo
            // 
            btnToggleActivo.Location = new Point(299, 8);
            btnToggleActivo.Name = "btnToggleActivo";
            btnToggleActivo.Size = new Size(94, 29);
            btnToggleActivo.TabIndex = 3;
            btnToggleActivo.Text = "Activar/Desactivar";
            btnToggleActivo.UseVisualStyleBackColor = true;
            btnToggleActivo.Click += btnToggleActivo_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(399, 8);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // pnlFiltros
            // 
            pnlFiltros.Controls.Add(lblBuscar);
            pnlFiltros.Controls.Add(txtBuscar);
            pnlFiltros.Controls.Add(lblTotal);
            pnlFiltros.Controls.Add(chkMostrarInactivos);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 40);
            pnlFiltros.MaximumSize = new Size(0, 40);
            pnlFiltros.MinimumSize = new Size(0, 40);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(5);
            pnlFiltros.Size = new Size(636, 40);
            pnlFiltros.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(8, 5);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(55, 20);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(69, 8);
            txtBuscar.MaximumSize = new Size(300, 0);
            txtBuscar.MinimumSize = new Size(300, 0);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(300, 27);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(375, 5);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(57, 20);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total: 0";
            // 
            // chkMostrarInactivos
            // 
            chkMostrarInactivos.AutoSize = true;
            chkMostrarInactivos.Location = new Point(438, 8);
            chkMostrarInactivos.Name = "chkMostrarInactivos";
            chkMostrarInactivos.Size = new Size(144, 24);
            chkMostrarInactivos.TabIndex = 3;
            chkMostrarInactivos.Text = "Mostrar Inactivos";
            chkMostrarInactivos.UseVisualStyleBackColor = true;
            chkMostrarInactivos.CheckedChanged += chkMostrarInactivos_CheckedChanged;
            // 
            // dgvProveedores
            // 
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AllowUserToDeleteRows = false;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Columns.AddRange(new DataGridViewColumn[] { ColId, ColNombre, ColCategoria, colContacto });
            dgvProveedores.Dock = DockStyle.Fill;
            dgvProveedores.Location = new Point(0, 80);
            dgvProveedores.MultiSelect = false;
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.RowHeadersWidth = 51;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(636, 70);
            dgvProveedores.TabIndex = 2;
            dgvProveedores.CellFormatting += dgvProveedores_CellFormatting;
            // 
            // ColId
            // 
            ColId.DataPropertyName = "Id";
            ColId.HeaderText = "#";
            ColId.MinimumWidth = 6;
            ColId.Name = "ColId";
            ColId.Width = 125;
            // 
            // ColNombre
            // 
            ColNombre.DataPropertyName = "Nombre";
            ColNombre.HeaderText = "Nombre";
            ColNombre.MinimumWidth = 6;
            ColNombre.Name = "ColNombre";
            ColNombre.Width = 125;
            // 
            // ColCategoria
            // 
            ColCategoria.DataPropertyName = "Categoria";
            ColCategoria.HeaderText = "Categoría";
            ColCategoria.MinimumWidth = 6;
            ColCategoria.Name = "ColCategoria";
            ColCategoria.Width = 125;
            // 
            // colContacto
            // 
            colContacto.DataPropertyName = "Contacto";
            colContacto.HeaderText = "Contacto";
            colContacto.MinimumWidth = 6;
            colContacto.Name = "colContacto";
            colContacto.Width = 125;
            // 
            // ucProveedores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvProveedores);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlAcciones);
            Name = "ucProveedores";
            Size = new Size(636, 150);
            Load += ucProveedores_Load;
            pnlAcciones.ResumeLayout(false);
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlAcciones;
        private Button bntNuevo;
        private Button btnEditar;
        private Button btnVolver;
        private FlowLayoutPanel pnlFiltros;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Label lblTotal;
        private DataGridView dgvProveedores;
        private DataGridViewTextBoxColumn ColId;
        private DataGridViewTextBoxColumn ColNombre;
        private DataGridViewTextBoxColumn ColCategoria;
        private DataGridViewTextBoxColumn colContacto;
        private Button btnToggleActivo;
        private CheckBox chkMostrarInactivos;
    }
}
