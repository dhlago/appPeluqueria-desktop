namespace appPeluqueriaDesktop
{
    partial class valoracion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvValoraciones = new DataGridView();
            lblTitulo = new Label();
            lblContador = new Label();
            btnEliminar = new Button();
            panelHeader = new Panel();
            lblBuscar = new Label();
            txtBuscar = new ProyectoPelu.RoundedTextBox();
            lblOrden = new Label();
            cmbOrden = new ComboBox();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvValoraciones).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // dgvValoraciones
            // 
            dgvValoraciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvValoraciones.BackgroundColor = Color.White;
            dgvValoraciones.Location = new Point(20, 120);
            dgvValoraciones.Name = "dgvValoraciones";
            dgvValoraciones.Size = new Size(760, 280);
            dgvValoraciones.TabIndex = 0;
            dgvValoraciones.CellDoubleClick += dgvValoraciones_CellDoubleClick;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(40, 40, 40);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(328, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Valoraciones de Clientes";
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Font = new Font("Segoe UI", 10F);
            lblContador.ForeColor = Color.Gray;
            lblContador.Location = new Point(360, 25);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(53, 19);
            lblContador.TabIndex = 1;
            lblContador.Text = "Total: 0";
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(620, 410);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(160, 40);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar Selección";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Controls.Add(lblContador);
            panelHeader.Controls.Add(lblBuscar);
            panelHeader.Controls.Add(txtBuscar);
            panelHeader.Controls.Add(lblOrden);
            panelHeader.Controls.Add(cmbOrden);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 100);
            panelHeader.TabIndex = 0;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBuscar.ForeColor = Color.Gray;
            lblBuscar.Location = new Point(24, 60);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(63, 15);
            lblBuscar.TabIndex = 2;
            lblBuscar.Text = "\uD83D\uDD0D Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.WhiteSmoke;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.Location = new Point(90, 56);
            txtBuscar.MinimumSize = new Size(50, 28);
            txtBuscar.Multiline = false;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PasswordChar = '\0';
            txtBuscar.PlaceholderText = "Nombre, comentario, estrellas...";
            txtBuscar.ReadOnly = false;
            txtBuscar.ScrollBars = ScrollBars.None;
            txtBuscar.Size = new Size(250, 28);
            txtBuscar.TabIndex = 3;
            txtBuscar.UseSystemPasswordChar = false;
            toolTip1.SetToolTip(txtBuscar, "Introduce Nombre del cliente, comentario o número de puntuación");
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblOrden
            // 
            lblOrden.AutoSize = true;
            lblOrden.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOrden.ForeColor = Color.Gray;
            lblOrden.Location = new Point(380, 60);
            lblOrden.Name = "lblOrden";
            lblOrden.Size = new Size(94, 15);
            lblOrden.TabIndex = 4;
            lblOrden.Text = "\uD83D\uDD04 Ordenar por:";
            // 
            // cmbOrden
            // 
            cmbOrden.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrden.Font = new Font("Segoe UI", 10F);
            cmbOrden.Location = new Point(480, 56);
            cmbOrden.Name = "cmbOrden";
            cmbOrden.Size = new Size(200, 25);
            cmbOrden.TabIndex = 5;
            toolTip1.SetToolTip(cmbOrden, "Selecciona como quieres ordenar");
            cmbOrden.SelectedIndexChanged += cmbOrden_SelectedIndexChanged;
            // 
            // valoracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 470);
            Controls.Add(panelHeader);
            Controls.Add(dgvValoraciones);
            Controls.Add(btnEliminar);
            Name = "valoracion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Valoraciones";
            Load += valoracion_Load;
            ((System.ComponentModel.ISupportInitialize)dgvValoraciones).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblContador;
        
        // Controles de Busqueda y Filtro
        private System.Windows.Forms.Label lblBuscar;
        private ProyectoPelu.RoundedTextBox txtBuscar;
        private System.Windows.Forms.Label lblOrden;
        private System.Windows.Forms.ComboBox cmbOrden;

        private System.Windows.Forms.DataGridView dgvValoraciones;
        private System.Windows.Forms.Button btnEliminar;
        private ToolTip toolTip1;
    }
}
