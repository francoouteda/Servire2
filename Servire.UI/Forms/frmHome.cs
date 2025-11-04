using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Servire.Domain.Entities;

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


            menuAdmin.Visible = (u?.Rol == Rol.Admin);
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            using var f = Program.Services.GetRequiredService<frmUsuarios>();
            f.ShowDialog(this);
        }

        private void menuBitacora_Click(object sender, EventArgs e)
        {
            using var f = Program.Services.GetRequiredService<frmBitacora>();
            f.ShowDialog(this);
        }

        private void menuUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
