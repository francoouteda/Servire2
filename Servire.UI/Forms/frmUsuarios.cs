using Servire.Services.Dal.Interfaces; // 1. USAR INTERFACES
using Servire.Services.Domain.Composite;
using Servire.Services.Interfaces; // 2. USAR INTERFACES
using System;
using System.Collections.Generic; // Para List<T>
using System.Drawing;
using System.Linq; // Para filtrado
using System.Windows.Forms;

namespace Servire.UI.Forms
{
    public partial class frmUsuarios : Form
    {
        // --- 3. Dependencias Inyectadas ---
        private readonly Usuario _usuarioLogueado;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger _logger;

        // 4. Lista para manejar filtros
        private List<Usuario> _listaCompletaUsuarios;

        // --- 5. Constructor actualizado con DI ---
        public frmUsuarios(Usuario usuarioLogueado, IUsuarioRepository usuarioRepository, ILogger logger)
        {
            InitializeComponent();
            _usuarioLogueado = usuarioLogueado;
            _usuarioRepository = usuarioRepository;
            _logger = logger;
            _listaCompletaUsuarios = new List<Usuario>(); // Inicializar
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            // 6. Cargar roles para el filtro
            cboRolFiltro.Items.Add("(Todos)");
            cboRolFiltro.Items.AddRange(Enum.GetValues(typeof(Rol)).Cast<object>().ToArray());
            cboRolFiltro.SelectedIndex = 0;

            RefrescarGrilla();
        }

        private void RefrescarGrilla()
        {
            try
            {
                // Obtenemos todos los usuarios una vez
                _listaCompletaUsuarios = _usuarioRepository.Listar().ToList();
                // Aplicamos filtros locales
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frmUsuarios.RefrescarGrilla", _usuarioLogueado.Username);
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 7. Implementación de los filtros (estaban faltando) ---
        private void AplicarFiltros()
        {
            var filtroTexto = txtBuscar.Text.Trim().ToLower();
            var filtroRol = cboRolFiltro.SelectedItem;

            var filtrados = _listaCompletaUsuarios.AsEnumerable();

            if (!string.IsNullOrEmpty(filtroTexto))
            {
                filtrados = filtrados.Where(u => u.Username.ToLower().Contains(filtroTexto) ||
                                                 u.Nombre.ToLower().Contains(filtroTexto) ||
                                                 u.Dni.Contains(filtroTexto));
            }

            if (filtroRol is Rol rol) // Si se seleccionó un Rol específico
            {
                filtrados = filtrados.Where(u => u.Rol == rol);
            }

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = filtrados.ToList();
            lblTotal.Text = $"Total: {filtrados.Count()}";
        }

        // --- 8. Eventos de UI corregidos ---

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cboRolFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        // --- 9. Nombres de botones corregidos ---

        // Corregido de 'btnBaja_Click'
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            ToggleUsuario(false);
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            ToggleUsuario(true);
        }

        private void ToggleUsuario(bool habilitar)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;
            var usuarioSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;
            if (usuarioSeleccionado.IdUsuario == _usuarioLogueado.IdUsuario)
            {
                MessageBox.Show("No puede desactivarse a sí mismo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string accionLog = habilitar ? "Activación" : "Desactivación";
            if (MessageBox.Show($"¿Desea {accionLog.ToLower()} a este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    usuarioSeleccionado.Habilitado = habilitar;
                    _usuarioRepository.Actualizar(usuarioSeleccionado);
                    _logger.Info($"Usuario {usuarioSeleccionado.Username} {accionLog}", "frmUsuarios", _usuarioLogueado.Username);
                    RefrescarGrilla(); // Vuelve a cargar y aplicar filtros
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "frmUsuarios.ToggleUsuario", _usuarioLogueado.Username);
                    MessageBox.Show($"Error al {accionLog.ToLower()} el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Corregido de 'btnAlta_Click'
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Ahora debemos resolver 'frmUsuarioEdit' desde el ServiceProvider
            // ya que 'frmUsuarioEdit' también debería usar DI.
            // Esta es una "solución temporal"
            var frm = new frmUsuarioEdit(null, _usuarioLogueado);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                RefrescarGrilla();
            }
        }

        // Corregido de 'btnModificar_Click'
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;
            var usuarioSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;

            var frm = new frmUsuarioEdit(usuarioSeleccionado, _usuarioLogueado);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                RefrescarGrilla();
            }
        }

        // --- 10. Eventos de formato (ya estaban bien) ---
        private void dgvUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvUsuarios.DataSource == null) return;
            dgvUsuarios.Columns[nameof(Usuario.IdUsuario)].Visible = false;
            dgvUsuarios.Columns[nameof(Usuario.PasswordHash)].Visible = false;
            dgvUsuarios.Columns[nameof(Usuario.Privilegios)].Visible = false;
            dgvUsuarios.Columns[nameof(Usuario.Patentes)].Visible = false;
            dgvUsuarios.Columns[nameof(Usuario.Habilitado)].HeaderText = "Activo";
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == nameof(Usuario.Habilitado))
            {
                if (e.Value != null && (bool)e.Value)
                {
                    e.Value = "Sí";
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
                else
                {
                    e.Value = "No";
                    e.CellStyle.ForeColor = Color.DarkRed;
                }
                e.FormattingApplied = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}