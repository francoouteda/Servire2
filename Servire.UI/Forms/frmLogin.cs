using Servire.Services.Dal.Interfaces; // USAR INTERFAZ
using Servire.Services.Domain.Composite;
using Servire.Services.Interfaces; // USAR INTERFAZ
using Servire.Bll.Interfaces; // Para IPasswordHasher
using System;
using System.Windows.Forms;

namespace Servire.UI.Forms
{
    public partial class frmLogin : Form
    {
        // Dependencias Inyectadas
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger _loggerService;

        // Propiedad pública para que Program.cs recoja el resultado
        public Usuario UsuarioLogueado { get; private set; }

        // CORRECCIÓN: Constructor con Inyección de Dependencias
        public frmLogin(IUsuarioRepository usuarioRepository, IPasswordHasher passwordHasher, ILogger loggerService)
        {
            InitializeComponent();
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
            _loggerService = loggerService;
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
                // Usamos la dependencia inyectada
                var usuario = _usuarioRepository.ObtenerPorUsername(usernameIntentado);

                if (usuario != null && usuario.Habilitado)
                {
                    // Usamos la dependencia inyectada
                    if (_passwordHasher.Verify(txtPassword.Text, usuario.PasswordHash))
                    {
                        _loggerService.Info($"Inicio de sesión exitoso", origen, usuario.Username);

                        // Asignamos el usuario a la propiedad pública
                        this.UsuarioLogueado = usuario;

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

        // Eventos vacíos que estaban en tu designer, los dejamos
        private void txtUsuario_TextChanged(object sender, EventArgs e) { }
        private void frmLogin_Load(object sender, EventArgs e) { }
    }
}