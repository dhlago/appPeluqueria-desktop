using System.Drawing;
using System.Windows.Forms;

namespace ProyectoPelu
{
    partial class gestion_HorarioSemanal
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
            btnEditar = new Button();
            btnNuevo = new Button();
            lblFiltrar = new Label();
            comboBoxFiltrar = new ComboBox();
            lblBuscar = new Label();
            txtBuscar = new RoundedTextBox();
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
            lblTitulo.Text = "Gestión de Horarios 📅";
            // 
            // pnlControles
            // 
            pnlControles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlControles.BackColor = Color.White;
            pnlControles.Controls.Add(lblFiltrar);
            pnlControles.Controls.Add(comboBoxFiltrar);
            pnlControles.Controls.Add(btnEliminar);
            pnlControles.Controls.Add(btnEditar);
            pnlControles.Controls.Add(btnNuevo);
            pnlControles.Controls.Add(txtBuscar);
            pnlControles.Controls.Add(lblBuscar);
            pnlControles.Location = new Point(27, 80);
            pnlControles.Name = "pnlControles";
            pnlControles.Size = new Size(1070, 70);
            pnlControles.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.Gray;
            lblBuscar.Location = new Point(13, 10);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(63, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "🔍 Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.WhiteSmoke;
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(16, 28);
            txtBuscar.MinimumSize = new Size(50, 28);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(400, 28);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblFiltrar
            // 
            lblFiltrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFiltrar.AutoSize = true;
            lblFiltrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFiltrar.ForeColor = Color.Gray;
            lblFiltrar.Location = new Point(570, 10);
            lblFiltrar.Name = "lblFiltrar";
            lblFiltrar.Size = new Size(43, 15);
            lblFiltrar.TabIndex = 2;
            lblFiltrar.Text = "Filtrar:";
            // 
            // comboBoxFiltrar
            // 
            comboBoxFiltrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxFiltrar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFiltrar.Font = new Font("Segoe UI", 10F);
            comboBoxFiltrar.FormattingEnabled = true;
            comboBoxFiltrar.Items.AddRange(new object[] { "Todos", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" });
            comboBoxFiltrar.Location = new Point(570, 28);
            comboBoxFiltrar.Name = "comboBoxFiltrar";
            comboBoxFiltrar.Size = new Size(150, 25);
            comboBoxFiltrar.TabIndex = 3;
            comboBoxFiltrar.SelectedIndexChanged += comboBoxFiltrar_SelectedIndexChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(730, 20);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 35);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.BackColor = Color.FromArgb(255, 193, 7);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(840, 20);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 35);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
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
            // gestion_HorarioSemanal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(1124, 602);
            Controls.Add(lblTitulo);
            Controls.Add(pnlControles);
            Controls.Add(dataGridView1);
            Name = "gestion_HorarioSemanal";
            Text = "Gestión de Horarios Semanales";
            Load += gestion_HorarioSemanal_Load;
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
        private Button btnEditar;
        private Button btnNuevo;
        private Label lblFiltrar;
        private ComboBox comboBoxFiltrar;
        private Label lblBuscar;
        private RoundedTextBox txtBuscar;
        private DataGridView dataGridView1;
    }
}
