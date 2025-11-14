using Microsoft.Extensions.DependencyInjection;
using Servire.Bll;
using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using System.Data;

namespace Servire.UI.Forms
{
    public partial class frmUsuarios : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IErrorLogger _log;
        private List<Usuario> _listaCompleta; 

        
        public frmUsuarios(IUsuarioService usuarioService, IErrorLogger log)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _log = log;
            _listaCompleta = new List<Usuario>();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarComboRoles();
            CargarGrilla();
        }

        private void CargarComboRoles()
        {
            var roles = new Dictionary<Rol, string>
            {
                { (Rol)0, "(Todos)" }
            };
            foreach (Rol r in Enum.GetValues(typeof(Rol)))
            {
                roles.Add(r, r.ToString());
            }
            cboRolFiltro.DataSource = new BindingSource(roles, null);
            cboRolFiltro.DisplayMember = "Value";
            cboRolFiltro.ValueMember = "Key";
            cboRolFiltro.SelectedIndex = 0;
        }

        private void CargarGrilla()
        {
            try
            {
                _listaCompleta = _usuarioService.Listar().ToList();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                ManejarError("Error al cargar usuarios", ex);
            }
        }

        private void AplicarFiltros()
        {
            var filtroTexto = txtBuscar.Text.Trim().ToLower();

            Rol filtroRol;
            if (cboRolFiltro.SelectedValue == null)
            {
                return;
            }

            if (cboRolFiltro.SelectedValue is KeyValuePair<Rol, string> pair)
            {
                filtroRol = pair.Key;
            }
            else
            {
                filtroRol = (Rol)cboRolFiltro.SelectedValue;
            }

            var filtrados = _listaCompleta.AsEnumerable();

            if (!string.IsNullOrEmpty(filtroTexto))
            {
                filtrados = filtrados.Where(u => u.Username.ToLower().Contains(filtroTexto) ||
                                                 u.Nombre.ToLower().Contains(filtroTexto) ||
                                                 u.Dni.Contains(filtroTexto));
            }

            if (filtroRol != 0) 
            {
                filtrados = filtrados.Where(u => u.Rol == filtroRol);
            }

            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.DataSource = filtrados.ToList();
            lblTotal.Text = $"Total: {filtrados.Count()}";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cboRolFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private int? ObtenerIdSeleccionado()
        {
            if (dgvUsuarios.CurrentRow != null && dgvUsuarios.CurrentRow.DataBoundItem is Usuario u)
            {
                return u.Id;
            }
            MessageBox.Show("Seleccione un usuario de la grilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var f = Program.Services.GetRequiredService<frmUsuarioEdit>())
            {
                f.Text = "Nuevo Usuario";
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    CargarGrilla(); 
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var id = ObtenerIdSeleccionado();
            if (id == null) return;

            var usuario = _usuarioService.ObtenerPorId(id.Value);
            if (usuario == null)
            {
                ManejarError("Usuario no encontrado", new Exception($"ID {id} no hallado."));
                CargarGrilla();
                return;
            }

            using (var f = Program.Services.GetRequiredService<frmUsuarioEdit>())
            {
                f.Text = "Editar Usuario";
                f.CargarUsuario(usuario); 
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    CargarGrilla(); 
                }
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            ToggleActivo(true);
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            ToggleActivo(false);
        }

        private void ToggleActivo(bool activar)
        {
            var id = ObtenerIdSeleccionado();
            if (id == null) return;

            if (id == Program.CurrentUser?.Id)
            {
                MessageBox.Show("No puede modificar su propio estado de activación.", "Acción denegada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var accion = activar ? "Activar" : "Desactivar";
            var confirm = MessageBox.Show($"¿Está seguro que desea {accion} al usuario seleccionado?", accion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _usuarioService.ToggleActivo(id.Value, activar);
                CargarGrilla();
            }
            catch (Exception ex)
            {
                ManejarError($"Error al {accion} usuario", ex);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            var id = ObtenerIdSeleccionado();
            if (id == null) return;

            string nuevoPassword = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la nueva contraseña temporal:", "Reiniciar Contraseña", "");
            if (string.IsNullOrWhiteSpace(nuevoPassword))
            {
                MessageBox.Show("La contraseña no puede estar vacía.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _usuarioService.CambiarPassword(id.Value, nuevoPassword);
                MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ManejarError("Error al reiniciar la contraseña", ex);
            }
        }

        private void ManejarError(string titulo, Exception ex)
        {
            _log.Error(nameof(frmUsuarios), ex, Program.CurrentUser?.Username);
            MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}