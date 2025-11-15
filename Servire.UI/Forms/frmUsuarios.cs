using Servire.Services.Dal.Implementations; // USINGS NUEVOS
using Servire.Services.Domain.Composite;
using Servire.Services.Implementations;
using Servire.Services.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Servire.UI.Forms
{
    public partial class frmUsuarios : Form
    {
        private readonly Usuario _usuarioLogueado;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly LoggerService _logger;

        public frmUsuarios(Usuario usuarioLogueado) // Constructor NUEVO
        {
            InitializeComponent();
            _usuarioLogueado = usuarioLogueado;
            _usuarioRepository = new UsuarioRepository();
            _logger = new LoggerService();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            RefrescarGrilla();
        }

        private void RefrescarGrilla()
        {
            try
            {
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = _usuarioRepository.Listar();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frmUsuarios.RefrescarGrilla", _usuarioLogueado.Username);
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void btnBaja_Click(object sender, EventArgs e)
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
                    RefrescarGrilla();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "frmUsuarios.ToggleUsuario", _usuarioLogueado.Username);
                    MessageBox.Show($"Error al {accionLog.ToLower()} el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            frmUsuarioEdit frm = new frmUsuarioEdit(null, _usuarioLogueado);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                RefrescarGrilla();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;
            var usuarioSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;
            frmUsuarioEdit frm = new frmUsuarioEdit(usuarioSeleccionado, _usuarioLogueado);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                RefrescarGrilla();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}