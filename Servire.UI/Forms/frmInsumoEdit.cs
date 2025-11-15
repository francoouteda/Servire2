using Servire.Bll.Interfaces;
using Servire.Bll.Services;
using Servire.Domain.Entities;
using Servire.Services.Interfaces;

namespace Servire.UI.Forms
{
    public partial class frmInsumoEdit : Form
    {
        private readonly IStockService _stockService;
        private readonly ILogger _log; 
        private Insumo? _insumoEditado;


        public frmInsumoEdit(IStockService stockService, ILogger log) // <- Corrección aquí
        {
            InitializeComponent();
            _stockService = stockService;
            _log = log;
        }
        public void CargarInsumo(Insumo insumo)
        {
            _insumoEditado = insumo;
        }

        private void frmInsumoEdit_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();

                if (_insumoEditado == null)
                {
                    this.Text = "Nuevo Insumo";
                    numStockActual.Enabled = true;
                    cboProveedor.SelectedIndex = 0;
                    cboUnidadMedida.SelectedIndex = -1;
                    cboCategoria.Text = "";
                    chkEsVendible.Checked = false;
                    numPrecioVenta.Value = 0;
                    numPrecioVenta.Enabled = false; 
                    numCostoUnitario.Value = 0;


                }
                else
                {
                    this.Text = "Editar Insumo";
                    txtNombre.Text = _insumoEditado.Nombre;
                    cboCategoria.Text = _insumoEditado.Categoria;
                    cboUnidadMedida.SelectedItem = _insumoEditado.UnidadMedida;
                    cboProveedor.SelectedValue = _insumoEditado.ProveedorId;
                    numStockMinimo.Value = _insumoEditado.StockMinimo;
                    numStockActual.Value = _insumoEditado.StockActual;
                    numStockActual.Enabled = false;
                    numCostoUnitario.Value = _insumoEditado.CostoUnitario;
                    chkEsVendible.Checked = _insumoEditado.EsVendible;
                    numPrecioVenta.Value = _insumoEditado.PrecioVenta;
                    numPrecioVenta.Enabled = _insumoEditado.EsVendible;
                }
            }
            catch (Exception ex)
            {
                ManejarError("Error fatal al cargar el formulario", ex);
                this.Close();
            }
        }

        private void CargarCombos()
        {

            _stockService.GetUoW().Commit();
            cboUnidadMedida.Items.Clear();
            cboUnidadMedida.Items.AddRange(new object[] { "Kg", "Gr", "Lt", "Ml", "Un." });

            var proveedores = _stockService.GetProveedores();
            var listaConNinguno = new List<Proveedor>
            { new Proveedor { Id = 0, Nombre = "(Ninguno)" } };
            listaConNinguno.AddRange(proveedores);
            cboProveedor.DataSource = listaConNinguno;
            cboProveedor.DisplayMember = "Nombre";
            cboProveedor.ValueMember = "Id";

            

            var categorias = _stockService.GetCategoriasInsumos();
            cboCategoria.DataSource = categorias;
        }

        private void chkEsVendible_CheckedChanged(object sender, EventArgs e)
        {
            numPrecioVenta.Enabled = chkEsVendible.Checked;
            if (!chkEsVendible.Checked)
            {
                numPrecioVenta.Value = 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new Exception("El Nombre es requerido.");
                if (cboUnidadMedida.SelectedItem == null || string.IsNullOrWhiteSpace(cboUnidadMedida.Text))
                    throw new Exception("La Unidad de Medida es requerida.");

                Insumo insumo = _insumoEditado ?? new Insumo();

                insumo.Nombre = txtNombre.Text.Trim();
                insumo.Categoria = cboCategoria.Text.Trim();
                insumo.UnidadMedida = cboUnidadMedida.SelectedItem.ToString();
                insumo.ProveedorId = (int)cboProveedor.SelectedValue;
                insumo.StockMinimo = numStockMinimo.Value;
                insumo.EsVendible = chkEsVendible.Checked;
                insumo.PrecioVenta = numPrecioVenta.Value;
                insumo.CostoUnitario = numCostoUnitario.Value;  
        

                if (_insumoEditado == null)
                {
                    insumo.StockActual = numStockActual.Value;
                }

                _stockService.GuardarInsumo(insumo);

                MessageBox.Show("Insumo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ManejarError("Error al guardar el insumo", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void ManejarError(string titulo, Exception ex)
        {
            _log.Error(nameof(frmInsumoEdit), ex, Program.CurrentUser?.Username);
            MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}