using Microsoft.Extensions.DependencyInjection;
using Servire.Bll.Interfaces;
using Servire.Bll.Services;
using Servire.Domain.Entities;
using System.Data;
using Servire.Services.Interfaces;
{
    
}

namespace Servire.UI.Forms
{
    public partial class ucStock : UserControl
    {
        public delegate void NavegacionRequeridaHandler(object sender, UserControl controlANavegar);

        public event NavegacionRequeridaHandler? OnNavegacionRequerida;
        private readonly IStockService _stockService;
        private readonly ILogger _log;
        private List<Insumo> _listaCompleta; 
        public ucStock(IStockService stockService, ILogger log)
        {
            InitializeComponent();

            dgvInsumos.AutoGenerateColumns = false;
            _stockService = stockService;
            _log = log;
            _listaCompleta = new List<Insumo>();
        }
        private void ucStock_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                _stockService.GetUoW().Commit();
                _listaCompleta = _stockService.GetInsumos();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                ManejarError("Error al cargar insumos", ex);
            }
        }
        private void AplicarFiltros()
        {
            try
            {
                var filtroTexto = txtBuscar.Text.Trim().ToLower();
                bool soloCriticos = chkStockCritico.Checked;

                var filtrados = _listaCompleta.AsEnumerable();

                if (!string.IsNullOrEmpty(filtroTexto))
                {
                    filtrados = filtrados.Where(i => i.Nombre.ToLower().Contains(filtroTexto) ||
                                                     (i.Proveedor != null && i.Proveedor.Nombre.ToLower().Contains(filtroTexto)));
                }
                if (soloCriticos)
                {
                    filtrados = filtrados.Where(i => i.StockActual <= i.StockMinimo && i.StockMinimo > 0);
                }

                dgvInsumos.DataSource = filtrados.ToList();
                lblTotal.Text = $"Total: {filtrados.Count()}";
            }
            catch (Exception ex)
            {
                ManejarError("Error al aplicar filtros", ex);
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void chkStockCritico_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void dgvInsumos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColProveedor.Index && e.RowIndex >= 0)
            {
                var insumo = dgvInsumos.Rows[e.RowIndex].DataBoundItem as Insumo;

                if (insumo?.Proveedor != null)
                {
                    e.Value = insumo.Proveedor.Nombre;
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = "N/A";
                    e.FormattingApplied = true;
                }
            }
        }

        private Insumo? ObtenerInsumoSeleccionado()
        {
            if (dgvInsumos.CurrentRow != null && dgvInsumos.CurrentRow.DataBoundItem is Insumo insumo)
            {
                return insumo;
            }
            MessageBox.Show("Seleccione un insumo de la grilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        private void btnNuevoInsumo_Click(object sender, EventArgs e)
        {
            using (var f = Program.Services.GetRequiredService<frmInsumoEdit>())
            {
                f.Text = "Nuevo Insumo";
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    CargarGrilla(); 
                }
            }
        }

        private void btnEditarInsumo_Click(object sender, EventArgs e)
        {
            var insumo = ObtenerInsumoSeleccionado();
            if (insumo == null) return;

            var insumoFull = _stockService.GetInsumo(insumo.Id);

            using (var f = Program.Services.GetRequiredService<frmInsumoEdit>())
            {
                f.Text = "Editar Insumo";
                f.CargarInsumo(insumoFull);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    CargarGrilla(); 
                }
            }
        }

        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            
            var insumo = ObtenerInsumoSeleccionado();
            if (insumo == null) return;

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Ingrese la cantidad de '{insumo.Nombre}' ({insumo.UnidadMedida}) que ingresa:",
                "Registrar Entrada de Stock",
                "0");

            if (decimal.TryParse(input, out decimal cantidad) && cantidad > 0)
            {
                try
                {
                    var usuarioId = Program.CurrentUser?.Id ?? 0; 
                    if (usuarioId == 0) throw new Exception("No se pudo identificar al usuario logueado.");

                    _stockService.RegistrarEntrada(insumo.Id, cantidad, usuarioId);
                    MessageBox.Show("Entrada registrada. Stock actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla(); 
                }
                catch (Exception ex)
                {
                    ManejarError("Error al registrar entrada", ex);
                }
            }
            else if (!string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Cantidad inválida. Debe ingresar un número mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGestionarProveedores_Click(object sender, EventArgs e)
        {
            var ucProveedores = Program.Services.GetRequiredService<ucProveedores>();

            OnNavegacionRequerida?.Invoke(this, ucProveedores);
        }
        private void ManejarError(string titulo, Exception ex)
        {
            _log.Error(nameof(ucStock), ex, Program.CurrentUser?.Username);
            MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}