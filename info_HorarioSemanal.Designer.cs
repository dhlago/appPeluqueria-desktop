using System.Drawing;
using System.Windows.Forms;

namespace ProyectoPelu
{
    partial class info_HorarioSemanal
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblDia;
        private ComboBox cmbDia;
        private Label lblHoraInicio;
        private DateTimePicker dtpHoraInicio;
        private Label lblHoraFin;
        private DateTimePicker dtpHoraFin;
        private Label lblCupo;
        private RoundedTextBox txtCupo;
        private Label lblGrupo;
        private ComboBox cmbGrupo;
        private Label lblServicio;
        private RoundedTextBox txtServicio;
        private Button btnBuscarServicio;
        private Button btnGuardar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            // Form
            ClientSize = new Size(500, 450);
            BackColor = Color.FromArgb(245, 247, 250);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión Horario Semanal";
            Load += info_HorarioSemanal_Load;

            // Título
            lblTitulo = new Label
            {
                Text = "📅 Gestión de Horario",
                ForeColor = Color.FromArgb(0, 102, 204),
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Día de la semana
            lblDia = new Label { Text = "Día:", Location = new Point(30, 80), Font = new Font("Segoe UI", 11F), AutoSize = true };
            cmbDia = new ComboBox
            {
                Location = new Point(160, 77),
                Size = new Size(280, 30),
                Font = new Font("Segoe UI", 11F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbDia.Items.AddRange(new object[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" });

            // Hora Inicio
            lblHoraInicio = new Label { Text = "Hora Inicio:", Location = new Point(30, 125), Font = new Font("Segoe UI", 11F), AutoSize = true };
            dtpHoraInicio = new DateTimePicker
            {
                Location = new Point(160, 122),
                Size = new Size(130, 30),
                Font = new Font("Segoe UI", 11F),
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true
            };

            // Hora Fin
            lblHoraFin = new Label { Text = "Hora Fin:", Location = new Point(30, 170), Font = new Font("Segoe UI", 11F), AutoSize = true };
            dtpHoraFin = new DateTimePicker
            {
                Location = new Point(160, 167),
                Size = new Size(130, 30),
                Font = new Font("Segoe UI", 11F),
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true
            };

            // Cupo Máximo
            lblCupo = new Label { Text = "Cupo Máximo:", Location = new Point(30, 215), Font = new Font("Segoe UI", 11F), AutoSize = true };
            txtCupo = new RoundedTextBox { Location = new Point(160, 212), Size = new Size(100, 36), Font = new Font("Segoe UI", 11F) };

            // Grupo
            lblGrupo = new Label { Text = "Grupo:", Location = new Point(30, 260), Font = new Font("Segoe UI", 11F), AutoSize = true };
            cmbGrupo = new ComboBox
            {
                Location = new Point(160, 257),
                Size = new Size(280, 30),
                Font = new Font("Segoe UI", 11F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Servicio
            lblServicio = new Label { Text = "Servicio:", Location = new Point(30, 305), Font = new Font("Segoe UI", 11F), AutoSize = true };
            txtServicio = new RoundedTextBox
            {
                Location = new Point(160, 302),
                Size = new Size(200, 36),
                Font = new Font("Segoe UI", 11F),
                ReadOnly = true
            };

            btnBuscarServicio = new Button
            {
                Text = "🔍",
                Location = new Point(370, 302),
                Size = new Size(50, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGray,
                Cursor = Cursors.Hand
            };
            btnBuscarServicio.FlatAppearance.BorderSize = 0;
            btnBuscarServicio.Click += btnBuscarServicio_Click;

            // Botón Guardar
            btnGuardar = new Button
            {
                Text = "💾 Guardar",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 102, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 45),
                Location = new Point(65, 370)
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
                Location = new Point(255, 370)
            };
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Click += (s, e) => this.Close();

            // Añadir controles al Form
            Controls.AddRange(new Control[] {
                lblTitulo,
                lblDia, cmbDia,
                lblHoraInicio, dtpHoraInicio,
                lblHoraFin, dtpHoraFin,
                lblCupo, txtCupo,
                lblGrupo, cmbGrupo,
                lblServicio, txtServicio, btnBuscarServicio,
                btnGuardar,
                btnCancelar
            });

            ResumeLayout(false);
        }
    }
}
