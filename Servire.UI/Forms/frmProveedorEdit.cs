using Servire.Bll.Interfaces;
using Servire.Bll.Services;
using Servire.Domain.Entities;

namespace Servire.UI.Forms
{
    public partial class frmProveedorEdit : Form
    {
        private readonly IStockService _stockService;
        private readonly IErrorLogger _log;
        private Proveedor? _proveedorEditado; 

        public frmProveedorEdit(IStockService stockService, IErrorLogger log)
        {
            InitializeComponent();
            _stockService = stockService;
            _log = log;
        }

        public void CargarProveedor(Proveedor proveedor)
        {
            _proveedorEditado = proveedor;
        }

        private void frmProveedorEdit_Load(object sender, EventArgs e)
        {
            try
            {
                cboCategoria.DataSource = _stockService.GetCategoriasProveedores();

                if (_proveedorEditado == null)
                {
                    this.Text = "Nuevo Proveedor";
                    cboCategoria.Text = "";
                }
                else
                {
                    this.Text = "Editar Proveedor";
                    txtNombre.Text = _proveedorEditado.Nombre;
                    cboCategoria.Text = _proveedorEditado.Categoria;
                    txtContacto.Text = _proveedorEditado.Contacto;
                }
            }
            catch (Exception ex)
            {
                ManejarError("Error al cargar formulario", ex);
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new Exception("El Nombre es requerido.");

                Proveedor proveedor = _proveedorEditado ?? new Proveedor();
                proveedor.Nombre = txtNombre.Text.Trim();
                proveedor.Categoria = cboCategoria.Text.Trim();
                proveedor.Contacto = txtContacto.Text.Trim();

                _stockService.GuardarProveedor(proveedor);

                MessageBox.Show("Proveedor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
            }
            catch (Exception ex)
            {
                ManejarError("Error al guardar", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ManejarError(string titulo, Exception ex)
        {
            _log.Error(nameof(frmProveedorEdit), ex, Program.CurrentUser?.Username);
            MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}