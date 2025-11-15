using Servire.Services.Dal.Implementations;
using Servire.Services.Domain.Composite;
using Servire.Services.Implementations;
using Servire.Services.Tools;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Servire.UI.Forms
{
    public partial class frmUsuarioEdit : Form
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly LoggerService _logger;
        private readonly Usuario _usuarioLogueado;
        private Usuario _usuarioAEditar;
        private bool _esNuevo = false;

        public frmUsuarioEdit(Usuario usuarioAEditar, Usuario usuarioLogueado)
        {
            InitializeComponent();
            _usuarioAEditar = usuarioAEditar;
            _usuarioLogueado = usuarioLogueado;
            _usuarioRepository = new UsuarioRepository();
            _logger = new LoggerService();
        }

        private void frmUsuarioEdit_Load(object sender, EventArgs e)
        {
            CargarRoles();

            if (_usuarioAEditar == null)
            {
                _esNuevo = true;
                this.Text = "Nuevo Usuario";
                _usuarioAEditar = new Usuario();
                // CORRECCIÓN: Nombre 'chkHabilitado'
                chkHabilitado.Checked = true;
            }
            else
            {
                _esNuevo = false;
                this.Text = $"Editando a {_usuarioAEditar.Username}";

                // CORRECCIÓN: Nombres de todos los controles
                txtUsuario.Text = _usuarioAEditar.Username;
                txtNombreApellido.Text = _usuarioAEditar.Nombre;
                txtDocumento.Text = _usuarioAEditar.Dni;
                txtMail.Text = _usuarioAEditar.Email;
                chkHabilitado.Checked = _usuarioAEditar.Habilitado;
                cmbRoles.SelectedItem = _usuarioAEditar.Rol; // 'cmbRoles'

                // Deshabilitamos contraseñas en modo Edición
                txtPass.Enabled = false;
                txtPassConfirm.Enabled = false;
            }
        }

        private void CargarRoles()
        {
            // CORRECCIÓN: Nombre 'cmbRoles'
            cmbRoles.DataSource = Enum.GetValues(typeof(Rol));
        }

        // CORRECCIÓN: Tu botón se llama 'btnGuardar', no 'btnAceptar'
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarControles()) return;

                // CORRECCIÓN: Nombres de todos los controles
                _usuarioAEditar.Username = txtUsuario.Text.Trim();
                _usuarioAEditar.Nombre = txtNombreApellido.Text.Trim();
                _usuarioAEditar.Dni = txtDocumento.Text.Trim();
                _usuarioAEditar.Email = txtMail.Text.Trim();
                _usuarioAEditar.Habilitado = chkHabilitado.Checked;
                _usuarioAEditar.Rol = (Rol)cmbRoles.SelectedItem;

                if (_esNuevo)
                {
                    // CORRECCIÓN: Nombre 'txtPass'
                    _usuarioAEditar.SetPassword(txtPass.Text);
                    _usuarioRepository.RegistrarUsuario(_usuarioAEditar);
                    _logger.Info($"Usuario '{_usuarioAEditar.Username}' creado.", "frmUsuarioEdit", _usuarioLogueado.Username);
                }
                else
                {
                    _usuarioRepository.Actualizar(_usuarioAEditar);
                    _logger.Info($"Usuario '{_usuarioAEditar.Username}' modificado.", "frmUsuarioEdit", _usuarioLogueado.Username);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frmUsuarioEdit.btnGuardar_Click", _usuarioLogueado.Username);
                MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarControles()
        {
            // CORRECCIÓN: Nombres de controles
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtNombreApellido.Text) || string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Username, Nombre y DNI son requeridos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_esNuevo)
            {
                // CORRECCIÓN: Nombres 'txtPass' y 'txtPassConfirm'
                if (string.IsNullOrWhiteSpace(txtPass.Text) || txtPass.Text.Length < 8)
                {
                    MessageBox.Show("La contraseña es requerida (mín. 8 caracteres).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtPass.Text != txtPassConfirm.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            Guid? idExcluir = _esNuevo ? null : (Guid?)_usuarioAEditar.IdUsuario;

            // CORRECCIÓN: Nombres 'txtUsuario' y 'txtDocumento'
            if (_usuarioRepository.ExisteUsername(txtUsuario.Text.Trim(), idExcluir))
            {
                MessageBox.Show("El nombre de usuario ya existe.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_usuarioRepository.ExisteDni(txtDocumento.Text.Trim(), idExcluir))
            {
                MessageBox.Show("El DNI ya existe.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // -------------------------------------------------------------------
        // MÉTODOS QUE NO SE USAN (De tu código .cs original)
        // -------------------------------------------------------------------

        // ELIMINADO: private void cmbRol_DataSourceChanged(object sender, EventArgs e)
        // (La lógica ahora está en el Load)

        // Estos eventos estaban en tu .cs pero no en el .Designer, así que los omito:
        // private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        // private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
    }
}