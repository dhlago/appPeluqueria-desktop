namespace appPeluqueriaDesktop
{
    partial class info_Valoracion
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblPuntuacion = new System.Windows.Forms.Label();
            this.lblTratoPersonal = new System.Windows.Forms.Label();
            this.lblDesarrolloServicio = new System.Windows.Forms.Label();
            this.lblClaridadComunicacion = new System.Windows.Forms.Label();
            this.lblLimpiezaOrganizacion = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNoImagen = new System.Windows.Forms.Label();
            this.panelDetalles = new System.Windows.Forms.Panel();
            
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.panelDetalles.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(240, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Detalle de Valoración";

            // 
            // panelDetalles
            // 
            this.panelDetalles.BackColor = System.Drawing.Color.White;
            this.panelDetalles.Controls.Add(this.lblNombreCliente);
            this.panelDetalles.Controls.Add(this.lblServicio);
            this.panelDetalles.Controls.Add(this.lblFecha);
            this.panelDetalles.Controls.Add(this.lblPuntuacion);
            this.panelDetalles.Controls.Add(this.lblTratoPersonal);
            this.panelDetalles.Controls.Add(this.lblDesarrolloServicio);
            this.panelDetalles.Controls.Add(this.lblClaridadComunicacion);
            this.panelDetalles.Controls.Add(this.lblLimpiezaOrganizacion);
            this.panelDetalles.Controls.Add(this.txtComentario);
            this.panelDetalles.Location = new System.Drawing.Point(25, 70);
            this.panelDetalles.Name = "panelDetalles";
            this.panelDetalles.Size = new System.Drawing.Size(350, 480);
            this.panelDetalles.TabIndex = 1;

            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNombreCliente.Location = new System.Drawing.Point(15, 15);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(150, 21);
            this.lblNombreCliente.TabIndex = 0;
            this.lblNombreCliente.Text = "Nombre Cliente";

            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblServicio.ForeColor = System.Drawing.Color.Gray;
            this.lblServicio.Location = new System.Drawing.Point(15, 45);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(120, 19);
            this.lblServicio.TabIndex = 1;
            this.lblServicio.Text = "Nombre Servicio";

            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.ForeColor = System.Drawing.Color.Gray;
            this.lblFecha.Location = new System.Drawing.Point(15, 70);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(100, 15);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha Valoración";

            // 
            // lblPuntuacion
            // 
            this.lblPuntuacion.AutoSize = true;
            this.lblPuntuacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPuntuacion.ForeColor = System.Drawing.Color.FromArgb(241, 123, 35);
            this.lblPuntuacion.Location = new System.Drawing.Point(15, 100);
            this.lblPuntuacion.Name = "lblPuntuacion";
            this.lblPuntuacion.Size = new System.Drawing.Size(120, 21);
            this.lblPuntuacion.TabIndex = 3;
            this.lblPuntuacion.Text = "General: ⭐⭐⭐⭐⭐";

            // 
            // lblTratoPersonal
            // 
            this.lblTratoPersonal.AutoSize = true;
            this.lblTratoPersonal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTratoPersonal.Location = new System.Drawing.Point(15, 130);
            this.lblTratoPersonal.Name = "lblTratoPersonal";
            this.lblTratoPersonal.Size = new System.Drawing.Size(120, 19);
            this.lblTratoPersonal.TabIndex = 4;
            this.lblTratoPersonal.Text = "Trato: ⭐⭐⭐⭐⭐";

            // 
            // lblDesarrolloServicio
            // 
            this.lblDesarrolloServicio.AutoSize = true;
            this.lblDesarrolloServicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDesarrolloServicio.Location = new System.Drawing.Point(15, 160);
            this.lblDesarrolloServicio.Name = "lblDesarrolloServicio";
            this.lblDesarrolloServicio.Size = new System.Drawing.Size(150, 19);
            this.lblDesarrolloServicio.TabIndex = 5;
            this.lblDesarrolloServicio.Text = "Desarrollo: ⭐⭐⭐⭐⭐";

            // 
            // lblClaridadComunicacion
            // 
            this.lblClaridadComunicacion.AutoSize = true;
            this.lblClaridadComunicacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClaridadComunicacion.Location = new System.Drawing.Point(15, 190);
            this.lblClaridadComunicacion.Name = "lblClaridadComunicacion";
            this.lblClaridadComunicacion.Size = new System.Drawing.Size(150, 19);
            this.lblClaridadComunicacion.TabIndex = 6;
            this.lblClaridadComunicacion.Text = "Comunicación: ⭐⭐⭐⭐⭐";

            // 
            // lblLimpiezaOrganizacion
            // 
            this.lblLimpiezaOrganizacion.AutoSize = true;
            this.lblLimpiezaOrganizacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLimpiezaOrganizacion.Location = new System.Drawing.Point(15, 220);
            this.lblLimpiezaOrganizacion.Name = "lblLimpiezaOrganizacion";
            this.lblLimpiezaOrganizacion.Size = new System.Drawing.Size(150, 19);
            this.lblLimpiezaOrganizacion.TabIndex = 7;
            this.lblLimpiezaOrganizacion.Text = "Limpieza: ⭐⭐⭐⭐⭐";

            // 
            // txtComentario
            // 
            this.txtComentario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComentario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtComentario.Location = new System.Drawing.Point(15, 260);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.ReadOnly = true;
            this.txtComentario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComentario.Size = new System.Drawing.Size(320, 200);
            this.txtComentario.TabIndex = 8;
            this.txtComentario.Text = "Comentario del usuario...";

            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagen.BackColor = System.Drawing.Color.Gainsboro;
            this.pbImagen.Location = new System.Drawing.Point(400, 70);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(350, 350);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagen.TabIndex = 2;
            this.pbImagen.TabStop = false;

            // 
            // lblNoImagen
            // 
            this.lblNoImagen.AutoSize = true;
            this.lblNoImagen.BackColor = System.Drawing.Color.Gainsboro;
            this.lblNoImagen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblNoImagen.ForeColor = System.Drawing.Color.Gray;
            this.lblNoImagen.Location = new System.Drawing.Point(510, 230);
            this.lblNoImagen.Name = "lblNoImagen";
            this.lblNoImagen.Size = new System.Drawing.Size(140, 19);
            this.lblNoImagen.TabIndex = 3;
            this.lblNoImagen.Text = "Sin imagen adjunta";
            this.lblNoImagen.Visible = false;

            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(241, 123, 35);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(630, 560);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 40);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCerrar_Click);

            // 
            // info_Valoracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(780, 620);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblNoImagen);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.panelDetalles);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "info_Valoracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de Valoración";
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.panelDetalles.ResumeLayout(false);
            this.panelDetalles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelDetalles;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblPuntuacion;
        private System.Windows.Forms.Label lblTratoPersonal;
        private System.Windows.Forms.Label lblDesarrolloServicio;
        private System.Windows.Forms.Label lblClaridadComunicacion;
        private System.Windows.Forms.Label lblLimpiezaOrganizacion;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Label lblNoImagen;
        private System.Windows.Forms.Button btnCancelar;
    }
}
