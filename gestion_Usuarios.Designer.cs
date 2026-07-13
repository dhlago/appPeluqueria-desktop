namespace ProyectoPelu
{
    partial class gestion_Usuarios
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
            dataGridView1 = new DataGridView();
            pnlControles = new Panel();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnNuevoUsuario = new Button();
            txtBuscarUsuario = new RoundedTextBox();
            lblBuscar = new Label();
            lblTitulo = new Label();
            comboBoxFiltrarUsuario = new ComboBox();
            lblFiltrar = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlControles.SuspendLayout();
            SuspendLayout();
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
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // pnlControles
            // 
            pnlControles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlControles.BackColor = Color.White;
            pnlControles.Controls.Add(lblFiltrar);
            pnlControles.Controls.Add(comboBoxFiltrarUsuario);
            pnlControles.Controls.Add(btnEliminar);
            pnlControles.Controls.Add(btnEditar);
            pnlControles.Controls.Add(btnNuevoUsuario);
            pnlControles.Controls.Add(txtBuscarUsuario);
            pnlControles.Controls.Add(lblBuscar);
            pnlControles.Location = new Point(27, 80);
            pnlControles.Name = "pnlControles";
            pnlControles.Size = new Size(1070, 70);
            pnlControles.TabIndex = 4;
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
            btnEliminar.TabIndex = 5;
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
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNuevoUsuario
            // 
            btnNuevoUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoUsuario.BackColor = SystemColors.HotTrack;
            btnNuevoUsuario.FlatStyle = FlatStyle.Flat;
            btnNuevoUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevoUsuario.ForeColor = Color.White;
            btnNuevoUsuario.Location = new Point(950, 20);
            btnNuevoUsuario.Name = "btnNuevoUsuario";
            btnNuevoUsuario.Size = new Size(100, 35);
            btnNuevoUsuario.TabIndex = 3;
            btnNuevoUsuario.Text = "+ Nuevo";
            btnNuevoUsuario.UseVisualStyleBackColor = false;
            btnNuevoUsuario.Click += btnNuevoUsuario_Click;
            // 
            // txtBuscarUsuario
            // 
            txtBuscarUsuario.BackColor = Color.WhiteSmoke;
            txtBuscarUsuario.Font = new Font("Segoe UI", 11F);
            txtBuscarUsuario.Location = new Point(16, 28);
            txtBuscarUsuario.MinimumSize = new Size(50, 28);
            txtBuscarUsuario.Multiline = false;
            txtBuscarUsuario.Name = "txtBuscarUsuario";
            txtBuscarUsuario.PasswordChar = '\0';
            txtBuscarUsuario.PlaceholderText = "";
            txtBuscarUsuario.ReadOnly = false;
            txtBuscarUsuario.ScrollBars = ScrollBars.None;
            txtBuscarUsuario.Size = new Size(400, 28);
            txtBuscarUsuario.TabIndex = 2;
            txtBuscarUsuario.UseSystemPasswordChar = false;
            txtBuscarUsuario.TextChanged += txtBuscarUsuario_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.Gray;
            lblBuscar.Location = new Point(13, 10);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(63, 15);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "\uD83D\uDD0D Buscar:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(40, 40, 40);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(372, 45);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "Gesti\u00F3n de Usuarios \uD83D\uDC65";
            // 
            // comboBoxFiltrarUsuario
            // 
            comboBoxFiltrarUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxFiltrarUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFiltrarUsuario.FormattingEnabled = true;
            comboBoxFiltrarUsuario.Items.AddRange(new object[] { "Todos", "ADMIN", "CLIENTE", "GRUPO" });
            comboBoxFiltrarUsuario.Location = new Point(570, 28);
            comboBoxFiltrarUsuario.Name = "comboBoxFiltrarUsuario";
            comboBoxFiltrarUsuario.Size = new Size(150, 25);
            comboBoxFiltrarUsuario.TabIndex = 6;
            comboBoxFiltrarUsuario.SelectedIndexChanged += comboBoxFiltrarUsuario_SelectedIndexChanged;
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
            lblFiltrar.TabIndex = 6;
            lblFiltrar.Text = "Filtrar:";
            // 
            // gestion_Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(1124, 602);
            Controls.Add(lblTitulo);
            Controls.Add(pnlControles);
            Controls.Add(dataGridView1);
            Name = "gestion_Usuarios";
            Text = "Gestión de Usuarios";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlControles.ResumeLayout(false);
            pnlControles.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevoUsuario;
        private RoundedTextBox txtBuscarUsuario;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnEditar;
        private ComboBox comboBoxFiltrarUsuario;
        private Label lblFiltrar;
    }
}
