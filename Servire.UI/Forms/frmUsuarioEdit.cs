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
            // Esto es parte del problema de arquitectura, pero lo dejamos por ahora
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
                // CORRECCIÓN: Nombre 'chkActivo'
                chkActivo.Checked = true;
            }
            else
            {
                _esNuevo = false;
                this.Text = $"Editando a {_usuarioAEditar.Username}";

                // CORRECCIÓN: Nombres de todos los controles
                txtUserName.Text = _usuarioAEditar.Username;
                txtNombre.Text = _usuarioAEditar.Nombre;
                txtdni.Text = _usuarioAEditar.Dni;
                // txtMail no existe en el .designer, se omite la lógica de Email
                chkActivo.Checked = _usuarioAEditar.Habilitado;
                cboRol.SelectedItem = _usuarioAEditar.Rol; // 'cboRol'

                // Deshabilitamos contraseñas en modo Edición
                txtPassword.Enabled = false;
                txtConfirm.Enabled = false;
            }
        }

        private void CargarRoles()
        {
            // CORRECCIÓN: Nombre 'cboRol'
            cboRol.DataSource = Enum.GetValues(typeof(Rol));
        }

        // CORRECCIÓN: El evento se llama 'btnGuardar_Click' para coincidir con el botón
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarControles()) return;

                // CORRECCIÓN: Nombres de todos los controles
                _usuarioAEditar.Username = txtUserName.Text.Trim();
                _usuarioAEditar.Nombre = txtNombre.Text.Trim();
                _usuarioAEditar.Dni = txtdni.Text.Trim();
                // Lógica de Email omitida
                _usuarioAEditar.Habilitado = chkActivo.Checked;
                _usuarioAEditar.Rol = (Rol)cboRol.SelectedItem;

                if (_esNuevo)
                {
                    // CORRECCIÓN: Nombre 'txtPassword'
                    // El método SetPassword fue eliminado de tu entidad 'Usuario'
                    // Asumiré que quieres hashear y asignar
                    var hasher = new PasswordHasher(); // Otro 'new' que debería ser DI
                    _usuarioAEditar.PasswordHash = hasher.Hash(txtPassword.Text);

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
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtdni.Text))
            {
                MessageBox.Show("Username, Nombre y DNI son requeridos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_esNuevo)
            {
                // CORRECCIÓN: Nombres 'txtPassword' y 'txtConfirm'
                if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 8)
                {
                    MessageBox.Show("La contraseña es requerida (mín. 8 caracteres).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtPassword.Text != txtConfirm.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            Guid? idExcluir = _esNuevo ? null : (Guid?)_usuarioAEditar.IdUsuario;

            // CORRECCIÓN: Nombres 'txtUserName' y 'txtdni'
            if (_usuarioRepository.ExisteUsername(txtUserName.Text.Trim(), idExcluir))
            {
                MessageBox.Show("El nombre de usuario ya existe.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_usuarioRepository.ExisteDni(txtdni.Text.Trim(), idExcluir))
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
    }
}