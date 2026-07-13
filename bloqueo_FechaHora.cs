using System;
using System.Data;
using System.Drawing;
using System.Net.Http; // Librería moderna
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ProyectoPelu
{
    public partial class bloqueo_FechaHora : Form
    {
        private const string API_BLOQUEOS_URL = "http://217.154.179.135:8080/peluqueria/api/bloqueos-horarios";
        private const string COLUMN_ID_NAME = "ColId";
        private DataTable dtBloqueos = new DataTable();

        // Creamos un cliente HTTP estático y reutilizable
        private static readonly HttpClient client = new HttpClient();

        public bloqueo_FechaHora(string token)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(token)) Session.Token = token;

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            ConfigurarDataGridView();
            ConfigurarResponsividad();
        }

        private void ConfigurarResponsividad()
        {
            if (dataGridView1 != null) dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            if (pnlControles != null) pnlControles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            if (btnNuevo != null) btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            if (btnEliminar != null) btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // --- ESTILO VISUAL MODERNO ---
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            // Estilo Encabezados
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50); // Gris oscuro
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            // Estilo Filas
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridView1.DefaultCellStyle.SelectionBackColor = SystemColors.HotTrack;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.RowTemplate.Height = 35;

            // --- COLUMNAS ---
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = COLUMN_ID_NAME, DataPropertyName = "idBloqueo", Visible = false });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColFecha", HeaderText = "📅 Fecha", DataPropertyName = "fecha" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColHoraInicio", HeaderText = "🕐 Hora Inicio", DataPropertyName = "horaInicio" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColHoraFin", HeaderText = "🕓 Hora Fin", DataPropertyName = "horaFin" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColMotivo", HeaderText = "📝 Motivo", DataPropertyName = "motivo" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColTodoDia", HeaderText = "🌞 Todo el día", DataPropertyName = "todoElDia" });
        }

        // Convertimos el evento Load a async
        private async void bloqueo_FechaHora_Load(object sender, EventArgs e)
        {
            await CargarBloqueos();

            // Restricción: GRUPO solo puede VER los bloqueos
            if (Session.Rol == "GRUPO")
            {
                btnNuevo.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        // Método asíncrono para cargar datos
        private async Task CargarBloqueos()
        {
            if (string.IsNullOrEmpty(Session.Token)) return;

            try
            {
                // Usamos HttpClient
                ConfigurarHeaders();
                string json = await client.GetStringAsync(API_BLOQUEOS_URL);

                JArray bloqueosArray = JArray.Parse(json);
                dtBloqueos.Clear();

                if (dtBloqueos.Columns.Count == 0)
                {
                    dtBloqueos.Columns.Add("idBloqueo", typeof(long));
                    dtBloqueos.Columns.Add("fecha", typeof(string));
                    dtBloqueos.Columns.Add("horaInicio", typeof(string));
                    dtBloqueos.Columns.Add("horaFin", typeof(string));
                    dtBloqueos.Columns.Add("motivo", typeof(string));
                    dtBloqueos.Columns.Add("todoElDia", typeof(string));
                }

                foreach (JObject bloqueo in bloqueosArray)
                {
                    DataRow row = dtBloqueos.NewRow();
                    row["idBloqueo"] = bloqueo["idBloqueo"]?.Value<long>() ?? 0;
                    row["fecha"] = bloqueo["fecha"]?.ToString();
                    row["horaInicio"] = bloqueo["horaInicio"]?.ToString() ?? "-";
                    row["horaFin"] = bloqueo["horaFin"]?.ToString() ?? "-";
                    row["motivo"] = bloqueo["motivo"]?.ToString();
                    row["todoElDia"] = (bloqueo["todoElDia"]?.Value<bool>() ?? false) ? "SÍ" : "NO";
                    dtBloqueos.Rows.Add(row);
                }
                dataGridView1.DataSource = dtBloqueos.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar bloqueos: " + ex.Message);
            }
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            // Asegúrate de que info_Bloqueo existe
            info_Bloqueo formNuevo = new info_Bloqueo(Session.Token);
            if (formNuevo.ShowDialog() == DialogResult.OK)
            {
                await CargarBloqueos();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            long id = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[COLUMN_ID_NAME].Value);
            string fecha = dataGridView1.SelectedRows[0].Cells["ColFecha"].Value?.ToString() ?? "";

            if (MessageBox.Show($"¿Eliminar bloqueo del {fecha}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await EliminarBloqueoDeAPI(id);
            }
        }

        private async Task EliminarBloqueoDeAPI(long id)
        {
            try
            {
                ConfigurarHeaders();
                var response = await client.DeleteAsync($"{API_BLOQUEOS_URL}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Bloqueo eliminado.");
                    await CargarBloqueos();
                }
                else
                {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al eliminar ({response.StatusCode}): {errorMsg}");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error de conexión: " + ex.Message); }
        }

        private void dtpFiltrar_ValueChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (dtBloqueos == null || dtBloqueos.Rows.Count == 0) return;
            // Lógica de filtrado si es necesaria
        }

        // Configuración de cabeceras para HttpClient
        private void ConfigurarHeaders()
        {
            client.DefaultRequestHeaders.Authorization = null; // Limpiar anterior
            if (!string.IsNullOrEmpty(Session.Token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Token);
            }
        }
    }
}
