using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using appPeluqueriaDesktop;
using Newtonsoft.Json.Linq;

namespace ProyectoPelu
{
    public partial class pagina_principal : Form
    {
        private const string API_CITAS_URL = "http://217.154.179.135:8080/peluqueria/api/citas/todas";

        public pagina_principal()
        {
            InitializeComponent();
            OcultarContenidoInicio();
            ConfigurarPanelContenedor();

            // 1. DESACTIVAR ANCHORS AUTOMÁTICOS (Crucial para que no se muevan solos y se monten)
            if (panel4 != null) panel4.Anchor = AnchorStyles.None;
            if (AccionesControlPanel != null) AccionesControlPanel.Anchor = AnchorStyles.None;
            if (HorarioControlPanel != null) HorarioControlPanel.Anchor = AnchorStyles.None;
            if (panel3 != null) panel3.Anchor = AnchorStyles.None;
            if (CitasControlPanel != null) CitasControlPanel.Anchor = AnchorStyles.None;

            // 2. Suscribir al evento de cambio de tamaño
            this.Resize += Pagina_principal_Resize;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarContenidoInicio();
            CargarDatosUsuario();
            CargarHorarioHoy();
            CargarEstadisticasSemanales();
            AplicarRestriccionesPorRol();

            // Forzar el ajuste visual inmediato
            this.BeginInvoke(new Action(() => AjustarResponsividad()));
        }

        // --- SOLUCIÓN MATEMÁTICA PARA EL DISEÑO ---
        private void AjustarResponsividad()
        {
            if (panel4 == null || AccionesControlPanel == null || HorarioControlPanel == null) return;

            int margen = 20; // Espacio entre paneles
            int menuAncho = 270; // Ancho de la barra lateral naranja
            int topY = 164; // Altura fila superior (Tarjetas de colores)
            int bottomY = 310; // Altura fila inferior (Horario y Acciones) - SUBIDO para que no se corte

            // Ancho total disponible para dibujar
            int anchoVentana = this.ClientSize.Width;
            int altoVentana = this.ClientSize.Height;

            // 1. PANELES DERECHOS (Ingresos y Acciones)
            int anchoPanelDerecho = 410; // Aumentado para evitar corte de botones
            int xDerecha = anchoVentana - anchoPanelDerecho - margen;

            // Evitamos que se meta encima del menú si la ventana es muy pequeña
            if (xDerecha < menuAncho + 500) xDerecha = menuAncho + 500;

            panel4.Size = new Size(anchoPanelDerecho, 140); // Tarjeta Donaciones (más baja para dejar aire)
            panel4.Location = new Point(xDerecha, topY);

            AccionesControlPanel.Size = new Size(anchoPanelDerecho, altoVentana - bottomY - margen); // Panel Acciones
            AccionesControlPanel.Location = new Point(xDerecha, bottomY);

            // Ajustar ancho de los paneles internos de Acciones Rápidas
            int anchoInterno = anchoPanelDerecho - 40;
            HorarioCompletoPanel.Width = AgregaClientePanel.Width = VerIngresosPanel.Width = VerServiciosPanel.Width = anchoInterno;

            // Traer al frente para evitar solapamientos
            panel4.BringToFront();
            AccionesControlPanel.BringToFront();

            // 2. PANEL IZQUIERDO (Citas)
            int xIzquierda = menuAncho + margen;
            CitasControlPanel.Location = new Point(xIzquierda, topY);
            CitasControlPanel.Height = 140; // Mismo alto que panel4

            // 3. PANEL CENTRAL (Clientes) - Centrado entre Izquierda y Derecha
            int finCitasPanel = CitasControlPanel.Location.X + CitasControlPanel.Width;
            int inicioIngresosPanel = panel4.Location.X;
            int espacioCentro = inicioIngresosPanel - finCitasPanel;

            int xCentro = finCitasPanel + (espacioCentro / 2) - (panel3.Width / 2);

            // Seguridad: Si el espacio es muy pequeño, pegarlo a la izquierda
            if (xCentro < finCitasPanel + 10) xCentro = finCitasPanel + 10;

            panel3.Location = new Point(xCentro, topY);
            panel3.Height = 140; // Mismo alto que panel4
            panel3.BringToFront();

            // 4. HORARIO (El panel grande blanco)
            HorarioControlPanel.Location = new Point(xIzquierda, bottomY);

            // Su ancho es: Desde donde empieza (izq) hasta donde empieza el panel de Acciones (der) - margen
            int anchoHorario = AccionesControlPanel.Location.X - xIzquierda - margen;

            if (anchoHorario < 300) anchoHorario = 300; // Mínimo seguro

            HorarioControlPanel.Size = new Size(anchoHorario, altoVentana - bottomY - margen);
        }

        private void Pagina_principal_Resize(object sender, EventArgs e)
        {
            AjustarResponsividad();
        }

        // --- CARGA DE DATOS ---

        private async void CargarHorarioHoy()
        {
            if (string.IsNullOrEmpty(Session.Token)) return;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Session.Token);
                    // Añadimos un timestamp para evitar cacheo
                    string url = $"{API_CITAS_URL}?t={DateTime.Now.Ticks}";
                    string json = await client.GetStringAsync(url);
                    JArray todasLasCitas = JArray.Parse(json);
                    
                    DateTime hoy = DateTime.Now.Date;
                    
                    var citasDeHoy = todasLasCitas.Where(c => 
                    {
                        string fechaStr = c["fecha"]?.ToString();
                        if (DateTime.TryParse(fechaStr, out DateTime fechaCita))
                        {
                            return fechaCita.Date == hoy;
                        }
                        return false;
                    }).OrderBy(c => c["horaInicio"]?.ToString()).ToList();

                    // Actualizar UI en el hilo principal
                    this.Invoke(new Action(() => 
                    {
                        NumCitasControlLabel.Text = citasDeHoy.Count.ToString();
                        InfoDiariaLabel.Text = $"Esto es lo que está pasando hoy, {DateTime.Now.ToLongDateString()}.";

                        var borrar = HorarioControlPanel.Controls.OfType<Panel>().Where(p => p.Tag?.ToString() == "FilaDinamica").ToList();
                        foreach (var b in borrar) HorarioControlPanel.Controls.Remove(b);

                        int yPos = 80;
                        if (citasDeHoy.Count == 0)
                        {
                            Label lbl = new Label { Text = "No hay citas hoy.", AutoSize = true, Location = new Point(30, 80), Font = new Font("Segoe UI", 12, FontStyle.Italic), ForeColor = Color.Gray, Tag = "FilaDinamica" };
                            HorarioControlPanel.Controls.Add(lbl);
                        }
                        else
                        {
                            foreach (var cita in citasDeHoy)
                            {
                                Panel p = CrearFilaCita(cita, yPos);
                                p.Width = HorarioControlPanel.Width - 60;
                                p.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                                HorarioControlPanel.Controls.Add(p);
                                yPos += 80;
                            }
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar horario: " + ex.Message);
            }
        }

        private async void CargarEstadisticasSemanales()
        {
            if (string.IsNullOrEmpty(Session.Token)) return;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Session.Token);
                    string json = await client.GetStringAsync(API_CITAS_URL);
                    JArray todasLasCitas = JArray.Parse(json);

                    // Definir rango de la semana (Lunes a Domingo)
                    DateTime hoy = DateTime.Now.Date;
                    int diff = (7 + (hoy.DayOfWeek - DayOfWeek.Monday)) % 7;
                    DateTime inicioSemana = hoy.AddDays(-1 * diff).Date;
                    DateTime finSemana = inicioSemana.AddDays(7).Date;

                    var citasSemana = todasLasCitas.Where(c =>
                    {
                        if (DateTime.TryParse(c["fecha"]?.ToString(), out DateTime f))
                        {
                            return f.Date >= inicioSemana && f.Date < finSemana && c["estado"]?.ToString() != "CANCELADA";
                        }
                        return false;
                    }).ToList();

                    double totalDonaciones = 0;
                    HashSet<long> clientesUnicos = new HashSet<long>();

                    foreach (var cita in citasSemana)
                    {
                        double precio = 0;
                        var precioStr = cita["horarioSemanal"]?["servicio"]?["precio"]?.ToString();
                        if (precioStr != null) {
                            precioStr = precioStr.Replace("€", "").Trim();
                            double.TryParse(precioStr, out precio);
                        }
                        totalDonaciones += precio;

                        if (long.TryParse(cita["cliente"]?["id"]?.ToString(), out long clientID))
                        {
                            clientesUnicos.Add(clientID);
                        }
                    }

                    this.Invoke(new Action(() =>
                    {
                        NumIngresosControl.Text = $"{totalDonaciones:N2}€";
                        NumClientesControlLabel.Text = clientesUnicos.Count.ToString();
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en estadísticas: " + ex.Message);
            }
        }

        private Panel CrearFilaCita(JToken cita, int yPos)
        {
            string groupName = cita["horarioSemanal"]?["grupo"]?["nombre"]?.ToString();
            
            Panel p = new Panel();
            p.Tag = "FilaDinamica";
            p.Size = new Size(HorarioControlPanel.Width - 60, 70);
            p.Location = new Point(30, yPos);
            p.BorderStyle = BorderStyle.FixedSingle;
            p.BackColor = GetGroupColor(groupName);
            p.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            string hora = cita["horaInicio"]?.ToString() ?? "00:00";
            Label lblHora = new Label { Text = hora.Length > 5 ? hora.Substring(0, 5) : hora, Location = new Point(15, 25), Font = new Font("Segoe UI Semibold", 10), ForeColor = Color.DimGray, AutoSize = true };
            Label lblNom = new Label { Text = $"{cita["cliente"]?["nombre"]} {cita["cliente"]?["apellidos"]}", Location = new Point(100, 15), Font = new Font("Segoe UI", 11, FontStyle.Bold), AutoSize = true };
            Label lblServ = new Label { Text = cita["horarioSemanal"]?["servicio"]?["nombre"]?.ToString(), Location = new Point(100, 38), Font = new Font("Segoe UI", 9), ForeColor = Color.Gray, AutoSize = true };

            Button btn = new Button { Text = "Detalles", Size = new Size(80, 30), Location = new Point(p.Width - 100, 20), Anchor = AnchorStyles.Top | AnchorStyles.Right, BackColor = Color.WhiteSmoke, FlatStyle = FlatStyle.Flat };
            btn.Click += (s, e) => {
                info_Cita f = new info_Cita(cita["idCita"].Value<long>());
                if (f.ShowDialog() == DialogResult.OK) CargarHorarioHoy();
            };

            p.Controls.Add(lblHora); p.Controls.Add(lblNom); p.Controls.Add(lblServ); p.Controls.Add(btn);
            return p;
        }

        private Color GetGroupColor(string groupName)
        {
            if (string.IsNullOrEmpty(groupName)) return Color.White;

            string name = groupName.ToLower();
            
            // Colores suaves para no dificultar la lectura
            // Mapear por palabras clave del curso (según la base de datos y captura del usuario)
            if (name.Contains("1a") || name.Contains("1º peluquería")) return Color.FromArgb(255, 230, 230); // Rojo muy suave
            if (name.Contains("1b") || name.Contains("1º estética")) return Color.FromArgb(230, 245, 255); // Azul muy suave
            if (name.Contains("1c")) return Color.FromArgb(230, 255, 230); // Verde muy suave
            if (name.Contains("2a") || name.Contains("2º peluquería")) return Color.FromArgb(255, 255, 230); // Amarillo muy suave
            if (name.Contains("2b")) return Color.FromArgb(240, 230, 255); // Violeta muy suave
            if (name.Contains("2c")) return Color.FromArgb(255, 245, 230); // Naranja muy suave

            return Color.White;
        }

        private async void CargarDatosUsuario()
        {
            if (string.IsNullOrEmpty(Session.Token)) return;
            try
            {
                using (HttpClient c = new HttpClient())
                {
                    c.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Session.Token);
                    string json = await c.GetStringAsync("http://217.154.179.135:8080/peluqueria/api/usuarios/me");
                    JObject o = JObject.Parse(json);
                    string nom = o["nombre"]?.ToString();
                    string rol = o["rol"]?.ToString();
                    
                    Session.Rol = rol;
                    AdminLabel.Text = nom; 
                    SaludoLabel.Text = $"¡Bienvenido de vuelta, {nom}!"; 
                    ProfesorLabel.Text = $"Rol: {rol}";
                    
                    this.Invoke(new Action(() => AplicarRestriccionesPorRol()));
                }
            }
            catch { }
        }

        private void AplicarRestriccionesPorRol()
        {
            // Ya no ocultamos las secciones de gestión, el usuario pidió que se puedan "ver"
            // Las restricciones se aplicarán ahora dentro de cada formulario (gestion_Servicios, etc)
        }

        private void ConfigurarPanelContenedor()
        {
            pnlContenedor.Location = new Point(270, 0);
            pnlContenedor.Size = new Size(this.Width - 270, this.Height);
            pnlContenedor.Visible = false;
        }

        private void MostrarContenidoInicio() { CitasControlPanel.Visible = HorarioControlPanel.Visible = AccionesControlPanel.Visible = panel3.Visible = panel4.Visible = SaludoLabel.Visible = InfoDiariaLabel.Visible = true; pnlContenedor.Visible = false; AjustarResponsividad(); }
        private void OcultarContenidoInicio() { CitasControlPanel.Visible = HorarioControlPanel.Visible = AccionesControlPanel.Visible = panel3.Visible = panel4.Visible = SaludoLabel.Visible = InfoDiariaLabel.Visible = false; pnlContenedor.Visible = true; }
        private void CargarNuevaPagina(Form fh) { pnlContenedor.Controls.Clear(); fh.TopLevel = false; fh.FormBorderStyle = FormBorderStyle.None; fh.Dock = DockStyle.Fill; pnlContenedor.Controls.Add(fh); fh.Show(); }

        private void PrincipalLabel_Click(object sender, EventArgs e)
        {
            MostrarContenidoInicio();
            // Forzamos la recarga de datos al volver al inicio
            CargarHorarioHoy();
            CargarEstadisticasSemanales();
            CargarDatosUsuario();
        }
        private void GestionCitasLabel_Click(object sender, EventArgs e) { OcultarContenidoInicio(); CargarNuevaPagina(new gestion_Citas(Session.Token)); }
        private void GestionServiciosLabel_Click(object sender, EventArgs e) { OcultarContenidoInicio(); CargarNuevaPagina(new gestion_Servicios(Session.Token)); }
        private void ClientesLabel_Click(object sender, EventArgs e) { OcultarContenidoInicio(); CargarNuevaPagina(new gestion_Usuarios(Session.Token)); }
        private void RendimientoLabel_Click(object sender, EventArgs e) { OcultarContenidoInicio(); CargarNuevaPagina(new rendimiento_Empresa()); }
        private void BloqueosLabel_Click(object sender, EventArgs e) { OcultarContenidoInicio(); CargarNuevaPagina(new bloqueo_FechaHora(Session.Token)); }
        private void HorarioSemanalLabel_Click(object sender, EventArgs e) { OcultarContenidoInicio(); CargarNuevaPagina(new gestion_HorarioSemanal(Session.Token)); }
        private void CerrarSesionLabel_Click(object sender, EventArgs e) { Session.Token = null; new iniciar_Sesion().Show(); this.Hide(); }
        private void ValoracionesLabel_Click(object sender, EventArgs e) { OcultarContenidoInicio(); CargarNuevaPagina(new valoracion()); }

        // --- EVENTOS FALTANTES QUE CAUSABAN EL ERROR ---
        private void CitaControlPanel2_Paint(object sender, PaintEventArgs e) { }
        private void CitaControlPanel1_Paint(object sender, PaintEventArgs e) { }
        private void IngresosControlLabel_Click(object sender, EventArgs e) { }
        private void pnlContenedor_Paint(object sender, PaintEventArgs e) { }

        // Otros eventos vacíos necesarios
        private void BarraLateralPanel_Paint(object sender, PaintEventArgs e)
        {
            // Gradient horizontal 90deg: naranja a amarillo
            Color colorLeft = Color.FromArgb(241, 123, 35);   // Naranja
            Color colorRight = Color.FromArgb(244, 206, 47);  // Amarillo
            
            using (LinearGradientBrush brush = new LinearGradientBrush(
                BarraLateralPanel.ClientRectangle,
                colorLeft,
                colorRight,
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, BarraLateralPanel.ClientRectangle);
            }
        }
        private void label1_Click(object sender, EventArgs e) { }
        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void ProfesorLabel_Click(object sender, EventArgs e) { }
    }
}
