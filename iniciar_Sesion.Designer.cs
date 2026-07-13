using System.Drawing;
using System.Windows.Forms;

namespace ProyectoPelu
{
    partial class iniciar_Sesion
    {
        private System.ComponentModel.IContainer components = null;

        // Controles
        private Panel panelBrand;
        private Label lblBrandTitle;
        private PictureBox pictureBox1;

        private Panel panelLogin;
        private Panel card;
        private Label lblTitulo;
        private Label LblUsuario;
        private Label LblContrasenya;
        private RoundedTextBox textBoxUsuario;
        private RoundedTextBox textBoxContrasenya;
        private RoundedButton btnIniciarSesion;

        // Iconos añadidos
        private PictureBox iconUsuario;
        private PictureBox iconContrasenya;
        private Label lblTogglePassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iniciar_Sesion));
            panelBrand = new Panel();
            pictureBox1 = new PictureBox();
            lblBrandTitle = new Label();
            panelLogin = new Panel();
            card = new Panel();
            btnIniciarSesion = new RoundedButton();
            textBoxContrasenya = new RoundedTextBox();
            iconContrasenya = new PictureBox();
            lblTogglePassword = new Label();
            LblContrasenya = new Label();
            textBoxUsuario = new RoundedTextBox();
            iconUsuario = new PictureBox();
            LblUsuario = new Label();
            lblTitulo = new Label();
            panelBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelLogin.SuspendLayout();
            card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconContrasenya).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconUsuario).BeginInit();
            SuspendLayout();
            // 
            // panelBrand
            // 
            panelBrand.BackColor = Color.FromArgb(240, 185, 60); // Base para gradient HSL(48, 90%, 57%)
            panelBrand.Controls.Add(pictureBox1);
            panelBrand.Controls.Add(lblBrandTitle);
            panelBrand.Dock = DockStyle.Left;
            panelBrand.Location = new Point(0, 0);
            panelBrand.Name = "panelBrand";
            panelBrand.Padding = new Padding(35, 45, 35, 30);
            panelBrand.Size = new Size(315, 450);
            panelBrand.TabIndex = 1;
            panelBrand.Paint += panelBrand_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(35, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(245, 183);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.BackColor = Color.Transparent;
            lblBrandTitle.Dock = DockStyle.Top;
            lblBrandTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblBrandTitle.ForeColor = Color.White;
            lblBrandTitle.Location = new Point(35, 45);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(245, 88);
            lblBrandTitle.TabIndex = 1;
            lblBrandTitle.Text = "Bernat Experience";
            lblBrandTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelLogin
            // 
            panelLogin.BackColor = Color.Transparent;
            panelLogin.Controls.Add(card);
            panelLogin.Dock = DockStyle.Fill;
            panelLogin.Location = new Point(315, 0);
            panelLogin.Name = "panelLogin";
            panelLogin.Padding = new Padding(52, 45, 52, 45);
            panelLogin.Size = new Size(473, 450);
            panelLogin.TabIndex = 0;
            panelLogin.Paint += panelLogin_Paint;
            // 
            // card
            // 
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Controls.Add(lblTogglePassword);
            card.Controls.Add(btnIniciarSesion);
            card.Controls.Add(textBoxContrasenya);
            card.Controls.Add(iconContrasenya);
            card.Controls.Add(LblContrasenya);
            card.Controls.Add(textBoxUsuario);
            card.Controls.Add(iconUsuario);
            card.Controls.Add(LblUsuario);
            card.Controls.Add(lblTitulo);
            card.Location = new Point(0, 0);
            card.Name = "card";
            card.Size = new Size(420, 316);
            card.TabIndex = 0;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(26, 210);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(350, 40);
            btnIniciarSesion.TabIndex = 2;
            btnIniciarSesion.Text = "Entrar";
            btnIniciarSesion.Click += btnIniciarSesion_Click_1;
            // 
            // textBoxContrasenya
            // 
            textBoxContrasenya.Location = new Point(26, 160);
            textBoxContrasenya.Name = "textBoxContrasenya";
            textBoxContrasenya.PasswordChar = '\u25CF';
            textBoxContrasenya.PaddingRight = 40;
            textBoxContrasenya.PlaceholderText = "Escribe aquí tu contraseña...";
            textBoxContrasenya.Size = new Size(350, 35);
            textBoxContrasenya.TabIndex = 1;
            // 
            // lblTogglePassword
            // 
            lblTogglePassword.BackColor = Color.White;
            lblTogglePassword.Cursor = Cursors.Hand;
            lblTogglePassword.Font = new Font("Segoe UI", 12F);
            lblTogglePassword.ForeColor = Color.Black;
            lblTogglePassword.Location = new Point(340, 164); // Positioned inside textBoxContrasenya area on the card
            lblTogglePassword.Name = "lblTogglePassword";
            lblTogglePassword.Size = new Size(30, 27);
            lblTogglePassword.TabIndex = 10;
            lblTogglePassword.Text = "\uD83D\uDC41";
            lblTogglePassword.TextAlign = ContentAlignment.MiddleCenter;
            lblTogglePassword.Click += lblTogglePassword_Click;
            // 
            // iconContrasenya
            // 
            iconContrasenya.Image = (Image)resources.GetObject("iconContrasenya.Image");
            iconContrasenya.Location = new Point(-100, -100);
            iconContrasenya.Name = "iconContrasenya";
            iconContrasenya.Size = new Size(24, 24);
            iconContrasenya.SizeMode = PictureBoxSizeMode.Zoom;
            iconContrasenya.TabIndex = 2;
            iconContrasenya.TabStop = false;
            // 
            // LblContrasenya
            // 
            LblContrasenya.AutoSize = true;
            LblContrasenya.Font = new Font("Segoe UI", 11F);
            LblContrasenya.Location = new Point(26, 138);
            LblContrasenya.Name = "LblContrasenya";
            LblContrasenya.Size = new Size(83, 20);
            LblContrasenya.TabIndex = 3;
            LblContrasenya.Text = "Contraseña";
            // 
            // textBoxUsuario
            // 
            textBoxUsuario.Location = new Point(26, 100);
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.PlaceholderText = "Escribe aquí tu nombre de usuario...";
            textBoxUsuario.Size = new Size(350, 35);
            textBoxUsuario.TabIndex = 0;
            // 
            // iconUsuario
            // 
            iconUsuario.Image = (Image)resources.GetObject("iconUsuario.Image");
            iconUsuario.Location = new Point(-100, -100);
            iconUsuario.Name = "iconUsuario";
            iconUsuario.Size = new Size(24, 24);
            iconUsuario.SizeMode = PictureBoxSizeMode.Zoom;
            iconUsuario.TabIndex = 5;
            iconUsuario.TabStop = false;
            // 
            // LblUsuario
            // 
            LblUsuario.AutoSize = true;
            LblUsuario.Font = new Font("Segoe UI", 11F);
            LblUsuario.Location = new Point(26, 78);
            LblUsuario.Name = "LblUsuario";
            LblUsuario.Size = new Size(59, 20);
            LblUsuario.TabIndex = 6;
            LblUsuario.Text = "Usuario";
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(200, 150, 40); // Dorado más oscuro para contraste
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(418, 52);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "Iniciar sesión";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iniciar_Sesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(788, 450);
            Controls.Add(panelLogin);
            Controls.Add(panelBrand);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "iniciar_Sesion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AppPeluquería - Acceso";
            Load += Form4_Load;
            panelBrand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelLogin.ResumeLayout(false);
            card.ResumeLayout(false);
            card.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconContrasenya).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconUsuario).EndInit();
            ResumeLayout(false);
        }
    }
}
