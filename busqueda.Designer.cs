namespace ProyectoPelu
{
    partial class Busqueda
    {
        private System.ComponentModel.IContainer components = null;

        // Esto soluciona el error de Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new System.Windows.Forms.Label();
            txtFiltro = new RoundedTextBox();
            dgvBusqueda = new System.Windows.Forms.DataGridView();
            btnSeleccionar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvBusqueda).BeginInit();
            SuspendLayout();

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(12, 15);
            lblTitulo.Text = "Buscador";

            label1.Text = "Filtrar:";
            label1.Location = new System.Drawing.Point(12, 50);
            label1.AutoSize = true;

            txtFiltro.Location = new System.Drawing.Point(12, 75);
            txtFiltro.Size = new System.Drawing.Size(460, 27);
            txtFiltro.TextChanged += txtFiltro_TextChanged;

            dgvBusqueda.AllowUserToAddRows = false;
            dgvBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvBusqueda.Location = new System.Drawing.Point(12, 115);
            dgvBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvBusqueda.Size = new System.Drawing.Size(460, 300);
            dgvBusqueda.CellDoubleClick += dgvBusqueda_CellDoubleClick;

            btnSeleccionar.BackColor = System.Drawing.SystemColors.HotTrack;
            btnSeleccionar.ForeColor = System.Drawing.Color.White;
            btnSeleccionar.Location = new System.Drawing.Point(260, 430);
            btnSeleccionar.Size = new System.Drawing.Size(100, 35);
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = false;
            btnSeleccionar.Click += btnSeleccionar_Click;

            btnCancelar.BackColor = System.Drawing.Color.Gray;
            btnCancelar.ForeColor = System.Drawing.Color.White;
            btnCancelar.Location = new System.Drawing.Point(372, 430);
            btnCancelar.Size = new System.Drawing.Size(100, 35);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;

            // ESTO SOLUCIONA LOS ERRORES DE CLIENTSIZE Y FORM_BORDER_STYLE
            this.ClientSize = new System.Drawing.Size(484, 481);
            this.Controls.Add(label1);
            this.Controls.Add(btnCancelar);
            this.Controls.Add(btnSeleccionar);
            this.Controls.Add(dgvBusqueda);
            this.Controls.Add(txtFiltro);
            this.Controls.Add(lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)dgvBusqueda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private RoundedTextBox txtFiltro;
        private System.Windows.Forms.DataGridView dgvBusqueda;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
    }
}
