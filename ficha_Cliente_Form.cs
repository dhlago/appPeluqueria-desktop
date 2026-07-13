using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ProyectoPelu
{
    public partial class ficha_Cliente_Form : Form
    {
        private readonly string _token;
        private readonly long _clienteId;
        private readonly string _nombreCliente;
        private JObject _originalClientObj;

        public ficha_Cliente_Form(string token, long clienteId, string nombreCliente)
        {
            InitializeComponent();
            _token = token;
            _clienteId = clienteId;
            _nombreCliente = nombreCliente;
            lblSubtitulo.Text = $"Cliente: {nombreCliente}";
            this.Load += new System.EventHandler(this.ficha_Cliente_Form_Load);
        }

        private void ficha_Cliente_Form_Load(object sender, EventArgs e)
        {
            CargarDatosFicha();
        }

        private void CargarDatosFicha()
        {
            string url = $"http://217.154.179.135:8080/peluqueria/api/clientes/{_clienteId}";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Headers["Authorization"] = $"Bearer {_token}";

                using (var response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseBody = reader.ReadToEnd();
                    _originalClientObj = JObject.Parse(responseBody);

                    string fichaTecnicaRaw = _originalClientObj["ficha_tecnica"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(fichaTecnicaRaw))
                    {
                        JObject ficha = JObject.Parse(fichaTecnicaRaw);
                        BindDatosFicha(ficha);
                    }
                    else
                    {
                        // Rellenar fecha de visita con el día de hoy como sugerencia si está vacío
                        txtFechaVisita.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la ficha del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDatosFicha(JObject ficha)
        {
            try
            {
                // Tab 1
                txtFechaVisita.Text = ficha["fechaVisita"]?.ToString();
                txtFrecuenciaLavado.Text = ficha["frecuenciaLavado"]?.ToString();
                txtProductos.Text = ficha["productosUtilizados"]?.ToString();

                chkCueroDescamacion.Checked = ficha["cueroDescamacion"]?.Value<bool>() ?? false;
                chkCueroGrasa.Checked = ficha["cueroGrasa"]?.Value<bool>() ?? false;
                chkCueroCaida.Checked = ficha["cueroCaida"]?.Value<bool>() ?? false;
                chkCueroPicor.Checked = ficha["cueroPicor"]?.Value<bool>() ?? false;
                chkCueroNormal.Checked = ficha["cueroNormal"]?.Value<bool>() ?? false;
                chkCueroSeco.Checked = ficha["cueroSeco"]?.Value<bool>() ?? false;
                chkCueroGraso.Checked = ficha["cueroGraso"]?.Value<bool>() ?? false;

                chkCabelloLiso.Checked = ficha["cabelloLiso"]?.Value<bool>() ?? false;
                chkCabelloOndulado.Checked = ficha["cabelloOndulado"]?.Value<bool>() ?? false;
                chkCabelloRizado.Checked = ficha["cabelloRizado"]?.Value<bool>() ?? false;

                txtAlteraciones.Text = ficha["alteraciones"]?.ToString();
                txtColorMatiz.Text = ficha["colorMatiz"]?.ToString();
                txtCanas.Text = ficha["canas"]?.ToString();
                txtGrosor.Text = ficha["grosor"]?.ToString();
                txtLongitud.Text = ficha["longitud"]?.ToString();
                txtObservaciones.Text = ficha["observaciones"]?.ToString();

                // Tab 2
                chkPalpacionNormal.Checked = ficha["palpacionNormal"]?.Value<bool>() ?? false;
                chkPalpacionHumedo.Checked = ficha["palpacionHumedo"]?.Value<bool>() ?? false;
                chkPalpacionUntuoso.Checked = ficha["palpacionUntuoso"]?.Value<bool>() ?? false;

                chkPresionNormal.Checked = ficha["presionNormal"]?.Value<bool>() ?? false;
                chkPresionDeficiente.Checked = ficha["presionDeficiente"]?.Value<bool>() ?? false;

                chkMovilizacionAdherencia.Checked = ficha["movilizacionAdherencia"]?.Value<bool>() ?? false;
                chkMovilizacionNo.Checked = ficha["movilizacionNoAdherencia"]?.Value<bool>() ?? false;

                chkJaquetPos.Checked = ficha["jaquetPositivo"]?.Value<bool>() ?? false;
                chkJaquetNeg.Checked = ficha["jaquetNegativo"]?.Value<bool>() ?? false;

                chkSaboraudPos.Checked = ficha["saboraudPositivo"]?.Value<bool>() ?? false;
                chkSaboraudNeg.Checked = ficha["saboraudNegativo"]?.Value<bool>() ?? false;

                chkPapelPos.Checked = ficha["papelPositivo"]?.Value<bool>() ?? false;
                chkPapelNeg.Checked = ficha["papelNegativo"]?.Value<bool>() ?? false;

                chkTexturaFinas.Checked = ficha["texturaFinas"]?.Value<bool>() ?? false;
                chkTexturaGruesas.Checked = ficha["texturaGruesas"]?.Value<bool>() ?? false;

                chkPuntasAbiertas.Checked = ficha["puntasAbiertas"]?.Value<bool>() ?? false;
                chkPuntasCerradas.Checked = ficha["puntasCerradas"]?.Value<bool>() ?? false;

                chkPullPos.Checked = ficha["pullPositivo"]?.Value<bool>() ?? false;
                chkPullNeg.Checked = ficha["pullNegativo"]?.Value<bool>() ?? false;

                chkDeslizarAlta.Checked = ficha["deslizarAlta"]?.Value<bool>() ?? false;
                chkDeslizarMedia.Checked = ficha["deslizarMedia"]?.Value<bool>() ?? false;
                chkDeslizarNinguna.Checked = ficha["deslizarNinguna"]?.Value<bool>() ?? false;

                chkCorneoMuyDes.Checked = ficha["corneoMuyDes"]?.Value<bool>() ?? false;
                chkCorneoDes.Checked = ficha["corneoDes"]?.Value<bool>() ?? false;
                chkCorneoNormal.Checked = ficha["corneoNormal"]?.Value<bool>() ?? false;
                chkCorneoMuyHid.Checked = ficha["corneoMuyHid"]?.Value<bool>() ?? false;

                chkSeboSeco.Checked = ficha["seboSeco"]?.Value<bool>() ?? false;
                chkSeboNormal.Checked = ficha["seboNormal"]?.Value<bool>() ?? false;
                chkSeboGraso.Checked = ficha["seboGraso"]?.Value<bool>() ?? false;
                chkSeboSeborrea.Checked = ficha["seboSeborrea"]?.Value<bool>() ?? false;

                chkPhNormal.Checked = ficha["phNormal"]?.Value<bool>() ?? false;
                chkPhAlto.Checked = ficha["phAlto"]?.Value<bool>() ?? false;
                chkPhBajo.Checked = ficha["phBajo"]?.Value<bool>() ?? false;

                chkWoodAmarillo.Checked = ficha["woodAmarillo"]?.Value<bool>() ?? false;
                chkWoodVioClaro.Checked = ficha["woodVioClaro"]?.Value<bool>() ?? false;
                chkWoodVioOscuro.Checked = ficha["woodVioOscuro"]?.Value<bool>() ?? false;
                chkWoodAzul.Checked = ficha["woodAzul"]?.Value<bool>() ?? false;
                chkWoodBlanco.Checked = ficha["woodBlanco"]?.Value<bool>() ?? false;
                chkWoodOscuro.Checked = ficha["woodOscuro"]?.Value<bool>() ?? false;
                chkWoodDebil.Checked = ficha["woodDebil"]?.Value<bool>() ?? false;

                chkMicroSueltas.Checked = ficha["microSueltas"]?.Value<bool>() ?? false;
                chkMicroPegadas.Checked = ficha["microPegadas"]?.Value<bool>() ?? false;
                chkMicroEritema.Checked = ficha["microEritema"]?.Value<bool>() ?? false;
                chkMicroGrasa.Checked = ficha["microGrasa"]?.Value<bool>() ?? false;
                chkMicroMini.Checked = ficha["microMini"]?.Value<bool>() ?? false;
                chkMicroObstruccion.Checked = ficha["microObstruccion"]?.Value<bool>() ?? false;
                chkMicroDebil.Checked = ficha["microDebil"]?.Value<bool>() ?? false;

                txtObsAparatologia.Text = ficha["obsAparatologia"]?.ToString();

                // Tab 3
                chkAnomTricorrexis.Checked = ficha["anomTricorrexis"]?.Value<bool>() ?? false;
                chkAnomMonilethrix.Checked = ficha["anomMonilethrix"]?.Value<bool>() ?? false;
                chkAnomPiliTorti.Checked = ficha["anomPiliTorti"]?.Value<bool>() ?? false;
                chkAnomPiliBifur.Checked = ficha["anomPiliBifur"]?.Value<bool>() ?? false;
                chkAnomTricInvag.Checked = ficha["anomTricInvag"]?.Value<bool>() ?? false;
                chkAnomTricotio.Checked = ficha["anomTricotio"]?.Value<bool>() ?? false;

                chkDanoCuticula.Checked = ficha["danoCuticula"]?.Value<bool>() ?? false;
                chkDanoPuntas.Checked = ficha["danoPuntas"]?.Value<bool>() ?? false;
                chkDanoTricoNodosa.Checked = ficha["danoTricoNodosa"]?.Value<bool>() ?? false;
                chkDanoTricoclasia.Checked = ficha["danoTricoclasia"]?.Value<bool>() ?? false;
                chkDanoTriconodosis.Checked = ficha["danoTriconodosis"]?.Value<bool>() ?? false;
                chkDanoTricolomania.Checked = ficha["danoTricolomania"]?.Value<bool>() ?? false;
                chkDanoBayoneta.Checked = ficha["danoBayoneta"]?.Value<bool>() ?? false;
                chkDanoEnfundado.Checked = ficha["danoEnfundado"]?.Value<bool>() ?? false;

                txtObsMicrovisor.Text = ficha["obsMicrovisor"]?.ToString();

                // Tricograma
                txtTricoFrontAnagena.Text = ficha["tricoFrontAnagena"]?.ToString();
                txtTricoFrontCatagena.Text = ficha["tricoFrontCatagena"]?.ToString();
                txtTricoFrontTelogena.Text = ficha["tricoFrontTelogena"]?.ToString();

                txtTricoTempIzqAnagena.Text = ficha["tricoTempIzqAnagena"]?.ToString();
                txtTricoTempIzqCatagena.Text = ficha["tricoTempIzqCatagena"]?.ToString();
                txtTricoTempIzqTelogena.Text = ficha["tricoTempIzqTelogena"]?.ToString();

                txtTricoTempDchoAnagena.Text = ficha["tricoTempDchoAnagena"]?.ToString();
                txtTricoTempDchoCatagena.Text = ficha["tricoTempDchoCatagena"]?.ToString();
                txtTricoTempDchoTelogena.Text = ficha["tricoTempDchoTelogena"]?.ToString();

                txtTricoParietalAnagena.Text = ficha["tricoParietalAnagena"]?.ToString();
                txtTricoParietalCatagena.Text = ficha["tricoParietalCatagena"]?.ToString();
                txtTricoParietalTelogena.Text = ficha["tricoParietalTelogena"]?.ToString();

                txtTricoOccipitalAnagena.Text = ficha["tricoOccipitalAnagena"]?.ToString();
                txtTricoOccipitalCatagena.Text = ficha["tricoOccipitalCatagena"]?.ToString();
                txtTricoOccipitalTelogena.Text = ficha["tricoOccipitalTelogena"]?.ToString();

                txtObsTricograma.Text = ficha["obsTricograma"]?.ToString();

                // Seguimiento
                dgvSeguimiento.Rows.Clear();
                JArray segArr = ficha["seguimiento"] as JArray;
                if (segArr != null)
                {
                    foreach (JObject item in segArr)
                    {
                        dgvSeguimiento.Rows.Add(item["fecha"]?.ToString(), item["datos"]?.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Advertencia al mapear algunos campos de la ficha: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddSeguimiento_Click(object sender, EventArgs e)
        {
            string hoy = DateTime.Now.ToString("yyyy-MM-dd");
            dgvSeguimiento.Rows.Add(hoy, "");
            // Enfocar la celda del texto para que el usuario pueda escribir de inmediato
            dgvSeguimiento.CurrentCell = dgvSeguimiento.Rows[dgvSeguimiento.Rows.Count - 1].Cells["ColDatosTecnicos"];
            dgvSeguimiento.BeginEdit(true);
        }

        private void btnRemoveSeguimiento_Click(object sender, EventArgs e)
        {
            if (dgvSeguimiento.SelectedRows.Count > 0)
            {
                dgvSeguimiento.Rows.Remove(dgvSeguimiento.SelectedRows[0]);
            }
            else if (dgvSeguimiento.CurrentRow != null)
            {
                dgvSeguimiento.Rows.Remove(dgvSeguimiento.CurrentRow);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_originalClientObj == null)
            {
                MessageBox.Show("No se han cargado los datos iniciales del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                JObject ficha = new JObject();

                // Tab 1
                ficha.Add("fechaVisita", txtFechaVisita.Text);
                ficha.Add("frecuenciaLavado", txtFrecuenciaLavado.Text);
                ficha.Add("productosUtilizados", txtProductos.Text);

                ficha.Add("cueroDescamacion", chkCueroDescamacion.Checked);
                ficha.Add("cueroGrasa", chkCueroGrasa.Checked);
                ficha.Add("cueroCaida", chkCueroCaida.Checked);
                ficha.Add("cueroPicor", chkCueroPicor.Checked);
                ficha.Add("cueroNormal", chkCueroNormal.Checked);
                ficha.Add("cueroSeco", chkCueroSeco.Checked);
                ficha.Add("cueroGraso", chkCueroGraso.Checked);

                ficha.Add("cabelloLiso", chkCabelloLiso.Checked);
                ficha.Add("cabelloOndulado", chkCabelloOndulado.Checked);
                ficha.Add("cabelloRizado", chkCabelloRizado.Checked);

                ficha.Add("alteraciones", txtAlteraciones.Text);
                ficha.Add("colorMatiz", txtColorMatiz.Text);
                ficha.Add("canas", txtCanas.Text);
                ficha.Add("grosor", txtGrosor.Text);
                ficha.Add("longitud", txtLongitud.Text);
                ficha.Add("observaciones", txtObservaciones.Text);

                // Tab 2
                ficha.Add("palpacionNormal", chkPalpacionNormal.Checked);
                ficha.Add("palpacionHumedo", chkPalpacionHumedo.Checked);
                ficha.Add("palpacionUntuoso", chkPalpacionUntuoso.Checked);

                ficha.Add("presionNormal", chkPresionNormal.Checked);
                ficha.Add("presionDeficiente", chkPresionDeficiente.Checked);

                ficha.Add("movilizacionAdherencia", chkMovilizacionAdherencia.Checked);
                ficha.Add("movilizacionNoAdherencia", chkMovilizacionNo.Checked);

                ficha.Add("jaquetPositivo", chkJaquetPos.Checked);
                ficha.Add("jaquetNegativo", chkJaquetNeg.Checked);

                ficha.Add("saboraudPositivo", chkSaboraudPos.Checked);
                ficha.Add("saboraudNegativo", chkSaboraudNeg.Checked);

                ficha.Add("papelPositivo", chkPapelPos.Checked);
                ficha.Add("papelNegativo", chkPapelNeg.Checked);

                ficha.Add("texturaFinas", chkTexturaFinas.Checked);
                ficha.Add("texturaGruesas", chkTexturaGruesas.Checked);

                ficha.Add("puntasAbiertas", chkPuntasAbiertas.Checked);
                ficha.Add("puntasCerradas", chkPuntasCerradas.Checked);

                ficha.Add("pullPositivo", chkPullPos.Checked);
                ficha.Add("pullNegativo", chkPullNeg.Checked);

                ficha.Add("deslizarAlta", chkDeslizarAlta.Checked);
                ficha.Add("deslizarMedia", chkDeslizarMedia.Checked);
                ficha.Add("deslizarNinguna", chkDeslizarNinguna.Checked);

                ficha.Add("corneoMuyDes", chkCorneoMuyDes.Checked);
                ficha.Add("corneoDes", chkCorneoDes.Checked);
                ficha.Add("corneoNormal", chkCorneoNormal.Checked);
                ficha.Add("corneoMuyHid", chkCorneoMuyHid.Checked);

                ficha.Add("seboSeco", chkSeboSeco.Checked);
                ficha.Add("seboNormal", chkSeboNormal.Checked);
                ficha.Add("seboGraso", chkSeboGraso.Checked);
                ficha.Add("seboSeborrea", chkSeboSeborrea.Checked);

                ficha.Add("phNormal", chkPhNormal.Checked);
                ficha.Add("phAlto", chkPhAlto.Checked);
                ficha.Add("phBajo", chkPhBajo.Checked);

                ficha.Add("woodAmarillo", chkWoodAmarillo.Checked);
                ficha.Add("woodVioClaro", chkWoodVioClaro.Checked);
                ficha.Add("woodVioOscuro", chkWoodVioOscuro.Checked);
                ficha.Add("woodAzul", chkWoodAzul.Checked);
                ficha.Add("woodBlanco", chkWoodBlanco.Checked);
                ficha.Add("woodOscuro", chkWoodOscuro.Checked);
                ficha.Add("woodDebil", chkWoodDebil.Checked);

                ficha.Add("microSueltas", chkMicroSueltas.Checked);
                ficha.Add("microPegadas", chkMicroPegadas.Checked);
                ficha.Add("microEritema", chkMicroEritema.Checked);
                ficha.Add("microGrasa", chkMicroGrasa.Checked);
                ficha.Add("microMini", chkMicroMini.Checked);
                ficha.Add("microObstruccion", chkMicroObstruccion.Checked);
                ficha.Add("microDebil", chkMicroDebil.Checked);

                ficha.Add("obsAparatologia", txtObsAparatologia.Text);

                // Tab 3
                ficha.Add("anomTricorrexis", chkAnomTricorrexis.Checked);
                ficha.Add("anomMonilethrix", chkAnomMonilethrix.Checked);
                ficha.Add("anomPiliTorti", chkAnomPiliTorti.Checked);
                ficha.Add("anomPiliBifur", chkAnomPiliBifur.Checked);
                ficha.Add("anomTricInvag", chkAnomTricInvag.Checked);
                ficha.Add("anomTricotio", chkAnomTricotio.Checked);

                ficha.Add("danoCuticula", chkDanoCuticula.Checked);
                ficha.Add("danoPuntas", chkDanoPuntas.Checked);
                ficha.Add("danoTricoNodosa", chkDanoTricoNodosa.Checked);
                ficha.Add("danoTricoclasia", chkDanoTricoclasia.Checked);
                ficha.Add("danoTriconodosis", chkDanoTriconodosis.Checked);
                ficha.Add("danoTricolomania", chkDanoTricolomania.Checked);
                ficha.Add("danoBayoneta", chkDanoBayoneta.Checked);
                ficha.Add("danoEnfundado", chkDanoEnfundado.Checked);

                ficha.Add("obsMicrovisor", txtObsMicrovisor.Text);

                // Tricograma
                ficha.Add("tricoFrontAnagena", txtTricoFrontAnagena.Text);
                ficha.Add("tricoFrontCatagena", txtTricoFrontCatagena.Text);
                ficha.Add("tricoFrontTelogena", txtTricoFrontTelogena.Text);

                ficha.Add("tricoTempIzqAnagena", txtTricoTempIzqAnagena.Text);
                ficha.Add("tricoTempIzqCatagena", txtTricoTempIzqCatagena.Text);
                ficha.Add("tricoTempIzqTelogena", txtTricoTempIzqTelogena.Text);

                ficha.Add("tricoTempDchoAnagena", txtTricoTempDchoAnagena.Text);
                ficha.Add("tricoTempDchoCatagena", txtTricoTempDchoCatagena.Text);
                ficha.Add("tricoTempDchoTelogena", txtTricoTempDchoTelogena.Text);

                ficha.Add("tricoParietalAnagena", txtTricoParietalAnagena.Text);
                ficha.Add("tricoParietalCatagena", txtTricoParietalCatagena.Text);
                ficha.Add("tricoParietalTelogena", txtTricoParietalTelogena.Text);

                ficha.Add("tricoOccipitalAnagena", txtTricoOccipitalAnagena.Text);
                ficha.Add("tricoOccipitalCatagena", txtTricoOccipitalCatagena.Text);
                ficha.Add("tricoOccipitalTelogena", txtTricoOccipitalTelogena.Text);

                ficha.Add("obsTricograma", txtObsTricograma.Text);

                // Seguimiento
                JArray segArr = new JArray();
                foreach (DataGridViewRow row in dgvSeguimiento.Rows)
                {
                    if (row.IsNewRow) continue;
                    JObject item = new JObject();
                    item.Add("fecha", row.Cells[0].Value?.ToString() ?? "");
                    item.Add("datos", row.Cells[1].Value?.ToString() ?? "");
                    segArr.Add(item);
                }
                ficha.Add("seguimiento", segArr);

                // Actualizar el objeto cliente original con la nueva ficha_tecnica serializada como JSON string
                string fichaJsonString = ficha.ToString(Newtonsoft.Json.Formatting.None);
                _originalClientObj["ficha_tecnica"] = fichaJsonString;

                // Si grupo es un objeto anidado en la respuesta pero el PUT requiere solo el ID, se puede limpiar o dejar
                // Para evitar errores en Spring Boot si grupo_id es nulo, dejamos que Jackson maneje el grupo.

                // Enviar la petición PUT
                string url = $"http://217.154.179.135:8080/peluqueria/api/clientes/{_clienteId}";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "PUT";
                request.ContentType = "application/json";
                request.Headers["Authorization"] = $"Bearer {_token}";

                byte[] jsonBytes = Encoding.UTF8.GetBytes(_originalClientObj.ToString());
                request.ContentLength = jsonBytes.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(jsonBytes, 0, jsonBytes.Length);
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
                    {
                        MessageBox.Show("Ficha técnica de diagnóstico guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        string err = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        MessageBox.Show($"Error al guardar ({response.StatusCode}): {err}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la ficha técnica: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
