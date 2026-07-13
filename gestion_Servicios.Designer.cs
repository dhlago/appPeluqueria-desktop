namespace ProyectoPelu
{
    partial class gestion_Servicios
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
            panel1 = new Panel();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnNuevoServicio = new Button();
            lblFiltrar = new Label();
            comBoxFiltrarServicios = new ComboBox();
            nombreBuscarServLabel = new Label();
            textBox1 = new RoundedTextBox();
            dataGridView1 = new DataGridView();
            pictureBox4 = new PictureBox();
            ServiciosLabel = new Label();
            PrincipalPictureBox = new PictureBox();
            PrincipalLabel = new Label();
            pictureBox1 = new PictureBox();
            ConfPictureBox = new PictureBox();
            RendimientoPictureBox = new PictureBox();
            ClientesPictureBox = new PictureBox();
            CitasPictureBox = new PictureBox();
            CerrarSesionLabel = new Label();
            ConfiguracionLabel = new Label();
            label2 = new Label();
            RendimientoLabel = new Label();
            ClientesLabel = new Label();
            GestionCitasLabel = new Label();
            ProfesorLabel = new Label();
            AdminLabel = new Label();
            LineaLabel2 = new Label();
            UserBox1 = new PictureBox();
            LineaLabel1 = new Label();
            label1 = new Label();
            Tit = new Label();
            LogoPictureBox = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PrincipalPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ConfPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RendimientoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ClientesPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CitasPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UserBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(40, 40, 40);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(376, 45);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Gesti\u00F3n de Servicios \uD83D\uDEE0\uFE0F";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(btnNuevoServicio);
            panel1.Controls.Add(lblFiltrar);
            panel1.Controls.Add(comBoxFiltrarServicios);
            panel1.Controls.Add(nombreBuscarServLabel);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(27, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(1070, 78);
            panel1.TabIndex = 1;
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
            btnEliminar.TabIndex = 8;
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
            btnEditar.TabIndex = 6;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNuevoServicio
            // 
            btnNuevoServicio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoServicio.BackColor = SystemColors.HotTrack;
            btnNuevoServicio.FlatStyle = FlatStyle.Flat;
            btnNuevoServicio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevoServicio.ForeColor = Color.White;
            btnNuevoServicio.Location = new Point(950, 20);
            btnNuevoServicio.Name = "btnNuevoServicio";
            btnNuevoServicio.Size = new Size(100, 35);
            btnNuevoServicio.TabIndex = 7;
            btnNuevoServicio.Text = "+ Nuevo";
            btnNuevoServicio.UseVisualStyleBackColor = false;
            btnNuevoServicio.Click += btnNuevoServicio_Click;
            // 
            // lblFiltrar
            // 
            lblFiltrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFiltrar.AutoSize = true;
            lblFiltrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFiltrar.ForeColor = Color.Gray;
            lblFiltrar.Location = new Point(570, 10);
            lblFiltrar.Name = "lblFiltrar";
            lblFiltrar.Size = new Size(56, 15);
            lblFiltrar.TabIndex = 4;
            lblFiltrar.Text = "Ordenar:";
            // 
            // comBoxFiltrarServicios
            // 
            comBoxFiltrarServicios.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comBoxFiltrarServicios.DropDownStyle = ComboBoxStyle.DropDownList;
            comBoxFiltrarServicios.Font = new Font("Segoe UI", 10F);
            comBoxFiltrarServicios.FormattingEnabled = true;
            comBoxFiltrarServicios.Items.AddRange(new object[] { "MinMaxPrecio", "MaxMinPrecio", "MinMaxDuracion", "MaxMinDuracion" });
            comBoxFiltrarServicios.Location = new Point(570, 28);
            comBoxFiltrarServicios.Name = "comBoxFiltrarServicios";
            comBoxFiltrarServicios.Size = new Size(150, 25);
            comBoxFiltrarServicios.TabIndex = 3;
            comBoxFiltrarServicios.SelectedIndexChanged += comBoxFiltrarServicios_SelectedIndexChanged;
            // 
            // nombreBuscarServLabel
            // 
            nombreBuscarServLabel.AutoSize = true;
            nombreBuscarServLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            nombreBuscarServLabel.ForeColor = Color.Gray;
            nombreBuscarServLabel.Location = new Point(13, 10);
            nombreBuscarServLabel.Name = "nombreBuscarServLabel";
            nombreBuscarServLabel.Size = new Size(63, 15);
            nombreBuscarServLabel.TabIndex = 0;
            nombreBuscarServLabel.Text = "\uD83D\uDD0D Buscar:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.Location = new Point(16, 28);
            textBox1.MinimumSize = new Size(50, 28);
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '\0';
            textBox1.PlaceholderText = "";
            textBox1.ReadOnly = false;
            textBox1.ScrollBars = ScrollBars.None;
            textBox1.Size = new Size(400, 28);
            textBox1.TabIndex = 1;
            textBox1.UseSystemPasswordChar = false;
            textBox1.TextChanged += textBox1_TextChanged;
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
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(100, 50);
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // ServiciosLabel
            // 
            ServiciosLabel.Location = new Point(0, 0);
            ServiciosLabel.Name = "ServiciosLabel";
            ServiciosLabel.Size = new Size(100, 23);
            ServiciosLabel.TabIndex = 3;
            // 
            // PrincipalPictureBox
            // 
            PrincipalPictureBox.Location = new Point(0, 0);
            PrincipalPictureBox.Name = "PrincipalPictureBox";
            PrincipalPictureBox.Size = new Size(100, 50);
            PrincipalPictureBox.TabIndex = 4;
            PrincipalPictureBox.TabStop = false;
            // 
            // PrincipalLabel
            // 
            PrincipalLabel.Location = new Point(0, 0);
            PrincipalLabel.Name = "PrincipalLabel";
            PrincipalLabel.Size = new Size(100, 23);
            PrincipalLabel.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ConfPictureBox
            // 
            ConfPictureBox.Location = new Point(0, 0);
            ConfPictureBox.Name = "ConfPictureBox";
            ConfPictureBox.Size = new Size(100, 50);
            ConfPictureBox.TabIndex = 0;
            ConfPictureBox.TabStop = false;
            // 
            // RendimientoPictureBox
            // 
            RendimientoPictureBox.Location = new Point(0, 0);
            RendimientoPictureBox.Name = "RendimientoPictureBox";
            RendimientoPictureBox.Size = new Size(100, 50);
            RendimientoPictureBox.TabIndex = 0;
            RendimientoPictureBox.TabStop = false;
            // 
            // ClientesPictureBox
            // 
            ClientesPictureBox.Location = new Point(0, 0);
            ClientesPictureBox.Name = "ClientesPictureBox";
            ClientesPictureBox.Size = new Size(100, 50);
            ClientesPictureBox.TabIndex = 0;
            ClientesPictureBox.TabStop = false;
            // 
            // CitasPictureBox
            // 
            CitasPictureBox.Location = new Point(0, 0);
            CitasPictureBox.Name = "CitasPictureBox";
            CitasPictureBox.Size = new Size(100, 50);
            CitasPictureBox.TabIndex = 0;
            CitasPictureBox.TabStop = false;
            // 
            // CerrarSesionLabel
            // 
            CerrarSesionLabel.Location = new Point(0, 0);
            CerrarSesionLabel.Name = "CerrarSesionLabel";
            CerrarSesionLabel.Size = new Size(100, 23);
            CerrarSesionLabel.TabIndex = 0;
            // 
            // ConfiguracionLabel
            // 
            ConfiguracionLabel.Location = new Point(0, 0);
            ConfiguracionLabel.Name = "ConfiguracionLabel";
            ConfiguracionLabel.Size = new Size(100, 23);
            ConfiguracionLabel.TabIndex = 0;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            // 
            // RendimientoLabel
            // 
            RendimientoLabel.Location = new Point(0, 0);
            RendimientoLabel.Name = "RendimientoLabel";
            RendimientoLabel.Size = new Size(100, 23);
            RendimientoLabel.TabIndex = 0;
            // 
            // ClientesLabel
            // 
            ClientesLabel.Location = new Point(0, 0);
            ClientesLabel.Name = "ClientesLabel";
            ClientesLabel.Size = new Size(100, 23);
            ClientesLabel.TabIndex = 0;
            // 
            // GestionCitasLabel
            // 
            GestionCitasLabel.Location = new Point(0, 0);
            GestionCitasLabel.Name = "GestionCitasLabel";
            GestionCitasLabel.Size = new Size(100, 23);
            GestionCitasLabel.TabIndex = 0;
            // 
            // ProfesorLabel
            // 
            ProfesorLabel.Location = new Point(0, 0);
            ProfesorLabel.Name = "ProfesorLabel";
            ProfesorLabel.Size = new Size(100, 23);
            ProfesorLabel.TabIndex = 0;
            // 
            // AdminLabel
            // 
            AdminLabel.Location = new Point(0, 0);
            AdminLabel.Name = "AdminLabel";
            AdminLabel.Size = new Size(100, 23);
            AdminLabel.TabIndex = 0;
            // 
            // LineaLabel2
            // 
            LineaLabel2.Location = new Point(0, 0);
            LineaLabel2.Name = "LineaLabel2";
            LineaLabel2.Size = new Size(100, 23);
            LineaLabel2.TabIndex = 0;
            // 
            // UserBox1
            // 
            UserBox1.Location = new Point(0, 0);
            UserBox1.Name = "UserBox1";
            UserBox1.Size = new Size(100, 50);
            UserBox1.TabIndex = 0;
            UserBox1.TabStop = false;
            // 
            // LineaLabel1
            // 
            LineaLabel1.Location = new Point(0, 0);
            LineaLabel1.Name = "LineaLabel1";
            LineaLabel1.Size = new Size(100, 23);
            LineaLabel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // Tit
            // 
            Tit.Location = new Point(0, 0);
            Tit.Name = "Tit";
            Tit.Size = new Size(100, 23);
            Tit.TabIndex = 0;
            // 
            // LogoPictureBox
            // 
            LogoPictureBox.Location = new Point(0, 0);
            LogoPictureBox.Name = "LogoPictureBox";
            LogoPictureBox.Size = new Size(100, 50);
            LogoPictureBox.TabIndex = 0;
            LogoPictureBox.TabStop = false;
            // 
            // gestion_Servicios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 251);
            ClientSize = new Size(1124, 602);
            Controls.Add(lblTitulo);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(ServiciosLabel);
            Controls.Add(PrincipalPictureBox);
            Controls.Add(PrincipalLabel);
            Name = "gestion_Servicios";
            Text = "Gestión de Servicios";
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)PrincipalPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ConfPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)RendimientoPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ClientesPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)CitasPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)UserBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LogoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Controles de diseño principal
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label nombreBuscarServLabel;
        private RoundedTextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNuevoServicio;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox comBoxFiltrarServicios;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.PictureBox pictureBox4; // (Posiblemente un resto, lo mantenemos)

        // Controles de barra lateral (Se mantienen para que no rompa el código existente)
        private System.Windows.Forms.Label ServiciosLabel;
        private System.Windows.Forms.PictureBox PrincipalPictureBox;
        private System.Windows.Forms.Label PrincipalLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ConfPictureBox;
        private System.Windows.Forms.PictureBox RendimientoPictureBox;
        private System.Windows.Forms.PictureBox ClientesPictureBox;
        private System.Windows.Forms.PictureBox CitasPictureBox;
        private System.Windows.Forms.Label CerrarSesionLabel;
        private System.Windows.Forms.Label ConfiguracionLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RendimientoLabel;
        private System.Windows.Forms.Label ClientesLabel;
        private System.Windows.Forms.Label GestionCitasLabel;
        private System.Windows.Forms.Label ProfesorLabel;
        private System.Windows.Forms.Label AdminLabel;
        private System.Windows.Forms.Label LineaLabel2;
        private System.Windows.Forms.PictureBox UserBox1;
        private System.Windows.Forms.Label LineaLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Tit;
        private System.Windows.Forms.PictureBox LogoPictureBox;
    }
}
