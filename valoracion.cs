using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using ProyectoPelu; 

namespace appPeluqueriaDesktop
{
    public partial class valoracion : Form
    {
        private const string API_VALORACIONES_URL = "http://217.154.179.135:8080/peluqueria/api/valoraciones";
        private JArray todasLasValoraciones;
        private DataTable dtValoraciones;

        public valoracion()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            ConfigurarFiltros();
        }

        private void valoracion_Load(object sender, EventArgs e)
        {
            CargarValoraciones();
        }

        private void ConfigurarDataGridView()
        {
            // Estilo Visual Moderno
            dgvValoraciones.AutoGenerateColumns = false;
            dgvValoraciones.Columns.Clear();
            dgvValoraciones.AllowUserToAddRows = false;
            dgvValoraciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvValoraciones.MultiSelect = false;
            dgvValoraciones.ReadOnly = true;
            dgvValoraciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvValoraciones.BackgroundColor = Color.White;
            dgvValoraciones.BorderStyle = BorderStyle.None;
            dgvValoraciones.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvValoraciones.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvValoraciones.EnableHeadersVisualStyles = false;
            dgvValoraciones.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50); 
            dgvValoraciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvValoraciones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvValoraciones.ColumnHeadersHeight = 40;

            dgvValoraciones.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvValoraciones.DefaultCellStyle.SelectionBackColor = SystemColors.HotTrack;
            dgvValoraciones.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvValoraciones.RowTemplate.Height = 35;

            // Definir Columnas
            dgvValoraciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColId", DataPropertyName = "idValoracion", Visible = false });
            dgvValoraciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColCliente", HeaderText = "\uD83D\uDC64 Cliente", DataPropertyName = "nombreCliente" });
            dgvValoraciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColServicio", HeaderText = "\u2702\uFE0F Servicio", DataPropertyName = "nombreServicio" });
            dgvValoraciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColGeneral", HeaderText = "\u2B50 Puntuaci\u00F3n", DataPropertyName = "general", Width = 100 });
            dgvValoraciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColFecha", HeaderText = "\uD83D\uDCC5 Fecha", DataPropertyName = "fecha", Width = 150 });
            dgvValoraciones.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColComentario", HeaderText = "\uD83D\uDCAC Comentario", DataPropertyName = "comentarioResumen" });
        }

        private void ConfigurarFiltros()
        {
            // Llenar el ComboBox de Ordenación
            cmbOrden.Items.Clear();
            cmbOrden.Items.Add("Más Recientes");
            cmbOrden.Items.Add("Más Antiguas");
            cmbOrden.Items.Add("Mejor Valoraci\u00F3n (5\u2B50)");
            cmbOrden.Items.Add("Peor Valoraci\u00F3n (1\u2B50)");
            cmbOrden.SelectedIndex = 0; // Default: Recientes
        }

        private void CargarValoraciones()
        {
            if (string.IsNullOrEmpty(Session.Token)) return;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(API_VALORACIONES_URL);
                request.Method = "GET";
                request.Headers["Authorization"] = "Bearer " + Session.Token;
                request.Accept = "application/json";

                using (var response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();
                    todasLasValoraciones = JArray.Parse(json);
                    MapearDatosADataTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar valoraciones: {ex.Message}");
            }
        }

        private void MapearDatosADataTable()
        {
            dtValoraciones = new DataTable();
            dtValoraciones.Columns.Add("idValoracion", typeof(long));
            dtValoraciones.Columns.Add("nombreCliente", typeof(string));
            dtValoraciones.Columns.Add("nombreServicio", typeof(string));
            dtValoraciones.Columns.Add("general", typeof(double));
            dtValoraciones.Columns.Add("tratoPersonal", typeof(double));
            dtValoraciones.Columns.Add("desarrolloServicio", typeof(double));
            dtValoraciones.Columns.Add("claridadComunicacion", typeof(double));
            dtValoraciones.Columns.Add("limpiezaOrganizacion", typeof(double));
            dtValoraciones.Columns.Add("fecha", typeof(string)); // Texto formateado
            dtValoraciones.Columns.Add("fechaSort", typeof(DateTime)); // Para ordenar correctamente
            dtValoraciones.Columns.Add("comentarioResumen", typeof(string));

            if (todasLasValoraciones != null)
            {
                foreach (JObject item in todasLasValoraciones)
                {
                    DataRow row = dtValoraciones.NewRow();
                    row["idValoracion"] = item["idValoracion"]?.Value<long>() ?? 0;

                    var cita = item["cita"];
                    var cliente = cita?["cliente"];
                    row["nombreCliente"] = cliente != null ? $"{cliente["nombre"]} {cliente["apellidos"]}" : "Desconocido";

                    var horario = cita?["horarioSemanal"];
                    var servicio = horario?["servicio"];
                    row["nombreServicio"] = servicio != null ? servicio["nombre"]?.ToString() : "Sin Servicio";

                    row["general"] = item["general"]?.Value<double>() ?? 0;
                    row["tratoPersonal"] = item["tratoPersonal"]?.Value<double>() ?? 0;
                    row["desarrolloServicio"] = item["desarrolloServicio"]?.Value<double>() ?? 0;
                    row["claridadComunicacion"] = item["claridadComunicacion"]?.Value<double>() ?? 0;
                    row["limpiezaOrganizacion"] = item["limpiezaOrganizacion"]?.Value<double>() ?? 0;
                    
                    string fechaStr = item["fechaValoracion"]?.ToString();
                    if (DateTime.TryParse(fechaStr, out DateTime fecha))
                    {
                        row["fecha"] = fecha.ToString("yyyy-MM-dd HH:mm");
                        row["fechaSort"] = fecha;
                    }
                    else
                    {
                        row["fecha"] = fechaStr;
                        row["fechaSort"] = DateTime.MinValue;
                    }

                    string comentario = item["comentario"]?.ToString() ?? "";
                    row["comentarioResumen"] = comentario.Length > 50 ? comentario.Substring(0, 47) + "..." : comentario;

                    dtValoraciones.Rows.Add(row);
                }
            }

            dgvValoraciones.DataSource = dtValoraciones;
            lblContador.Text = $"Total Valoraciones: {dgvValoraciones.Rows.Count}";
            
            // Aplicar filtro inicial
            AplicarFiltrosYOrden();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltrosYOrden();
        }

        private void cmbOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltrosYOrden();
        }

        private void AplicarFiltrosYOrden()
        {
            if (dtValoraciones == null) return;

            string filtro = txtBuscar.Text.Trim().Replace("'", "''");
            string sort = "";

            // 1. Filtrado
            try 
            {
                // Convertimmos puntuacion a string para buscar numeros tb
                dtValoraciones.DefaultView.RowFilter = string.Format(
                    "nombreCliente LIKE '%{0}%' OR nombreServicio LIKE '%{0}%' OR comentarioResumen LIKE '%{0}%' OR CONVERT(general, 'System.String') LIKE '%{0}%'",
                    filtro
                );
            }
            catch (Exception) { /* Ignorar errores de sintaxis mientras escribe */ }


            // 2. Ordenación
            switch (cmbOrden.SelectedIndex)
            {
                case 0: // Recientes
                    sort = "fechaSort DESC";
                    break;
                case 1: // Antiguas
                    sort = "fechaSort ASC";
                    break;
                case 2: // Mejor Valoracion
                    sort = "general DESC";
                    break;
                case 3: // Peor Valoracion
                    sort = "general ASC";
                    break;
            }

            dtValoraciones.DefaultView.Sort = sort;
            lblContador.Text = $"Mostrando: {dgvValoraciones.Rows.Count}";
        }


        // --- EVENTOS DE BOTONES Y GRID ---

        private void dgvValoraciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            AbrirDetalleValoracion();
        }

        private void AbrirDetalleValoracion()
        {
            if (dgvValoraciones.SelectedRows.Count == 0) return;

            long id = Convert.ToInt64(dgvValoraciones.SelectedRows[0].Cells["ColId"].Value);
            
            // Buscar el JObject original
            JObject valoracionSeleccionada = null;
            foreach (JObject item in todasLasValoraciones)
            {
                if (item["idValoracion"]?.Value<long>() == id)
                {
                    valoracionSeleccionada = item;
                    break;
                }
            }

            if (valoracionSeleccionada != null)
            {
                info_Valoracion formularioDetalle = new info_Valoracion(valoracionSeleccionada);
                formularioDetalle.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvValoraciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una valoraci\u00F3n para eliminar.");
                return;
            }

            long id = Convert.ToInt64(dgvValoraciones.SelectedRows[0].Cells["ColId"].Value);

            if (MessageBox.Show("¿Estás seguro de que deseas eliminar esta valoración?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                EliminarValoracionAPI(id);
            }
        }

        private void EliminarValoracionAPI(long id)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create($"{API_VALORACIONES_URL}/{id}");
                request.Method = "DELETE";
                request.Headers["Authorization"] = "Bearer " + Session.Token;

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)
                    {
                        MessageBox.Show("Valoraci\u00F3n eliminada correctamente.");
                        CargarValoraciones();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}");
            }
        }
    }
}
