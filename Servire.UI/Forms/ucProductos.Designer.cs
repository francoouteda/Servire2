namespace Servire.UI.Forms
{
    partial class ucProductos
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
            btnNuevo = new Button();
            btnEditar = new Button();
            btnToggleActivo = new Button();
            pnlFIltros = new FlowLayoutPanel();
            label1 = new Label();
            txtBuscar = new TextBox();
            label2 = new Label();
            cboCategoriaFiltro = new ComboBox();
            chkMostrarInactivos = new CheckBox();
            lblTotal = new Label();
            label3 = new Label();
            dgvProductos = new DataGridView();
            ColId = new DataGridViewTextBoxColumn();
            ColNombre = new DataGridViewTextBoxColumn();
            ColCategoria = new DataGridViewTextBoxColumn();
            ColPrecio = new DataGridViewTextBoxColumn();
            ColTiempo = new DataGridViewTextBoxColumn();
            pnlAcciones.SuspendLayout();
            pnlFIltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // pnlAcciones
            // 
            pnlAcciones.Controls.Add(btnNuevo);
            pnlAcciones.Controls.Add(btnEditar);
            pnlAcciones.Controls.Add(btnToggleActivo);
            pnlAcciones.Dock = DockStyle.Top;
            pnlAcciones.Location = new Point(0, 0);
            pnlAcciones.MaximumSize = new Size(0, 40);
            pnlAcciones.MinimumSize = new Size(0, 40);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Padding = new Padding(5);
            pnlAcciones.Size = new Size(626, 40);
            pnlAcciones.TabIndex = 0;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(8, 8);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo Producto";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(108, 8);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar Producto";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnToggleActivo
            // 
            btnToggleActivo.Location = new Point(208, 8);
            btnToggleActivo.Name = "btnToggleActivo";
            btnToggleActivo.Size = new Size(94, 29);
            btnToggleActivo.TabIndex = 2;
            btnToggleActivo.Text = "Activar/Desactivar";
            btnToggleActivo.UseVisualStyleBackColor = true;
            btnToggleActivo.Click += btnToggleActivo_Click;
            // 
            // pnlFIltros
            // 
            pnlFIltros.Controls.Add(label1);
            pnlFIltros.Controls.Add(txtBuscar);
            pnlFIltros.Controls.Add(label2);
            pnlFIltros.Controls.Add(cboCategoriaFiltro);
            pnlFIltros.Controls.Add(chkMostrarInactivos);
            pnlFIltros.Controls.Add(lblTotal);
            pnlFIltros.Controls.Add(label3);
            pnlFIltros.Dock = DockStyle.Top;
            pnlFIltros.Location = new Point(0, 40);
            pnlFIltros.MaximumSize = new Size(0, 40);
            pnlFIltros.MinimumSize = new Size(0, 40);
            pnlFIltros.Name = "pnlFIltros";
            pnlFIltros.Padding = new Padding(5);
            pnlFIltros.Size = new Size(626, 40);
            pnlFIltros.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 5);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(69, 8);
            txtBuscar.MaximumSize = new Size(250, 0);
            txtBuscar.MinimumSize = new Size(250, 0);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(250, 27);
            txtBuscar.TabIndex = 3;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(325, 5);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "Categoría:";
            // 
            // cboCategoriaFiltro
            // 
            cboCategoriaFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoriaFiltro.FormattingEnabled = true;
            cboCategoriaFiltro.Location = new Point(408, 8);
            cboCategoriaFiltro.MaximumSize = new Size(200, 0);
            cboCategoriaFiltro.MinimumSize = new Size(200, 0);
            cboCategoriaFiltro.Name = "cboCategoriaFiltro";
            cboCategoriaFiltro.Size = new Size(200, 28);
            cboCategoriaFiltro.TabIndex = 4;
            cboCategoriaFiltro.SelectedIndexChanged += cboCategoriaFiltro_SelectedIndexChanged;
            // 
            // chkMostrarInactivos
            // 
            chkMostrarInactivos.AutoSize = true;
            chkMostrarInactivos.Location = new Point(8, 42);
            chkMostrarInactivos.Name = "chkMostrarInactivos";
            chkMostrarInactivos.Size = new Size(144, 24);
            chkMostrarInactivos.TabIndex = 6;
            chkMostrarInactivos.Text = "Mostrar Inactivos";
            chkMostrarInactivos.UseVisualStyleBackColor = true;
            chkMostrarInactivos.CheckedChanged += chkMostrarInactivos_CheckedChanged;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(158, 39);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(57, 20);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total: 0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(221, 39);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 2;
            label3.Text = "Total: 0";
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { ColId, ColNombre, ColCategoria, ColPrecio, ColTiempo });
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(0, 80);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(626, 70);
            dgvProductos.TabIndex = 2;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick;
            // 
            // ColId
            // 
            ColId.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColId.DataPropertyName = "Id";
            ColId.HeaderText = "#";
            ColId.MinimumWidth = 6;
            ColId.Name = "ColId";
            ColId.Width = 47;
            // 
            // ColNombre
            // 
            ColNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColNombre.DataPropertyName = "Nombre";
            ColNombre.HeaderText = "Nombre";
            ColNombre.MinimumWidth = 6;
            ColNombre.Name = "ColNombre";
            // 
            // ColCategoria
            // 
            ColCategoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColCategoria.DataPropertyName = "Categoria";
            ColCategoria.HeaderText = "Categoría";
            ColCategoria.MinimumWidth = 6;
            ColCategoria.Name = "ColCategoria";
            ColCategoria.Width = 103;
            // 
            // ColPrecio
            // 
            ColPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColPrecio.DataPropertyName = "PrecioVenta";
            ColPrecio.HeaderText = "Precio Venta";
            ColPrecio.MinimumWidth = 6;
            ColPrecio.Name = "ColPrecio";
            ColPrecio.Width = 110;
            // 
            // ColTiempo
            // 
            ColTiempo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColTiempo.DataPropertyName = "TiempoPreparacionMinutos";
            ColTiempo.HeaderText = "Tiempo de Preparación (min)";
            ColTiempo.MinimumWidth = 6;
            ColTiempo.Name = "ColTiempo";
            ColTiempo.Width = 143;
            // 
            // ucProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvProductos);
            Controls.Add(pnlFIltros);
            Controls.Add(pnlAcciones);
            Name = "ucProductos";
            Size = new Size(626, 150);
            Load += ucProductos_Load;
            pnlAcciones.ResumeLayout(false);
            pnlFIltros.ResumeLayout(false);
            pnlFIltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlAcciones;
        private Button btnNuevo;
        private Button btnEditar;
        private Button btnToggleActivo;
        private FlowLayoutPanel pnlFIltros;
        private Label label1;
        private TextBox txtBuscar;
        private Label label2;
        private ComboBox cboCategoriaFiltro;
        private Label label3;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn ColId;
        private DataGridViewTextBoxColumn ColNombre;
        private DataGridViewTextBoxColumn ColCategoria;
        private DataGridViewTextBoxColumn ColPrecio;
        private DataGridViewTextBoxColumn ColTiempo;
        private Label lblTotal;
        private CheckBox chkMostrarInactivos;
    }
}
