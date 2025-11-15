using Servire.Services.Domain.Composite; // USINGS NUEVOS
using Servire.Services.Domain.Logging;
using Servire.Services.Implementations;
using Servire.Services.Tools;
using System;
using System.Windows.Forms;

namespace Servire.UI.Forms
{
    public partial class frmBitacora : Form
    {
        private readonly Usuario _usuarioLogueado;
        private readonly LoggerService _logger;

        public frmBitacora(Usuario usuarioLogueado) // Constructor NUEVO
        {
            InitializeComponent();
            _usuarioLogueado = usuarioLogueado;
            _logger = new LoggerService();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            // CORRECCIÓN: Nombres de control 'dtDesde' y 'dtHasta'
            dtDesde.Value = DateTime.Now.AddDays(-7);
            dtHasta.Value = DateTime.Now;
            BuscarLogs();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarLogs();
        }

        private void BuscarLogs()
        {
            try
            {
                var logs = _logger.Listar(
                      dtDesde.Value,
                      dtHasta.Value,
                      txtUsuario.Text.Trim() 
                  );
                dgvLogs.DataSource = null;
                dgvLogs.DataSource = logs;
                dgvBitacora.DataSource = null;
                dgvBitacora.DataSource = logs;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frmBitacora.BuscarLogs", _usuarioLogueado.Username);
                MessageBox.Show($"Error al cargar la bitácora: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CORRECCIÓN: Nombre 'dgvLogs'
        private void dgvBitacora_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvLogs.DataSource == null) return;

            dgvLogs.Columns[nameof(LogEntry.Id)].Visible = false;
            dgvLogs.Columns[nameof(LogEntry.StackTrace)].Visible = false;
            dgvLogs.Columns[nameof(LogEntry.Fecha)].Width = 130;
            dgvLogs.Columns[nameof(LogEntry.Usuario)].Width = 100;
            dgvLogs.Columns[nameof(LogEntry.Nivel)].Width = 70;
            dgvLogs.Columns[nameof(LogEntry.Origen)].Width = 100;
            dgvLogs.Columns[nameof(LogEntry.Mensaje)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}