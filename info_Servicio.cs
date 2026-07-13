using System;

using System.Data;

using System.Windows.Forms;

using System.Net.Http;

using System.Text;

using System.Threading.Tasks;

using Newtonsoft.Json;

using Newtonsoft.Json.Linq;

namespace appPeluqueriaDesktop

{

    public partial class info_Servicio : Form

    {

        private const string API_BASE_URL = "http://217.154.179.135:8080/peluqueria/api";

        private const string API_SERVICE_URL = API_BASE_URL + "/servicios";

        private const string API_TIPOSERVICIO_URL = API_BASE_URL + "/tipos-servicio";

        private readonly string _token;

        private long? _servicioId;

        private string _base64Imagen = null;

        public info_Servicio(string token, long? idServicio = null)

        {

            txtDuracion.KeyPress += (s, ev) =>

            {

                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar))

                {

                    ev.Handled = true;

                }

            };

            txtPrecio.KeyPress += (s, ev) =>

            {

                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && ev.KeyChar != '.' && ev.KeyChar != ',')

                {

                    ev.Handled = true;

                }

                if (ev.KeyChar == '.' || ev.KeyChar == ',')

                {

                    if (txtPrecio.Text.Contains(".") || txtPrecio.Text.Contains(","))

                    {

                        ev.Handled = true;

                    }

                }

            };

            InitializeComponent();

            _token = token;

            _servicioId = idServicio;

            btnGuardar.Click += btnGuardar_Click;

            btnSubirImagen.Click += btnSubirImagen_Click;

            Load += Form5_Load;

            Text = _servicioId.HasValue ? $"Editar Servicio (ID: {_servicioId.Value})" : "Nuevo Servicio";

        }

        // ============================

        // CARGA DE DATOS

        // ============================

        private async Task CargarDatosServicioAsync(long id)

        {

            string url = $"{API_SERVICE_URL}/{id}";

            using (var client = new HttpClient())

            {

                client.DefaultRequestHeaders.Authorization =

                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)

                {

                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject serviceObject = JObject.Parse(responseBody);

                    txtNombreServicio.Text = serviceObject["nombre"]?.ToString();

                    txtDescripcion.Text = serviceObject["descripcion"]?.ToString();

                    txtDuracion.Text = serviceObject["duracionBloques"]?.ToString();

                    txtPrecio.Text = serviceObject["precio"]?.ToString();

                    txtCategoria.Text = serviceObject["tipoServicio"]?["nombre"]?.ToString();

                    _base64Imagen = serviceObject["imagenBase64"]?.ToString();

                    if (!string.IsNullOrEmpty(_base64Imagen))

                    {

                        try

                        {

                            byte[] imageBytes = Convert.FromBase64String(_base64Imagen);

                            using (var ms = new MemoryStream(imageBytes))

                            {

                                pbImagen.Image = Image.FromStream(ms);

                            }

                        }

                        catch { /* Ignorar error de formato */ }

                    }

                }

                else

                {

                    MessageBox.Show($"Error al cargar servicio: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Close();

                }

            }

        }

        private async void Form5_Load(object sender, EventArgs e)

        {

            if (_servicioId.HasValue)

                await CargarDatosServicioAsync(_servicioId.Value);

        }

        // ============================

        // GUARDAR

        // ============================

        private async void btnGuardar_Click(object sender, EventArgs e)

        {

            if (string.IsNullOrWhiteSpace(txtNombreServicio.Text) ||

                string.IsNullOrWhiteSpace(txtPrecio.Text) ||

                string.IsNullOrWhiteSpace(txtCategoria.Text))

            {

                MessageBox.Show("Complete Nombre, Precio y Categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;

            }

                        string precioText = txtPrecio.Text.Trim().Replace(',', '.');
            if (!int.TryParse(txtDuracion.Text, out int duracionBloques) ||
                !double.TryParse(precioText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double precio))
            {
                MessageBox.Show("Duración y Precio deben ser numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long tipoServicioId = await ObtenerTipoServicioIdAsync(txtCategoria.Text.Trim());

            if (tipoServicioId == 0)

            {

                MessageBox.Show("Categoría no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            var servicioDto = new

            {

                idServicio = _servicioId.HasValue ? _servicioId.Value : (long?)null,

                nombre = txtNombreServicio.Text.Trim(),

                descripcion = txtDescripcion.Text ?? "",

                duracionBloques = duracionBloques,

                precio = precio,

                tipoServicio = new { id = tipoServicioId },

                imagenBase64 = _base64Imagen

            };

            string jsonPayload = JsonConvert.SerializeObject(servicioDto);

            string url = _servicioId.HasValue ? $"{API_SERVICE_URL}/{_servicioId.Value}" : API_SERVICE_URL;

            HttpMethod method = _servicioId.HasValue ? HttpMethod.Put : HttpMethod.Post;

            bool exito = await EnviarServicioApiAsync(url, method, jsonPayload);

            if (exito)

            {

                MessageBox.Show("Servicio guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;

                Close();

            }

            else

            {

                MessageBox.Show("Error al guardar servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        // ============================

        // OBTENER TIPO SERVICIO

        // ============================

        private async Task<long> ObtenerTipoServicioIdAsync(string nombreTipo)

        {

            string nombreNormalizado = NormalizarCadena(nombreTipo);

            string url = $"{API_TIPOSERVICIO_URL}/buscar?texto={Uri.EscapeDataString(nombreNormalizado)}";

            using (var client = new HttpClient())

            {

                client.DefaultRequestHeaders.Authorization =

                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

                try

                {

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)

                        return 0;

                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(responseBody))

                        return 0;

                    try

                    {

                        JArray tipos = JArray.Parse(responseBody);

                        if (tipos.Count > 0)

                            return tipos[0]["id"]?.Value<long>() ?? 0;

                    }

                    catch

                    {

                        JObject tipo = JObject.Parse(responseBody);

                        return tipo["id"]?.Value<long>() ?? 0;

                    }

                }

                catch (Exception ex)

                {

                    MessageBox.Show("Error al buscar TipoServicio: " + ex.Message,

                                    "Error API", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                return 0;

            }

        }

        // ============================

        // ENVIAR A API

        // ============================

        private async Task<bool> EnviarServicioApiAsync(string url, HttpMethod method, string jsonPayload)

        {

            using (var client = new HttpClient())

            using (var request = new HttpRequestMessage(method, url))

            {

                request.Headers.Authorization =

                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

                request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.SendAsync(request);

                return response.IsSuccessStatusCode;

            }

        }

        // ============================

        // UTILIDAD

        // ============================

        private static string NormalizarCadena(string texto)

        {

            if (string.IsNullOrEmpty(texto)) return texto;

            string normalized = texto.Normalize(System.Text.NormalizationForm.FormD);

            var sb = new StringBuilder();

            foreach (char c in normalized)

            {

                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)

                    sb.Append(c);

            }

            return sb.ToString().Normalize(System.Text.NormalizationForm.FormC).ToLower().Trim();

        }

        private void btnSubirImagen_Click(object sender, EventArgs e)

        {

            using (OpenFileDialog ofd = new OpenFileDialog())

            {

                ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)

                {

                    try

                    {

                        pbImagen.Image = Image.FromFile(ofd.FileName);

                        byte[] imageBytes = File.ReadAllBytes(ofd.FileName);

                        _base64Imagen = Convert.ToBase64String(imageBytes);

                    }

                    catch (Exception ex)

                    {

                        MessageBox.Show("Error al cargar imagen: " + ex.Message);

                    }

                }

            }

        }

        private void label1_Click(object sender, EventArgs e) { }

    }

}
