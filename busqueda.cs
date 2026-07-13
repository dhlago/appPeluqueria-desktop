using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoPelu
{
    // El ": Form" es VITAL para que reconozca ClientSize, SuspendLayout, etc.
    public partial class Busqueda : Form
    {
        public object ItemSeleccionado { get; private set; }
        private IEnumerable<object> _listaOriginal;

        public Busqueda(string titulo, IEnumerable lista)
        {
            InitializeComponent();
            this.Text = titulo;
            lblTitulo.Text = titulo;

            _listaOriginal = lista.Cast<object>().ToList();
            ActualizarGrid(_listaOriginal);
        }

        private void ActualizarGrid(IEnumerable<object> lista)
        {
            dgvBusqueda.DataSource = null;
            dgvBusqueda.DataSource = lista.ToList();

            if (dgvBusqueda.Columns.Count > 0)
            {
                if (dgvBusqueda.Columns.Contains("Id")) dgvBusqueda.Columns["Id"].Visible = false;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.ToLower();
            var filtrada = _listaOriginal.Where(item =>
                item.ToString().ToLower().Contains(filtro) ||
                item.GetType().GetProperties().Any(p =>
                    p.GetValue(item)?.ToString().ToLower().Contains(filtro) == true)
            ).ToList();
            ActualizarGrid(filtrada);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e) => SeleccionarYSalir();
        private void dgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0) SeleccionarYSalir(); }

        private void SeleccionarYSalir()
        {
            if (dgvBusqueda.CurrentRow != null)
            {
                ItemSeleccionado = dgvBusqueda.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
    }
}
