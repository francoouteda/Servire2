using Servire.Services.Domain.Composite;
using Servire.Services.Implementations;
using Servire.UI.Forms; // Asegúrate que esto esté
using System;
using System.Windows.Forms;
// 1. Usings para la nueva capa 'Servire.Services'
using Servire.Services.Tools; // No parece usarse aquí, pero estaba en tu original

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
                // Esta lógica de login se moverá a Program.cs (ver sección 4)
                // Por ahora, asumimos que UsuarioLogueado ya fue asignado ANTES de mostrar frmHome
                if (this.UsuarioLogueado == null)
                {
                    MessageBox.Show("Error fatal: No se ha iniciado sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                this.Text = $"Servire - {UsuarioLogueado.Nombre} ({UsuarioLogueado.Rol})";

                // 6. Validación de permisos con el método 'TienePermiso'
                // CORRECCIÓN: Usamos los nombres de los MenuStrip
                menuUsuarios.Enabled = UsuarioLogueado.TienePermiso("Gestion_Usuarios");
                MenuStock.Enabled = UsuarioLogueado.TienePermiso("Gestion_Stock");
                menuBitacora.Enabled = UsuarioLogueado.TienePermiso("Acceso_Bitacora");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frmHome_Load", "Sistema");
                MessageBox.Show("Error fatal al iniciar la aplicación. Revise los logs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // --- CÓDIGO COMPLETO: Eventos de Menú ---
        // (Respetando los nombres de tu .Designer.cs)

        // CORRECCIÓN: Renombrado de 'btnUsuarios_Click' a 'menuUsuarios_Click'
        private void menuUsuarios_Click(object sender, EventArgs e) // Antes 'btnUsuarios_Click'
        {
            frmUsuarios frm = new frmUsuarios(UsuarioLogueado);
            frm.ShowDialog();
        }

        // CORRECCIÓN: Renombrado de 'btnBitacora_Click' a 'menuBitacora_Click'
        private void menuBitacora_Click(object sender, EventArgs e) // Antes 'btnBitacora_Click'
        {
            frmBitacora frm = new frmBitacora(UsuarioLogueado);
            frm.ShowDialog();
        }
        // CORRECCIÓN: Renombrado de 'btnStock_Click' a 'menuStock_Click'
        private void menuStock_Click(object sender, EventArgs e)
        {
            // Este formulario (frmStock) no existe en tu proyecto
            // Supongo que querías abrir 'ucStock' dentro del panel principal
            // Esto requiere más refactorización (DI y manejo de UserControls)
            // Por ahora, lo comento.
            // frmStock frm = new frmStock();
            // frm.ShowDialog();
            MessageBox.Show("Funcionalidad 'Stock' no implementada en frmHome.");
        }

        // NUEVO: Manejador para el menú Productos que existía en la UI
        private void menuProductos_Click(object sender, EventArgs e)
        {
            // Esta lógica también debería usar el panel principal 'pnlContenedorPrincipal'
            // en lugar de ShowDialog()
            MessageBox.Show("Funcionalidad 'Productos' no implementada en frmHome.");
        }

        // El evento 'menuSalir_Click' ya estaba correcto en tu .Designer
        private void menuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}