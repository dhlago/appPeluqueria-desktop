using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using appPeluqueriaDesktop;
using Newtonsoft.Json.Linq;

namespace ProyectoPelu
{
    public partial class historial_Citas : Form
    {
        private readonly string _token;
        private readonly long _clienteId;
        private readonly string _nombreCliente;
        private const string API_CITAS_URL = "http://217.154.179.135:8080/peluqueria/api/citas/todas";

        public historial_Citas(string token, long clienteId, string nombreCliente)
        {
            InitializeComponent();
            _token = token;
            _clienteId = clienteId;
            _nombreCliente = nombreCliente;
            
            lblTitulo.Text = $"Historial: {_nombreCliente}";
            ConfigurarDataGridView();
            CargarDatosCliente();
        }

        private void historial_Citas_Load(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void ConfigurarDataGridView()
        {
            dgvHistorial.AutoGenerateColumns = false;
            dgvHistorial.Columns.Clear();
            dgvHistorial.ReadOnly = true;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "fecha", HeaderText = "📅 Fecha", Width = 100 });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "horaInicio", HeaderText = "⏰ Hora", Width = 80 });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "servicio", HeaderText = "✂️ Servicio" });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "grupo", HeaderText = "💈 Atendido por" });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "estado", HeaderText = "📌 Estado", Width = 100 });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColIdCita", DataPropertyName = "idCita", Visible = false });
            dgvHistorial.Columns.Add(new DataGridViewCheckBoxColumn { Name = "ColTieneValoracion", DataPropertyName = "tieneValoracion", Visible = false });

            dgvHistorial.CellFormatting += dgvHistorial_CellFormatting;
        }

        private void CargarDatosCliente()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create($"http://217.154.179.135:8080/peluqueria/api/clientes/{_clienteId}");
                request.Method = "GET";
                request.Headers["Authorization"] = $"Bearer {_token}";

                using (var response = (HttpWebResponse)request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();
                    JObject cliente = JObject.Parse(json);

                    txtNombreCliente.Text = cliente["nombre"]?.ToString();
                    txtApellidos.Text = cliente["apellidos"]?.ToString();
                    txtUsername.Text = cliente["username"]?.ToString();
                    txtEmail.Text = cliente["email"]?.ToString();
                    txtRol.Text = cliente["rol"]?.ToString();
                    
                    string especialidad = cliente["especialidad"]?.ToString();
                    txtEspecialidad.Text = especialidad;
                    bool hasEspecialidad = !string.IsNullOrEmpty(especialidad);
                    lblEspecialidad.Visible = hasEspecialidad;
                    txtEspecialidad.Visible = hasEspecialidad;

                    txtTelefono.Text = cliente["telefono"]?.ToString();
                    txtObservacion.Text = cliente["observacion"]?.ToString();
                    txtAlergenos.Text = cliente["alergenos"]?.ToString();
                    txtDireccion.Text = cliente["direccion"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message);
            }
        }

        private void CargarHistorial()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(API_CITAS_URL);
                request.Method = "GET";
                request.Headers["Authorization"] = $"Bearer {_token}";

                using (var response = (HttpWebResponse)request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();
                    JArray citas = JArray.Parse(json);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("fecha");
                    dt.Columns.Add("horaInicio");
                    dt.Columns.Add("servicio");
                    dt.Columns.Add("grupo");
                    dt.Columns.Add("estado");
                    dt.Columns.Add("idCita", typeof(long));
                    dt.Columns.Add("tieneValoracion", typeof(bool));

                    // Obtener todas las valoraciones para marcar las citas
                    List<long> idsCitasValoradas = new List<long>();
                    try {
                        var valRequest = (HttpWebRequest)WebRequest.Create("http://217.154.179.135:8080/peluqueria/api/valoraciones");
                        valRequest.Method = "GET";
                        valRequest.Headers["Authorization"] = $"Bearer {_token}";
                        using (var valResponse = (HttpWebResponse)valRequest.GetResponse())
                        using (var valReader = new StreamReader(valResponse.GetResponseStream())) {
                            JArray vals = JArray.Parse(valReader.ReadToEnd());
                            foreach (var v in vals) {
                                long idCitaVal = v["cita"]?["idCita"]?.Value<long>() ?? 0;
                                if (idCitaVal > 0) idsCitasValoradas.Add(idCitaVal);
                            }
                        }
                    } catch { /* Ignorar si falla la carga de valoraciones */}

                    foreach (JObject cita in citas)
                    {
                        long idClienteCita = cita["cliente"]?["id"]?.Value<long>() ?? 0;
                        if (idClienteCita == _clienteId)
                        {
                            DataRow row = dt.NewRow();
                            row["fecha"] = cita["fecha"]?.ToString();
                            
                            string hora = cita["horaInicio"]?.ToString() ?? "";
                            row["horaInicio"] = hora.Length > 5 ? hora.Substring(0, 5) : hora;

                            var servicio = cita["horarioSemanal"]?["servicio"];
                            row["servicio"] = servicio?["nombre"]?.ToString() ?? "Sin servicio";

                            var grupo = cita["grupo"];
                            row["grupo"] = grupo != null ? $"{grupo["nombre"]} {grupo["apellidos"]}" : "Sin asignar";

                            row["estado"] = cita["estado"]?.ToString();
                            long idCita = cita["idCita"]?.Value<long>() ?? 0;
                            row["idCita"] = idCita;
                            row["tieneValoracion"] = idsCitasValoradas.Contains(idCita);

                            dt.Rows.Add(row);
                        }
                    }

                    // Ordenar por fecha descendente
                    DataView dv = dt.DefaultView;
                    dv.Sort = "fecha DESC, horaInicio DESC";
                    dgvHistorial.DataSource = dv.ToTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerValoracion_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una cita para ver su valoración.");
                return;
            }

            long idCita = Convert.ToInt64(dgvHistorial.CurrentRow.Cells["ColIdCita"].Value);

            try
            {
                // Consultar a la API si hay valoraciones para esta cita
                var request = (HttpWebRequest)WebRequest.Create($"http://217.154.179.135:8080/peluqueria/api/valoraciones/cita/{idCita}");
                request.Method = "GET";
                request.Headers["Authorization"] = $"Bearer {_token}";

                using (var response = (HttpWebResponse)request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();
                    JArray valoraciones = JArray.Parse(json);

                    if (valoraciones.Count > 0)
                    {
                        // Abrir info_Valoracion pasando el objeto de valoración
                        info_Valoracion formVal = new info_Valoracion((JObject)valoraciones[0]);
                        formVal.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Esta cita aún no ha sido valorada.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al comprobar la valoración: " + ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgvHistorial.DataSource is DataTable dt)
            {
                string filtro = txtBuscar.Text.Trim().Replace("'", "''");
                if (string.IsNullOrEmpty(filtro))
                {
                    dt.DefaultView.RowFilter = "";
                }
                else
                {
                    dt.DefaultView.RowFilter = string.Format(
                        "servicio LIKE '%{0}%' OR estado LIKE '%{0}%' OR fecha LIKE '%{0}%'",
                        filtro
                    );
                }
            }
        }

        private void dgvHistorial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvHistorial.Rows[e.RowIndex];
                // Comprobamos si la columna 'ColTieneValoracion' existe y tiene valor True
                if (row.Cells["ColTieneValoracion"].Value != null && (bool)row.Cells["ColTieneValoracion"].Value)
                {
                    // Fondo verde suave y texto oscuro para citas con valoración
                    e.CellStyle.BackColor = Color.FromArgb(200, 230, 201); // Verde pastel / Suave
                    e.CellStyle.SelectionBackColor = Color.FromArgb(76, 175, 80); // Verde más intenso al seleccionar
                }
            }
        }
    }
}
