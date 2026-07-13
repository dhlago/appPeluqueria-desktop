using System;

using System.Collections.Generic; // Necesario para las Listas

using System.Data;

using System.Drawing;

using System.Windows.Forms;

using System.Net;

using System.IO;

using Newtonsoft.Json.Linq;

using System.Linq; // Necesario para LINQ

namespace ProyectoPelu

{

    public partial class gestion_Citas : Form

    {

        private const string API_CITAS_URL = "http://217.154.179.135:8080/peluqueria/api/citas";

        private DataTable dtCitas = new DataTable();

        private JArray todasLasCitasJson;

        public gestion_Citas(string token)

        {

            InitializeComponent();

            if (!string.IsNullOrEmpty(token))

            {

                Session.Token = token;

            }

            this.TopLevel = false;

            this.FormBorderStyle = FormBorderStyle.None;

            this.Dock = DockStyle.Fill;

            ConfigurarDataGridView();

        }

        private void gestion_Citas_Load(object sender, EventArgs e)

        {

            CargarCitasDesdeAPI();

            // Restricción: GRUPO no puede editar ni cancelar citas

            if (Session.Rol == "GRUPO")

            {

                btnEditar.Visible = false;

                btnEliminar.Visible = false;

            }

        }

        private void ConfigurarDataGridView()

        {

            // Estilo Visual Moderno

            dgvCitas.AutoGenerateColumns = false;

            dgvCitas.Columns.Clear();

            dgvCitas.AllowUserToAddRows = false;

            dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvCitas.MultiSelect = false;

            dgvCitas.ReadOnly = true;

            dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Quitar bordes y mejorar colores

            dgvCitas.BackgroundColor = Color.White;

            dgvCitas.BorderStyle = BorderStyle.None;

            dgvCitas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvCitas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Estilo Encabezado

            dgvCitas.EnableHeadersVisualStyles = false;

            dgvCitas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50); // Gris oscuro

            dgvCitas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvCitas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvCitas.ColumnHeadersHeight = 40;

            dgvCitas.CellDoubleClick += dgvCitas_CellDoubleClick;

            // Estilo Filas

            dgvCitas.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            dgvCitas.DefaultCellStyle.SelectionBackColor = SystemColors.HotTrack;

            dgvCitas.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvCitas.RowTemplate.Height = 35;

            // Columnas con Iconos/Emojis para mejorar visualmente

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColId", DataPropertyName = "idCita", Visible = false });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColHora", HeaderText = "\uD83D\uDD52 Hora", DataPropertyName = "horaInicio", Width = 80 });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColCliente", HeaderText = "\uD83D\uDC64 Cliente", DataPropertyName = "nombreCliente" });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColServicio", HeaderText = "\uD83D\uDC87 Servicio", DataPropertyName = "nombreServicio" });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColGrupo", HeaderText = "\uD83D\uDC65 Atendido por", DataPropertyName = "nombreGrupo" });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColEstado", HeaderText = "\uD83D\uDCCC Estado", DataPropertyName = "estado", Width = 100 });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColIdCliente", DataPropertyName = "idCliente", Visible = false });

            // Suscribir al evento de formateo para colorear filas

            dgvCitas.CellFormatting += dgvCitas_CellFormatting;

        }

        private void CargarCitasDesdeAPI()

        {

            if (string.IsNullOrEmpty(Session.Token)) return;

            try

            {

                var request = (HttpWebRequest)WebRequest.Create($"{API_CITAS_URL}/todas");

                request.Method = "GET";

                request.Headers["Authorization"] = "Bearer " + Session.Token;

                request.Accept = "application/json";

                using (var response = (HttpWebResponse)request.GetResponse())

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))

                {

                    string json = reader.ReadToEnd();

                    todasLasCitasJson = JArray.Parse(json);

                    // 1. Marcar días con citas en el calendario

                    MarcarDiasConCitas();

                    // 2. Filtrar para la fecha que esté seleccionada actualmente

                    FiltrarCitasPorFecha(calSemanal.SelectionStart);

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show($"Error al cargar citas: {ex.Message}");

            }

        }

        private void MarcarDiasConCitas()

        {

            if (todasLasCitasJson == null) return;

            List<DateTime> diasOcupados = new List<DateTime>();

            foreach (JObject item in todasLasCitasJson)

            {

                string fechaStr = item["fecha"]?.ToString();

                if (DateTime.TryParse(fechaStr, out DateTime fecha))

                {

                    diasOcupados.Add(fecha);

                }

            }

            // La propiedad del MonthCalendar para marcar días es BoldedDates

            calSemanal.BoldedDates = diasOcupados.ToArray();

            calSemanal.UpdateBoldedDates(); // Forzar refresco

        }

        private void FiltrarCitasPorFecha(DateTime fechaSeleccionada)

        {

            if (todasLasCitasJson == null) return;

            dtCitas = new DataTable();

            dtCitas.Columns.Add("idCita", typeof(long));

            dtCitas.Columns.Add("horaInicio", typeof(string));

            dtCitas.Columns.Add("nombreCliente", typeof(string));

            dtCitas.Columns.Add("nombreServicio", typeof(string));

            dtCitas.Columns.Add("nombreGrupo", typeof(string));

            dtCitas.Columns.Add("estado", typeof(string));

            dtCitas.Columns.Add("idCliente", typeof(long));

            string fechaBusqueda = fechaSeleccionada.ToString("yyyy-MM-dd");

            foreach (JObject item in todasLasCitasJson)

            {

                string fechaCita = item["fecha"]?.ToString();

                if (fechaCita == fechaBusqueda)

                {

                    DataRow row = dtCitas.NewRow();

                    row["idCita"] = item["idCita"]?.Value<long>() ?? 0;

                    string hora = item["horaInicio"]?.ToString() ?? "00:00";

                    row["horaInicio"] = hora.Length > 5 ? hora.Substring(0, 5) : hora;

                    var cliente = item["cliente"];

                    row["nombreCliente"] = cliente != null ? $"{cliente["nombre"]} {cliente["apellidos"]}" : "Desconocido";

                    var horario = item["horarioSemanal"];

                    var servicio = horario?["servicio"];

                    row["nombreServicio"] = servicio != null ? servicio["nombre"]?.ToString() : "Sin servicio";

                    var grupo = item["grupo"];

                    row["nombreGrupo"] = grupo != null ? $"{grupo["nombre"]} {grupo["apellidos"]}" : "Sin asignar";

                    row["estado"] = item["estado"]?.ToString();

                    row["idCliente"] = item["cliente"]?["id"]?.Value<long>() ?? 0;

                    dtCitas.Rows.Add(row);

                }

            }

            dtCitas.DefaultView.Sort = "horaInicio ASC";

            dgvCitas.DataSource = dtCitas;

            // Formatear título

            lblCitasSemana.Text = $"Citas del día: {fechaSeleccionada.ToLongDateString().ToUpper()}";

        }

        private void calSemanal_DateChanged(object sender, DateRangeEventArgs e)

        {

            FiltrarCitasPorFecha(e.Start);

        }

        // --- BOTONES ---

        private void btnNuevaCita_Click(object sender, EventArgs e)

        {

            info_Cita form = new info_Cita();

            // Si creamos una cita correctamente, recargamos todo para que el calendario se pinte de nuevo

            if (form.ShowDialog() == DialogResult.OK)

            {

                CargarCitasDesdeAPI();

            }

        }

        private void btnEditar_Click(object sender, EventArgs e)

        {

            if (dgvCitas.SelectedRows.Count == 0)

            {

                MessageBox.Show("Selecciona una cita para editar.");

                return;

            }

            long idCita = Convert.ToInt64(dgvCitas.SelectedRows[0].Cells["ColId"].Value);

            info_Cita form = new info_Cita(idCita);

            if (form.ShowDialog() == DialogResult.OK)

            {

                CargarCitasDesdeAPI();

            }

        }

        private void dgvCitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)

        {

            if (e.RowIndex >= 0)

            {

                long idCliente = Convert.ToInt64(dgvCitas.Rows[e.RowIndex].Cells["ColIdCliente"].Value);

                string nombreCliente = dgvCitas.Rows[e.RowIndex].Cells["ColCliente"].Value.ToString();

                if (idCliente > 0)

                {

                    historial_Citas form = new historial_Citas(Session.Token, idCliente, nombreCliente);

                    form.ShowDialog();

                }

                else

                {

                    MessageBox.Show("No se encontró el ID del cliente.");

                }

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)

        {

            if (dgvCitas.SelectedRows.Count == 0)

            {

                MessageBox.Show("Selecciona una cita.");

                return;

            }

            long id = Convert.ToInt64(dgvCitas.SelectedRows[0].Cells["ColId"].Value);

            string estado = dgvCitas.SelectedRows[0].Cells["ColEstado"].Value.ToString();

            if (estado == "CANCELADA")

            {

                MessageBox.Show("Ya está cancelada.");

                return;

            }

            if (MessageBox.Show("\u00BFCancelar cita?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)

            {

                CancelarCitaEnAPI(id);

            }

        }

        private void CancelarCitaEnAPI(long id)

        {

            try

            {

                var request = (HttpWebRequest)WebRequest.Create($"{API_CITAS_URL}/{id}/estado/1");

                request.Method = "PUT";

                request.Headers["Authorization"] = "Bearer " + Session.Token;

                request.ContentLength = 0;

                using (var response = (HttpWebResponse)request.GetResponse())

                {

                    if (response.StatusCode == HttpStatusCode.OK)

                    {

                        MessageBox.Show("Cita cancelada.");

                        CargarCitasDesdeAPI();

                    }

                }

            }

            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }

        }

        private void txtBoxBuscarCitas_TextChanged(object sender, EventArgs e)

        {

            if (dtCitas == null || dtCitas.Rows.Count == 0) return;

            string filtro = txtBoxBuscarCitas.Text.Trim().Replace("'", "''");

            try

            {

                dtCitas.DefaultView.RowFilter = string.Format(

                    "nombreCliente LIKE '%{0}%' OR nombreServicio LIKE '%{0}%' OR nombreGrupo LIKE '%{0}%' OR estado LIKE '%{0}%' OR horaInicio LIKE '%{0}%'",

                    filtro

                );

                lblCitasSemana.Text = $"Resultados encontrados: {dgvCitas.Rows.Count}";

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error en el filtrado: " + ex.Message);

            }

        }

        private void dgvCitas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)

        {

            if (e.RowIndex < 0) return;

            // Obtener el nombre del grupo de la fila actual

            // El DataPropertyName es "nombreGrupo"

            string groupName = dgvCitas.Rows[e.RowIndex].Cells["ColGrupo"].Value?.ToString();

            if (!string.IsNullOrEmpty(groupName))

            {

                e.CellStyle.BackColor = GetGroupColor(groupName);

                // Usar un color de selección que sea una versión un poco más oscura del color de fondo del grupo

                // pero que siga siendo suave y permita leer el texto.

                e.CellStyle.SelectionBackColor = Color.FromArgb(

                    Math.Max(0, e.CellStyle.BackColor.R - 30),

                    Math.Max(0, e.CellStyle.BackColor.G - 30),

                    Math.Max(0, e.CellStyle.BackColor.B - 30)

                );

                e.CellStyle.SelectionForeColor = Color.Black;

            }

        }

        private Color GetGroupColor(string groupName)

        {

            if (string.IsNullOrEmpty(groupName)) return Color.White;

            // Mapear por nombres exactos del curso o abreviaturas

            string nameLower = groupName.ToLower();

            if (nameLower.Contains("1º grado medio peluquería") || nameLower.Contains("1gmp"))

                return Color.FromArgb(255, 220, 220); // Rojo suave (más visible)

            if (nameLower.Contains("1º grado medio estética") || nameLower.Contains("1gme") || nameLower.Contains("1gmest"))

                return Color.FromArgb(220, 240, 255); // Azul suave (más visible)

            if (nameLower.Contains("2º grado medio estética (ace)") || (nameLower.Contains("2gme") && nameLower.Contains("ace")))

                return Color.FromArgb(220, 255, 220); // Verde suave (más visible)

            if ((nameLower.Contains("2º grado medio estética") || nameLower.Contains("2gme")) && !nameLower.Contains("ace"))

                return Color.FromArgb(255, 255, 210); // Amarillo suave (más visible)

            if (nameLower.Contains("1º grado superior estética") || nameLower.Contains("1gse"))

                return Color.FromArgb(235, 220, 255); // Lavanda suave (más visible)

            if (nameLower.Contains("2º grado superior estética") || nameLower.Contains("2gse"))

                return Color.FromArgb(255, 230, 255); // Rosa suave (más visible)

            if (nameLower.Contains("2º fp básica estética (mañana)") || (nameLower.Contains("2fpb") && nameLower.Contains("mañana")))

                return Color.FromArgb(255, 235, 210); // Melocotón suave (más visible)

            if (nameLower.Contains("2º fp básica estética (tarde)") || (nameLower.Contains("2fpb") && nameLower.Contains("tarde")))

                return Color.FromArgb(225, 220, 210); // Arena suave (más visible)

            if (nameLower.Contains("2º grado superior edp") || nameLower.Contains("2gsedp") || nameLower.Contains("2edp"))

                return Color.FromArgb(210, 255, 255); // Cyan suave (más visible)

            return Color.White;

        }

        private void dgvCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {

        }

    }

}
