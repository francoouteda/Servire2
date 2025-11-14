namespace Servire.UI.Forms
{
    partial class frmProveedorEdit
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnCancelar = new Button();
            btnGuardar = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtContacto = new TextBox();
            label2 = new Label();
            label1 = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            cboCategoria = new ComboBox();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnCancelar);
            flowLayoutPanel1.Controls.Add(btnGuardar);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 405);
            flowLayoutPanel1.MaximumSize = new Size(0, 45);
            flowLayoutPanel1.MinimumSize = new Size(0, 45);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(800, 45);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(703, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(txtContacto, 1, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(lblNombre, 0, 0);
            tableLayoutPanel1.Controls.Add(txtNombre, 1, 0);
            tableLayoutPanel1.Controls.Add(cboCategoria, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 143F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 405);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // txtContacto
            // 
            txtContacto.Anchor = AnchorStyles.None;
            txtContacto.Location = new Point(153, 300);
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(644, 27);
            txtContacto.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 242);
            label2.Name = "label2";
            label2.Size = new Size(144, 143);
            label2.TabIndex = 4;
            label2.Text = "Contacto (Tel/Email):";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 121);
            label1.Name = "label1";
            label1.Size = new Size(144, 121);
            label1.TabIndex = 2;
            label1.Text = "Categoría:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Dock = DockStyle.Fill;
            lblNombre.Location = new Point(3, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(144, 121);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            lblNombre.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.None;
            txtNombre.Location = new Point(153, 47);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(644, 27);
            txtNombre.TabIndex = 1;
            // 
            // cboCategoria
            // 
            cboCategoria.Anchor = AnchorStyles.None;
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(153, 167);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(644, 28);
            cboCategoria.TabIndex = 3;
            // 
            // frmProveedorEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(flowLayoutPanel1);
            Name = "frmProveedorEdit";
            Text = "frmProveedorEdit";
            Load += frmProveedorEdit_Load;
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnGuardar;
        private Button btnCancelar;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblNombre;
        private Label label2;
        private Label label1;
        private TextBox txtNombre;
        private ComboBox cboCategoria;
        private TextBox txtContacto;
    }
}