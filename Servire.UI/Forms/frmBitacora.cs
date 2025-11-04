using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Servire.Bll.Interfaces;
using Servire.Domain.Entities;
using Servire.Bll.DTOs;
using System.Collections.Generic; // <-- Asegúrate de tener este using

namespace Servire.UI.Forms
{
    public partial class frmBitacora : Form
    {
        private readonly IBitacoraService _bitacora;
        private readonly IErrorLogService _errorLog;

        public frmBitacora(IBitacoraService bitacora, IErrorLogService errorLog)
        {
            InitializeComponent();
            _bitacora = bitacora;
            _errorLog = errorLog;
        }

        // --- INICIO DE CORRECCIONES EN CargarErrores ---
        private void CargarErrores()
        {
            // 1. USA LOS FILTROS DE FECHA CORRECTOS (dpDesde2, dpHasta2)
            var todosLosDatos = _errorLog.Listar(
                dpDesde2.Value,
                dpHasta2.Value
            );

            // 2. APLICA LOS FILTROS DE TEXTO Y NIVEL
            var userFilter = txtUsuario2.Text.Trim().ToLower();
            var textoFilter = txtTexto2.Text.Trim().ToLower();
            // cboNivel.Text o cboNivel.SelectedItem.ToString()
            var nivelFilter = cboNivel.SelectedIndex > 0 ? cboNivel.Text.ToLower() : "";

            var datosFiltrados = todosLosDatos.AsEnumerable();

            if (!string.IsNullOrEmpty(userFilter))
            {
                datosFiltrados = datosFiltrados.Where(e => e.Usuario.ToLower().Contains(userFilter));
            }
            if (!string.IsNullOrEmpty(textoFilter))
            {
                datosFiltrados = datosFiltrados.Where(e => e.Mensaje.ToLower().Contains(textoFilter) ||
                                                            e.Fuente.ToLower().Contains(textoFilter) ||
                                                            e.Stacktrace.ToLower().Contains(textoFilter));
            }
            if (!string.IsNullOrEmpty(nivelFilter))
            {
                datosFiltrados = datosFiltrados.Where(e => e.Nivel.ToLower() == nivelFilter);
            }

            var listaFinal = datosFiltrados.ToList();
            dgvErrores.AutoGenerateColumns = false;
            dgvErrores.DataSource = listaFinal;
            ActualizarStatus(listaFinal.Count);
        }
        // --- FIN DE CORRECCIONES EN CargarErrores ---

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            dpDesde.Value = DateTime.Today.AddDays(-7);
            dpHasta.Value = DateTime.Today;
            // También inicializa las fechas de la otra pestaña
            dpDesde2.Value = DateTime.Today.AddDays(-7);
            dpHasta2.Value = DateTime.Today;

            if (tabControl1.SelectedTab == tabBitacora)
            {
                if (lblNivel != null) lblNivel.Visible = false;
                if (cboNivel != null) cboNivel.Visible = false;
            }

            // Inicializa el ComboBox
            if (cboNivel != null) cboNivel.SelectedIndex = 0;

            Buscar();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Este evento estaba vacío, pero el evento correcto está más abajo
            // (tabControl1_SelectedIndexChanged_1) y ya está bien implementado.
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        // --- INICIO DE CORRECCIONES EN btnLimpiar_Click ---
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpia filtros de Bitácora
            txtUsuario.Text = "";
            txtTexto.Text = "";
            dpDesde.Value = DateTime.Today.AddDays(-7);
            dpHasta.Value = DateTime.Today;

            // Limpia filtros de Errores
            txtUsuario2.Text = "";
            txtTexto2.Text = "";
            dpDesde2.Value = DateTime.Today.AddDays(-7);
            dpHasta2.Value = DateTime.Today;
            if (cboNivel != null) cboNivel.SelectedIndex = 0;

            Buscar();
        }
        // --- FIN DE CORRECCIONES EN btnLimpiar_Click ---

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarCsv();
        }

        private void Buscar()
        {
            if (tabControl1.SelectedTab == tabBitacora)
            {
                CargarBitacora();
            }
            else if (tabControl1.SelectedTab == tabErrores)
            {
                CargarErrores();
            }
        }

        private void CargarBitacora()
        {
            var todosLosDatos = _bitacora.Listar(dpDesde.Value, dpHasta.Value);
            var userFilter = txtUsuario.Text.Trim().ToLower();
            var textoFilter = txtTexto.Text.Trim().ToLower();
            var datosFiltrados = todosLosDatos.AsEnumerable();
            if (!string.IsNullOrEmpty(userFilter))
            {
                datosFiltrados = datosFiltrados.Where(b => b.Username.ToLower().Contains(userFilter));
            }
            if (!string.IsNullOrEmpty(textoFilter))
            {
                datosFiltrados = datosFiltrados.Where(b => b.Accion.ToLower().Contains(textoFilter) || b.Mensaje.ToLower().Contains(textoFilter));
            }
            var listaFinal = datosFiltrados.ToList();
            dgvBitacora.AutoGenerateColumns = false;
            dgvBitacora.DataSource = listaFinal;
            ActualizarStatus(listaFinal.Count);
        }

        private void ActualizarStatus(int count)
        {
            if (lblCantidad != null)
                lblCantidad.Text = $"Registros: {count}";
        }


        private void ExportarCsv()
        {
            DataGridView dgv = (tabControl1.SelectedTab == tabBitacora) ? dgvBitacora : dgvErrores;
            string nombreArchivo = (tabControl1.SelectedTab == tabBitacora) ? "export_bitacora" : "export_errores";
            if (dgv?.DataSource == null) return;
            using var sfd = new SaveFileDialog
            {
                Filter = "CSV (*.csv)|*.csv",
                FileName = $"{nombreArchivo}_{DateTime.Now:yyyyMMddHHmm}.csv"
            };
            if (sfd.ShowDialog(this) != DialogResult.OK) return;
            using var sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true));
            var cols = dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).OrderBy(c => c.DisplayIndex).ToList();
            sw.WriteLine(string.Join(";", cols.Select(c => CsvQuote(c.HeaderText))));
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                var vals = cols.Select(c => CsvQuote(row.Cells[c.Index].Value?.ToString() ?? ""));
                sw.WriteLine(string.Join(";", vals));
            }
            MessageBox.Show("Exportado.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static string CsvQuote(string s) => $"\"{(s ?? "").Replace("\"", "\"\"")}\"";

        // Este método está bien, pero en el Designer.cs tienes un montón de filtros
        // (txtUsuario2, txtTexto2, dpDesde2, dpHasta2) que no estás ocultando/mostrando.
        // Por ahora lo dejamos así, pero ten en cuenta que los filtros de la pestaña "Errores"
        // (menos cboNivel) también se verán en la pestaña "Bitácora" y viceversa.
        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            bool esBitacora = tabControl1.SelectedTab == tabBitacora;
            if (lblUsuario != null) lblUsuario.Visible = esBitacora;
            if (txtUsuario != null) txtUsuario.Visible = esBitacora;
            if (lblTexto != null) lblTexto.Visible = esBitacora;
            if (txtTexto != null) txtTexto.Visible = esBitacora;

            // Oculta/Muestra TODOS los filtros de la pestaña Errores
            if (lblUsuario2 != null) lblUsuario2.Visible = !esBitacora;
            if (txtUsuario2 != null) txtUsuario2.Visible = !esBitacora;
            if (lblTexto2 != null) lblTexto2.Visible = !esBitacora;
            if (txtTexto2 != null) txtTexto2.Visible = !esBitacora;
            if (lblDesde2 != null) lblDesde2.Visible = !esBitacora;
            if (dpDesde2 != null) dpDesde2.Visible = !esBitacora;
            if (lblHasta2 != null) lblHasta2.Visible = !esBitacora;
            if (dpHasta2 != null) dpHasta2.Visible = !esBitacora;
            if (lblNivel != null) lblNivel.Visible = !esBitacora;
            if (cboNivel != null) cboNivel.Visible = !esBitacora;


            Buscar();
        }
    }
}