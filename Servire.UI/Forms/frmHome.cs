using Servire.UI.Forms;
using System;
using System.Windows.Forms;

// 1. Apuntamos a los NUEVOS namespaces
using Servire.Services.Dal.Implementations;
using Servire.Services.Domain.Composite;
using Servire.Services.Tools;

namespace Servire.UI.Forms
{
    public partial class frmHome : Form
    {
        // 2. Definimos la propiedad con la NUEVA entidad Usuario
        public Usuario UsuarioLogueado { get; set; }

        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            // 3. Ya no pasamos dependencias viejas al Login
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog(this); // 'this' es el Owner

            if (this.UsuarioLogueado == null) // Si no se logueó
            {
                Application.Exit();
                return;
            }

            // 4. Usamos la data del NUEVO usuario
            this.Text = $"Servire - {UsuarioLogueado.Nombre} ({UsuarioLogueado.Rol})";

            // 5. Validamos permisos usando la nueva lógica de Patentes
            //    (Asumiendo que tienes strings de permiso definidos)
            btnUsuarios.Enabled = UsuarioLogueado.TienePermiso("Gestion_Usuarios");
            btnStock.Enabled = UsuarioLogueado.TienePermiso("Gestion_Stock");
            btnComandas.Enabled = UsuarioLogueado.TienePermiso("Ver_Comandas");
            btnBitacora.Enabled = UsuarioLogueado.TienePermiso("Acceso_Bitacora");
        }

        private void AbrirControlEnPanel(Control controlAMostrar)
        {
           
            pnlContenedorPrincipal.Controls.Clear();

            controlAMostrar.Dock = DockStyle.Fill;

            pnlContenedorPrincipal.Controls.Add(controlAMostrar);
        }
        private void menuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            //AbrirFormulario<frmUsuarios>();
        }

        private void menuBitacora_Click(object sender, EventArgs e)
        {
            using var f = Program.Services.GetRequiredService<frmBitacora>();
            f.ShowDialog(this);
        }

        private void menuStock_Click(object sender, EventArgs e)
        {
            if (Program.CurrentUser?.Puede("Gestion_Stock") == false)
            {
                MessageBox.Show("No tiene permisos para acceder a este módulo.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var uc = Program.Services.GetRequiredService<ucStock>();
            uc.OnNavegacionRequerida += Uc_OnNavegacionRequerida;
            AbrirControlEnPanel(uc);
        }
        
        private void Uc_OnNavegacionRequerida(object sender, UserControl controlANavegar)
        {
            if (controlANavegar is ucStock ucStock)
            {
                ucStock.OnNavegacionRequerida += Uc_OnNavegacionRequerida;
            }

            if (controlANavegar is ucProveedores ucProveedores)
            {
                
                ucProveedores.OnNavegacionRequerida += Uc_OnNavegacionRequerida;
            }

            
            AbrirControlEnPanel(controlANavegar);

        }
        private void menuUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var f = Program.Services.GetRequiredService<frmUsuarios>();
            f.ShowDialog(this);
        }

        private void menuProductos_Click(object sender, EventArgs e)
        {
            var uc = Program.Services.GetRequiredService<ucProductos>();

            AbrirControlEnPanel(uc);

        }
    }
}
