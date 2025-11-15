using Microsoft.Extensions.DependencyInjection;
using Servire.Bll.Interfaces;
using Servire.Bll.Services;
using Servire.Domain.Entities;
using Servire.Services.Interfaces;
namespace Servire.UI.Forms
{
    public partial class ucProductos : UserControl
    {
        private readonly IProductoService _productoService;
        private readonly ILogger _log;
        private List<Producto> _listaCompleta;

        public ucProductos(IProductoService productoService, ILogger log)
        {
            InitializeComponent();

            dgvProductos.AutoGenerateColumns = false;

            _productoService = productoService;
            _log = log;
            _listaCompleta = new List<Producto>();
        }

        private void ucProductos_Load(object sender, EventArgs e)
        {
            CargarFiltros();
            CargarGrilla();
        }

        private void CargarFiltros()
        {
            try
            {
                var categorias = _productoService.GetCategoriasProductos();

                var ds = new Dictionary<string, string> { { "", "(Todas)" } };
                foreach (var cat in categorias)
                {
                    ds.Add(cat, cat);
                }
                cboCategoriaFiltro.DataSource = new BindingSource(ds, null);
                cboCategoriaFiltro.DisplayMember = "Value";
                cboCategoriaFiltro.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                ManejarError("Error al cargar filtros", ex);
            }
        }

        private void CargarGrilla()
        {
            try
            {
                _productoService.GetUoW().Commit();

                bool incluirInactivos = chkMostrarInactivos.Checked;
                _listaCompleta = _productoService.GetProductos(incluirInactivos);

                AplicarFiltros();

                btnEditar.Enabled = _listaCompleta.Any();
                btnToggleActivo.Enabled = _listaCompleta.Any();
            }
            catch (Exception ex)
            {
                ManejarError("Error al cargar productos", ex);
            }
        }

        private void AplicarFiltros()
        {
            var filtroTexto = txtBuscar.Text.Trim().ToLower();
            var filtroCat = cboCategoriaFiltro.SelectedValue?.ToString() ?? "";

            var filtrados = _listaCompleta.AsEnumerable();

            if (!string.IsNullOrEmpty(filtroTexto))
            {
                filtrados = filtrados.Where(p => p.Nombre.ToLower().Contains(filtroTexto));
            }

            if (!string.IsNullOrEmpty(filtroCat))
            {
                filtrados = filtrados.Where(p => p.Categoria.Equals(filtroCat, StringComparison.OrdinalIgnoreCase));
            }

            dgvProductos.DataSource = filtrados.ToList();
            lblTotal.Text = $"Total: {filtrados.Count()}";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cboCategoriaFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private Producto? ObtenerProductoSeleccionado()
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.DataBoundItem is Producto p)
            {
                return p;
            }
            MessageBox.Show("Seleccione un producto de la grilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var f = Program.Services.GetRequiredService<frmProductoEdit>())
            {
                f.Text = "Nuevo Producto Elaborado";
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    CargarGrilla(); 
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var p = ObtenerProductoSeleccionado();
            if (p == null) return;

            try
            {
                var productoCompleto = _productoService.GetProducto(p.Id);

                using (var f = Program.Services.GetRequiredService<frmProductoEdit>())
                {
                    f.Text = $"Editar: {productoCompleto.Nombre}";
                    f.CargarProducto(productoCompleto); 
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarGrilla(); 
                    }
                }
            }
            catch (Exception ex)
            {
                ManejarError("Error al abrir el editor", ex);
            }
        }

        private void btnToggleActivo_Click(object sender, EventArgs e)
        {
            var p = ObtenerProductoSeleccionado();
            if (p == null) return;

            bool nuevoEstado = !p.Activo;
            string accion = nuevoEstado ? "ACTIVAR" : "DESACTIVAR";
            string msg = nuevoEstado ? "El producto volverá a estar visible en la carta." : "El producto se ocultará de la carta.";

            var confirm = MessageBox.Show(
                $"¿Está seguro que desea {accion} el producto '{p.Nombre}'?\n\n{msg}",
                $"Confirmar {accion}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _productoService.SetActivoProducto(p.Id, nuevoEstado);
                CargarGrilla(); 
            }
            catch (Exception ex)
            {
                ManejarError($"Error al {accion}", ex);
            }
        }

        private void ManejarError(string titulo, Exception ex)
        {
            _log.Error(nameof(ucProductos), ex, Program.CurrentUser?.Username);
            MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}