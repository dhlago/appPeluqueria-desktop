using System;

using System.Data;

using System.Drawing; // Necesario para estilos

using System.IO;

using System.Linq;

using System.Net;

using System.Windows.Forms;

using Newtonsoft.Json.Linq;

namespace ProyectoPelu

{

    public partial class gestion_Usuarios : Form

    {

        private const string API_USUARIOS_URL = "http://217.154.179.135:8080/peluqueria/api/usuarios";

        private const string COLUMN_ID_NAME = "ColId";

        private DataTable dtUsuarios = new DataTable();

        public gestion_Usuarios(string token)

        {

            InitializeComponent();

            if (!string.IsNullOrEmpty(token)) Session.Token = token;

            // Configuración de ventana hija

            this.TopLevel = false;

            this.FormBorderStyle = FormBorderStyle.None;

            this.Dock = DockStyle.Fill;

            ConfigurarDataGridView();

            ConfigurarResponsividad(); // Ajuste automático de tamaño

        }

        private void ConfigurarResponsividad()

        {

            // El Grid ocupa todo el espacio restante

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // El panel de controles se estira a lo ancho

            pnlControles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // La caja de búsqueda se estira

            txtBuscarUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Los botones se quedan pegados a la derecha

            btnNuevoUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;

        }

        private void ConfigurarDataGridView()

        {

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Clear();

            // --- ESTILO VISUAL MODERNO ---

            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.BorderStyle = BorderStyle.None;

            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;

            dataGridView1.ReadOnly = true;

            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            // Estilo Encabezados

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50); // Gris oscuro

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersHeight = 40;

            // Estilo Filas

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);

            dataGridView1.DefaultCellStyle.SelectionBackColor = SystemColors.HotTrack;

            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.RowTemplate.Height = 35;

            // --- COLUMNAS ---

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = COLUMN_ID_NAME, DataPropertyName = "id", Visible = false });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColNombre", HeaderText = "\uD83D\uDC64 Nombre", DataPropertyName = "nombre" });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColApellidos", HeaderText = "\uD83D\uDC65 Apellidos", DataPropertyName = "apellidos" });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColUsername", HeaderText = "\uD83C\uDD94 Usuario", DataPropertyName = "username" });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColEmail", HeaderText = "\uD83D\uDCE7 Email", DataPropertyName = "email" });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColRol", HeaderText = "\uD83D\uDD11 Rol", DataPropertyName = "rol" });

        }

        private void CargarUsuarios()

        {

            if (string.IsNullOrEmpty(Session.Token)) return;

            try

            {

                var request = (HttpWebRequest)WebRequest.Create(API_USUARIOS_URL);

                request.Method = "GET";

                request.Headers["Authorization"] = $"Bearer {Session.Token}";

                using (var response = (HttpWebResponse)request.GetResponse())

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))

                {

                    string responseBody = reader.ReadToEnd();

                    JArray usersArray = JArray.Parse(responseBody);

                    dtUsuarios.Clear();

                    if (dtUsuarios.Columns.Count == 0)

                    {

                        dtUsuarios.Columns.Add("id", typeof(long));

                        dtUsuarios.Columns.Add("nombre", typeof(string));

                        dtUsuarios.Columns.Add("apellidos", typeof(string));

                        dtUsuarios.Columns.Add("username", typeof(string));

                        dtUsuarios.Columns.Add("email", typeof(string));

                        dtUsuarios.Columns.Add("rol", typeof(string));

                    }

                    foreach (JObject userObject in usersArray)

                    {

                        string rol = userObject["rol"]?.ToString();

                        // Restricción: GRUPO solo ve CLIENTES

                        if (Session.Rol == "GRUPO" && rol != "CLIENTE")

                            continue;

                        DataRow row = dtUsuarios.NewRow();

                        row["id"] = userObject["id"]?.Value<long>() ?? 0;

                        row["nombre"] = userObject["nombre"]?.ToString();

                        row["apellidos"] = userObject["apellidos"]?.ToString();

                        row["username"] = userObject["username"]?.ToString();

                        row["email"] = userObject["email"]?.ToString();

                        row["rol"] = rol;

                        dtUsuarios.Rows.Add(row);

                    }

                    dataGridView1.DataSource = dtUsuarios.DefaultView;

                }

            }

            catch (Exception ex) { MessageBox.Show("Error al cargar usuarios: " + ex.Message); }

        }

        private void Form3_Load(object sender, EventArgs e)

        {

            CargarUsuarios();

            // Restricción: GRUPO no puede eliminar ni editar usuarios

            if (Session.Rol == "GRUPO")

            {

                btnEditar.Visible = false;

                btnEliminar.Visible = false;

            }

        }

        // --- BOTONES ---

        private void btnNuevoUsuario_Click(object sender, EventArgs e)

        {

            info_Usuario formNuevo = new info_Usuario(Session.Token);

            if (formNuevo.ShowDialog() == DialogResult.OK) CargarUsuarios();

        }

        private void btnEditar_Click(object sender, EventArgs e)

        {

            if (dataGridView1.SelectedRows.Count == 0)

            {

                MessageBox.Show("Seleccione un usuario para editar.");

                return;

            }

            long id = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[COLUMN_ID_NAME].Value);

            info_Usuario formEdicion = new info_Usuario(Session.Token, id);

            if (formEdicion.ShowDialog() == DialogResult.OK) CargarUsuarios();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)

        {

            if (e.RowIndex >= 0)

            {

                btnEditar_Click(sender, e);

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)

        {

            if (dataGridView1.SelectedRows.Count == 0) return;

            long id = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[COLUMN_ID_NAME].Value);

            string nombre = dataGridView1.SelectedRows[0].Cells["ColNombre"].Value.ToString();

            if (MessageBox.Show($"\u00BFEliminar a {nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

                EliminarUsuarioDeAPI(id);

        }

        private void EliminarUsuarioDeAPI(long idUsuario)

        {

            try

            {

                var request = (HttpWebRequest)WebRequest.Create($"{API_USUARIOS_URL}/{idUsuario}");

                request.Method = "DELETE";

                request.Headers["Authorization"] = $"Bearer {Session.Token}";

                using (var response = (HttpWebResponse)request.GetResponse())

                {

                    if (response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.OK)

                    {

                        MessageBox.Show("Usuario eliminado.");

                        CargarUsuarios();

                    }

                }

            }

            catch (Exception ex) { MessageBox.Show("Error al eliminar: " + ex.Message); }

        }

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)

        {

            AplicarFiltros();

        }

        private void comboBoxFiltrarUsuario_SelectedIndexChanged(object sender, EventArgs e)

        {

            AplicarFiltros();

        }

        private void AplicarFiltros()

        {

            if (dtUsuarios == null) return;

            string textoBusqueda = txtBuscarUsuario.Text.Trim().Replace("'", "''");

            string tipoFiltro = comboBoxFiltrarUsuario.SelectedItem?.ToString() ?? "Todos";

            string filtro = "";

            // Filtro por texto de búsqueda

            if (!string.IsNullOrEmpty(textoBusqueda))

            {

                filtro = $"(nombre LIKE '%{textoBusqueda}%' OR apellidos LIKE '%{textoBusqueda}%' OR username LIKE '%{textoBusqueda}%' OR email LIKE '%{textoBusqueda}%' OR rol LIKE '%{textoBusqueda}%')";

            }

            // Filtro por tipo de usuario

            if (tipoFiltro != "Todos" && !string.IsNullOrEmpty(tipoFiltro))

            {

                string filtroTipo = $"rol = '{tipoFiltro}'";

                filtro = string.IsNullOrEmpty(filtro) ? filtroTipo : $"{filtro} AND {filtroTipo}";

            }

            dtUsuarios.DefaultView.RowFilter = filtro;

        }

        // Eventos vacíos para compatibilidad

        private void PrincipalLabel_Click(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void BarraLateralPanel_Paint_1(object sender, PaintEventArgs e) { }

        private void btnNuevoUsuario_Click_1(object sender, EventArgs e) { }

    }

}
