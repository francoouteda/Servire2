// 1. Usings para la nueva capa 'Servire.Services'
using Servire.Services.Domain.Composite;
using Servire.Services.Implementations;
using Servire.Services.Tools;
using Servire.UI.Forms;
using System;
using System.Windows.Forms;

namespace Servire.UI.Forms
{
    public partial class frmHome : Form
    {
        // 2. La propiedad con la NUEVA entidad Usuario
        public Usuario UsuarioLogueado { get; set; }

        // 3. Instanciamos el Logger
        private readonly LoggerService _logger;

        // 4. Constructor sin Inyección de Dependencias
        public frmHome()
        {
            InitializeComponent();
            _logger = new LoggerService();
        }

        // 5. frmHome_Load refactorizado
        private void frmHome_Load(object sender, EventArgs e)
        {
            try
            {
                // Instanciamos el Login sin pasarle nada
                frmLogin loginForm = new frmLogin();
                loginForm.ShowDialog(this); // 'this' es el Owner

                if (this.UsuarioLogueado == null)
                {
                    Application.Exit();
                    return;
                }

                this.Text = $"Servire - {UsuarioLogueado.Nombre} ({UsuarioLogueado.Rol})";

                // 6. Validación de permisos con el método 'TienePermiso'
                // (Los nombres de botones SÍ existen en tu .Designer.cs)
                btnUsuarios.Enabled = UsuarioLogueado.TienePermiso("Gestion_Usuarios");
                btnStock.Enabled = UsuarioLogueado.TienePermiso("Gestion_Stock");
                btnComandas.Enabled = UsuarioLogueado.TienePermiso("Ver_Comandas");
                btnBitacora.Enabled = UsuarioLogueado.TienePermiso("Acceso_Bitacora");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frmHome_Load", "Sistema");
                MessageBox.Show("Error fatal al iniciar la aplicación. Revise los logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // --- CÓDIGO COMPLETO: Eventos de Botón ---
        // (Respetando los nombres de tu .Designer.cs)

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // Pasamos el usuario logueado para auditoría y permisos
            frmUsuarios frm = new frmUsuarios(UsuarioLogueado);
            frm.ShowDialog();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            // Pasamos el usuario logueado
            frmBitacora frm = new frmBitacora(UsuarioLogueado);
            frm.ShowDialog();
        }

        private void btnComandas_Click(object sender, EventArgs e)
        {
            frmComandas frm = new frmComandas();
            frm.ShowDialog();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            frmStock frm = new frmStock();
            frm.ShowDialog();
        }
    }
}