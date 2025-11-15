using Servire.Bll.Interfaces;
using Servire.Bll.Services;
using Servire.Domain.Entities;
using Servire.Services.Interfaces;

namespace Servire.UI.Forms
{
    public partial class frmProductoEdit : Form
    {
        private readonly IProductoService _productoService;
        private readonly IStockService _stockService; 
        private readonly ILogger _log;

        private Producto? _productoEditado; 
        private List<Ingrediente> _recetaActual;
        private List<Insumo> _insumosDisponibles; 

        public frmProductoEdit(IProductoService productoService, IStockService stockService, ILogger log)
        {
            InitializeComponent();
            _productoService = productoService;
            _stockService = stockService;
            _log = log;

            _recetaActual = new List<Ingrediente>();
            _insumosDisponibles = new List<Insumo>();
        }

        public void CargarProducto(Producto producto)
        {
            _productoEditado = producto;          
            _recetaActual = new List<Ingrediente>(producto.Ingredientes);
        }

        private void frmProductoEdit_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();
                ConfigurarGrillaReceta();
                CalcularCostoReceta();

                if (_productoEditado == null)
                {
                    this.Text = "Nuevo Producto Elaborado";
                }
                else
                {
                   
                    this.Text = $"Editar: {_productoEditado.Nombre}";
                    txtNombre.Text = _productoEditado.Nombre;
                    cboCategoria.Text = _productoEditado.Categoria;
                    numPrecioVenta.Value = _productoEditado.PrecioVenta;
                    numTiempoPreparacion.Value = _productoEditado.TiempoPreparacionMinutos ?? 0;
                }

                RefrescarGrillaReceta();
            }
            catch (Exception ex)
            {
                ManejarError("Error fatal al cargar", ex);
                this.Close();
            }
        }

        private void CargarCombos()
        {
            
            cboCategoria.DataSource = _productoService.GetCategoriasProductos();
            _insumosDisponibles = _stockService.GetInsumos();
            cboInsumos.DataSource = _insumosDisponibles;
            cboInsumos.DisplayMember = "Nombre";
            cboInsumos.ValueMember = "Id";
            cboInsumos.SelectedIndex = -1;
            lblUnidadInsumo.Text = "(Unidad)";
        }

        private void ConfigurarGrillaReceta()
        {
            dgvIngredientes.AutoGenerateColumns = false;
            dgvIngredientes.Columns.Clear();

            dgvIngredientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColInsumoNombre",
                HeaderText = "Insumo",
                DataPropertyName = "InsumoNombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvIngredientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColCantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad"
            });
            dgvIngredientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColUnidad",
                HeaderText = "Unidad",
                DataPropertyName = "InsumoUnidad"
            });
        }

        private void RefrescarGrillaReceta()
        {
            var dataSource = _recetaActual.Select(ing => new
            {
                IngredienteObj = ing,
                InsumoNombre = ing.Insumo?.Nombre ?? _insumosDisponibles.FirstOrDefault(i => i.Id == ing.InsumoId)?.Nombre ?? "??",
                ing.Cantidad,
                InsumoUnidad = ing.Insumo?.UnidadMedida ?? _insumosDisponibles.FirstOrDefault(i => i.Id == ing.InsumoId)?.UnidadMedida ?? "??"
            }).ToList();

            dgvIngredientes.DataSource = dataSource;

            
        }


        private void cboInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboInsumos.SelectedItem is Insumo insumo)
            {
                lblUnidadInsumo.Text = $"({insumo.UnidadMedida})";
            }
            else
            {
                lblUnidadInsumo.Text = "(Unidad)";
            }
        }
        private void CalcularCostoReceta()
        {
            decimal costoTotal = 0;

         
            foreach (var ingrediente in _recetaActual)
            {
               
                var insumo = _insumosDisponibles.FirstOrDefault(i => i.Id == ingrediente.InsumoId);

                if (insumo != null)
                {
                    costoTotal += (ingrediente.Cantidad * insumo.CostoUnitario);
                }
            }

         
            lblCostoTotal.Text = $"Costo Total: $ {costoTotal:F2}";

            decimal precioVenta = numPrecioVenta.Value;

            if (precioVenta > 0 && costoTotal > 0)
            {
                decimal margen = (precioVenta - costoTotal) / precioVenta;

                if (margen < 0.20m) 
                {
                    lblCostoTotal.ForeColor = System.Drawing.Color.Red;
                    numPrecioVenta.ForeColor = System.Drawing.Color.Red;
                    
                }
                else
                {
                    lblCostoTotal.ForeColor = System.Drawing.Color.Black;
                    numPrecioVenta.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                lblCostoTotal.ForeColor = System.Drawing.Color.Black;
                numPrecioVenta.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (cboInsumos.SelectedItem is Insumo insumoSeleccionado)
            {
                var cantidad = numCantidad.Value;
                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existente = _recetaActual.FirstOrDefault(i => i.InsumoId == insumoSeleccionado.Id);
                if (existente != null)
                {
                    existente.Cantidad = cantidad;
                }
                else
                {
                    _recetaActual.Add(new Ingrediente
                    {
                        InsumoId = insumoSeleccionado.Id,
                        Cantidad = cantidad,
                        Insumo = insumoSeleccionado 
                    });
                }
                RefrescarGrillaReceta();
                CalcularCostoReceta();
            }
            else
            {
                MessageBox.Show("Seleccione un insumo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvIngredientes.CurrentRow != null)
            {
                var filaSeleccionada = dgvIngredientes.CurrentRow.DataBoundItem;
                if (filaSeleccionada == null) return;

                var ingredienteReal = (Ingrediente)filaSeleccionada.GetType().GetProperty("IngredienteObj").GetValue(filaSeleccionada);

                _recetaActual.Remove(ingredienteReal);
                RefrescarGrillaReceta();
                CalcularCostoReceta();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto p = _productoEditado ?? new Producto();

                p.Nombre = txtNombre.Text.Trim();
                p.Categoria = cboCategoria.Text.Trim();
                p.PrecioVenta = numPrecioVenta.Value;
                p.TiempoPreparacionMinutos = (int)numTiempoPreparacion.Value > 0 ? (int)numTiempoPreparacion.Value : (int?)null;
                p.Ingredientes = _recetaActual;

                _productoService.GuardarProducto(p);

                MessageBox.Show("Producto y receta guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
            }
            catch (Exception ex)
            {
                ManejarError("Error al guardar el producto", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ManejarError(string titulo, Exception ex)
        {
            _log.Error(nameof(frmProductoEdit), ex, Program.CurrentUser?.Username);
            MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void numPrecioVenta_ValueChanged(object sender, EventArgs e)
        {
            CalcularCostoReceta();
        }
    }
}