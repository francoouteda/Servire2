namespace Servire.UI.Forms
{
    partial class frmInsumoEdit
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
            btnCancelar = new Button();
            btnGuardar = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            numCostoUnitario = new NumericUpDown();
            label7 = new Label();
            cboProveedor = new ComboBox();
            numStockActual = new NumericUpDown();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblCategoría = new Label();
            cboCategoria = new ComboBox();
            lblUnidad = new Label();
            cboUnidadMedida = new ComboBox();
            label1 = new Label();
            numStockMinimo = new NumericUpDown();
            label2 = new Label();
            lblProveedor = new Label();
            lblVenta = new Label();
            chkEsVendible = new CheckBox();
            lblPrecio = new Label();
            numPrecioVenta = new NumericUpDown();
            pnlBotones.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCostoUnitario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockActual).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).BeginInit();
            SuspendLayout();
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Controls.Add(btnGuardar);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.FlowDirection = FlowDirection.RightToLeft;
            pnlBotones.Location = new Point(0, 405);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(800, 45);
            pnlBotones.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(703, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnGuardar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(603, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.07692F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.92308F));
            tableLayoutPanel1.Controls.Add(numCostoUnitario, 1, 8);
            tableLayoutPanel1.Controls.Add(label7, 0, 8);
            tableLayoutPanel1.Controls.Add(cboProveedor, 1, 5);
            tableLayoutPanel1.Controls.Add(numStockActual, 1, 4);
            tableLayoutPanel1.Controls.Add(lblNombre, 0, 0);
            tableLayoutPanel1.Controls.Add(txtNombre, 1, 0);
            tableLayoutPanel1.Controls.Add(lblCategoría, 0, 1);
            tableLayoutPanel1.Controls.Add(cboCategoria, 1, 1);
            tableLayoutPanel1.Controls.Add(lblUnidad, 0, 2);
            tableLayoutPanel1.Controls.Add(cboUnidadMedida, 1, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 3);
            tableLayoutPanel1.Controls.Add(numStockMinimo, 1, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 4);
            tableLayoutPanel1.Controls.Add(lblProveedor, 0, 5);
            tableLayoutPanel1.Controls.Add(lblVenta, 0, 6);
            tableLayoutPanel1.Controls.Add(chkEsVendible, 1, 6);
            tableLayoutPanel1.Controls.Add(lblPrecio, 0, 7);
            tableLayoutPanel1.Controls.Add(numPrecioVenta, 1, 7);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel1.Size = new Size(800, 405);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // numCostoUnitario
            // 
            numCostoUnitario.Anchor = AnchorStyles.Left;
            numCostoUnitario.DecimalPlaces = 2;
            numCostoUnitario.Location = new Point(187, 284);
            numCostoUnitario.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numCostoUnitario.Name = "numCostoUnitario";
            numCostoUnitario.Size = new Size(147, 27);
            numCostoUnitario.TabIndex = 17;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Location = new Point(36, 287);
            label7.Name = "label7";
            label7.Size = new Size(111, 20);
            label7.TabIndex = 16;
            label7.Text = "Costo Unitario: ";
            // 
            // cboProveedor
            // 
            cboProveedor.Dock = DockStyle.Fill;
            cboProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProveedor.FormattingEnabled = true;
            cboProveedor.Location = new Point(187, 178);
            cboProveedor.Name = "cboProveedor";
            cboProveedor.Size = new Size(610, 28);
            cboProveedor.TabIndex = 11;
            // 
            // numStockActual
            // 
            numStockActual.DecimalPlaces = 2;
            numStockActual.Dock = DockStyle.Fill;
            numStockActual.Location = new Point(187, 143);
            numStockActual.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStockActual.Name = "numStockActual";
            numStockActual.Size = new Size(610, 27);
            numStockActual.TabIndex = 9;
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.None;
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(58, 7);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Fill;
            txtNombre.Location = new Point(187, 3);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(610, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblCategoría
            // 
            lblCategoría.Anchor = AnchorStyles.None;
            lblCategoría.AutoSize = true;
            lblCategoría.Location = new Point(53, 42);
            lblCategoría.Name = "lblCategoría";
            lblCategoría.Size = new Size(77, 20);
            lblCategoría.TabIndex = 2;
            lblCategoría.Text = "Categoría:";
            // 
            // cboCategoria
            // 
            cboCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboCategoria.Dock = DockStyle.Fill;
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(187, 38);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(610, 28);
            cboCategoria.TabIndex = 3;
            // 
            // lblUnidad
            // 
            lblUnidad.Anchor = AnchorStyles.None;
            lblUnidad.AutoSize = true;
            lblUnidad.Location = new Point(24, 77);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new Size(136, 20);
            lblUnidad.TabIndex = 4;
            lblUnidad.Text = "Unidad de Medida:";
            // 
            // cboUnidadMedida
            // 
            cboUnidadMedida.Dock = DockStyle.Fill;
            cboUnidadMedida.FormattingEnabled = true;
            cboUnidadMedida.Location = new Point(187, 73);
            cboUnidadMedida.Name = "cboUnidadMedida";
            cboUnidadMedida.Size = new Size(610, 28);
            cboUnidadMedida.TabIndex = 5;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(40, 112);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 6;
            label1.Text = "Stock Mínimo:";
            // 
            // numStockMinimo
            // 
            numStockMinimo.DecimalPlaces = 2;
            numStockMinimo.Dock = DockStyle.Fill;
            numStockMinimo.Location = new Point(187, 108);
            numStockMinimo.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStockMinimo.Name = "numStockMinimo";
            numStockMinimo.Size = new Size(610, 27);
            numStockMinimo.TabIndex = 7;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(22, 147);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 8;
            label2.Text = "Stock Actual/Inicial:";
            // 
            // lblProveedor
            // 
            lblProveedor.Anchor = AnchorStyles.None;
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(52, 182);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(80, 20);
            lblProveedor.TabIndex = 10;
            lblProveedor.Text = "Proveedor:";
            // 
            // lblVenta
            // 
            lblVenta.Anchor = AnchorStyles.None;
            lblVenta.AutoSize = true;
            lblVenta.Location = new Point(41, 216);
            lblVenta.Name = "lblVenta";
            lblVenta.Size = new Size(101, 20);
            lblVenta.TabIndex = 12;
            lblVenta.Text = "Venta Directa:";
            // 
            // chkEsVendible
            // 
            chkEsVendible.AutoSize = true;
            chkEsVendible.Location = new Point(187, 213);
            chkEsVendible.Name = "chkEsVendible";
            chkEsVendible.Size = new Size(328, 24);
            chkEsVendible.TabIndex = 13;
            chkEsVendible.Text = "Este insumo se vende directamente al cliente";
            chkEsVendible.UseVisualStyleBackColor = true;
            chkEsVendible.CheckedChanged += chkEsVendible_CheckedChanged;
            // 
            // lblPrecio
            // 
            lblPrecio.Anchor = AnchorStyles.None;
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(34, 251);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(115, 20);
            lblPrecio.TabIndex = 14;
            lblPrecio.Text = "Precio de Venta:";
            // 
            // numPrecioVenta
            // 
            numPrecioVenta.DecimalPlaces = 2;
            numPrecioVenta.Location = new Point(187, 246);
            numPrecioVenta.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrecioVenta.Name = "numPrecioVenta";
            numPrecioVenta.Size = new Size(150, 27);
            numPrecioVenta.TabIndex = 15;
            // 
            // frmInsumoEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlBotones);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmInsumoEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Insumo";
            Load += frmInsumoEdit_Load;
            pnlBotones.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCostoUnitario).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockActual).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockMinimo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecioVenta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlBotones;
        private Button btnCancelar;
        private Button btnGuardar;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblCategoría;
        private ComboBox cboCategoria;
        private Label lblUnidad;
        private ComboBox cboUnidadMedida;
        private Label label1;
        private NumericUpDown numStockMinimo;
        private Label label2;
        private ComboBox cboProveedor;
        private NumericUpDown numStockActual;
        private Label lblProveedor;
        private Label lblVenta;
        private CheckBox chkEsVendible;
        private Label lblPrecio;
        private NumericUpDown numPrecioVenta;
        private Label label7;
        private NumericUpDown numCostoUnitario;
    }
}