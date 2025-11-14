using Microsoft.Extensions.DependencyInjection;
using Servire.Bll.Interfaces;
using Servire.Bll.Services;
using Servire.Domain.Entities;

namespace Servire.UI.Forms
{
    public partial class ucProveedores : UserControl
    {
        private readonly IStockService _stockService;
        private readonly IErrorLogger _log;
        private List<Proveedor> _listaCompleta;

        public delegate void NavegacionRequeridaHandler(object sender, UserControl controlANavegar);
        public event NavegacionRequeridaHandler? OnNavegacionRequerida;

        public ucProveedores(IStockService stockService, IErrorLogger log)
        {
            InitializeComponent();

            dgvProveedores.AutoGenerateColumns = false;

            _stockService = stockService;
            _log = log;
            _listaCompleta = new List<Proveedor>();
        }

        private void ucProveedores_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                _stockService.GetUoW().Commit();

                
                bool incluirInactivos = chkMostrarInactivos.Checked;
                _listaCompleta = _stockService.GetProveedores(incluirInactivos);
               
                AplicarFiltros();

                btnToggleActivo.Enabled = _listaCompleta.Any();
            }
            catch (Exception ex)
            {
                ManejarError("Error al cargar proveedores", ex);
            }
        }

        private void AplicarFiltros()
        {
            var filtroTexto = txtBuscar.Text.Trim().ToLower();
            var filtrados = _listaCompleta.AsEnumerable();

            if (!string.IsNullOrEmpty(filtroTexto))
            {
                filtrados = filtrados.Where(p => p.Nombre.ToLower().Contains(filtroTexto) ||
                                                 p.Categoria.ToLower().Contains(filtroTexto) ||
                                                 p.Contacto.ToLower().Contains(filtroTexto));
            }

            dgvProveedores.DataSource = filtrados.ToList();
            lblTotal.Text = $"Total: {filtrados.Count()}";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private Proveedor? ObtenerProveedorSeleccionado()
        {
            if (dgvProveedores.CurrentRow != null && dgvProveedores.CurrentRow.DataBoundItem is Proveedor p)
            {
                return p;
            }
            MessageBox.Show("Seleccione un proveedor de la grilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var f = Program.Services.GetRequiredService<frmProveedorEdit>())
            {
                f.Text = "Nuevo Proveedor";
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    CargarGrilla(); 
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var p = ObtenerProveedorSeleccionado();
            if (p == null) return;

            using (var f = Program.Services.GetRequiredService<frmProveedorEdit>())
            {
                f.Text = "Editar Proveedor";
                f.CargarProveedor(p); 
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    CargarGrilla(); 
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            var ucStock = Program.Services.GetRequiredService<ucStock>();

            OnNavegacionRequerida?.Invoke(this, ucStock);
        }

        private void ManejarError(string titulo, Exception ex)
        {
            _log.Error(nameof(ucProveedores), ex, Program.CurrentUser?.Username);
            MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvProveedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void btnToggleActivo_Click(object sender, EventArgs e)
        {
            var p = ObtenerProveedorSeleccionado();
            if (p == null) return;

            bool nuevoEstado = !p.Activo; 
            string accion = nuevoEstado ? "ACTIVAR" : "DESACTIVAR";

            var confirm = MessageBox.Show(
                $"¿Está seguro que desea {accion} al proveedor '{p.Nombre}'?",
                $"Confirmar {accion}",
                MessageBoxButtons.YesNo,
                (nuevoEstado) ? MessageBoxIcon.Question : MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _stockService.SetActivoProveedor(p.Id, nuevoEstado);

            }
            catch (Exception ex)
            {
                ManejarError($"Error al {accion}", ex);
            }
        }
        

        private void chkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}