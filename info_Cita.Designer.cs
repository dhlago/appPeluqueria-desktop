namespace ProyectoPelu
{
    partial class info_Cita
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new System.Windows.Forms.Label();
            cbClientes = new System.Windows.Forms.ComboBox();
            txtServicio = new RoundedTextBox();
            btnBuscarServicio = new System.Windows.Forms.Button();
            txtGrupo = new RoundedTextBox();
            monthCalendarCitas = new System.Windows.Forms.MonthCalendar();
            cbHoras = new System.Windows.Forms.ComboBox();
            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            lblDuracion = new System.Windows.Forms.Label();
            lblEstado = new System.Windows.Forms.Label();
            cbEstado = new System.Windows.Forms.ComboBox();
            btnCerrar = new System.Windows.Forms.Button();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(20, 20);
            lblTitulo.Text = "Reserva de Cita";

            // cbClientes (Combo Cliente)
            cbClientes.Location = new System.Drawing.Point(20, 70);
            cbClientes.Size = new System.Drawing.Size(350, 28);

            // txtServicio y Botón (Selección Servicio)
            txtServicio.Location = new System.Drawing.Point(20, 110);
            txtServicio.Size = new System.Drawing.Size(250, 27);
            txtServicio.Enabled = false;
            btnBuscarServicio.Location = new System.Drawing.Point(280, 109);
            btnBuscarServicio.Text = "Servicios";
            btnBuscarServicio.Click += btnBuscarServicio_Click;

            // monthCalendarCitas (EL CALENDARIO VISUAL)
            monthCalendarCitas.Location = new System.Drawing.Point(20, 150);
            monthCalendarCitas.MaxSelectionCount = 1;
            monthCalendarCitas.DateSelected += monthCalendarCitas_DateSelected;

            // txtGrupo (Empleado)
            txtGrupo.Location = new System.Drawing.Point(240, 150);
            txtGrupo.Size = new System.Drawing.Size(180, 27);
            txtGrupo.Enabled = false;

            // cbHoras
            cbHoras.Location = new System.Drawing.Point(240, 200);
            cbHoras.Size = new System.Drawing.Size(180, 28);
            cbHoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblEstado
            lblEstado.AutoSize = true;
            lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblEstado.Location = new System.Drawing.Point(240, 240);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new System.Drawing.Size(53, 19);
            lblEstado.TabIndex = 10;
            lblEstado.Text = "Estado";

            // cbEstado
            cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new System.Drawing.Point(240, 260);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new System.Drawing.Size(180, 25);
            cbEstado.TabIndex = 11;

            // btnGuardar y Cancelar
            // btnGuardar
            btnGuardar.BackColor = System.Drawing.SystemColors.HotTrack;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(240, 300);
            btnGuardar.Size = new System.Drawing.Size(180, 40);
            btnGuardar.Text = "Confirmar Cita";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // btnCancelar
            btnCancelar.BackColor = System.Drawing.Color.Red;
            btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCancelar.ForeColor = System.Drawing.Color.White;
            btnCancelar.Location = new System.Drawing.Point(240, 350);
            btnCancelar.Size = new System.Drawing.Size(180, 40);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;

            // Form
            this.ClientSize = new System.Drawing.Size(460, 430);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { cbEstado, lblEstado, btnCancelar, btnGuardar, cbHoras, txtGrupo, monthCalendarCitas, btnBuscarServicio, txtServicio, cbClientes, lblTitulo });
            this.Text = "Nueva Cita";
            this.Load += info_Cita_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cbClientes;
        private RoundedTextBox txtServicio;
        private System.Windows.Forms.Button btnBuscarServicio;
        private RoundedTextBox txtGrupo;
        private System.Windows.Forms.MonthCalendar monthCalendarCitas;
        private System.Windows.Forms.ComboBox cbHoras;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Button btnCerrar;
    }
}
