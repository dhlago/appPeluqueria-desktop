using System.Drawing;
using System.Windows.Forms;

namespace ProyectoPelu
{
    partial class info_Usuario
    {
        private System.ComponentModel.IContainer components = null;

        // Encabezado
        private Label lblTitulo;

        // Datos básicos
        private Label lblNombre;
        private RoundedTextBox txtNombre;
        private Label lblApellidos;
        private RoundedTextBox txtApellidos;
        private Label lblUsername;
        private RoundedTextBox txtUsername;
        private Label lblEmail;
        private RoundedTextBox txtEmail;
        private Label lblPassword;
        private RoundedTextBox txtPassword;

        // Tipo usuario
        private Label lblTipoUsuario;
        private ComboBox cmbTipoUsuario;

        // Admin
        private Label lblEspecialidad;
        private RoundedTextBox txtEspecialidad;

        // Cliente
        private Label lblTelefono;
        private RoundedTextBox txtTelefono;
        private Label lblObservacion;
        private RoundedTextBox txtObservacion;
        private Label lblAlergenos;
        private RoundedTextBox txtAlergenos;
        private Label lblDireccion;
        private RoundedTextBox txtDireccion;

        // Grupo
        private Label lblCurso;
        private RoundedTextBox txtCurso;
        private Label lblTurno;
        private RoundedTextBox txtTurno;

        // Botón
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnHistorialCitas;
        private Button btnFichaCliente;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            // Form
            ClientSize = new Size(950, 650);
            BackColor = Color.FromArgb(245, 247, 250);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión Usuario";
            Load += info_Usuario_Load_1;

            // Título
            lblTitulo = new Label
            {
                Text = "Gestión de Usuario",
                ForeColor = Color.FromArgb(0, 102, 204),
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Nombre
            lblNombre = new Label { Text = "Nombre:", Location = new Point(30, 100), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            txtNombre = new RoundedTextBox { Location = new Point(140, 97), Size = new Size(250, 36), Font = new Font("Segoe UI", 11F) };

            // Apellidos
            lblApellidos = new Label { Text = "Apellidos:", Location = new Point(430, 100), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            txtApellidos = new RoundedTextBox { Location = new Point(530, 97), Size = new Size(250, 36), Font = new Font("Segoe UI", 11F) };

            // Usuario
            lblUsername = new Label { Text = "Usuario:", Location = new Point(30, 150), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            txtUsername = new RoundedTextBox { Location = new Point(140, 147), Size = new Size(250, 36), Font = new Font("Segoe UI", 11F) };

            // Email
            lblEmail = new Label { Text = "Email:", Location = new Point(430, 150), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            txtEmail = new RoundedTextBox { Location = new Point(530, 147), Size = new Size(250, 36), Font = new Font("Segoe UI", 11F) };

            // Password
            lblPassword = new Label { Text = "Contraseña:", Location = new Point(30, 200), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            txtPassword = new RoundedTextBox { Location = new Point(140, 197), Size = new Size(250, 36), Font = new Font("Segoe UI", 11F), UseSystemPasswordChar = true };

            // Tipo usuario
            lblTipoUsuario = new Label { Text = "Tipo de usuario:", Location = new Point(30, 255), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            cmbTipoUsuario = new ComboBox
            {
                Location = new Point(170, 250),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 11F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTipoUsuario.Items.AddRange(new object[] { "ADMIN", "CLIENTE", "GRUPO" });
            cmbTipoUsuario.SelectedIndexChanged += cmbTipoUsuario_SelectedIndexChanged;

            // Admin
            lblEspecialidad = new Label { Text = "Especialidad:", Location = new Point(30, 305), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            txtEspecialidad = new RoundedTextBox { Location = new Point(170, 300), Size = new Size(250, 36), Font = new Font("Segoe UI", 11F) };

            // Cliente
            lblTelefono = new Label { Text = "Teléfono:", Location = new Point(30, 355), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            txtTelefono = new RoundedTextBox { Location = new Point(140, 350), Size = new Size(200, 36), Font = new Font("Segoe UI", 11F) };

            lblObservacion = new Label { Text = "Observación:", Location = new Point(400, 355), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            txtObservacion = new RoundedTextBox { Location = new Point(520, 350), Size = new Size(200, 36), Font = new Font("Segoe UI", 11F) };

            lblAlergenos = new Label { Text = "Alérgenos:", Location = new Point(30, 405), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            txtAlergenos = new RoundedTextBox { Location = new Point(140, 400), Size = new Size(200, 36), Font = new Font("Segoe UI", 11F) };

            lblDireccion = new Label { Text = "Dirección:", Location = new Point(400, 405), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            txtDireccion = new RoundedTextBox { Location = new Point(500, 400), Size = new Size(250, 36), Font = new Font("Segoe UI", 11F) };

            // Grupo
            lblCurso = new Label { Text = "Curso:", Location = new Point(30, 455), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            txtCurso = new RoundedTextBox { Location = new Point(140, 450), Size = new Size(250, 36), Font = new Font("Segoe UI", 11F) };

            lblTurno = new Label { Text = "Turno:", Location = new Point(400, 455), AutoSize = true, Font = new Font("Segoe UI", 11F) };
            txtTurno = new RoundedTextBox { Location = new Point(500, 450), Size = new Size(250, 36), Font = new Font("Segoe UI", 11F) };

            // Botón Guardar
            btnGuardar = new Button
            {
                Text = "💾 Guardar",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 45),
                Location = new Point(100, 530)
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += btnGuardar_Click;

            // btnCancelar
            btnCancelar = new Button
            {
                Text = "Cancelar",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 45),
                Location = new Point(300, 530)
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += (s, e) => this.Close();

            // btnHistorialCitas
            btnHistorialCitas = new Button
            {
                Text = "📅 Historial Citas",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 150, 136), // Teal color
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 45),
                Location = new Point(500, 530),
                Visible = false // Invisible by default
            };
            btnHistorialCitas.FlatAppearance.BorderSize = 0;
            btnHistorialCitas.Click += btnHistorialCitas_Click;

            // btnFichaCliente
            btnFichaCliente = new Button
            {
                Text = "📋 Ficha Técnica",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                BackColor = Color.FromArgb(142, 68, 173), // Purple/amethyst color for distinction
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 45),
                Location = new Point(700, 530),
                Visible = false // Invisible by default
            };
            btnFichaCliente.FlatAppearance.BorderSize = 0;
            btnFichaCliente.Click += btnFichaCliente_Click;
            
            // Añadir controles al Form directamente (sueltos)
            Controls.AddRange(new Control[] {
                lblTitulo,
                lblNombre, txtNombre,
                lblApellidos, txtApellidos,
                lblUsername, txtUsername,
                lblEmail, txtEmail,
                lblPassword, txtPassword,
                lblTipoUsuario, cmbTipoUsuario,
                lblEspecialidad, txtEspecialidad,
                lblTelefono, txtTelefono,
                lblObservacion, txtObservacion,
                lblAlergenos, txtAlergenos,
                lblDireccion, txtDireccion,
                lblCurso, txtCurso,
                lblTurno, txtTurno,
                btnGuardar,
                btnCancelar,
                btnHistorialCitas,
                btnFichaCliente
            });

            ResumeLayout(false);
        }
    }
}

