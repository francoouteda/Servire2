using Servire.Bll;
using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using System;
using System.Windows.Forms;

namespace Servire.UI.Forms
{
    public partial class frmUsuarioEdit : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IErrorLogger _log;
        private Usuario? _usuarioEditado; 
        public frmUsuarioEdit(IUsuarioService usuarioService, IErrorLogger log)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _log = log;
        }

        public void CargarUsuario(Usuario u)
        {
            _usuarioEditado = u;
        }

        private void frmUsuarioEdit_Load(object sender, EventArgs e)
        {
            CargarRoles();

            if (_usuarioEditado == null)
            {
                this.Text = "Nuevo Usuario";
                chkActivo.Checked = true;
                grpPassword.Enabled = true; 
                cboRol.SelectedIndex = -1; 
            }
            else
            {
                this.Text = "Editar Usuario";
                txtUserName.Text = _usuarioEditado.Username;
                txtNombre.Text = _usuarioEditado.Nombre;
                txtdni.Text = _usuarioEditado.Dni;

                cboRol.SelectedItem = _usuarioEditado.Rol;
              
                chkActivo.Checked = _usuarioEditado.Activo;

                grpPassword.Enabled = false;
                txtPassword.Text = "********";
                txtConfirm.Text = "********";
            }
        }

        private void CargarRoles()
        {
            cboRol.DataSource = Enum.GetValues(typeof(Rol));
           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario u;
                if (_usuarioEditado == null)
                {
                    u = new Usuario();
                }
                else
                {
                    u = _usuarioEditado; 
                }

                u.Username = txtUserName.Text.Trim();
                u.Nombre = txtNombre.Text.Trim();
                u.Dni = txtdni.Text.Trim();
                u.Activo = chkActivo.Checked;
                u.Rol = (Rol)cboRol.SelectedItem;


                if (_usuarioEditado == null)
                {
                    var pass = txtPassword.Text;
                    var confirm = txtConfirm.Text;
                    if (pass != confirm)
                        throw new Exception("Las contraseñas no coinciden.");

                    _usuarioService.Crear(u, pass);
                }
                else
                {
                    _usuarioService.Actualizar(u);
                }

                MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                _log.Error(nameof(frmUsuarioEdit), ex, Program.CurrentUser?.Username);
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
        }
    }
}