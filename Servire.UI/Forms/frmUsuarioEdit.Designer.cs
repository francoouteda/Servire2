namespace Servire.UI.Forms
{
    partial class frmUsuarioEdit
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
            pnlDatos = new FlowLayoutPanel();
            lblUsuario = new Label();
            txtUserName = new TextBox();
            label1 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtdni = new TextBox();
            chkActivo = new CheckBox();
            label2 = new Label();
            cboRol = new ComboBox();
            grpPassword = new GroupBox();
            txtConfirm = new TextBox();
            label6 = new Label();
            label5 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            pnlAcciones = new FlowLayoutPanel();
            btnGuardar = new Button();
            btnCancelar = new Button();
            pnlDatos.SuspendLayout();
            grpPassword.SuspendLayout();
            pnlAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDatos
            // 
            pnlDatos.Controls.Add(lblUsuario);
            pnlDatos.Controls.Add(txtUserName);
            pnlDatos.Controls.Add(label1);
            pnlDatos.Controls.Add(txtNombre);
            pnlDatos.Controls.Add(label3);
            pnlDatos.Controls.Add(txtdni);
            pnlDatos.Controls.Add(chkActivo);
            pnlDatos.Controls.Add(label2);
            pnlDatos.Controls.Add(cboRol);
            pnlDatos.Dock = DockStyle.Top;
            pnlDatos.Location = new Point(0, 0);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Padding = new Padding(12);
            pnlDatos.Size = new Size(1237, 63);
            pnlDatos.TabIndex = 0;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(15, 12);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(59, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(80, 15);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(260, 27);
            txtUserName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(346, 12);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 2;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(416, 15);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(260, 27);
            txtNombre.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(682, 12);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 4;
            label3.Text = "DNI";
            // 
            // txtdni
            // 
            txtdni.Location = new Point(723, 15);
            txtdni.MaxLength = 10;
            txtdni.Name = "txtdni";
            txtdni.Size = new Size(150, 27);
            txtdni.TabIndex = 5;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(879, 15);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(73, 24);
            chkActivo.TabIndex = 8;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(958, 12);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 6;
            label2.Text = "Rol";
            // 
            // cboRol
            // 
            cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRol.FormattingEnabled = true;
            cboRol.Location = new Point(995, 15);
            cboRol.Name = "cboRol";
            cboRol.Size = new Size(180, 28);
            cboRol.TabIndex = 7;
            // 
            // grpPassword
            // 
            grpPassword.Controls.Add(txtConfirm);
            grpPassword.Controls.Add(label6);
            grpPassword.Controls.Add(label5);
            grpPassword.Controls.Add(txtPassword);
            grpPassword.Controls.Add(label4);
            grpPassword.Location = new Point(3, 69);
            grpPassword.Name = "grpPassword";
            grpPassword.Size = new Size(1215, 151);
            grpPassword.TabIndex = 9;
            grpPassword.TabStop = false;
            grpPassword.Text = "Contraseña (Solo alta)";
            // 
            // txtConfirm
            // 
            txtConfirm.Location = new Point(104, 103);
            txtConfirm.Name = "txtConfirm";
            txtConfirm.Size = new Size(230, 27);
            txtConfirm.TabIndex = 4;
            txtConfirm.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 103);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 3;
            label6.Text = "Confirmar";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 50);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(115, 50);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(230, 27);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 50);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 1;
            label4.Text = "Contraseña:";
            // 
            // pnlAcciones
            // 
            pnlAcciones.Controls.Add(btnGuardar);
            pnlAcciones.Controls.Add(btnCancelar);
            pnlAcciones.Dock = DockStyle.Bottom;
            pnlAcciones.Location = new Point(0, 325);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Size = new Size(1237, 125);
            pnlAcciones.TabIndex = 10;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.Location = new Point(3, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(103, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmUsuarioEdit
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(1237, 450);
            Controls.Add(pnlAcciones);
            Controls.Add(pnlDatos);
            Controls.Add(grpPassword);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUsuarioEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Usuario";
            Load += frmUsuarioEdit_Load;
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            grpPassword.ResumeLayout(false);
            grpPassword.PerformLayout();
            pnlAcciones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel pnlDatos;
        private Label lblUsuario;
        private TextBox txtUserName;
        private Label label1;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtdni;
        private CheckBox chkActivo;
        private Label label2;
        private ComboBox cboRol;
        private GroupBox grpPassword;
        private Label label5;
        private TextBox txtPassword;
        private Label label4;
        private TextBox txtConfirm;
        private Label label6;
        private FlowLayoutPanel pnlAcciones;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}