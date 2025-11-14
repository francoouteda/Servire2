using Microsoft.Extensions.DependencyInjection;
using Servire.Bll;
using Servire.Bll.Interfaces;

namespace Servire.UI.Forms
{
    public partial class frmLogin : Form
    {
        private readonly IUsuarioService _usuarios;
        private readonly IErrorLogger _log;

        public frmLogin(IUsuarioService usuarios, IErrorLogger log)
        {
            InitializeComponent();
            _usuarios = usuarios;
            _log = log;
        }

        private void btnIngresar_Click(object? sender, EventArgs e)
        {
            try { 
                var u = _usuarios.Login(txtUsuario.Text.Trim().ToLower(), txtPassword.Text);

                Program.CurrentUser = u;

                var home = Program.Services.GetRequiredService<frmHome>();
                home.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                _log.Error(nameof(frmLogin), ex);
                MessageBox.Show(ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

    }
}