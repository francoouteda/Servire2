using Servire.Services.Dal.Implementations; // USINGS NUEVOS
using Servire.Services.Domain.Composite;
using Servire.Services.Implementations;
using Servire.Services.Tools;
using System;
using System.Windows.Forms;

namespace Servire.UI.Forms
{
    public partial class frmLogin : Form
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly PasswordHasher _passwordHasher;
        private readonly LoggerService _loggerService;

        public frmLogin() // Constructor SIN DI
        {
            InitializeComponent();
            _usuarioRepository = new UsuarioRepository();
            _passwordHasher = new PasswordHasher();
            _loggerService = new LoggerService();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            const string origen = "frmLogin";
            string usernameIntentado = txtUsuario.Text;

            try
            {
                var usuario = _usuarioRepository.ObtenerPorUsername(usernameIntentado);

                if (usuario != null && usuario.Habilitado)
                {
                    if (_passwordHasher.Verify(txtPassword.Text, usuario.PasswordHash))
                    {
                        _loggerService.Info($"Inicio de sesión exitoso", origen, usuario.Username);
                        (this.Owner as frmHome).UsuarioLogueado = usuario;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        _loggerService.Info($"Intento de login fallido (pass incorrecta)", origen, usernameIntentado);
                        MessageBox.Show("Credenciales inválidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    _loggerService.Info($"Intento de login fallido (usuario no existe o inactivo)", origen, usernameIntentado);
                    MessageBox.Show("Credenciales inválidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _loggerService.Error(ex, origen, usernameIntentado);
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}