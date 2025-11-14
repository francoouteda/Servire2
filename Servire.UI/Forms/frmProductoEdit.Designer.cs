namespace Servire.UI.Forms
{
    partial class frmProductoEdit
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
            pnlBotones = new FlowLayoutPanel();
            button2 = new Button();
            btnGuardar = new Button();
            splitContenedor = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            numTiempoPreparacion = new NumericUpDown();
            label1 = new Label();
            txtNombre = new TextBox();
            cboCategoria = new ComboBox();
            label3 = new Label();
            numPrecioVenta = new NumericUpDown();
            label4 = new Label();
            label2 = new Label();
            splitReceta = new SplitContainer();
            grpAñadir = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label5 = new Label();
            cboInsumos = new ComboBox();
            label6 = new Label();
            numCantidad = new NumericUpDown();
            lblUnidadInsumo = new Label();
            btnAnadir = new Button();
            grpReceta = new GroupBox();
            btnQuitar = new Button();
            dgvIngredientes = new DataGridView();
            ColInsumoNombre = new DataGridViewTextBoxColumn();
            ColCantidad = new DataGridViewTextBoxColumn();
            ColUnidad = new DataGridViewTextBoxColumn();
            lblCostoTotal = new Label();
            pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContenedor).BeginInit();
            splitContenedor.Panel1.SuspendLayout();
            splitContenedor.Panel2.SuspendLayout();
            splitContenedor.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTiempoPreparacion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitReceta).BeginInit();
            splitReceta.Panel1.SuspendLayout();
            splitReceta.Panel2.SuspendLayout();
            splitReceta.SuspendLayout();
            grpAñadir.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            grpReceta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngredientes).BeginInit();
            SuspendLayout();
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(button2);
            pnlBotones.Controls.Add(btnGuardar);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.FlowDirection = FlowDirection.RightToLeft;
            pnlBotones.Location = new Point(0, 608);
            pnlBotones.MaximumSize = new Size(0, 45);
            pnlBotones.MinimumSize = new Size(0, 45);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(882, 45);
            pnlBotones.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(785, 3);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(685, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = " Guardar Producto";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // splitContenedor
            // 
            splitContenedor.Dock = DockStyle.Fill;
            splitContenedor.Location = new Point(0, 0);
            splitContenedor.Name = "splitContenedor";
            splitContenedor.Orientation = Orientation.Horizontal;
            // 
            // splitContenedor.Panel1
            // 
            splitContenedor.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContenedor.Panel2
            // 
            splitContenedor.Panel2.Controls.Add(splitReceta);
            splitContenedor.Size = new Size(882, 608);
            splitContenedor.SplitterDistance = 200;
            splitContenedor.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.484848F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.515152F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 228F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 356F));
            tableLayoutPanel1.Controls.Add(numTiempoPreparacion, 3, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(txtNombre, 1, 0);
            tableLayoutPanel1.Controls.Add(cboCategoria, 3, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(numPrecioVenta, 1, 1);
            tableLayoutPanel1.Controls.Add(label4, 2, 1);
            tableLayoutPanel1.Controls.Add(label2, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 102F));
            tableLayoutPanel1.Size = new Size(882, 200);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // numTiempoPreparacion
            // 
            numTiempoPreparacion.Anchor = AnchorStyles.None;
            numTiempoPreparacion.DecimalPlaces = 2;
            numTiempoPreparacion.Location = new Point(528, 60);
            numTiempoPreparacion.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numTiempoPreparacion.Name = "numTiempoPreparacion";
            numTiempoPreparacion.Size = new Size(351, 27);
            numTiempoPreparacion.TabIndex = 7;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(10, 14);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre Producto:";
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.None;
            txtNombre.Location = new Point(147, 11);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(147, 27);
            txtNombre.TabIndex = 1;
            // 
            // cboCategoria
            // 
            cboCategoria.Anchor = AnchorStyles.None;
            cboCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(528, 10);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(351, 28);
            cboCategoria.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(47, 63);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 4;
            label3.Text = "Precio Venta:";
            // 
            // numPrecioVenta
            // 
            numPrecioVenta.Anchor = AnchorStyles.None;
            numPrecioVenta.DecimalPlaces = 2;
            numPrecioVenta.Location = new Point(147, 60);
            numPrecioVenta.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrecioVenta.Name = "numPrecioVenta";
            numPrecioVenta.Size = new Size(147, 27);
            numPrecioVenta.TabIndex = 5;
            numPrecioVenta.ValueChanged += numPrecioVenta_ValueChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(319, 63);
            label4.Name = "label4";
            label4.Size = new Size(203, 20);
            label4.TabIndex = 6;
            label4.Text = "Tiempo de Preparación (min)";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(445, 14);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 2;
            label2.Text = "Categoría:";
            // 
            // splitReceta
            // 
            splitReceta.Dock = DockStyle.Fill;
            splitReceta.Location = new Point(0, 0);
            splitReceta.Name = "splitReceta";
            // 
            // splitReceta.Panel1
            // 
            splitReceta.Panel1.Controls.Add(grpAñadir);
            // 
            // splitReceta.Panel2
            // 
            splitReceta.Panel2.Controls.Add(grpReceta);
            splitReceta.Size = new Size(882, 404);
            splitReceta.SplitterDistance = 300;
            splitReceta.TabIndex = 0;
            // 
            // grpAñadir
            // 
            grpAñadir.Controls.Add(tableLayoutPanel2);
            grpAñadir.Dock = DockStyle.Fill;
            grpAñadir.Location = new Point(0, 0);
            grpAñadir.Name = "grpAñadir";
            grpAñadir.Size = new Size(300, 404);
            grpAñadir.TabIndex = 0;
            grpAñadir.TabStop = false;
            grpAñadir.Text = "Añadir Insumo a la Receta";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label5, 0, 0);
            tableLayoutPanel2.Controls.Add(cboInsumos, 1, 0);
            tableLayoutPanel2.Controls.Add(label6, 0, 1);
            tableLayoutPanel2.Controls.Add(numCantidad, 1, 1);
            tableLayoutPanel2.Controls.Add(lblUnidadInsumo, 0, 2);
            tableLayoutPanel2.Controls.Add(btnAnadir, 1, 2);
            tableLayoutPanel2.Location = new Point(44, 67);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 87F));
            tableLayoutPanel2.Size = new Size(250, 199);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(107, 20);
            label5.TabIndex = 0;
            label5.Text = "Buscar Insumo:";
            // 
            // cboInsumos
            // 
            cboInsumos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboInsumos.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboInsumos.Dock = DockStyle.Fill;
            cboInsumos.FormattingEnabled = true;
            cboInsumos.Location = new Point(128, 3);
            cboInsumos.Name = "cboInsumos";
            cboInsumos.Size = new Size(119, 28);
            cboInsumos.TabIndex = 1;
            cboInsumos.SelectedIndexChanged += cboInsumos_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 56);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 2;
            label6.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            numCantidad.DecimalPlaces = 3;
            numCantidad.Dock = DockStyle.Fill;
            numCantidad.Location = new Point(128, 59);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(119, 27);
            numCantidad.TabIndex = 3;
            // 
            // lblUnidadInsumo
            // 
            lblUnidadInsumo.AutoSize = true;
            lblUnidadInsumo.Location = new Point(3, 112);
            lblUnidadInsumo.Name = "lblUnidadInsumo";
            lblUnidadInsumo.Size = new Size(67, 20);
            lblUnidadInsumo.TabIndex = 4;
            lblUnidadInsumo.Text = "(Unidad)";
            // 
            // btnAnadir
            // 
            btnAnadir.Dock = DockStyle.Fill;
            btnAnadir.Location = new Point(128, 115);
            btnAnadir.Name = "btnAnadir";
            btnAnadir.Size = new Size(119, 81);
            btnAnadir.TabIndex = 5;
            btnAnadir.Text = "Añadir >>";
            btnAnadir.UseVisualStyleBackColor = true;
            btnAnadir.Click += btnAnadir_Click;
            // 
            // grpReceta
            // 
            grpReceta.Controls.Add(btnQuitar);
            grpReceta.Controls.Add(dgvIngredientes);
            grpReceta.Controls.Add(lblCostoTotal);
            grpReceta.Dock = DockStyle.Fill;
            grpReceta.Location = new Point(0, 0);
            grpReceta.Name = "grpReceta";
            grpReceta.Size = new Size(578, 404);
            grpReceta.TabIndex = 0;
            grpReceta.TabStop = false;
            grpReceta.Text = "Receta Actual (Ingredientes)";
            // 
            // btnQuitar
            // 
            btnQuitar.Dock = DockStyle.Bottom;
            btnQuitar.Location = new Point(3, 352);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(572, 29);
            btnQuitar.TabIndex = 1;
            btnQuitar.Text = "Quitar Insumo Seleccionado";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // dgvIngredientes
            // 
            dgvIngredientes.AllowUserToAddRows = false;
            dgvIngredientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIngredientes.Columns.AddRange(new DataGridViewColumn[] { ColInsumoNombre, ColCantidad, ColUnidad });
            dgvIngredientes.Dock = DockStyle.Fill;
            dgvIngredientes.Location = new Point(3, 23);
            dgvIngredientes.MultiSelect = false;
            dgvIngredientes.Name = "dgvIngredientes";
            dgvIngredientes.RowHeadersVisible = false;
            dgvIngredientes.RowHeadersWidth = 51;
            dgvIngredientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIngredientes.Size = new Size(572, 358);
            dgvIngredientes.TabIndex = 0;
            // 
            // ColInsumoNombre
            // 
            ColInsumoNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColInsumoNombre.DataPropertyName = "InsumoNombre";
            ColInsumoNombre.HeaderText = "Insumo";
            ColInsumoNombre.MinimumWidth = 6;
            ColInsumoNombre.Name = "ColInsumoNombre";
            // 
            // ColCantidad
            // 
            ColCantidad.DataPropertyName = "Cantidad";
            ColCantidad.HeaderText = "Cantidad";
            ColCantidad.MinimumWidth = 6;
            ColCantidad.Name = "ColCantidad";
            ColCantidad.Width = 125;
            // 
            // ColUnidad
            // 
            ColUnidad.DataPropertyName = "InsumoUnidad";
            ColUnidad.HeaderText = "Unidad";
            ColUnidad.MinimumWidth = 6;
            ColUnidad.Name = "ColUnidad";
            ColUnidad.Width = 125;
            // 
            // lblCostoTotal
            // 
            lblCostoTotal.AutoSize = true;
            lblCostoTotal.Dock = DockStyle.Bottom;
            lblCostoTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCostoTotal.Location = new Point(3, 381);
            lblCostoTotal.Name = "lblCostoTotal";
            lblCostoTotal.Size = new Size(140, 20);
            lblCostoTotal.TabIndex = 2;
            lblCostoTotal.Text = "Costo Total: $ 0.00";
            lblCostoTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmProductoEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 653);
            Controls.Add(splitContenedor);
            Controls.Add(pnlBotones);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(900, 700);
            MinimizeBox = false;
            MinimumSize = new Size(900, 700);
            Name = "frmProductoEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Producto y Receta";
            Load += frmProductoEdit_Load;
            pnlBotones.ResumeLayout(false);
            splitContenedor.Panel1.ResumeLayout(false);
            splitContenedor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContenedor).EndInit();
            splitContenedor.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTiempoPreparacion).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).EndInit();
            splitReceta.Panel1.ResumeLayout(false);
            splitReceta.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitReceta).EndInit();
            splitReceta.ResumeLayout(false);
            grpAñadir.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            grpReceta.ResumeLayout(false);
            grpReceta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIngredientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlBotones;
        private Button button2;
        private Button btnGuardar;
        private SplitContainer splitContenedor;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label1;
        private TextBox txtNombre;
        private ComboBox cboCategoria;
        private NumericUpDown numTiempoPreparacion;
        private Label label3;
        private NumericUpDown numPrecioVenta;
        private Label label4;
        private SplitContainer splitReceta;
        private GroupBox grpAñadir;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label5;
        private ComboBox cboInsumos;
        private Label label6;
        private NumericUpDown numCantidad;
        private Label lblUnidadInsumo;
        private Button btnAnadir;
        private GroupBox grpReceta;
        private DataGridView dgvIngredientes;
        private DataGridViewTextBoxColumn ColInsumoNombre;
        private DataGridViewTextBoxColumn ColCantidad;
        private DataGridViewTextBoxColumn ColUnidad;
        private Button btnQuitar;
        private Label lblCostoTotal;
    }
}