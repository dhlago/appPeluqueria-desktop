namespace ProyectoPelu
{
    partial class historial_Citas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnVerValoracion;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearchIcon;
        private RoundedTextBox txtBuscar;
        
        // Panel de Datos del Cliente
        private System.Windows.Forms.Panel pnlDatosCliente;
        private System.Windows.Forms.Label lblNombre;
        private RoundedTextBox txtNombreCliente;
        private System.Windows.Forms.Label lblApellidos;
        private RoundedTextBox txtApellidos;
        private System.Windows.Forms.Label lblUsuario;
        private RoundedTextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private RoundedTextBox txtEmail;
        private System.Windows.Forms.Label lblRol;
        private RoundedTextBox txtRol;
        private System.Windows.Forms.Label lblEspecialidad;
        private RoundedTextBox txtEspecialidad;
        private System.Windows.Forms.Label lblTelefono;
        private RoundedTextBox txtTelefono;
        private System.Windows.Forms.Label lblObservacion;
        private RoundedTextBox txtObservacion;
        private System.Windows.Forms.Label lblAlergenos;
        private RoundedTextBox txtAlergenos;
        private System.Windows.Forms.Label lblDireccion;
        private RoundedTextBox txtDireccion;
        private System.Windows.Forms.Label lblHistorialHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnVerValoracion = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.txtBuscar = new RoundedTextBox();
            this.pnlDatosCliente = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombreCliente = new RoundedTextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new RoundedTextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsername = new RoundedTextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new RoundedTextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.txtRol = new RoundedTextBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtEspecialidad = new RoundedTextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new RoundedTextBox();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.txtObservacion = new RoundedTextBox();
            this.lblAlergenos = new System.Windows.Forms.Label();
            this.txtAlergenos = new RoundedTextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new RoundedTextBox();
            this.lblHistorialHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.pnlDatosCliente.SuspendLayout();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 32);
            this.lblTitulo.Text = "Historial de Citas";

            // pnlSearch
            this.pnlSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearch.Controls.Add(this.lblSearchIcon);
            this.pnlSearch.Controls.Add(this.txtBuscar);
            this.pnlSearch.Location = new System.Drawing.Point(540, 380);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(425, 40);
            this.pnlSearch.TabIndex = 2;

            // lblSearchIcon
            this.lblSearchIcon.AutoSize = true;
            this.lblSearchIcon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearchIcon.ForeColor = System.Drawing.Color.Gray;
            this.lblSearchIcon.Location = new System.Drawing.Point(10, 10);
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.Size = new System.Drawing.Size(70, 19);
            this.lblSearchIcon.Text = "🔍 Buscar:";

            // txtBuscar
            this.txtBuscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.Location = new System.Drawing.Point(90, 6);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(325, 28);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            // pnlDatosCliente
            this.pnlDatosCliente.BackColor = System.Drawing.Color.White;
            this.pnlDatosCliente.Controls.Add(this.lblNombre);
            this.pnlDatosCliente.Controls.Add(this.txtNombreCliente);
            this.pnlDatosCliente.Controls.Add(this.lblApellidos);
            this.pnlDatosCliente.Controls.Add(this.txtApellidos);
            this.pnlDatosCliente.Controls.Add(this.lblUsuario);
            this.pnlDatosCliente.Controls.Add(this.txtUsername);
            this.pnlDatosCliente.Controls.Add(this.lblEmail);
            this.pnlDatosCliente.Controls.Add(this.txtEmail);
            this.pnlDatosCliente.Controls.Add(this.lblRol);
            this.pnlDatosCliente.Controls.Add(this.txtRol);
            this.pnlDatosCliente.Controls.Add(this.lblEspecialidad);
            this.pnlDatosCliente.Controls.Add(this.txtEspecialidad);
            this.pnlDatosCliente.Controls.Add(this.lblTelefono);
            this.pnlDatosCliente.Controls.Add(this.txtTelefono);
            this.pnlDatosCliente.Controls.Add(this.lblObservacion);
            this.pnlDatosCliente.Controls.Add(this.txtObservacion);
            this.pnlDatosCliente.Controls.Add(this.lblAlergenos);
            this.pnlDatosCliente.Controls.Add(this.txtAlergenos);
            this.pnlDatosCliente.Controls.Add(this.lblDireccion);
            this.pnlDatosCliente.Controls.Add(this.txtDireccion);
            this.pnlDatosCliente.Location = new System.Drawing.Point(25, 60);
            this.pnlDatosCliente.Name = "pnlDatosCliente";
            this.pnlDatosCliente.Size = new System.Drawing.Size(940, 310);
            this.pnlDatosCliente.TabIndex = 0;
            this.pnlDatosCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            // Un borde sutil se puede simular con el color de fondo del formulario, 
            // pero vamos a asegurar un diseño limpio.

            // Configuración de dimensiones y columnas para el diseño tipo "Contact Card"
            int labelWidth = 140;
            int editWidth = 280;
            int rowHeight = 50;
            int col1LabelX = 20;
            int col1EditX = 160;
            int col2LabelX = 490;
            int col2EditX = 630;
            
            // Bloque 1: Información Personal (Fila 0 y 1)
            this.lblNombre.Location = new System.Drawing.Point(col1LabelX, 15);
            this.lblNombre.Size = new System.Drawing.Size(labelWidth, 25);
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtNombreCliente.Location = new System.Drawing.Point(col1EditX, 12);
            this.txtNombreCliente.Size = new System.Drawing.Size(editWidth, 32);
            this.txtNombreCliente.ReadOnly = true;

            this.lblApellidos.Location = new System.Drawing.Point(col2LabelX, 15);
            this.lblApellidos.Size = new System.Drawing.Size(labelWidth, 25);
            this.lblApellidos.Text = "Apellidos:";
            this.lblApellidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblApellidos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtApellidos.Location = new System.Drawing.Point(col2EditX, 12);
            this.txtApellidos.Size = new System.Drawing.Size(editWidth, 32);
            this.txtApellidos.ReadOnly = true;

            this.lblUsuario.Location = new System.Drawing.Point(col1LabelX, 15 + rowHeight);
            this.lblUsuario.Size = new System.Drawing.Size(labelWidth, 25);
            this.lblUsuario.Text = "Username:";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtUsername.Location = new System.Drawing.Point(col1EditX, 12 + rowHeight);
            this.txtUsername.Size = new System.Drawing.Size(editWidth, 32);
            this.txtUsername.ReadOnly = true;

            this.lblRol.Location = new System.Drawing.Point(col2LabelX, 15 + rowHeight);
            this.lblRol.Size = new System.Drawing.Size(labelWidth, 25);
            this.lblRol.Text = "Tipo:";
            this.lblRol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtRol.Location = new System.Drawing.Point(col2EditX, 12 + rowHeight);
            this.txtRol.Size = new System.Drawing.Size(editWidth, 32);
            this.txtRol.ReadOnly = true;

            // Bloque 2: Contacto (Fila 2 y 3)
            this.lblTelefono.Location = new System.Drawing.Point(col1LabelX, 15 + rowHeight * 2);
            this.lblTelefono.Size = new System.Drawing.Size(labelWidth, 25);
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtTelefono.Location = new System.Drawing.Point(col1EditX, 12 + rowHeight * 2);
            this.txtTelefono.Size = new System.Drawing.Size(editWidth, 32);
            this.txtTelefono.ReadOnly = true;

            this.lblEmail.Location = new System.Drawing.Point(col2LabelX, 15 + rowHeight * 2);
            this.lblEmail.Size = new System.Drawing.Size(labelWidth, 25);
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtEmail.Location = new System.Drawing.Point(col2EditX, 12 + rowHeight * 2);
            this.txtEmail.Size = new System.Drawing.Size(editWidth, 32);
            this.txtEmail.ReadOnly = true;

            this.lblDireccion.Location = new System.Drawing.Point(col1LabelX, 15 + rowHeight * 3);
            this.lblDireccion.Size = new System.Drawing.Size(labelWidth, 25);
            this.lblDireccion.Text = "Dirección:";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtDireccion.Location = new System.Drawing.Point(col1EditX, 12 + rowHeight * 3);
            this.txtDireccion.Size = new System.Drawing.Size(col2EditX + editWidth - col1EditX, 32); // Full width
            this.txtDireccion.ReadOnly = true;

            // Bloque 3: Notas y Detalles (Fila 4 y 5)
            this.lblAlergenos.Location = new System.Drawing.Point(col1LabelX, 15 + rowHeight * 4);
            this.lblAlergenos.Size = new System.Drawing.Size(labelWidth, 25);
            this.lblAlergenos.Text = "Alérgenos:";
            this.lblAlergenos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAlergenos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtAlergenos.Location = new System.Drawing.Point(col1EditX, 12 + rowHeight * 4);
            this.txtAlergenos.Size = new System.Drawing.Size(editWidth, 32);
            this.txtAlergenos.ReadOnly = true;

            this.lblEspecialidad.Location = new System.Drawing.Point(col2LabelX, 15 + rowHeight * 4);
            this.lblEspecialidad.Size = new System.Drawing.Size(labelWidth, 25);
            this.lblEspecialidad.Text = "Especialidad:";
            this.lblEspecialidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtEspecialidad.Location = new System.Drawing.Point(col2EditX, 12 + rowHeight * 4);
            this.txtEspecialidad.Size = new System.Drawing.Size(editWidth, 32);
            this.txtEspecialidad.ReadOnly = true;

            this.lblObservacion.Location = new System.Drawing.Point(col1LabelX, 15 + rowHeight * 5);
            this.lblObservacion.Size = new System.Drawing.Size(labelWidth, 25);
            this.lblObservacion.Text = "Observación:";
            this.lblObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblObservacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtObservacion.Location = new System.Drawing.Point(col1EditX, 12 + rowHeight * 5);
            this.txtObservacion.Size = new System.Drawing.Size(col2EditX + editWidth - col1EditX, 32); // Full width
            this.txtObservacion.ReadOnly = true;

            // lblHistorialHeader
            this.lblHistorialHeader.AutoSize = true;
            this.lblHistorialHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHistorialHeader.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.lblHistorialHeader.Location = new System.Drawing.Point(25, 385);
            this.lblHistorialHeader.Name = "lblHistorialHeader";
            this.lblHistorialHeader.Size = new System.Drawing.Size(200, 25);
            this.lblHistorialHeader.Text = "Historial de Citas";

            // dgvHistorial
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(25, 420);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(940, 320);
            this.dgvHistorial.TabIndex = 1;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // btnCerrar
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(845, 770);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 40);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // btnVerValoracion
            this.btnVerValoracion.BackColor = System.Drawing.Color.FromArgb(0, 150, 136); // Teal moderno
            this.btnVerValoracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerValoracion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVerValoracion.ForeColor = System.Drawing.Color.White;
            this.btnVerValoracion.Location = new System.Drawing.Point(700, 770);
            this.btnVerValoracion.Name = "btnVerValoracion";
            this.btnVerValoracion.Size = new System.Drawing.Size(130, 40);
            this.btnVerValoracion.TabIndex = 4;
            this.btnVerValoracion.Text = "Ver Valoración";
            this.btnVerValoracion.UseVisualStyleBackColor = false;
            this.btnVerValoracion.Click += new System.EventHandler(this.btnVerValoracion_Click);

            // historial_Citas
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(1000, 830);
            this.Controls.Add(this.pnlDatosCliente);
            this.Controls.Add(this.lblHistorialHeader);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnVerValoracion);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "historial_Citas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial de Citas";
            this.Load += new System.EventHandler(this.historial_Citas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
