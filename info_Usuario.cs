using System;

using System.IO;

using System.Net;

using System.Text;

using System.Windows.Forms;

using Newtonsoft.Json.Linq;

namespace ProyectoPelu

{

    public partial class info_Usuario : Form

    {

        private const string API_USUARIOS_URL = "http://217.154.179.135:8080/peluqueria/api/usuarios";

        private readonly string _token;

        private long? _usuarioId;

        // Constructor para crear nuevo usuario

        public info_Usuario(string token)

        {

            InitializeComponent();

            _token = token;

            _usuarioId = null;

            if (cmbTipoUsuario.Items.Count > 0 && cmbTipoUsuario.SelectedIndex < 0)

                cmbTipoUsuario.SelectedIndex = 0;

            // Al inicio deshabilitamos los campos específicos

            DeshabilitarCamposEspecificos();

            // Restricción por Rol: Si es GRUPO, solo puede crear CLIENTES

            if (Session.Rol == "GRUPO")

            {

                cmbTipoUsuario.Items.Clear();

                cmbTipoUsuario.Items.Add("CLIENTE");

                cmbTipoUsuario.SelectedIndex = 0;

                cmbTipoUsuario.Enabled = false;

            }

        }

        // Constructor para editar usuario existente

        public info_Usuario(string token, long usuarioId)

        {

            InitializeComponent();

            _token = token;

            _usuarioId = usuarioId;

            CargarDatosUsuarioParaEdicion(usuarioId);

            // Restricción: GRUPO no puede editar usuarios existentes

            if (Session.Rol == "GRUPO")

            {

                btnGuardar.Visible = false;

            }

        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)

        {

            string tipo = cmbTipoUsuario.SelectedItem?.ToString() ?? string.Empty;

            DeshabilitarCamposEspecificos();

            if (tipo == "ADMIN")

            {

                HabilitarCampo(txtEspecialidad);

            }

            else if (tipo == "CLIENTE")

            {

                HabilitarCampo(txtTelefono);

                HabilitarCampo(txtObservacion);

                HabilitarCampo(txtAlergenos);

                HabilitarCampo(txtDireccion);

            }

            else if (tipo == "GRUPO")

            {

                HabilitarCampo(txtCurso);

                HabilitarCampo(txtTurno);

            }

            // Mostrar botón historial si es CLIENTE y tiene ID (estamos en modo edición)

            bool esClienteConId = (tipo == "CLIENTE" && _usuarioId.HasValue);

            btnHistorialCitas.Visible = esClienteConId;

            btnFichaCliente.Visible = esClienteConId;

            btnHistorialCitas.Enabled = esClienteConId;

            btnFichaCliente.Enabled = esClienteConId;

        }

        private void HabilitarCampo(RoundedTextBox campo)

        {

            campo.Enabled = true;

            campo.BackColor = System.Drawing.Color.White;

        }

        private void DeshabilitarCampo(RoundedTextBox campo)

        {

            campo.Enabled = false;

            campo.BackColor = System.Drawing.Color.FromArgb(255, 220, 220); // Rosado claro - deshabilitado

        }

        private void DeshabilitarCamposEspecificos()

        {

            DeshabilitarCampo(txtEspecialidad);

            DeshabilitarCampo(txtTelefono);

            DeshabilitarCampo(txtObservacion);

            DeshabilitarCampo(txtAlergenos);

            DeshabilitarCampo(txtDireccion);

            DeshabilitarCampo(txtCurso);

            DeshabilitarCampo(txtTurno);

        }

        private void btnGuardar_Click(object sender, EventArgs e)

        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Rellene Nombre y Apellidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Rellene Usuario y Email.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = txtEmail.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_usuarioId.HasValue && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es obligatoria para un nuevo usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tipo = cmbTipoUsuario.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("Debe seleccionar un tipo de usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tipo == "CLIENTE")
            {
                string tel = txtTelefono.Text.Trim();
                if (string.IsNullOrEmpty(tel) || tel.Length != 9)
                {
                    MessageBox.Show("El teléfono del cliente debe tener exactamente 9 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            JObject userData = new JObject

            {

                { "nombre", txtNombre.Text },

                { "apellidos", txtApellidos.Text },

                { "username", txtUsername.Text },

                { "email", txtEmail.Text },

                { "rol", tipo }

            };

            if (!string.IsNullOrWhiteSpace(txtPassword.Text))

                userData.Add("password", txtPassword.Text);

            // Campos específicos

            if (tipo == "ADMIN")

            {

                userData.Add("especialidad", txtEspecialidad.Text);

            }

            else if (tipo == "CLIENTE")

            {

                userData.Add("telefono", txtTelefono.Text);

                userData.Add("observacion", txtObservacion.Text);

                userData.Add("alergenos", txtAlergenos.Text);

                userData.Add("direccion", txtDireccion.Text);

            }

            else if (tipo == "GRUPO")

            {

                userData.Add("curso", txtCurso.Text);

                userData.Add("turno", txtTurno.Text);

            }

            string metodo = _usuarioId.HasValue ? "PUT" : "POST";

            long id = _usuarioId.HasValue ? _usuarioId.Value : 0;

            EnviarDatosAPI(metodo, id, userData, tipo);

        }

        private void EnviarDatosAPI(string metodo, long id, JObject data, string tipo)

        {

            string url;

            if (metodo == "POST")

            {

                url = $"http://217.154.179.135:8080/peluqueria/api/auth/signup/{tipo.ToLower()}";

            }

            else

            {

                url = $"{API_USUARIOS_URL}/{id}";

            }

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

                        MessageBox.Show("Usuario guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                MessageBox.Show("Error de red/API al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void CargarDatosUsuarioParaEdicion(long id)

        {

            string url = $"{API_USUARIOS_URL}/{id}";

            try

            {

                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "GET";

                request.Headers["Authorization"] = $"Bearer {_token}";

                using (var response = (HttpWebResponse)request.GetResponse())

                using (Stream strReader = response.GetResponseStream())

                using (StreamReader reader = new StreamReader(strReader))

                {

                    string responseBody = reader.ReadToEnd();

                    JObject userObject = JObject.Parse(responseBody);

                    // Campos comunes

                    txtNombre.Text = userObject["nombre"]?.ToString();

                    txtApellidos.Text = userObject["apellidos"]?.ToString();

                    txtUsername.Text = userObject["username"]?.ToString();

                    txtEmail.Text = userObject["email"]?.ToString();

                    // Seleccionar rol en el combo

                    string rol = userObject["rol"]?.ToString();

                    cmbTipoUsuario.SelectedItem = rol;

                    // Mostrar grupo correcto (habilitar campos)

                    cmbTipoUsuario_SelectedIndexChanged(null, null);

                    // Campos específicos según rol

                    if (rol == "ADMIN")

                    {

                        txtEspecialidad.Text = userObject["especialidad"]?.ToString();

                    }

                    else if (rol == "CLIENTE")

                    {

                        txtTelefono.Text = userObject["telefono"]?.ToString();

                        txtObservacion.Text = userObject["observacion"]?.ToString();

                        txtAlergenos.Text = userObject["alergenos"]?.ToString();

                        txtDireccion.Text = userObject["direccion"]?.ToString();

                    }

                    else if (rol == "GRUPO")

                    {

                        txtCurso.Text = userObject["curso"]?.ToString();

                        txtTurno.Text = userObject["turno"]?.ToString();

                    }

                }

            }

            catch (WebException ex)

            {

                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message, "Error de Red/API", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void info_Usuario_Load(object sender, EventArgs e)

        {

        }

        private void info_Usuario_Load_1(object sender, EventArgs e)

        {
            if (cmbTipoUsuario.Items.Count > 0 && cmbTipoUsuario.SelectedIndex < 0)
                cmbTipoUsuario.SelectedIndex = 0;

            txtTelefono.MaxLength = 9;
            txtTelefono.KeyPress += (s, ev) =>
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar))
                {
                    ev.Handled = true;
                }
            };
        }

        private void btnHistorialCitas_Click(object sender, EventArgs e)

        {

            if (_usuarioId.HasValue)

            {

                string nombreCompleto = $"{txtNombre.Text} {txtApellidos.Text}";

                historial_Citas f = new historial_Citas(_token, _usuarioId.Value, nombreCompleto);

                f.ShowDialog();

            }

        }

        private void btnFichaCliente_Click(object sender, EventArgs e)

        {

            if (_usuarioId.HasValue)

            {

                string nombreCompleto = $"{txtNombre.Text} {txtApellidos.Text}";

                ficha_Cliente_Form f = new ficha_Cliente_Form(_token, _usuarioId.Value, nombreCompleto);

                f.ShowDialog();

            }

        }

    }

}
