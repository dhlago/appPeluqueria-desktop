using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace appPeluqueriaDesktop
{
    public partial class info_Valoracion : Form
    {
        private JObject _valoracionData;

        public info_Valoracion(JObject valoracionData)
        {
            InitializeComponent();
            _valoracionData = valoracionData;
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (_valoracionData == null) return;

            // Extraer datos básicos
            // Estructura esperada segun Valoracion.java:
            // - idValoracion
            // - puntuacion
            // - comentario
            // - fechaValoracion
            // - imagenBase64
            // - cita (objeto) -> cliente (objeto) -> nombre, apellidos
            //                 -> horarioSemanal -> servicio -> nombre

            // Cliente
            var cita = _valoracionData["cita"];
            var cliente = cita?["cliente"];
            string nombreCliente = cliente != null 
                ? $"{cliente["nombre"]} {cliente["apellidos"]}" 
                : "Cliente Desconocido";
            lblNombreCliente.Text = nombreCliente;

            // Servicio (si disponible en la estructura de cita)
            var horario = cita?["horarioSemanal"];
            var servicio = horario?["servicio"];
            lblServicio.Text = servicio != null ? servicio["nombre"]?.ToString() : "Servicio no especificado";

            // Fecha
            string fechaStr = _valoracionData["fechaValoracion"]?.ToString();
            if (DateTime.TryParse(fechaStr, out DateTime fecha))
            {
                lblFecha.Text = fecha.ToLongDateString() + " " + fecha.ToShortTimeString();
            }
            else
            {
                lblFecha.Text = fechaStr ?? "-";
            }

            // Puntuación General
            double general = _valoracionData["general"]?.Value<double>() ?? 0;
            lblPuntuacion.Text = $"General: {general:0.0}/5 " + GetStarString(general);

            // Trato Personal
            double trato = _valoracionData["tratoPersonal"]?.Value<double>() ?? 0;
            lblTratoPersonal.Text = $"Trato Personal: {trato:0.0}/5 " + GetStarString(trato);

            // Desarrollo Servicio
            double desarrollo = _valoracionData["desarrolloServicio"]?.Value<double>() ?? 0;
            lblDesarrolloServicio.Text = $"Desarrollo Servicio: {desarrollo:0.0}/5 " + GetStarString(desarrollo);

            // Claridad Comunicación
            double claridad = _valoracionData["claridadComunicacion"]?.Value<double>() ?? 0;
            lblClaridadComunicacion.Text = $"Comunicación: {claridad:0.0}/5 " + GetStarString(claridad);

            // Limpieza y Organización
            double limpieza = _valoracionData["limpiezaOrganizacion"]?.Value<double>() ?? 0;
            lblLimpiezaOrganizacion.Text = $"Limpieza: {limpieza:0.0}/5 " + GetStarString(limpieza);

            // Comentario
            txtComentario.Text = _valoracionData["comentario"]?.ToString() ?? "Sin comentario.";

            // Imagen Base64
            string base64Img = _valoracionData["imagenBase64"]?.ToString();
            if (!string.IsNullOrEmpty(base64Img))
            {
                try
                {
                    // Limpiar cabeceras si existen (data:image/png;base64,)
                    if (base64Img.Contains(",")) 
                    {
                        base64Img = base64Img.Split(',')[1];
                    }

                    byte[] imageBytes = Convert.FromBase64String(base64Img);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pbImagen.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                    pbImagen.Image = null; // O poner una imagen de error por defecto
                }
            }
            else
            {
                // Ocultar picturebox o poner placeholder si no hay imagen
                pbImagen.Visible = false;
                lblNoImagen.Visible = true;
            }
        }

        private string GetStarString(double rating)
        {
            int fullStars = (int)Math.Floor(rating);
            bool hasHalf = (rating - fullStars) >= 0.5;
            string result = string.Concat(Enumerable.Repeat("⭐", fullStars));
            if (hasHalf) result += "½";
            return result;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
