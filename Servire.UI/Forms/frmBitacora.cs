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
            _logger = new LoggerService(); // Debería ser DI
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            // CORRECCIÓN: Nombres de control 'dpDesde' y 'dpHasta' (para la pestaña Bitacora)
            // Y 'dpDesde2', 'dpHasta2' (para la pestaña Errores)
            dpDesde.Value = DateTime.Now.AddDays(-7);
            dpHasta.Value = DateTime.Now;

            dpDesde2.Value = DateTime.Now.AddDays(-7);
            dpHasta2.Value = DateTime.Now;

            // Al cargar, buscamos en la pestaña que esté activa (que será la primera, Bitácora)
            // OJO: Tu método 'BuscarLogs' solo busca Errores. No tienes un método para la Bitácora de negocio.
            // Por ahora, llamaré al método de buscar Errores para la grilla de Errores.
            BuscarLogsErrores();
        }

        // CORRECCIÓN: Este evento es para los botones 'Buscar' de AMBAS pestañas
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabBitacora)
            {
                // Aquí deberías llamar al método que busca en la Bitácora de Negocio
                MessageBox.Show("Búsqueda de bitácora de negocio no implementada.");
            }
            else if (tabControl1.SelectedTab == tabErrores)
            {
                BuscarLogsErrores();
            }
        }

        // CORRECCIÓN: Renombré el método para que sea claro que busca Errores
        private void BuscarLogsErrores()
        {
            try
            {
                // Usa los controles de la Pestaña Errores
                var logs = _logger.Listar(
                      dpDesde2.Value, // Control de pestaña Errores
                      dpHasta2.Value, // Control de pestaña Errores
                      txtUsuario2.Text.Trim() // Control de pestaña Errores
                  );

                // CORRECCIÓN: Asignar al 'dgvErrores'
                dgvErrores.DataSource = null;
                dgvErrores.DataSource = logs;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "frmBitacora.BuscarLogsErrores", _usuarioLogueado.Username);
                MessageBox.Show($"Error al cargar la bitácora: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CORRECCIÓN: Este evento estaba en tu código original pero apuntaba a 'dgvLogs'
        // Lo muevo para que apunte a 'dgvErrores' que es la que se llena
        private void dgvErrores_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvErrores.DataSource == null) return;

            // Esto debe coincidir con los DataPropertyName del .Designer
            dgvErrores.Columns[nameof(LogEntry.Id)].Visible = false;
            dgvErrores.Columns[nameof(LogEntry.StackTrace)].Visible = false;
            dgvErrores.Columns[nameof(LogEntry.Fecha)].Width = 130;
            dgvErrores.Columns[nameof(LogEntry.Usuario)].Width = 100;
            dgvErrores.Columns[nameof(LogEntry.Nivel)].Width = 70;
            dgvErrores.Columns[nameof(LogEntry.Origen)].Width = 100;
            dgvErrores.Columns[nameof(LogEntry.Mensaje)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        // --- EVENTOS QUE NO USABAS PERO ESTÁN EN EL DESIGNER ---

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabBitacora)
            {
                txtUsuario.Text = "";
                txtTexto.Text = "";
                dpDesde.Value = DateTime.Now.AddDays(-7);
                dpHasta.Value = DateTime.Now;
                dgvBitacora.DataSource = null;
            }
            else if (tabControl1.SelectedTab == tabErrores)
            {
                txtUsuario2.Text = "";
                txtTexto2.Text = "";
                cboNivel.SelectedIndex = 0;
                dpDesde2.Value = DateTime.Now.AddDays(-7);
                dpHasta2.Value = DateTime.Now;
                dgvErrores.DataSource = null;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de exportar no implementada.");
        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Opcional: Cargar datos automáticamente al cambiar de pestaña
            if (tabControl1.SelectedTab == tabErrores && dgvErrores.Rows.Count == 0)
            {
                BuscarLogsErrores();
            }
        }
    }
}