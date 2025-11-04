namespace Servire.UI.Forms
{
    partial class frmBitacora
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabBitacora = new TabPage();
            dgvBitacora = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colAccion = new DataGridViewTextBoxColumn();
            colDetalle = new DataGridViewTextBoxColumn();
            flowFiltrosBitacora = new FlowLayoutPanel();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblTexto = new Label();
            txtTexto = new TextBox();
            lblDesde = new Label();
            dpDesde = new DateTimePicker();
            lblHasta = new Label();
            dpHasta = new DateTimePicker();
            btnExportar = new Button();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            tabErrores = new TabPage();
            dgvErrores = new DataGridView();
            panelFiltrosErrores = new FlowLayoutPanel();
            flowFiltrosErrores = new FlowLayoutPanel();
            lblUsuario2 = new Label();
            txtUsuario2 = new TextBox();
            lblTexto2 = new Label();
            txtTexto2 = new TextBox();
            lblDesde2 = new Label();
            dpDesde2 = new DateTimePicker();
            lblHasta2 = new Label();
            dpHasta2 = new DateTimePicker();
            lblNivel = new Label();
            cboNivel = new ComboBox();
            btnBuscar2 = new Button();
            btnLimpiar2 = new Button();
            btnExportar2 = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            statusStrip1 = new StatusStrip();
            lblCantidad = new ToolStripStatusLabel();
            ColIdE = new DataGridViewTextBoxColumn();
            ColFechaE = new DataGridViewTextBoxColumn();
            colNivel = new DataGridViewTextBoxColumn();
            colOrigen = new DataGridViewTextBoxColumn();
            ColMensaje = new DataGridViewTextBoxColumn();
            colUsuarioE = new DataGridViewTextBoxColumn();
            tabControl1.SuspendLayout();
            tabBitacora.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).BeginInit();
            flowFiltrosBitacora.SuspendLayout();
            tabErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvErrores).BeginInit();
            panelFiltrosErrores.SuspendLayout();
            flowFiltrosErrores.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabBitacora);
            tabControl1.Controls.Add(tabErrores);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(0, 0);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1453, 447);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged_1;
            // 
            // tabBitacora
            // 
            tabBitacora.Controls.Add(dgvBitacora);
            tabBitacora.Controls.Add(flowFiltrosBitacora);
            tabBitacora.Location = new Point(4, 29);
            tabBitacora.Name = "tabBitacora";
            tabBitacora.Padding = new Padding(3);
            tabBitacora.Size = new Size(1445, 414);
            tabBitacora.TabIndex = 0;
            tabBitacora.Text = "Bitácora";
            tabBitacora.UseVisualStyleBackColor = true;
            // 
            // dgvBitacora
            // 
            dgvBitacora.AllowUserToAddRows = false;
            dgvBitacora.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.Gainsboro;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBitacora.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gainsboro;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBitacora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBitacora.Columns.AddRange(new DataGridViewColumn[] { colId, colFecha, colUsuario, colAccion, colDetalle });
            dgvBitacora.Dock = DockStyle.Fill;
            dgvBitacora.EnableHeadersVisualStyles = false;
            dgvBitacora.Location = new Point(3, 55);
            dgvBitacora.Margin = new Padding(0);
            dgvBitacora.MultiSelect = false;
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.ReadOnly = true;
            dgvBitacora.RowHeadersVisible = false;
            dgvBitacora.RowHeadersWidth = 51;
            dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBitacora.Size = new Size(1439, 356);
            dgvBitacora.TabIndex = 0;
            // 
            // colId
            // 
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colId.DataPropertyName = "Id";
            colId.HeaderText = "#";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 50;
            // 
            // colFecha
            // 
            colFecha.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFecha.DataPropertyName = "Fecha";
            colFecha.FillWeight = 120F;
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 140;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colUsuario
            // 
            colUsuario.DataPropertyName = "UserName";
            colUsuario.FillWeight = 90F;
            colUsuario.HeaderText = "Usuario";
            colUsuario.MinimumWidth = 100;
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            colUsuario.Width = 192;
            // 
            // colAccion
            // 
            colAccion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colAccion.DataPropertyName = "Accion";
            colAccion.FillWeight = 140F;
            colAccion.HeaderText = "Accion";
            colAccion.MinimumWidth = 140;
            colAccion.Name = "colAccion";
            colAccion.ReadOnly = true;
            // 
            // colDetalle
            // 
            colDetalle.DataPropertyName = "Mensaje";
            colDetalle.FillWeight = 300F;
            colDetalle.HeaderText = "Detalle";
            colDetalle.MinimumWidth = 250;
            colDetalle.Name = "colDetalle";
            colDetalle.ReadOnly = true;
            colDetalle.Width = 640;
            // 
            // flowFiltrosBitacora
            // 
            flowFiltrosBitacora.AutoSize = true;
            flowFiltrosBitacora.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowFiltrosBitacora.Controls.Add(lblUsuario);
            flowFiltrosBitacora.Controls.Add(txtUsuario);
            flowFiltrosBitacora.Controls.Add(lblTexto);
            flowFiltrosBitacora.Controls.Add(txtTexto);
            flowFiltrosBitacora.Controls.Add(lblDesde);
            flowFiltrosBitacora.Controls.Add(dpDesde);
            flowFiltrosBitacora.Controls.Add(lblHasta);
            flowFiltrosBitacora.Controls.Add(dpHasta);
            flowFiltrosBitacora.Controls.Add(btnExportar);
            flowFiltrosBitacora.Controls.Add(btnBuscar);
            flowFiltrosBitacora.Controls.Add(btnLimpiar);
            flowFiltrosBitacora.Dock = DockStyle.Top;
            flowFiltrosBitacora.Location = new Point(3, 3);
            flowFiltrosBitacora.Name = "flowFiltrosBitacora";
            flowFiltrosBitacora.Padding = new Padding(8);
            flowFiltrosBitacora.Size = new Size(1439, 52);
            flowFiltrosBitacora.TabIndex = 0;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(11, 8);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            lblUsuario.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(79, 11);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(160, 27);
            txtUsuario.TabIndex = 4;
            // 
            // lblTexto
            // 
            lblTexto.AutoSize = true;
            lblTexto.Location = new Point(248, 12);
            lblTexto.Margin = new Padding(6, 4, 6, 4);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(48, 20);
            lblTexto.TabIndex = 2;
            lblTexto.Text = "Texto:";
            // 
            // txtTexto
            // 
            txtTexto.Location = new Point(308, 12);
            txtTexto.Margin = new Padding(6, 4, 6, 4);
            txtTexto.Name = "txtTexto";
            txtTexto.Size = new Size(220, 27);
            txtTexto.TabIndex = 5;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(540, 12);
            lblDesde.Margin = new Padding(6, 4, 6, 4);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(54, 20);
            lblDesde.TabIndex = 6;
            lblDesde.Text = "Desde:";
            lblDesde.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dpDesde
            // 
            dpDesde.Format = DateTimePickerFormat.Short;
            dpDesde.Location = new Point(603, 11);
            dpDesde.Name = "dpDesde";
            dpDesde.Size = new Size(155, 27);
            dpDesde.TabIndex = 2;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(767, 12);
            lblHasta.Margin = new Padding(6, 4, 6, 4);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(50, 20);
            lblHasta.TabIndex = 7;
            lblHasta.Text = "Hasta:";
            lblHasta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dpHasta
            // 
            dpHasta.Format = DateTimePickerFormat.Short;
            dpHasta.Location = new Point(829, 12);
            dpHasta.Margin = new Padding(6, 4, 6, 4);
            dpHasta.Name = "dpHasta";
            dpHasta.Size = new Size(116, 27);
            dpHasta.TabIndex = 3;
            // 
            // btnExportar
            // 
            btnExportar.AutoSize = true;
            btnExportar.Location = new Point(954, 11);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(94, 30);
            btnExportar.TabIndex = 8;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.AutoSize = true;
            btnBuscar.Location = new Point(1054, 11);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 30);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.AutoSize = true;
            btnLimpiar.Location = new Point(1154, 11);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 30);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // tabErrores
            // 
            tabErrores.Controls.Add(dgvErrores);
            tabErrores.Controls.Add(panelFiltrosErrores);
            tabErrores.Location = new Point(4, 29);
            tabErrores.Name = "tabErrores";
            tabErrores.Padding = new Padding(3);
            tabErrores.Size = new Size(1445, 414);
            tabErrores.TabIndex = 1;
            tabErrores.Text = "Errores";
            tabErrores.UseVisualStyleBackColor = true;
            // 
            // dgvErrores
            // 
            dgvErrores.AllowUserToAddRows = false;
            dgvErrores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.Gainsboro;
            dgvErrores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvErrores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Gainsboro;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvErrores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvErrores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvErrores.Columns.AddRange(new DataGridViewColumn[] { ColIdE, ColFechaE, colNivel, colOrigen, ColMensaje, colUsuarioE });
            dgvErrores.Dock = DockStyle.Fill;
            dgvErrores.EnableHeadersVisualStyles = false;
            dgvErrores.Location = new Point(3, 59);
            dgvErrores.MultiSelect = false;
            dgvErrores.Name = "dgvErrores";
            dgvErrores.RowHeadersVisible = false;
            dgvErrores.RowHeadersWidth = 51;
            dgvErrores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvErrores.Size = new Size(1439, 352);
            dgvErrores.TabIndex = 0;
            // 
            // panelFiltrosErrores
            // 
            panelFiltrosErrores.Controls.Add(flowFiltrosErrores);
            panelFiltrosErrores.Dock = DockStyle.Top;
            panelFiltrosErrores.Location = new Point(3, 3);
            panelFiltrosErrores.Name = "panelFiltrosErrores";
            panelFiltrosErrores.Size = new Size(1439, 56);
            panelFiltrosErrores.TabIndex = 2;
            // 
            // flowFiltrosErrores
            // 
            flowFiltrosErrores.AutoSize = true;
            flowFiltrosErrores.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowFiltrosErrores.Controls.Add(lblUsuario2);
            flowFiltrosErrores.Controls.Add(txtUsuario2);
            flowFiltrosErrores.Controls.Add(lblTexto2);
            flowFiltrosErrores.Controls.Add(txtTexto2);
            flowFiltrosErrores.Controls.Add(lblDesde2);
            flowFiltrosErrores.Controls.Add(dpDesde2);
            flowFiltrosErrores.Controls.Add(lblHasta2);
            flowFiltrosErrores.Controls.Add(dpHasta2);
            flowFiltrosErrores.Controls.Add(lblNivel);
            flowFiltrosErrores.Controls.Add(cboNivel);
            flowFiltrosErrores.Controls.Add(btnBuscar2);
            flowFiltrosErrores.Controls.Add(btnLimpiar2);
            flowFiltrosErrores.Controls.Add(btnExportar2);
            flowFiltrosErrores.Dock = DockStyle.Fill;
            flowFiltrosErrores.Location = new Point(3, 3);
            flowFiltrosErrores.Name = "flowFiltrosErrores";
            flowFiltrosErrores.Padding = new Padding(8);
            flowFiltrosErrores.Size = new Size(1417, 53);
            flowFiltrosErrores.TabIndex = 0;
            // 
            // lblUsuario2
            // 
            lblUsuario2.AutoSize = true;
            lblUsuario2.Location = new Point(14, 12);
            lblUsuario2.Margin = new Padding(6, 4, 6, 4);
            lblUsuario2.Name = "lblUsuario2";
            lblUsuario2.Size = new Size(66, 20);
            lblUsuario2.TabIndex = 1;
            lblUsuario2.Text = "Usuario: ";
            lblUsuario2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUsuario2
            // 
            txtUsuario2.Location = new Point(92, 12);
            txtUsuario2.Margin = new Padding(6, 4, 6, 4);
            txtUsuario2.Name = "txtUsuario2";
            txtUsuario2.Size = new Size(160, 27);
            txtUsuario2.TabIndex = 1;
            // 
            // lblTexto2
            // 
            lblTexto2.AutoSize = true;
            lblTexto2.Location = new Point(264, 12);
            lblTexto2.Margin = new Padding(6, 4, 6, 4);
            lblTexto2.Name = "lblTexto2";
            lblTexto2.Size = new Size(48, 20);
            lblTexto2.TabIndex = 3;
            lblTexto2.Text = "Texto:";
            lblTexto2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTexto2
            // 
            txtTexto2.Location = new Point(324, 12);
            txtTexto2.Margin = new Padding(6, 4, 6, 4);
            txtTexto2.Name = "txtTexto2";
            txtTexto2.Size = new Size(220, 27);
            txtTexto2.TabIndex = 2;
            // 
            // lblDesde2
            // 
            lblDesde2.AutoSize = true;
            lblDesde2.Location = new Point(556, 12);
            lblDesde2.Margin = new Padding(6, 4, 6, 4);
            lblDesde2.Name = "lblDesde2";
            lblDesde2.Size = new Size(54, 20);
            lblDesde2.TabIndex = 3;
            lblDesde2.Text = "Desde:";
            lblDesde2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dpDesde2
            // 
            dpDesde2.Format = DateTimePickerFormat.Short;
            dpDesde2.Location = new Point(622, 12);
            dpDesde2.Margin = new Padding(6, 4, 6, 4);
            dpDesde2.Name = "dpDesde2";
            dpDesde2.Size = new Size(123, 27);
            dpDesde2.TabIndex = 5;
            // 
            // lblHasta2
            // 
            lblHasta2.AutoSize = true;
            lblHasta2.Location = new Point(757, 12);
            lblHasta2.Margin = new Padding(6, 4, 6, 4);
            lblHasta2.Name = "lblHasta2";
            lblHasta2.Size = new Size(50, 20);
            lblHasta2.TabIndex = 4;
            lblHasta2.Text = "Hasta:";
            // 
            // dpHasta2
            // 
            dpHasta2.Format = DateTimePickerFormat.Short;
            dpHasta2.Location = new Point(819, 12);
            dpHasta2.Margin = new Padding(6, 4, 6, 4);
            dpHasta2.Name = "dpHasta2";
            dpHasta2.Size = new Size(113, 27);
            dpHasta2.TabIndex = 3;
            // 
            // lblNivel
            // 
            lblNivel.AutoSize = true;
            lblNivel.Location = new Point(944, 12);
            lblNivel.Margin = new Padding(6, 4, 6, 4);
            lblNivel.Name = "lblNivel";
            lblNivel.Size = new Size(43, 20);
            lblNivel.TabIndex = 3;
            lblNivel.Text = "Nivel";
            lblNivel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboNivel
            // 
            cboNivel.FormattingEnabled = true;
            cboNivel.Items.AddRange(new object[] { "\"\"", "INFO", "ERROR" });
            cboNivel.Location = new Point(999, 12);
            cboNivel.Margin = new Padding(6, 4, 6, 4);
            cboNivel.Name = "cboNivel";
            cboNivel.Size = new Size(86, 28);
            cboNivel.TabIndex = 1;
            // 
            // btnBuscar2
            // 
            btnBuscar2.Location = new Point(1097, 12);
            btnBuscar2.Margin = new Padding(6, 4, 6, 4);
            btnBuscar2.Name = "btnBuscar2";
            btnBuscar2.Size = new Size(94, 29);
            btnBuscar2.TabIndex = 3;
            btnBuscar2.Text = "Buscar";
            btnBuscar2.UseVisualStyleBackColor = true;
            btnBuscar2.Click += btnBuscar_Click;
            // 
            // btnLimpiar2
            // 
            btnLimpiar2.Location = new Point(1203, 12);
            btnLimpiar2.Margin = new Padding(6, 4, 6, 4);
            btnLimpiar2.Name = "btnLimpiar2";
            btnLimpiar2.Size = new Size(94, 29);
            btnLimpiar2.TabIndex = 4;
            btnLimpiar2.Text = "Limpiar";
            btnLimpiar2.UseVisualStyleBackColor = true;
            btnLimpiar2.Click += btnLimpiar_Click;
            // 
            // btnExportar2
            // 
            btnExportar2.Location = new Point(1309, 12);
            btnExportar2.Margin = new Padding(6, 4, 6, 4);
            btnExportar2.Name = "btnExportar2";
            btnExportar2.Size = new Size(94, 29);
            btnExportar2.TabIndex = 5;
            btnExportar2.Text = "Exportar";
            btnExportar2.UseVisualStyleBackColor = true;
            btnExportar2.Click += btnExportar_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblCantidad });
            statusStrip1.Location = new Point(0, 447);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1453, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblCantidad
            // 
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(85, 20);
            lblCantidad.Text = "Registros: 0";
            // 
            // ColIdE
            // 
            ColIdE.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColIdE.DataPropertyName = "Id";
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            ColIdE.DefaultCellStyle = dataGridViewCellStyle5;
            ColIdE.FillWeight = 453.24115F;
            ColIdE.HeaderText = "#";
            ColIdE.MinimumWidth = 100;
            ColIdE.Name = "ColIdE";
            // 
            // ColFechaE
            // 
            ColFechaE.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColFechaE.DataPropertyName = "Fecha";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            ColFechaE.DefaultCellStyle = dataGridViewCellStyle6;
            ColFechaE.FillWeight = 305.936768F;
            ColFechaE.HeaderText = "Fecha";
            ColFechaE.MinimumWidth = 200;
            ColFechaE.Name = "ColFechaE";
            ColFechaE.Resizable = DataGridViewTriState.False;
            ColFechaE.Width = 200;
            // 
            // colNivel
            // 
            colNivel.DataPropertyName = "Nivel";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            colNivel.DefaultCellStyle = dataGridViewCellStyle7;
            colNivel.FillWeight = 4.995705F;
            colNivel.HeaderText = "Nivel";
            colNivel.MinimumWidth = 200;
            colNivel.Name = "colNivel";
            // 
            // colOrigen
            // 
            colOrigen.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colOrigen.DataPropertyName = "Fuente";
            colOrigen.FillWeight = 54.1185F;
            colOrigen.HeaderText = "Origen";
            colOrigen.MinimumWidth = 200;
            colOrigen.Name = "colOrigen";
            colOrigen.Width = 200;
            // 
            // ColMensaje
            // 
            ColMensaje.DataPropertyName = "Mensaje";
            ColMensaje.FillWeight = 27.9324951F;
            ColMensaje.HeaderText = "Mensaje";
            ColMensaje.MinimumWidth = 200;
            ColMensaje.Name = "ColMensaje";
            // 
            // colUsuarioE
            // 
            colUsuarioE.DataPropertyName = "Usuario";
            colUsuarioE.FillWeight = 1.33635139F;
            colUsuarioE.HeaderText = "Usuario";
            colUsuarioE.MinimumWidth = 200;
            colUsuarioE.Name = "colUsuarioE";
            // 
            // frmBitacora
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1453, 473);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            KeyPreview = true;
            MinimumSize = new Size(1000, 520);
            Name = "frmBitacora";
            Text = "Bitácora";
            Load += frmBitacora_Load;
            tabControl1.ResumeLayout(false);
            tabBitacora.ResumeLayout(false);
            tabBitacora.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            flowFiltrosBitacora.ResumeLayout(false);
            flowFiltrosBitacora.PerformLayout();
            tabErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvErrores).EndInit();
            panelFiltrosErrores.ResumeLayout(false);
            panelFiltrosErrores.PerformLayout();
            flowFiltrosErrores.ResumeLayout(false);
            flowFiltrosErrores.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabBitacora;
        private TabPage tabErrores;
        private DataGridView dgvBitacora;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DateTimePicker dpHasta;
        private DateTimePicker dpDesde;
        private Button btnBuscar;
        private DataGridView dgvErrores;
        private TextBox txtTexto;
        private TextBox txtUsuario;
        private ComboBox cboNivel
            ;
        private FlowLayoutPanel flowFiltrosBitacora;
        private Label lblUsuario;
        private Label lblTexto;
        private Label lblDesde;
        private Button btnExportar;
        private Button btnLimpiar;
        private Label lblHasta;
        private Label lblTexto2;
        private FlowLayoutPanel panelFiltrosErrores;
        private FlowLayoutPanel flowFiltrosErrores;
        private Label lblUsuario2;
        private TextBox txtTexto2;
        private TextBox txtUsuario2;
        private Label lblDesde2;
        private DateTimePicker dpDesde2;
        private Label lblHasta2;
        private DateTimePicker dpHasta2;
        private Label lblNivel;
        private Button btnBuscar2;
        private Button btnLimpiar2;
        private Button btnExportar2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblCantidad;

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colAccion;
        private DataGridViewTextBoxColumn colDetalle;
        private DataGridViewTextBoxColumn ColIdE;
        private DataGridViewTextBoxColumn ColFechaE;
        private DataGridViewTextBoxColumn colNivel;
        private DataGridViewTextBoxColumn colOrigen;
        private DataGridViewTextBoxColumn ColMensaje;
        private DataGridViewTextBoxColumn colUsuarioE;
    }
}