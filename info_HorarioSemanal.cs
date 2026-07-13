using System;

using System.IO;

using System.Net;

using System.Text;

using System.Windows.Forms;

using Newtonsoft.Json.Linq;

namespace ProyectoPelu

{

    public partial class info_HorarioSemanal : Form

    {

        private const string API_HORARIOS_URL = "http://217.154.179.135:8080/peluqueria/api/horarios-semanales";

        private const string API_GRUPOS_URL = "http://217.154.179.135:8080/peluqueria/api/grupos";

        private const string API_SERVICIOS_URL = "http://217.154.179.135:8080/peluqueria/api/servicios";

        private readonly string _token;

        private long? _horarioId;

        // Constructor para crear nuevo horario

        public info_HorarioSemanal(string token)

        {

            InitializeComponent();

            _token = token;

            _horarioId = null;

        }

        // Constructor para editar horario existente (Carga API)

        public info_HorarioSemanal(string token, long horarioId)

        {

            InitializeComponent();

            _token = token;

            _horarioId = horarioId;

        }

        // Constructor para editar con datos YA cargados (Evita error 401/405)

        private string _diaPre;

        private string _horaInicioPre;

        private string _horaFinPre;

        private int _cupoPre;

        private long _grupoIdPre;

        private long _servicioIdPre;

        private string _servicioNombrePre;

        private bool _datosPreCargados = false;

        private long? _idServicioSeleccionado = null;

        public info_HorarioSemanal(string token, long horarioId, string dia, string hInicio, string hFin, int cupo, long grupoId, long servicioId, string servicioNombre)

        {

            InitializeComponent();

            _token = token;

            _horarioId = horarioId;

            _diaPre = dia;

            _horaInicioPre = hInicio;

            _horaFinPre = hFin;

            _cupoPre = cupo;

            _grupoIdPre = grupoId;

            _servicioIdPre = servicioId;

            _servicioNombrePre = servicioNombre;

            _datosPreCargados = true;

        }

        private void info_HorarioSemanal_Load(object sender, EventArgs e)

        {
            txtCupo.KeyPress += (s, ev) =>
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar))
                {
                    ev.Handled = true;
                }
            };


            CargarGrupos();

            if (_datosPreCargados)

            {

                CargarDatosPreCargados();

            }

            else if (_horarioId.HasValue)

            {

                CargarDatosHorario(_horarioId.Value);

            }

            else

            {

                // Valores por defecto para nuevo horario

                if (cmbDia.Items.Count > 0) cmbDia.SelectedIndex = 0;

                dtpHoraInicio.Value = DateTime.Today.AddHours(9);

                dtpHoraFin.Value = DateTime.Today.AddHours(10);

                txtCupo.Text = "10";

            }

        }

        private void CargarDatosPreCargados()

        {

            // Día

            for (int i = 0; i < cmbDia.Items.Count; i++)

            {

                if (cmbDia.Items[i].ToString() == _diaPre)

                {

                    cmbDia.SelectedIndex = i;

                    break;

                }

            }

            // Horas

            if (TimeSpan.TryParse(_horaInicioPre, out TimeSpan tsInicio))

                dtpHoraInicio.Value = DateTime.Today.Add(tsInicio);

            if (TimeSpan.TryParse(_horaFinPre, out TimeSpan tsFin))

                dtpHoraFin.Value = DateTime.Today.Add(tsFin);

            // Cupo

            txtCupo.Text = _cupoPre.ToString();

            // Grupo

            for (int i = 0; i < cmbGrupo.Items.Count; i++)

            {

                if (((ComboItem)cmbGrupo.Items[i]).Value == _grupoIdPre)

                {

                    cmbGrupo.SelectedIndex = i;

                    break;

                }

            }

            // Servicio

            _idServicioSeleccionado = _servicioIdPre;

            txtServicio.Text = _servicioNombrePre;

        }

        private void CargarGrupos()

        {

            try

            {

                var request = (HttpWebRequest)WebRequest.Create(API_GRUPOS_URL);

                request.Method = "GET";

                request.Headers["Authorization"] = $"Bearer {_token}";

                using (var response = (HttpWebResponse)request.GetResponse())

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))

                {

                    string responseBody = reader.ReadToEnd();

                    JArray grupos = JArray.Parse(responseBody);

                    cmbGrupo.Items.Clear();

                    cmbGrupo.DisplayMember = "Text";

                    cmbGrupo.ValueMember = "Value";

                    foreach (JObject grupo in grupos)

                    {

                        long id = grupo["id"]?.Value<long>() ?? 0;

                        string curso = grupo["curso"]?.ToString() ?? grupo["nombre"]?.ToString() ?? "Grupo";

                        cmbGrupo.Items.Add(new ComboItem(curso, id));

                    }

                }

            }

            catch (Exception ex) { MessageBox.Show("Error al cargar grupos: " + ex.Message); }

        }

        private void CargarServicios()

        {

            // Este método ya no es necesario para cargar un ComboBox,

            // la lógica se movió a btnBuscarServicio_Click

        }

        private void CargarDatosHorario(long id)

        {

            try

            {

                var request = (HttpWebRequest)WebRequest.Create($"{API_HORARIOS_URL}/{id}");

                request.Method = "GET";

                request.Headers["Authorization"] = $"Bearer {_token}";

                using (var response = (HttpWebResponse)request.GetResponse())

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))

                {

                    string responseBody = reader.ReadToEnd();

                    JObject horario = JObject.Parse(responseBody);

                    // Día

                    string dia = horario["diasSemana"]?.ToString();

                    for (int i = 0; i < cmbDia.Items.Count; i++)

                    {

                        if (cmbDia.Items[i].ToString() == dia)

                        {

                            cmbDia.SelectedIndex = i;

                            break;

                        }

                    }

                    // Horas

                    string horaInicio = horario["horaInicio"]?.ToString();

                    string horaFin = horario["horaFin"]?.ToString();

                    if (TimeSpan.TryParse(horaInicio, out TimeSpan tsInicio))

                        dtpHoraInicio.Value = DateTime.Today.Add(tsInicio);

                    if (TimeSpan.TryParse(horaFin, out TimeSpan tsFin))

                        dtpHoraFin.Value = DateTime.Today.Add(tsFin);

                    // Cupo

                    txtCupo.Text = horario["cupoMaximo"]?.ToString() ?? "0";

                    // Grupo

                    var grupo = horario["grupo"];

                    if (grupo != null)

                    {

                        long grupoId = grupo["id"]?.Value<long>() ?? 0;

                        for (int i = 0; i < cmbGrupo.Items.Count; i++)

                        {

                            if (((ComboItem)cmbGrupo.Items[i]).Value == grupoId)

                            {

                                cmbGrupo.SelectedIndex = i;

                                break;

                            }

                        }

                    }

                    // Servicio

                    var servicio = horario["servicio"];

                    if (servicio != null)

                    {

                        _idServicioSeleccionado = servicio["idServicio"]?.Value<long>() ?? 0;

                        txtServicio.Text = servicio["nombre"]?.ToString() ?? "Servicio";

                    }

                }

            }

            catch (Exception ex) { MessageBox.Show("Error al cargar horario: " + ex.Message); }

        }

        private void btnBuscarServicio_Click(object sender, EventArgs e)

        {

            try

            {

                var request = (HttpWebRequest)WebRequest.Create(API_SERVICIOS_URL);

                request.Method = "GET";

                request.Headers["Authorization"] = $"Bearer {_token}";

                using (var response = (HttpWebResponse)request.GetResponse())

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))

                {

                    string json = reader.ReadToEnd();

                    var lista = JArray.Parse(json).Select(s => new {

                        Id = s["idServicio"].Value<long>(),

                        Nombre = s["nombre"]?.ToString()

                    }).ToList();

                    using (var buscador = new Busqueda("Seleccionar Servicio", lista))

                    {

                        if (buscador.ShowDialog() == DialogResult.OK)

                        {

                            dynamic sel = buscador.ItemSeleccionado;

                            _idServicioSeleccionado = sel.Id;

                            txtServicio.Text = sel.Nombre;

                        }

                    }

                }

            }

            catch (Exception ex) { MessageBox.Show("Error al buscar servicios: " + ex.Message); }

        }

        private void btnGuardar_Click(object sender, EventArgs e)

        {

            // Validaciones

            if (cmbDia.SelectedItem == null)

            {

                MessageBox.Show("Seleccione un día de la semana.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;

            }

            if (cmbGrupo.SelectedItem == null)

            {

                MessageBox.Show("Seleccione un grupo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;

            }

            if (_idServicioSeleccionado == null)

            {

                MessageBox.Show("Seleccione un servicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;

            }

            if (!int.TryParse(txtCupo.Text, out int cupo) || cupo < 0)

            {

                MessageBox.Show("El cupo debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;

            }

            // Construir JSON con rol = GRUPO para cumplir con el polimorfismo de Jackson en el backend

            JObject horarioData = new JObject

            {

                { "diasSemana", cmbDia.SelectedItem.ToString() },

                { "horaInicio", dtpHoraInicio.Value.ToString("HH:mm:ss") },

                { "horaFin", dtpHoraFin.Value.ToString("HH:mm:ss") },

                { "cupoMaximo", cupo },

                { "grupo", new JObject { { "id", ((ComboItem)cmbGrupo.SelectedItem).Value }, { "rol", "GRUPO" } } },

                { "servicio", new JObject { { "idServicio", _idServicioSeleccionado.Value } } }

            };

            // FIX: Incluir ID si es edición

            if(_horarioId.HasValue)

            {

                horarioData.Add("idHorarioSemana", _horarioId.Value);

            }

            string metodo = _horarioId.HasValue ? "PUT" : "POST";

            string url = _horarioId.HasValue ? $"{API_HORARIOS_URL}/{_horarioId.Value}" : API_HORARIOS_URL;

            EnviarDatosAPI(metodo, url, horarioData);

        }

        private void EnviarDatosAPI(string metodo, string url, JObject data)

        {

            try

            {

                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = metodo;

                request.ContentType = "application/json";

                request.Headers["Authorization"] = $"Bearer {_token}";

                byte[] jsonBytes = Encoding.UTF8.GetBytes(data.ToString());

                request.ContentLength = jsonBytes.Length;

                using (var stream = request.GetRequestStream())

                {

                    stream.Write(jsonBytes, 0, jsonBytes.Length);

                }

                using (var response = (HttpWebResponse)request.GetResponse())

                {

                    if (response.StatusCode == HttpStatusCode.OK ||

                        response.StatusCode == HttpStatusCode.Created ||

                        response.StatusCode == HttpStatusCode.NoContent)

                    {

                        MessageBox.Show("Horario guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;

                        this.Close();

                    }

                    else

                    {

                        string errorBody = new StreamReader(response.GetResponseStream()).ReadToEnd();

                        MessageBox.Show($"Error {response.StatusCode}: {errorBody}", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

            }

            catch (WebException ex)

            {

                string errorMsg = "Error de red/API al guardar.";

                if (ex.Response != null)

                {

                    using (var errorStream = ex.Response.GetResponseStream())

                    using (var reader = new StreamReader(errorStream))

                    {

                        errorMsg = reader.ReadToEnd();

                    }

                }

                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

    }

    // Clase auxiliar para ComboBox con valor

    public class ComboItem

    {

        public string Text { get; set; }

        public long Value { get; set; }

        public ComboItem(string text, long value)

        {

            Text = text;

            Value = value;

        }

        public override string ToString() => Text;

    }

}
