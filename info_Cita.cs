using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProyectoPelu
{
    public partial class info_Cita : Form
    {
        private const string BASE_URL = "http://217.154.179.135:8080/peluqueria/api";
        private long? _idCita = null;

        // Variables de estado
        private long? _idServicioSeleccionado = null;
        private long? _idGrupoSeleccionado = null;
        private long? _idHorarioSemanalSeleccionado = null;

        // NUEVA VARIABLE: Para calcular la hora de fin
        private int _duracionMinutos = 30; // Valor por defecto

        private List<string> diasValidosServicio = new List<string>();

        public info_Cita(long? idCita = null)
        {
            InitializeComponent();
            _idCita = idCita;

            if (_idCita.HasValue)
            {
                lblTitulo.Text = "Editar Cita";
                btnGuardar.Text = "Actualizar";
            }

            // Inicializar ComboBox Estado
            cbEstado.Items.Add("CONFIRMADA");
            cbEstado.Items.Add("COMPLETADA");
            cbEstado.Items.Add("CANCELADA");
            cbEstado.SelectedIndex = 0; // Default: CONFIRMADA

            // Si es nueva cita, ocultamos el estado (siempre nace confirmada)
            if (!_idCita.HasValue)
            {
                lblEstado.Visible = false;
                cbEstado.Visible = false;
            }

            // Restricción: GRUPO no puede editar citas existentes (solo leerlas o crear nuevas)
            if (Session.Rol == "GRUPO" && _idCita.HasValue)
            {
                btnGuardar.Visible = false;
            }
        }

        private void info_Cita_Load(object sender, EventArgs e)
        {
            CargarClientes();
            if (_idCita.HasValue)
            {
                CargarDatosCita(_idCita.Value);
            }
        }

        private void CargarClientes()
        {
            try
            {
                string json = GetFromApi($"{BASE_URL}/usuarios");
                JArray arr = JArray.Parse(json);
                var lista = arr.Where(u => u["rol"]?.ToString() == "CLIENTE")
                               .Select(u => new { Id = u["id"].Value<long>(), Nombre = $"{u["nombre"]} {u["apellidos"]}" })
                               .ToList();

                cbClientes.DataSource = lista;
                cbClientes.DisplayMember = "Nombre";
                cbClientes.ValueMember = "Id";
            }
            catch (Exception ex) { MessageBox.Show("Error cargando clientes: " + ex.Message); }
        }

        private void CargarDatosCita(long id)
        {
            try
            {
                string json = GetFromApi($"{BASE_URL}/citas/{id}");
                JObject cita = JObject.Parse(json);

                // 1. Cliente
                if (cita["cliente"] != null)
                    cbClientes.SelectedValue = cita["cliente"]["id"].Value<long>();

                // 2. Servicio y Duración
                var servicio = cita["horarioSemanal"]?["servicio"];
                if (servicio != null)
                {
                    _idServicioSeleccionado = servicio["idServicio"].Value<long>();
                    txtServicio.Text = servicio["nombre"]?.ToString();

                    // Recuperamos duración para poder calcular horaFin al editar
                    int bloques = servicio["duracionBloques"]?.Value<int>() ?? 1;
                    _duracionMinutos = bloques * 15;
                    lblDuracion.Text = $"Duración: {_duracionMinutos} min";

                    ActualizarDiasDisponiblesEnCalendario();
                }

                // 3. Grupo
                var grupo = cita["grupo"];
                if (grupo != null)
                {
                    _idGrupoSeleccionado = grupo["id"].Value<long>();
                    txtGrupo.Text = $"{grupo["nombre"]} {grupo["apellidos"]}";
                    txtGrupo.BackColor = Color.LightGreen;
                }

                // 4. Fecha y Horario
                string fechaStr = cita["fecha"]?.ToString();
                if (!string.IsNullOrEmpty(fechaStr))
                {
                    monthCalendarCitas.SetDate(DateTime.Parse(fechaStr));
                }

                if (cita["horarioSemanal"] != null)
                {
                    _idHorarioSemanalSeleccionado = cita["horarioSemanal"]["idHorarioSemana"].Value<long>();
                    string horaInicioTurno = cita["horarioSemanal"]["horaInicio"].ToString();
                    string horaFinTurno = cita["horarioSemanal"]["horaFin"].ToString();
                    GenerarHorasDisponibles(horaInicioTurno, horaFinTurno);
                }

                // 5. Hora seleccionada
                string horaCita = cita["horaInicio"]?.ToString();
                if (!string.IsNullOrEmpty(horaCita))
                {
                    string horaCorta = horaCita.Length >= 5 ? horaCita.Substring(0, 5) : horaCita;
                    if (!cbHoras.Items.Contains(horaCorta)) cbHoras.Items.Add(horaCorta);
                    cbHoras.SelectedItem = horaCorta;
                }

                // 6. Estado
                string estado = cita["estado"]?.ToString();
                if (!string.IsNullOrEmpty(estado) && cbEstado.Items.Contains(estado))
                {
                    cbEstado.SelectedItem = estado;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error cargando cita: " + ex.Message); }
        }

        private void btnBuscarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                string json = GetFromApi($"{BASE_URL}/servicios");
                // Mapeamos para el buscador, calculando la duración en minutos
                var lista = JArray.Parse(json).Select(s => new {
                    Id = s["idServicio"].Value<long>(),
                    Nombre = s["nombre"]?.ToString(),
                    DuracionMinutos = (s["duracionBloques"]?.Value<int>() ?? 1) * 15, // Guardamos el int
                    TextoDuracion = ((s["duracionBloques"]?.Value<int>() ?? 1) * 15) + " min" // Para mostrar
                }).ToList();

                using (var buscador = new Busqueda("Seleccionar Servicio", lista))
                {
                    if (buscador.ShowDialog() == DialogResult.OK)
                    {
                        dynamic sel = buscador.ItemSeleccionado;
                        _idServicioSeleccionado = sel.Id;
                        txtServicio.Text = sel.Nombre;

                        // ACTUALIZAMOS LA DURACIÓN
                        _duracionMinutos = sel.DuracionMinutos;
                        lblDuracion.Text = $"Duración: {_duracionMinutos} min";

                        ActualizarDiasDisponiblesEnCalendario();
                        ValidarDisponibilidadYHoras();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void ActualizarDiasDisponiblesEnCalendario()
        {
            if (!_idServicioSeleccionado.HasValue) return;

            try
            {
                string json = GetFromApi($"{BASE_URL}/horarios-semanales");
                JArray horarios = JArray.Parse(json);

                diasValidosServicio = horarios
                    .Where(h => h["servicio"]["idServicio"].Value<long>() == _idServicioSeleccionado.Value)
                    .Select(h => h["diasSemana"].ToString().ToUpper())
                    .Distinct()
                    .ToList();

                List<DateTime> fechasNegrita = new List<DateTime>();
                DateTime inicio = DateTime.Today.AddDays(-30);
                for (int i = 0; i < 90; i++)
                {
                    DateTime d = inicio.AddDays(i);
                    if (diasValidosServicio.Contains(TraducirDia(d.DayOfWeek)))
                        fechasNegrita.Add(d);
                }
                monthCalendarCitas.BoldedDates = fechasNegrita.ToArray();
            }
            catch { }
        }

        private void monthCalendarCitas_DateSelected(object sender, DateRangeEventArgs e)
        {
            ValidarDisponibilidadYHoras();
        }

        private void ValidarDisponibilidadYHoras()
        {
            if (!_idServicioSeleccionado.HasValue) return;

            DateTime fechaSel = monthCalendarCitas.SelectionStart;
            string diaBusqueda = TraducirDia(fechaSel.DayOfWeek);

            if (EsDiaBloqueado(fechaSel))
            {
                txtGrupo.Text = "⛔ DÍA BLOQUEADO";
                txtGrupo.BackColor = Color.LightCoral;
                cbHoras.Items.Clear();
                _idGrupoSeleccionado = null;
                return;
            }

            if (!diasValidosServicio.Contains(diaBusqueda))
            {
                txtGrupo.Text = "SIN SERVICIO";
                txtGrupo.BackColor = Color.MistyRose;
                cbHoras.Items.Clear();
                _idGrupoSeleccionado = null;
                return;
            }

            try
            {
                string json = GetFromApi($"{BASE_URL}/horarios-semanales");
                JArray horarios = JArray.Parse(json);

                var horarioValido = horarios.FirstOrDefault(h =>
                    h["servicio"]["idServicio"].Value<long>() == _idServicioSeleccionado.Value &&
                    h["diasSemana"].ToString().Equals(diaBusqueda, StringComparison.OrdinalIgnoreCase)
                );

                if (horarioValido != null)
                {
                    _idGrupoSeleccionado = horarioValido["grupo"]["id"].Value<long>();
                    _idHorarioSemanalSeleccionado = horarioValido["idHorarioSemana"].Value<long>();

                    txtGrupo.Text = $"{horarioValido["grupo"]["nombre"]} {horarioValido["grupo"]["apellidos"]}";
                    txtGrupo.BackColor = Color.LightGreen;

                    GenerarHorasDisponibles(horarioValido["horaInicio"].ToString(), horarioValido["horaFin"].ToString());
                }
                else
                {
                    txtGrupo.Text = "SIN PERSONAL";
                    txtGrupo.BackColor = Color.MistyRose;
                    cbHoras.Items.Clear();
                }
            }
            catch { }
        }

        private void GenerarHorasDisponibles(string inicioStr, string finStr)
        {
            cbHoras.Items.Clear();
            try
            {
                DateTime hora = DateTime.Parse(inicioStr);
                DateTime fin = DateTime.Parse(finStr);

                bool esHoy = monthCalendarCitas.SelectionStart.Date == DateTime.Today;
                DateTime ahora = DateTime.Now;

                // Generamos horas cada 30 min (puedes cambiarlo a 15 si prefieres)
                while (hora.AddMinutes(_duracionMinutos) <= fin)
                {
                    // Si es hoy, no mostrar horas pasadas
                    if (!esHoy || hora.TimeOfDay > ahora.TimeOfDay)
                    {
                        cbHoras.Items.Add(hora.ToString("HH:mm"));
                    }
                    hora = hora.AddMinutes(30);
                }
                if (cbHoras.Items.Count > 0) cbHoras.SelectedIndex = 0;
            }
            catch { }
        }

        // --- AQUÍ ESTABA EL ERROR 400 ---
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbClientes.SelectedValue == null || !_idServicioSeleccionado.HasValue || _idGrupoSeleccionado == null || cbHoras.SelectedItem == null)
            {
                MessageBox.Show("Faltan datos (Cliente, Servicio, Fecha u Hora).");
                return;
            }

            // Validar Bloqueo
            if (EsDiaBloqueado(monthCalendarCitas.SelectionStart))
            {
                MessageBox.Show("No se puede reservar: El día seleccionado está bloqueado por la empresa.");
                return;
            }

            try
            {
                // 1. Calcular Hora Fin
                string horaInicioStr = cbHoras.SelectedItem.ToString(); // "09:50"
                DateTime horaInicioDt = DateTime.Parse(horaInicioStr);
                DateTime horaFinDt = horaInicioDt.AddMinutes(_duracionMinutos);
                string horaFinStr = horaFinDt.ToString("HH:mm");

                // 2. Construir JSON COMPLETO (Incluyendo horaFin y roles obligatorios para Jackson Polymorphism)
                var jsonBody = new
                {
                    fecha = monthCalendarCitas.SelectionStart.ToString("yyyy-MM-dd"),
                    horaInicio = horaInicioStr + ":00",
                    horaFin = horaFinStr + ":00",  // <--- ESTO FALTABA
                    estado = _idCita.HasValue ? (cbEstado.SelectedItem?.ToString() ?? "CONFIRMADA") : "CONFIRMADA", // <--- Safe check
                    cliente = new { id = Convert.ToInt64(cbClientes.SelectedValue), rol = "CLIENTE" }, // <--- Se agrega rol para Jackson Polymorphism
                    grupo = new { id = _idGrupoSeleccionado.Value, rol = "GRUPO" }, // <--- Se agrega rol para Jackson Polymorphism
                    horarioSemanal = new { idHorarioSemana = _idHorarioSemanalSeleccionado.Value }
                };

                string url = _idCita.HasValue ? $"{BASE_URL}/citas/{_idCita}" : $"{BASE_URL}/citas/reservar";
                string method = _idCita.HasValue ? "PUT" : "POST";

                SendToApi(url, method, JsonConvert.SerializeObject(jsonBody));

                // --- NUEVO: ACTUALIZAR ESTADO SI ES EDICIÓN ---
                if (_idCita.HasValue)
                {
                    string estadoSeleccionado = cbEstado.SelectedItem.ToString();
                    int opcion = -1;
                    if (estadoSeleccionado == "CONFIRMADA") opcion = 0;
                    else if (estadoSeleccionado == "CANCELADA") opcion = 1;
                    else if (estadoSeleccionado == "COMPLETADA") opcion = 2; // Requiere backend actualizado

                    if (opcion != -1)
                    {
                        // Llamada extra solo para el estado
                        try
                        {
                            SendToApi($"{BASE_URL}/citas/{_idCita}/estado/{opcion}", "PUT", "");
                        }
                        catch { /* Si falla el estado, al menos se guardó lo otro */ }
                    }
                }

                MessageBox.Show("Cita guardada correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Muestra el mensaje detallado si falla
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private bool EsDiaBloqueado(DateTime fecha)
        {
            try
            {
                // Consultamos la API de bloqueos
                // Idealmente, esto deberia estar cacheado o filtrar por rango, 
                // pero por simplicidad traemos todos y verificamos.
                string json = GetFromApi("http://217.154.179.135:8080/peluqueria/api/bloqueos-horarios");
                JArray bloqueos = JArray.Parse(json);
                string fechaStr = fecha.ToString("yyyy-MM-dd");

                foreach (var b in bloqueos)
                {
                    // Si hay un bloqueo para esta fecha
                    if (b["fecha"]?.ToString() == fechaStr)
                    {
                        // Si es todo el dia (horaInicio 00:00 y fin 23:59 o null)
                        // O si choca con la hora seleccionada (mas complejo), 
                        // aqui asumiremos bloqueo TOTAL del dia si existe registro,
                        // o podemos verificar si cubre "todo el dia"
                        
                        // Simplificacion: Si existe bloqueo en esa fecha, avisamos.
                        // Podriamos refinar para ver si es parcial.
                        return true; 
                    }
                }
            }
            catch { /* Ignorar errores de red en validacion no-critica */ }
            return false;
        }

        private string TraducirDia(DayOfWeek dia)
        {
            switch (dia)
            {
                case DayOfWeek.Monday: return "LUNES";
                case DayOfWeek.Tuesday: return "MARTES";
                case DayOfWeek.Wednesday: return "MIERCOLES";
                case DayOfWeek.Thursday: return "JUEVES";
                case DayOfWeek.Friday: return "VIERNES";
                case DayOfWeek.Saturday: return "SABADO";
                case DayOfWeek.Sunday: return "DOMINGO";
                default: return "";
            }
        }

        private string GetFromApi(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            if (!string.IsNullOrEmpty(Session.Token)) request.Headers["Authorization"] = "Bearer " + Session.Token;
            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream())) return reader.ReadToEnd();
        }

        private void SendToApi(string url, string method, string json)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.ContentType = "application/json";
            if (!string.IsNullOrEmpty(Session.Token)) request.Headers["Authorization"] = "Bearer " + Session.Token;

            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(json);
            }

            // Leemos la respuesta para asegurarnos de capturar errores del servidor
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse()) { }
            }
            catch (WebException ex)
            {
                string serverError = null;
                if (ex.Response != null)
                {
                    try
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        using (var reader = new StreamReader(stream))
                        {
                            serverError = reader.ReadToEnd();
                        }
                    }
                    catch { }
                }

                if (!string.IsNullOrWhiteSpace(serverError))
                {
                    throw new Exception(serverError);
                }
                throw new Exception(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}
