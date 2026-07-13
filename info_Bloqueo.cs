using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ProyectoPelu
{
    public partial class info_Bloqueo : Form
    {
        // Asegúrate de que esta URL coincide con tu Controller de Java
        private const string API_URL = "http://217.154.179.135:8080/peluqueria/api/bloqueos-horarios";
        private string _token;

        public info_Bloqueo(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private void info_Bloqueo_Load(object sender, EventArgs e)
        {
            // Configuración inicial
            dtpFecha.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            dtpFecha.MinDate = DateTime.Now.Date;
            dtpFechaFin.MinDate = DateTime.Now.Date;

            chkVariosDias.Checked = false;
            chkVariosDias_CheckedChanged(null, null);

            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraFin.Format = DateTimePickerFormat.Custom;
            dtpHoraFin.CustomFormat = "HH:mm";

            // Valores por defecto
            dtpHoraInicio.Value = DateTime.Now.Date.AddHours(9);
            dtpHoraFin.Value = DateTime.Now.Date.AddHours(10);
            chkTodoElDia_CheckedChanged(null, null);
        }

        private void chkTodoElDia_CheckedChanged(object sender, EventArgs e)
        {
            // Si es todo el día, deshabilitamos los selectores de hora
            bool esTodoElDia = chkTodoElDia.Checked;
            dtpHoraInicio.Enabled = !esTodoElDia;
            dtpHoraFin.Enabled = !esTodoElDia;

            lblHoraInicio.ForeColor = esTodoElDia ? Color.Gray : Color.Black;
            lblHoraFin.ForeColor = esTodoElDia ? Color.Gray : Color.Black;
        }

        private void chkVariosDias_CheckedChanged(object sender, EventArgs e)
        {
            bool variosDias = chkVariosDias.Checked;
            lblFechaFin.Visible = variosDias;
            dtpFechaFin.Visible = variosDias;

            if (!variosDias)
            {
                dtpFechaFin.Value = dtpFecha.Value;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtMotivo.Text))
                {
                    MessageBox.Show("Por favor, escribe un motivo.");
                    return;
                }

                if (dtpFechaFin.Value.Date < dtpFecha.Value.Date)
                {
                    MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.");
                    return;
                }

                // 2. Construir el objeto JSON
                // Nota: Ajustamos las horas. Si es 'Todo el día', Java suele esperar nulos o ignorarlos, 
                // pero enviaremos las horas seleccionadas o nulas según tu lógica de backend.

                var payload = new
                {
                    fecha = dtpFecha.Value.ToString("yyyy-MM-dd"),
                    motivo = txtMotivo.Text,
                    todoElDia = chkTodoElDia.Checked,
                    // Si es todo el día, enviamos null en las horas (o ignora esto si tu backend requiere horas fijas)
                    horaInicio = chkTodoElDia.Checked ? null : dtpHoraInicio.Value.ToString("HH:mm:ss"),
                    horaFin = chkTodoElDia.Checked ? null : dtpHoraFin.Value.ToString("HH:mm:ss")
                };

                string json = JsonConvert.SerializeObject(payload);
                string finalUrl = API_URL;

                if (chkVariosDias.Checked)
                {
                    string fechaFinStr = dtpFechaFin.Value.ToString("yyyy-MM-dd");
                    finalUrl += $"?fechaFin={fechaFinStr}";
                }

                // 3. Enviar al servidor
                SendToApi(finalUrl, "POST", json);

                MessageBox.Show("Bloqueo creado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        // --- MÉTODOS DE RED (Iguales a los que ya te funcionan) ---

        private void SendToApi(string url, string method, string json)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.ContentType = "application/json";
            request.AllowAutoRedirect = false; // Importante para evitar error 405

            if (!string.IsNullOrEmpty(_token))
                request.Headers["Authorization"] = "Bearer " + _token;

            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(json);
            }

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.Redirect)
                        throw new Exception("Error de redirección en API.");
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        string errorServer = reader.ReadToEnd();
                        throw new Exception($"Error del servidor: {errorServer}");
                    }
                }
                throw;
            }
        }
    }
}
