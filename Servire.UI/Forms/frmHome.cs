using Microsoft.Extensions.DependencyInjection;

namespace Servire.UI.Forms
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();

        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            var u = Program.CurrentUser;
            lblSesion.Text = (u == null)
                ? "Sesión: -"
                : $"Sesión: {u.Username} ({u.Rol})";


            
            menuAdmin.Visible = u?.Puede("Acceso_Admin") ?? false;
            menuUsuarios.Visible = u?.Puede("Gestion_Usuarios") ?? false;
            menuBitacora.Visible = u?.Puede("Acceso_Bitacora") ?? false;

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
