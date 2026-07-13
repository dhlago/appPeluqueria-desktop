using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json.Linq;
using ProyectoPelu;

namespace appPeluqueriaDesktop
{
    public partial class rendimiento_Empresa : Form
    {
        private Chart chartRendimiento;
        private ComboBox cmbFiltro;
        private Label lblTotalIngresos;
        private Label lblTotalCitas;
        private FlowLayoutPanel panelKPIs;
        
        // Data storage
        private JArray _allAppointments;
        private const string API_URL = "http://217.154.179.135:8080/peluqueria/api/citas/todas";

        public rendimiento_Empresa()
        {
            InitializeComponent();
            ConfigurarUI();
        }

        private void ConfigurarUI()
        {
            // 1. Limpiar controles existentes (menos el panelHeader si queremos mantenerlo, pero vamos a reconstruir el cuerpo)
            // Asumimos que hay un panelHeader en el Designer. Lo mantenemos.
            // Eliminamos el PictureBox si existe
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox)
                {
                    this.Controls.Remove(ctrl);
                    break;
                }
            }

            this.BackColor = Color.WhiteSmoke;

            // 2. Panel de Filtros
            Panel panelFiltros = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            Label lblFiltro = new Label
            {
                Text = "Filtrar por:",
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(20, 20)
            };

            cmbFiltro = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10),
                Width = 200,
                Location = new Point(100, 16)
            };
            cmbFiltro.Items.AddRange(new string[] { "Hoy", "Esta Semana", "Este Mes", "Este Año", "Histórico" });
            cmbFiltro.SelectedIndex = 2; // Default: Este Mes
            cmbFiltro.SelectedIndexChanged += (s, e) => ActualizarDashboard();

            panelFiltros.Controls.Add(lblFiltro);
            panelFiltros.Controls.Add(cmbFiltro);
            
            // Asegurarnos que el panelFiltros esté debajo del panelHeader (que tiene Dock.Top)
            // Al añadirlo a Controls, si usas Dock.Top, el orden importa (z-order).
            // Lo añadiremos al final y usaremos BringToFront/SendToBack adecuadamente en el Load.
            
            // 3. Panel de KPIs
            panelKPIs = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(20),
                FlowDirection = FlowDirection.LeftToRight
            };

            // KPI Cards
            lblTotalIngresos = CrearTarjetaKPI("Ingresos Totales", "0.00 €", Color.SeaGreen);
            lblTotalCitas = CrearTarjetaKPI("Citas Realizadas", "0", Color.SteelBlue);

            // 4. Gráfico
            chartRendimiento = new Chart();
            chartRendimiento.Dock = DockStyle.Fill;
            chartRendimiento.BackColor = Color.White;
            
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
            chartRendimiento.ChartAreas.Add(chartArea);

            Legend legend = new Legend("Leyenda");
            legend.Docking = Docking.Top;
            chartRendimiento.Legends.Add(legend);

            Series serieIngresos = new Series("Ingresos");
            serieIngresos.ChartType = SeriesChartType.Column;
            serieIngresos.Color = Color.CornflowerBlue;
            chartRendimiento.Series.Add(serieIngresos);

            // Añadir controles al formulario
            // Orden inverso de Dock.Top: El último añadido aparece ARRIBA si no ajustamos z-order.
            // Pero WinForms Dock funciona apilando. El primero añadido con Dock.Top se queda más arriba.
            // El Designer ya añadió panelHeader.
            
            this.Controls.Add(chartRendimiento); // Fill ocupa el resto
            this.Controls.Add(panelKPIs);        // Top
            this.Controls.Add(panelFiltros);     // Top (debajo de Header)
            
            // Ajustar Z-Order en Load
        }

        private Label CrearTarjetaKPI(string titulo, string valorInicial, Color colorBorde)
        {
            Panel card = new Panel
            {
                Width = 250,
                Height = 100,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 20, 0)
            };
            
            // Borde izquierdo coloreado
            Panel borde = new Panel
            {
                Dock = DockStyle.Left,
                Width = 5,
                BackColor = colorBorde
            };

            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.Gray,
                Location = new Point(15, 15),
                AutoSize = true
            };

            Label lblValor = new Label
            {
                Text = valorInicial,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(15, 40),
                AutoSize = true
            };

            card.Controls.Add(lblValor);
            card.Controls.Add(lblTitulo);
            card.Controls.Add(borde);

            panelKPIs.Controls.Add(card);

            return lblValor;
        }

        private async void rendimiento_Empresa_Load(object sender, EventArgs e)
        {
            // Ajustar orden visual: Header -> Filtros -> KPIs -> Chart
            foreach (Control c in this.Controls)
            {
                if (c.Name == "panelHeader") c.BringToFront();
            }

            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            if (string.IsNullOrEmpty(Session.Token)) return;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = 
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Session.Token);

                    // Nota: Idealmente el backend tendría endpoints de reporte.
                    // Aquí traemos todas las citas y procesamos en memoria (OK para volúmenes pequeños/medianos).
                    HttpResponseMessage response = await client.GetAsync(API_URL);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        _allAppointments = JArray.Parse(json);
                        ActualizarDashboard();
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener datos del servidor.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ActualizarDashboard()
        {
            if (_allAppointments == null) return;

            string filtro = cmbFiltro.SelectedItem.ToString();
            DateTime fechaInicio = DateTime.MinValue;
            DateTime fechaFin = DateTime.MaxValue;
            DateTime hoy = DateTime.Today;

            // Definir rangos
            switch (filtro)
            {
                case "Hoy":
                    fechaInicio = hoy;
                    fechaFin = hoy.AddDays(1).AddTicks(-1);
                    break;
                case "Esta Semana":
                    int diff = (7 + (hoy.DayOfWeek - DayOfWeek.Monday)) % 7;
                    fechaInicio = hoy.AddDays(-1 * diff).Date;
                    fechaFin = fechaInicio.AddDays(7).AddTicks(-1);
                    break;
                case "Este Mes":
                    fechaInicio = new DateTime(hoy.Year, hoy.Month, 1);
                    fechaFin = fechaInicio.AddMonths(1).AddTicks(-1);
                    break;
                case "Este Año":
                    fechaInicio = new DateTime(hoy.Year, 1, 1);
                    fechaFin = fechaInicio.AddYears(1).AddTicks(-1);
                    break;
                case "Histórico":
                default:
                    fechaInicio = DateTime.MinValue;
                    fechaFin = DateTime.MaxValue;
                    break;
            }

            // Filtrar datos
            var citasFiltradas = _allAppointments
                .Where(c => 
                {
                    var fechaStr = c["fecha"]?.ToString();
                    if (DateTime.TryParse(fechaStr, out DateTime fecha))
                    {
                        return fecha >= fechaInicio && fecha <= fechaFin;
                    }
                    return false;
                })
                .ToList();

            // Calcular KPIs
            // Importante: Chequear estado (ej. no contar citas canceladas si se desea)
            // Asumimos estado "CANCELADA" no cuenta para ingresos, pero quizás sí para historial.
            // Filtremos solo completadas o pendientes para ingresos proyectados.
            // Por simplicidad, sumamos todo lo que no sea CANCELADA.
            
            double totalIngresos = 0;
            int totalCitas = citasFiltradas.Count;

            foreach (var cita in citasFiltradas)
            {
                string estado = cita["estado"]?.ToString();
                if (estado != "CANCELADA") // Ajustar según lógica de negocio
                {
                    var servicio = cita["horarioSemanal"]?["servicio"];
                    if (servicio != null)
                    {
                        double precio = servicio["precio"]?.Value<double>() ?? 0;
                        totalIngresos += precio;
                    }
                }
            }

            // Actualizar KPIs UI
            lblTotalIngresos.Text = $"{totalIngresos:N2} €";
            lblTotalCitas.Text = totalCitas.ToString();

            // Actualizar Gráfico
            ConfigurarGrafico(citasFiltradas, filtro);
        }

        private void ConfigurarGrafico(List<JToken> citas, string filtro)
        {
            chartRendimiento.Series["Ingresos"].Points.Clear();

            // Agrupar datos según el filtro
            // Si es Hoy -> Agrupar por Hora (si tienes hora) o simplemente mostrar total.
            // Si es Semana/Mes -> Agrupar por Día.
            // Si es Año -> Agrupar por Mes.
            
            var datosAgrupados = new Dictionary<string, double>();

            foreach (var cita in citas)
            {
                string estado = cita["estado"]?.ToString();
                if (estado == "CANCELADA") continue;

                string fechaStr = cita["fecha"]?.ToString();
                if (!DateTime.TryParse(fechaStr, out DateTime fecha)) continue;

                double precio = cita["horarioSemanal"]?["servicio"]?["precio"]?.Value<double>() ?? 0;
                string clave = "";

                if (filtro == "Hoy")
                {
                   clave = cita["horaInicio"]?.ToString() ?? "00:00"; 
                   // Simplificar a hora
                   if(clave.Length >= 2) clave = clave.Substring(0, 2) + ":00";
                }
                else if (filtro == "Este Año" || filtro == "Histórico")
                {
                    clave = fecha.ToString("MMM yyyy"); // Mes Año
                }
                else // Semana o Mes
                {
                    clave = fecha.ToString("dd/MM"); // Día Mes
                }

                if (datosAgrupados.ContainsKey(clave))
                    datosAgrupados[clave] += precio;
                else
                    datosAgrupados[clave] = precio;
            }

            // Ordenar claves cronológicamente es complejo con strings.
            // Mejor approach: iterar sobre el rango de fechas esperado y rellenar 0s.
            
            // Por simplicidad para el prototipo: agregamos tal cual vienen (ordenar por clave podría funcionar si formato es sortable)
            // Si usamos "dd/MM" no ordena bien entre meses.
            // Mejor usar DateTime como clave intermedia si quisiéramos orden perfecto.

            foreach (var kvp in datosAgrupados)
            {
                chartRendimiento.Series["Ingresos"].Points.AddXY(kvp.Key, kvp.Value);
            }
            
            // Título dinámico
            chartRendimiento.Titles.Clear();
            chartRendimiento.Titles.Add($"Ingresos por período ({filtro})");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
