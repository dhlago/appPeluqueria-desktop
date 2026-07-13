using System.Drawing;
using System.Windows.Forms;

namespace ProyectoPelu
{
    partial class bloqueo_FechaHora
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
            pnlControles = new Panel();
            btnEliminar = new Button();
            btnNuevo = new Button();
            lblFiltrar = new Label();
            dtpFiltrar = new DateTimePicker();
            dataGridView1 = new DataGridView();
            pnlControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(40, 40, 40);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(400, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Bloqueo de Fechas/Horas 🚫";
            // 
            // pnlControles
            // 
            pnlControles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlControles.BackColor = Color.White;
            pnlControles.Controls.Add(lblFiltrar);
            pnlControles.Controls.Add(dtpFiltrar);
            pnlControles.Controls.Add(btnEliminar);
            pnlControles.Controls.Add(btnNuevo);
            pnlControles.Location = new Point(27, 80);
            pnlControles.Name = "pnlControles";
            pnlControles.Size = new Size(1070, 70);
            pnlControles.TabIndex = 1;
            // 
            // lblFiltrar
            // 
            lblFiltrar.AutoSize = true;
            lblFiltrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFiltrar.ForeColor = Color.Gray;
            lblFiltrar.Location = new Point(13, 10);
            lblFiltrar.Name = "lblFiltrar";
            lblFiltrar.Size = new Size(63, 15);
            lblFiltrar.TabIndex = 0;
            lblFiltrar.Text = "📅 Filtrar por Fecha:";
            // 
            // dtpFiltrar
            // 
            dtpFiltrar.Font = new Font("Segoe UI", 11F);
            dtpFiltrar.Format = DateTimePickerFormat.Short;
            dtpFiltrar.Location = new Point(16, 28);
            dtpFiltrar.Name = "dtpFiltrar";
            dtpFiltrar.Size = new Size(150, 27);
            dtpFiltrar.TabIndex = 1;
            dtpFiltrar.ValueChanged += dtpFiltrar_ValueChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69); // Red color
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(840, 20);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 35);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevo.BackColor = SystemColors.HotTrack;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(950, 20);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 35);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "+ Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(27, 170);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1070, 420);
            dataGridView1.TabIndex = 2;
            // 
            // bloqueo_FechaHora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(1124, 602);
            Controls.Add(lblTitulo);
            Controls.Add(pnlControles);
            Controls.Add(dataGridView1);
            Name = "bloqueo_FechaHora";
            Text = "Gestión de Bloqueos";
            Load += bloqueo_FechaHora_Load;
            pnlControles.ResumeLayout(false);
            pnlControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel pnlControles;
        private Button btnEliminar;
        private Button btnNuevo;
        private Label lblFiltrar;
        private DateTimePicker dtpFiltrar;
        private DataGridView dataGridView1;
    }
}
