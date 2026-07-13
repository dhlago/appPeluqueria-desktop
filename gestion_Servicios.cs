using System;

using System.Data;

using System.Drawing; // Necesario para estilos visuales

using System.IO;

using System.Linq;

using System.Net;

using System.Windows.Forms;

using appPeluqueriaDesktop;

using Newtonsoft.Json.Linq;

namespace ProyectoPelu

{

    public partial class gestion_Servicios : Form

    {

        private const string API_SERVICIOS_URL = "http://217.154.179.135:8080/peluqueria/api/servicios";

        private readonly string _token;

        private DataTable dtservicios = new DataTable();

        public gestion_Servicios(string token)

        {

            InitializeComponent();

            _token = token;

            // Configuración de la ventana hija

            this.TopLevel = false;

            this.FormBorderStyle = FormBorderStyle.None;

            this.Dock = DockStyle.Fill;

            ConfigurarDataGridView();

            ConfigurarResponsividad();

        }

        private void ConfigurarResponsividad()

        {

            // El Grid ocupa todo el espacio restante

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // El panel de acciones se estira a lo ancho

            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        }

        private void Form2_Load(object sender, EventArgs e)

        {

            CargarServicios();

            // Restricción: GRUPO solo puede VER servicios

            if (Session.Rol == "GRUPO")

            {

                btnNuevoServicio.Visible = false;

                btnEditar.Visible = false;

                btnEliminar.Visible = false;

            }

        }

        private void ConfigurarDataGridView()

        {

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Clear();

            // --- ESTILO MODERNO (Igual que Citas) ---

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

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50); // Gris oscuro

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersHeight = 40;

            // Estilo Filas

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            dataGridView1.DefaultCellStyle.SelectionBackColor = SystemColors.HotTrack; // Azul Windows

            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.RowTemplate.Height = 35; // Filas más altas y cómodas

            // --- DEFINICIÓN DE COLUMNAS CON ICONOS ---

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdServicio", DataPropertyName = "id_servicio", Visible = false });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "\uD83D\uDCE6 Nombre", DataPropertyName = "nombre" });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descripcion", HeaderText = "\uD83D\uDCDD Descripci\u00F3n", DataPropertyName = "descripcion" });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Duracion", HeaderText = "\u23F1\uFE0F Duraci\u00F3n (15m)", DataPropertyName = "duracion_bloques" });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Precio", HeaderText = "\uD83D\uDCB6 Precio", DataPropertyName = "precio" });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "TipoServicio", HeaderText = "\uD83C\uDFF7\uFE0F Categor\u00EDa", DataPropertyName = "tipo_servicio" });

        }

        private void CargarServicios()

        {

            try

            {

                var request = (HttpWebRequest)WebRequest.Create(API_SERVICIOS_URL);

                request.Method = "GET";

                request.Headers["Authorization"] = $"Bearer {_token}";

                using (var response = (HttpWebResponse)request.GetResponse())

                using (var reader = new StreamReader(response.GetResponseStream()))

                {

                    string responseBody = reader.ReadToEnd();

                    JArray servicesArray = JArray.Parse(responseBody);

                    dtservicios.Clear();

                    if (dtservicios.Columns.Count == 0)

                    {

                        dtservicios.Columns.Add("id_servicio", typeof(long));

                        dtservicios.Columns.Add("nombre", typeof(string));

                        dtservicios.Columns.Add("descripcion", typeof(string));

                        dtservicios.Columns.Add("duracion_bloques", typeof(int));

                        dtservicios.Columns.Add("precio", typeof(double));

                        dtservicios.Columns.Add("tipo_servicio", typeof(string));

                    }

                    foreach (JObject serviceObject in servicesArray)

                    {

                        DataRow row = dtservicios.NewRow();

                        row["id_servicio"] = serviceObject["idServicio"]?.Value<long>() ?? 0;

                        row["nombre"] = serviceObject["nombre"]?.ToString();

                        row["descripcion"] = serviceObject["descripcion"]?.ToString();

                        row["duracion_bloques"] = serviceObject["duracionBloques"]?.Value<int>() ?? 0;

                        row["precio"] = serviceObject["precio"]?.Value<double>() ?? 0;

                        row["tipo_servicio"] = serviceObject["tipoServicio"]?["nombre"]?.ToString() ?? "General";

                        dtservicios.Rows.Add(row);

                    }

                    dataGridView1.DataSource = dtservicios.DefaultView;

                    AplicarFiltrosCombinados();

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show("Error al cargar servicios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void AplicarFiltrosCombinados()

        {

            if (dtservicios.Rows.Count == 0) return;

            DataView dvServicios = dtservicios.DefaultView;

            string filtroTexto = "";

            string textoBusqueda = textBox1.Text.Trim().Replace("'", "''");

            string filtroSeleccionado = comBoxFiltrarServicios.Text;

            if (!string.IsNullOrEmpty(textoBusqueda))

            {

                filtroTexto = $"nombre LIKE '%{textoBusqueda}%' OR descripcion LIKE '%{textoBusqueda}%' OR tipo_servicio LIKE '%{textoBusqueda}%' OR CONVERT(precio, 'System.String') LIKE '%{textoBusqueda}%' OR CONVERT(duracion_bloques, 'System.String') LIKE '%{textoBusqueda}%'";

            }

            switch (filtroSeleccionado)

            {

                case "MinMaxPrecio": dvServicios.Sort = "precio ASC"; break;

                case "MaxMinPrecio": dvServicios.Sort = "precio DESC"; break;

                case "MinMaxDuracion": dvServicios.Sort = "duracion_bloques ASC"; break;

                case "MaxMinDuracion": dvServicios.Sort = "duracion_bloques DESC"; break;

                default: dvServicios.Sort = string.Empty; break;

            }

            dvServicios.RowFilter = filtroTexto;

        }

        // ============================

        // EVENTOS BOTONES

        // ============================

        private void btnNuevoServicio_Click(object sender, EventArgs e)

        {

            info_Servicio nuevaVentana = new info_Servicio(_token, null);

            if (nuevaVentana.ShowDialog() == DialogResult.OK) CargarServicios();

        }

        private void btnEditar_Click(object sender, EventArgs e)

        {

            if (dataGridView1.CurrentRow == null)

            {

                MessageBox.Show("Selecciona un servicio para editar.");

                return;

            }

            long id = Convert.ToInt64(dataGridView1.CurrentRow.Cells["IdServicio"].Value);

            info_Servicio formEdicion = new info_Servicio(_token, id);

            if (formEdicion.ShowDialog() == DialogResult.OK) CargarServicios();

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

            if (dataGridView1.CurrentRow == null)

            {

                MessageBox.Show("Selecciona un servicio para eliminar.");

                return;

            }

            long id = Convert.ToInt64(dataGridView1.CurrentRow.Cells["IdServicio"].Value);

            string nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();

            if (MessageBox.Show($"\u00BFEliminar {nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                EliminarServicioDeBD(id);

        }

        private void EliminarServicioDeBD(long idServicio)

        {

            try

            {

                var request = (HttpWebRequest)WebRequest.Create($"{API_SERVICIOS_URL}/{idServicio}");

                request.Method = "DELETE";

                request.Headers["Authorization"] = $"Bearer {_token}";

                using (var response = (HttpWebResponse)request.GetResponse())

                {

                    if (response.StatusCode == HttpStatusCode.NoContent)

                    {

                        MessageBox.Show("Servicio eliminado.");

                        CargarServicios();

                    }

                }

            }

            catch (Exception ex) { MessageBox.Show("Error al eliminar: " + ex.Message); }

        }

        // Eventos de interfaz (Buscador/Filtros)

        private void comBoxFiltrarServicios_SelectedIndexChanged(object sender, EventArgs e) => AplicarFiltrosCombinados();

        private void textBox1_TextChanged(object sender, EventArgs e) => AplicarFiltrosCombinados();

        // Eventos vacíos para evitar errores del diseñador antiguo

        private void PrincipalLabel_Click(object sender, EventArgs e) { }

        private void pictureBox4_Click(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

    }

}
