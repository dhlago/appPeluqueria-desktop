using System;

using System.Text;

using System.Net.Http;

using Newtonsoft.Json.Linq;

using System.Windows.Forms;

using System.Drawing;

using System.Drawing.Drawing2D;

using appPeluqueriaDesktop;

namespace ProyectoPelu

{

    public partial class iniciar_Sesion : Form

    {

        public iniciar_Sesion()

        {

            InitializeComponent();

            // El botón "Entrar" se activa con Enter

            this.KeyPreview = true; this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnIniciarSesion_Click(s, e); };

            // Conexión del evento Click del botón a la lógica

            this.btnIniciarSesion.Click += new EventHandler(this.btnIniciarSesion_Click);

            this.textBoxUsuario.TabIndex = 0;

            this.textBoxContrasenya.TabIndex = 1;

            this.btnIniciarSesion.TabIndex = 2;

            // Eventos para centrar la tarjeta

            this.Load += iniciar_Sesion_Load;

            this.panelLogin.Resize += panelLogin_Resize;

        }

        public string? Token { get; private set; }

        private void iniciar_Sesion_Load(object sender, EventArgs e)

        {

            CenterCard();

        }

        private void panelLogin_Resize(object sender, EventArgs e)

        {

            CenterCard();

        }

        private void CenterCard()

        {

            if (card == null || panelLogin == null) return;

            int x = (panelLogin.ClientSize.Width - card.Width) / 2;

            int y = (panelLogin.ClientSize.Height - card.Height) / 2;

            card.Location = new Point(Math.Max(0, x), Math.Max(0, y));

        }

        private void Form4_Load(object sender, EventArgs e)

        {

            // Inicialización adicional si la necesitas

        }

        private async void btnIniciarSesion_Click(object sender, EventArgs e)

        {
            string usuario = textBoxUsuario.Text;
            string contranya = textBoxContrasenya.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contranya))
            {
                MessageBox.Show("Por favor, introduzca usuario y contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnIniciarSesion.Enabled = false;

            Cursor = Cursors.WaitCursor;

            var data = $"{{\"username\":\"{usuario}\",\"password\":\"{contranya}\"}}";

            var url = "http://217.154.179.135:8080/peluqueria/api/auth/signin";

            using (var client = new HttpClient())

            {

                try

                {

                    var content = new StringContent(data, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)

                    {

                        string responseBody = await response.Content.ReadAsStringAsync();

                        var jsonObject = JObject.Parse(responseBody);

                        string? token = jsonObject["token"]?.ToString();

                        if (!string.IsNullOrEmpty(token))

                        {

                            Session.Token = token;

                            Session.NombreUsuario = null;

                            Session.Rol = null;

                            this.DialogResult = DialogResult.OK;

                            this.Close();

                        }

                        else

                        {

                            MessageBox.Show("Respuesta inválida: No se recibió el token del servidor.");

                        }

                    }

                    else

                    {

                        MessageBox.Show("Inicio de sesión fallido. Verifique usuario y contraseña.");

                    }

                }

                catch (HttpRequestException)

                {

                    MessageBox.Show("Error de conexión: El servidor API no está disponible o la URL es incorrecta.");

                }

                catch (Exception ex)

                {

                    MessageBox.Show("Error al procesar el inicio de sesión: " + ex.Message);

                }

                finally

                {

                    btnIniciarSesion.Enabled = true;

                    Cursor = Cursors.Default;

                }

            }

        }

        private void lblBrandSubtitle_Click(object sender, EventArgs e)

        {

        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)

        {

        }

        private void textBoxContrasenya_TextChanged(object sender, EventArgs e)

        {

        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)

        {

        }

        private void panelBrand_Paint(object sender, PaintEventArgs e)

        {

            // Gradient horizontal 90deg: naranja a amarillo

            // rgba(241, 123, 35, 1) -> rgba(244, 206, 47, 1)

            Color colorLeft = Color.FromArgb(241, 123, 35);   // Naranja

            Color colorRight = Color.FromArgb(244, 206, 47);  // Amarillo

            using (LinearGradientBrush brush = new LinearGradientBrush(

                panelBrand.ClientRectangle,

                colorLeft,

                colorRight,

                LinearGradientMode.Horizontal))

            {

                e.Graphics.FillRectangle(brush, panelBrand.ClientRectangle);

            }

        }

        private void btnIniciarSesion_Click_1(object sender, EventArgs e)

        {

        }

    }

}
