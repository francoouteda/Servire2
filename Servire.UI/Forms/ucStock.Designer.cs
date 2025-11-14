namespace Servire.UI.Forms
{
    partial class ucStock
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
            btnNuevoInsumo = new Button();
            btnEditarInsumo = new Button();
            btnRegistrarEntrada = new Button();
            btnGestionarProveedores = new Button();
            pnlFiltros = new FlowLayoutPanel();
            label1 = new Label();
            txtBuscar = new TextBox();
            chkStockCritico = new CheckBox();
            lblTotal = new Label();
            dgvInsumos = new DataGridView();
            ColId = new DataGridViewTextBoxColumn();
            ColNombre = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            ColStockActual = new DataGridViewTextBoxColumn();
            ColStockMinimo = new DataGridViewTextBoxColumn();
            ColUnidad = new DataGridViewTextBoxColumn();
            ColProveedor = new DataGridViewTextBoxColumn();
            pnlAcciones.SuspendLayout();
            pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInsumos).BeginInit();
            SuspendLayout();
            // 
            // pnlAcciones
            // 
            pnlAcciones.Controls.Add(btnNuevoInsumo);
            pnlAcciones.Controls.Add(btnEditarInsumo);
            pnlAcciones.Controls.Add(btnRegistrarEntrada);
            pnlAcciones.Controls.Add(btnGestionarProveedores);
            pnlAcciones.Dock = DockStyle.Top;
            pnlAcciones.Location = new Point(0, 0);
            pnlAcciones.MaximumSize = new Size(0, 40);
            pnlAcciones.MinimumSize = new Size(0, 40);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Padding = new Padding(5);
            pnlAcciones.Size = new Size(666, 40);
            pnlAcciones.TabIndex = 0;
            // 
            // btnNuevoInsumo
            // 
            btnNuevoInsumo.Location = new Point(8, 8);
            btnNuevoInsumo.Name = "btnNuevoInsumo";
            btnNuevoInsumo.Size = new Size(124, 29);
            btnNuevoInsumo.TabIndex = 0;
            btnNuevoInsumo.Text = "Nuevo Insumo";
            btnNuevoInsumo.UseVisualStyleBackColor = true;
            btnNuevoInsumo.Click += btnNuevoInsumo_Click;
            // 
            // btnEditarInsumo
            // 
            btnEditarInsumo.Location = new Point(138, 8);
            btnEditarInsumo.Name = "btnEditarInsumo";
            btnEditarInsumo.Size = new Size(124, 29);
            btnEditarInsumo.TabIndex = 1;
            btnEditarInsumo.Text = "Editar Insumo";
            btnEditarInsumo.UseVisualStyleBackColor = true;
            btnEditarInsumo.Click += btnEditarInsumo_Click;
            // 
            // btnRegistrarEntrada
            // 
            btnRegistrarEntrada.Location = new Point(268, 8);
            btnRegistrarEntrada.Name = "btnRegistrarEntrada";
            btnRegistrarEntrada.Size = new Size(141, 29);
            btnRegistrarEntrada.TabIndex = 2;
            btnRegistrarEntrada.Text = "Registrar Insumo";
            btnRegistrarEntrada.UseVisualStyleBackColor = true;
            btnRegistrarEntrada.Click += btnRegistrarEntrada_Click;
            // 
            // btnGestionarProveedores
            // 
            btnGestionarProveedores.Location = new Point(415, 8);
            btnGestionarProveedores.Name = "btnGestionarProveedores";
            btnGestionarProveedores.Size = new Size(201, 29);
            btnGestionarProveedores.TabIndex = 3;
            btnGestionarProveedores.Text = "Gestionar Proveedores";
            btnGestionarProveedores.UseVisualStyleBackColor = true;
            btnGestionarProveedores.Click += btnGestionarProveedores_Click;
            // 
            // pnlFiltros
            // 
            pnlFiltros.Controls.Add(label1);
            pnlFiltros.Controls.Add(txtBuscar);
            pnlFiltros.Controls.Add(chkStockCritico);
            pnlFiltros.Controls.Add(lblTotal);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 40);
            pnlFiltros.MaximumSize = new Size(0, 40);
            pnlFiltros.MinimumSize = new Size(0, 40);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(5);
            pnlFiltros.Size = new Size(666, 40);
            pnlFiltros.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 5);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 0;
            label1.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(66, 8);
            txtBuscar.MaximumSize = new Size(250, 0);
            txtBuscar.MinimumSize = new Size(250, 0);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(250, 27);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // chkStockCritico
            // 
            chkStockCritico.AutoSize = true;
            chkStockCritico.Location = new Point(322, 8);
            chkStockCritico.Name = "chkStockCritico";
            chkStockCritico.Size = new Size(197, 24);
            chkStockCritico.TabIndex = 2;
            chkStockCritico.Text = "Mostrar solo stock crítico";
            chkStockCritico.UseVisualStyleBackColor = true;
            chkStockCritico.CheckedChanged += chkStockCritico_CheckedChanged;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(525, 5);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(57, 20);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total: 0";
            // 
            // dgvInsumos
            // 
            dgvInsumos.AllowUserToAddRows = false;
            dgvInsumos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInsumos.Columns.AddRange(new DataGridViewColumn[] { ColId, ColNombre, colCategoria, ColStockActual, ColStockMinimo, ColUnidad, ColProveedor });
            dgvInsumos.Dock = DockStyle.Fill;
            dgvInsumos.Location = new Point(0, 80);
            dgvInsumos.MultiSelect = false;
            dgvInsumos.Name = "dgvInsumos";
            dgvInsumos.RowHeadersVisible = false;
            dgvInsumos.RowHeadersWidth = 51;
            dgvInsumos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInsumos.Size = new Size(666, 192);
            dgvInsumos.TabIndex = 2;
            dgvInsumos.CellFormatting += dgvInsumos_CellFormatting;
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
            // colCategoria
            // 
            colCategoria.DataPropertyName = "Categoria";
            colCategoria.HeaderText = "Categoría";
            colCategoria.MinimumWidth = 6;
            colCategoria.Name = "colCategoria";
            colCategoria.Width = 125;
            // 
            // ColStockActual
            // 
            ColStockActual.DataPropertyName = "StockActual";
            ColStockActual.HeaderText = "Stock Actual";
            ColStockActual.MinimumWidth = 6;
            ColStockActual.Name = "ColStockActual";
            ColStockActual.Width = 125;
            // 
            // ColStockMinimo
            // 
            ColStockMinimo.DataPropertyName = "StockMinimo";
            ColStockMinimo.HeaderText = "Stock Mínimo";
            ColStockMinimo.MinimumWidth = 6;
            ColStockMinimo.Name = "ColStockMinimo";
            ColStockMinimo.Width = 125;
            // 
            // ColUnidad
            // 
            ColUnidad.DataPropertyName = "UnidadMedida";
            ColUnidad.HeaderText = "Unidad";
            ColUnidad.MinimumWidth = 6;
            ColUnidad.Name = "ColUnidad";
            ColUnidad.Width = 125;
            // 
            // ColProveedor
            // 
            ColProveedor.DataPropertyName = "Proveedor";
            ColProveedor.HeaderText = "Proveedor";
            ColProveedor.MinimumWidth = 6;
            ColProveedor.Name = "ColProveedor";
            ColProveedor.Width = 125;
            // 
            // ucStock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvInsumos);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlAcciones);
            Name = "ucStock";
            Size = new Size(666, 272);
            Load += ucStock_Load;
            pnlAcciones.ResumeLayout(false);
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInsumos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlAcciones;
        private Button btnNuevoInsumo;
        private Button btnEditarInsumo;
        private Button btnRegistrarEntrada;
        private Button btnGestionarProveedores;
        private FlowLayoutPanel pnlFiltros;
        private Label label1;
        private TextBox txtBuscar;
        private CheckBox chkStockCritico;
        private Label lblTotal;
        private DataGridView dgvInsumos;
        private DataGridViewTextBoxColumn ColId;
        private DataGridViewTextBoxColumn ColNombre;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn ColStockActual;
        private DataGridViewTextBoxColumn ColStockMinimo;
        private DataGridViewTextBoxColumn ColUnidad;
        private DataGridViewTextBoxColumn ColProveedor;
    }
}
