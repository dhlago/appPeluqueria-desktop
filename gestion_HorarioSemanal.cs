using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ProyectoPelu
{
    public partial class gestion_HorarioSemanal : Form
    {
        private const string API_HORARIOS_URL = "http://217.154.179.135:8080/peluqueria/api/horarios-semanales";
        private const string COLUMN_ID_NAME = "ColId";
        private DataTable dtHorarios = new DataTable();

        public gestion_HorarioSemanal(string token)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(token)) Session.Token = token;

            // Configuración de ventana hija
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            ConfigurarDataGridView();
            ConfigurarResponsividad();
        }

        private void ConfigurarResponsividad()
        {
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlControles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.Red; // Updated to red
            btnEliminar.ForeColor = Color.White;
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
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            // Estilo Encabezados
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            // Estilo Filas
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridView1.DefaultCellStyle.SelectionBackColor = SystemColors.HotTrack;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.RowTemplate.Height = 35;

            // --- COLUMNAS ---
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = COLUMN_ID_NAME, DataPropertyName = "id", Visible = false });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColDia", HeaderText = "📅 Día", DataPropertyName = "diasSemana" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColHoraInicio", HeaderText = "🕐 Hora Inicio", DataPropertyName = "horaInicio" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColHoraFin", HeaderText = "🕓 Hora Fin", DataPropertyName = "horaFin" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColCupo", HeaderText = "👥 Cupo Máx", DataPropertyName = "cupoMaximo" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColGrupo", HeaderText = "🎓 Grupo", DataPropertyName = "grupoNombre" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColServicio", HeaderText = "🛠️ Servicio", DataPropertyName = "servicioNombre" });
            
            // Hidden columns for IDs
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColGrupoId", DataPropertyName = "grupoId", Visible = false });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColServicioId", DataPropertyName = "servicioId", Visible = false });
        }

        private void CargarHorarios()
        {
            if (string.IsNullOrEmpty(Session.Token)) return;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(API_HORARIOS_URL);
                request.Method = "GET";
                request.Headers["Authorization"] = $"Bearer {Session.Token}";

                using (var response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseBody = reader.ReadToEnd();
                    JArray horariosArray = JArray.Parse(responseBody);

                    dtHorarios.Clear();

                    if (dtHorarios.Columns.Count == 0)
                    {
                        dtHorarios.Columns.Add("id", typeof(long));
                        dtHorarios.Columns.Add("diasSemana", typeof(string));
                        dtHorarios.Columns.Add("horaInicio", typeof(string));
                        dtHorarios.Columns.Add("horaFin", typeof(string));
                        dtHorarios.Columns.Add("cupoMaximo", typeof(int));
                        dtHorarios.Columns.Add("grupoNombre", typeof(string));
                        dtHorarios.Columns.Add("servicioNombre", typeof(string));
                        dtHorarios.Columns.Add("grupoId", typeof(long));
                        dtHorarios.Columns.Add("servicioId", typeof(long));
                    }

                    foreach (JObject horario in horariosArray)
                    {
                        DataRow row = dtHorarios.NewRow();
                        row["id"] = horario["idHorarioSemana"]?.Value<long>() ?? 0;
                        row["diasSemana"] = horario["diasSemana"]?.ToString();
                        row["horaInicio"] = horario["horaInicio"]?.ToString();
                        row["horaFin"] = horario["horaFin"]?.ToString();
                        row["cupoMaximo"] = horario["cupoMaximo"]?.Value<int>() ?? 0;
                        
                        // Extraer nombre del grupo y ID
                        var grupo = horario["grupo"];
                        row["grupoNombre"] = grupo?["curso"]?.ToString() ?? "Sin grupo";
                        row["grupoId"] = grupo?["id"]?.Value<long>() ?? 0;
                        
                        // Extraer nombre del servicio y ID
                        var servicio = horario["servicio"];
                        row["servicioNombre"] = servicio?["nombre"]?.ToString() ?? "Sin servicio";
                        row["servicioId"] = servicio?["idServicio"]?.Value<long>() ?? 0;
                        
                        dtHorarios.Rows.Add(row);
                    }
                    dataGridView1.DataSource = dtHorarios.DefaultView;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar horarios: " + ex.Message); }
        }

        private void gestion_HorarioSemanal_Load(object sender, EventArgs e)
        {
            comboBoxFiltrar.SelectedIndex = 0; // "Todos"
            CargarHorarios();

            // Restricción: GRUPO solo puede VER el horario semanal
            if (Session.Rol == "GRUPO")
            {
                btnNuevo.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        // --- BOTONES ---

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            info_HorarioSemanal formNuevo = new info_HorarioSemanal(Session.Token);
            if (formNuevo.ShowDialog() == DialogResult.OK) CargarHorarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un horario para editar.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            long id = Convert.ToInt64(row.Cells[COLUMN_ID_NAME].Value);
            string dia = row.Cells["ColDia"].Value.ToString();
            string horaInicio = row.Cells["ColHoraInicio"].Value.ToString();
            string horaFin = row.Cells["ColHoraFin"].Value.ToString();
            int cupo = Convert.ToInt32(row.Cells["ColCupo"].Value);
            long grupoId = Convert.ToInt64(row.Cells["ColGrupoId"].Value);
            long servicioId = Convert.ToInt64(row.Cells["ColServicioId"].Value);
            string servicioNombre = row.Cells["ColServicio"].Value.ToString();

            info_HorarioSemanal formEdicion = new info_HorarioSemanal(Session.Token, id, dia, horaInicio, horaFin, cupo, grupoId, servicioId, servicioNombre);
            if (formEdicion.ShowDialog() == DialogResult.OK) CargarHorarios();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar_Click(sender, e);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            long id = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[COLUMN_ID_NAME].Value);
            string dia = dataGridView1.SelectedRows[0].Cells["ColDia"].Value?.ToString() ?? "";

            if (MessageBox.Show($"¿Eliminar horario del {dia}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                EliminarHorarioDeAPI(id);
        }

        private void EliminarHorarioDeAPI(long idHorario)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create($"{API_HORARIOS_URL}/{idHorario}");
                request.Method = "DELETE";
                request.Headers["Authorization"] = $"Bearer {Session.Token}";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
                    {
                        MessageBox.Show("Horario eliminado.");
                        CargarHorarios();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al eliminar: " + ex.Message); }
        }

        // --- FILTROS ---

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void comboBoxFiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (dtHorarios == null) return;

            string textoBusqueda = txtBuscar.Text.Trim().Replace("'", "''");
            string diaFiltro = comboBoxFiltrar.SelectedItem?.ToString() ?? "Todos";

            string filtro = "";

            // Filtro por texto de búsqueda
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                filtro = $"(grupoNombre LIKE '%{textoBusqueda}%' OR servicioNombre LIKE '%{textoBusqueda}%')";
            }

            // Filtro por día de la semana
            if (diaFiltro != "Todos" && !string.IsNullOrEmpty(diaFiltro))
            {
                string filtroDia = $"diasSemana = '{diaFiltro}'";
                filtro = string.IsNullOrEmpty(filtro) ? filtroDia : $"{filtro} AND {filtroDia}";
            }

            dtHorarios.DefaultView.RowFilter = filtro;
        }
    }
}
