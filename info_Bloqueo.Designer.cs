using System.Drawing;
using System.Windows.Forms;

namespace ProyectoPelu
{
    partial class info_Bloqueo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            pnlFondo = new Panel();
            btnCancelar = new Button();
            btnGuardar = new Button();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblHoraInicio = new Label();
            dtpHoraInicio = new DateTimePicker();
            lblHoraFin = new Label();
            dtpHoraFin = new DateTimePicker();
            chkTodoElDia = new CheckBox();
            lblMotivo = new Label();
            txtMotivo = new TextBox();
            lblFechaFin = new Label();
            dtpFechaFin = new DateTimePicker();
            chkVariosDias = new CheckBox();
            pnlFondo.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(40, 40, 40);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(250, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Nuevo Bloqueo 🚫";
            // 
            // pnlFondo
            // 
            pnlFondo.BackColor = Color.White;
            pnlFondo.Controls.Add(lblTitulo);
            pnlFondo.Controls.Add(lblFecha);
            pnlFondo.Controls.Add(dtpFecha);
            pnlFondo.Controls.Add(lblHoraInicio);
            pnlFondo.Controls.Add(dtpHoraInicio);
            pnlFondo.Controls.Add(lblHoraFin);
            pnlFondo.Controls.Add(dtpHoraFin);
            pnlFondo.Controls.Add(chkTodoElDia);
            pnlFondo.Controls.Add(lblMotivo);
            pnlFondo.Controls.Add(txtMotivo);
            pnlFondo.Controls.Add(lblFechaFin);
            pnlFondo.Controls.Add(dtpFechaFin);
            pnlFondo.Controls.Add(chkVariosDias);
            pnlFondo.Controls.Add(btnCancelar);
            pnlFondo.Controls.Add(btnGuardar);
            pnlFondo.Location = new Point(12, 12);
            pnlFondo.Name = "pnlFondo";
            pnlFondo.Size = new Size(460, 480);
            pnlFondo.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFecha.Location = new Point(30, 80);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(48, 19);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Segoe UI", 11F);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(30, 105);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 27);
            dtpFecha.TabIndex = 3;
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFechaFin.Location = new Point(30, 140);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(68, 19);
            lblFechaFin.TabIndex = 13;
            lblFechaFin.Text = "Fecha Fin:";
            lblFechaFin.Visible = false;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Font = new Font("Segoe UI", 11F);
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(30, 165);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(200, 27);
            dtpFechaFin.TabIndex = 14;
            dtpFechaFin.Visible = false;
            // 
            // chkVariosDias
            // 
            chkVariosDias.AutoSize = true;
            chkVariosDias.Font = new Font("Segoe UI", 10F);
            chkVariosDias.Location = new Point(260, 78);
            chkVariosDias.Name = "chkVariosDias";
            chkVariosDias.Size = new Size(95, 23);
            chkVariosDias.TabIndex = 15;
            chkVariosDias.Text = "Varios días";
            chkVariosDias.CheckedChanged += chkVariosDias_CheckedChanged;
            // 
            // chkTodoElDia
            // 
            chkTodoElDia.AutoSize = true;
            chkTodoElDia.Font = new Font("Segoe UI", 10F);
            chkTodoElDia.Location = new Point(260, 108);
            chkTodoElDia.Name = "chkTodoElDia";
            chkTodoElDia.Size = new Size(97, 23);
            chkTodoElDia.TabIndex = 4;
            chkTodoElDia.Text = "Todo el día";
            chkTodoElDia.CheckedChanged += chkTodoElDia_CheckedChanged;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblHoraInicio.Location = new Point(30, 210);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(80, 19);
            lblHoraInicio.TabIndex = 5;
            lblHoraInicio.Text = "Hora Inicio:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Font = new Font("Segoe UI", 11F);
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Location = new Point(30, 235);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.Size = new Size(120, 27);
            dtpHoraInicio.TabIndex = 6;
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblHoraFin.Location = new Point(200, 210);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(66, 19);
            lblHoraFin.TabIndex = 7;
            lblHoraFin.Text = "Hora Fin:";
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Font = new Font("Segoe UI", 11F);
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Location = new Point(200, 235);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.Size = new Size(120, 27);
            dtpHoraFin.TabIndex = 8;
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblMotivo.Location = new Point(30, 290);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(57, 19);
            lblMotivo.TabIndex = 9;
            lblMotivo.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            txtMotivo.Font = new Font("Segoe UI", 11F);
            txtMotivo.Location = new Point(30, 315);
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(400, 80);
            txtMotivo.TabIndex = 10;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(140, 420);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 40);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.HotTrack;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(265, 420);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(110, 40);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += (s, e) => {
                if (MessageBox.Show("¿Desea bloquear este horario? Se cancelarán automáticamente todas las citas afectadas y se notificará a los clientes con el motivo proporcionado.", "Confirmar Bloqueo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    btnGuardar_Click(s, e);
                }
            };
            // 
            // 
            // info_Bloqueo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(484, 504);
            Controls.Add(pnlFondo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "info_Bloqueo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalles del Bloqueo";
            Load += info_Bloqueo_Load;
            pnlFondo.ResumeLayout(false);
            pnlFondo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Panel pnlFondo;
        private Button btnCancelar;
        private Button btnGuardar;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblHoraInicio;
        private DateTimePicker dtpHoraInicio;
        private Label lblHoraFin;
        private DateTimePicker dtpHoraFin;
        private CheckBox chkTodoElDia;
        private Label lblMotivo;
        private TextBox txtMotivo;
        private Label lblFechaFin;
        private DateTimePicker dtpFechaFin;
        private CheckBox chkVariosDias;
    }
}
