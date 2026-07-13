﻿namespace ProyectoPelu
{
    partial class gestion_Citas
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
            txtBoxBuscarCitas = new RoundedTextBox();
            pnlAcciones = new Panel();
            label1 = new Label();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnNuevaCita = new Button();
            calSemanal = new MonthCalendar();
            lblCitasSemana = new Label();
            dgvCitas = new DataGridView();
            pnlCalendarContainer = new Panel();
            pnlAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            pnlCalendarContainer.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(40, 40, 40);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(312, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gesti\u00F3n de Citas \uD83D\uDDD3\uFE0F";
            // 
            // pnlAcciones
            // 
            pnlAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.BackColor = Color.White;
            pnlAcciones.Controls.Add(label1);
            pnlAcciones.Controls.Add(txtBoxBuscarCitas);
            pnlAcciones.Controls.Add(btnEliminar);
            pnlAcciones.Controls.Add(btnEditar);
            pnlAcciones.Controls.Add(btnNuevaCita);
            pnlAcciones.Location = new Point(27, 80);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Padding = new Padding(10);
            pnlAcciones.Size = new Size(1070, 70);
            pnlAcciones.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(13, 10);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 4;
            label1.Text = "\uD83D\uDD0D Buscar:";
            //
            // 
            // txtBoxBuscarCitas
            // 
            txtBoxBuscarCitas.BackColor = Color.WhiteSmoke;
            txtBoxBuscarCitas.Font = new Font("Segoe UI", 11F);
            txtBoxBuscarCitas.Location = new Point(16, 28);
            txtBoxBuscarCitas.MinimumSize = new Size(50, 28);
            txtBoxBuscarCitas.Multiline = false;
            txtBoxBuscarCitas.Name = "txtBoxBuscarCitas";
            txtBoxBuscarCitas.PaddingRight = 10;
            txtBoxBuscarCitas.PasswordChar = '\0';
            txtBoxBuscarCitas.PlaceholderText = "";
            txtBoxBuscarCitas.ReadOnly = false;
            txtBoxBuscarCitas.ScrollBars = ScrollBars.None;
            txtBoxBuscarCitas.Size = new Size(400, 28);
            txtBoxBuscarCitas.TabIndex = 3;
            txtBoxBuscarCitas.UseSystemPasswordChar = false;
            txtBoxBuscarCitas.TextChanged += txtBoxBuscarCitas_TextChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(720, 20);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 35);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Cancelar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.BackColor = Color.FromArgb(255, 193, 7);
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(830, 20);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 35);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNuevaCita
            // 
            btnNuevaCita.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevaCita.BackColor = SystemColors.HotTrack;
            btnNuevaCita.Cursor = Cursors.Hand;
            btnNuevaCita.FlatStyle = FlatStyle.Flat;
            btnNuevaCita.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevaCita.ForeColor = Color.White;
            btnNuevaCita.Location = new Point(940, 20);
            btnNuevaCita.Name = "btnNuevaCita";
            btnNuevaCita.Size = new Size(110, 35);
            btnNuevaCita.TabIndex = 0;
            btnNuevaCita.Text = "+ Nueva Cita";
            btnNuevaCita.UseVisualStyleBackColor = false;
            btnNuevaCita.Click += btnNuevaCita_Click;
            // 
            // calSemanal
            // 
            calSemanal.Dock = DockStyle.Fill;
            calSemanal.Location = new Point(10, 10);
            calSemanal.MaxSelectionCount = 1;
            calSemanal.Name = "calSemanal";
            calSemanal.TabIndex = 2;
            calSemanal.DateChanged += calSemanal_DateChanged;
            // 
            // lblCitasSemana
            // 
            lblCitasSemana.AutoSize = true;
            lblCitasSemana.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblCitasSemana.ForeColor = SystemColors.HotTrack;
            lblCitasSemana.Location = new Point(300, 170);
            lblCitasSemana.Name = "lblCitasSemana";
            lblCitasSemana.Size = new Size(279, 30);
            lblCitasSemana.TabIndex = 3;
            lblCitasSemana.Text = "Citas del día seleccionado";
            // 
            // dgvCitas
            // 
            dgvCitas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCitas.BackgroundColor = Color.White;
            dgvCitas.BorderStyle = BorderStyle.None;
            dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCitas.GridColor = Color.WhiteSmoke;
            dgvCitas.Location = new Point(305, 210);
            dgvCitas.Name = "dgvCitas";
            dgvCitas.ReadOnly = true;
            dgvCitas.RowHeadersVisible = false;
            dgvCitas.RowHeadersWidth = 51;
            dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCitas.Size = new Size(792, 380);
            dgvCitas.TabIndex = 4;
            // 
            // pnlCalendarContainer
            // 
            pnlCalendarContainer.BackColor = Color.White;
            pnlCalendarContainer.Controls.Add(calSemanal);
            pnlCalendarContainer.Location = new Point(27, 170);
            pnlCalendarContainer.Name = "pnlCalendarContainer";
            pnlCalendarContainer.Padding = new Padding(10);
            pnlCalendarContainer.Size = new Size(250, 200);
            pnlCalendarContainer.TabIndex = 5;
            // 
            // gestion_Citas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(1124, 602);
            Controls.Add(pnlCalendarContainer);
            Controls.Add(dgvCitas);
            Controls.Add(lblCitasSemana);
            Controls.Add(pnlAcciones);
            Controls.Add(lblTitulo);
            Name = "gestion_Citas";
            Text = "Gestión de Citas";
            Load += gestion_Citas_Load;
            pnlAcciones.ResumeLayout(false);
            pnlAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            pnlCalendarContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnNuevaCita;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.MonthCalendar calSemanal;
        private System.Windows.Forms.Label lblCitasSemana;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Label label1;
        private RoundedTextBox txtBoxBuscarCitas;
        private System.Windows.Forms.Panel pnlCalendarContainer;
    }
}
