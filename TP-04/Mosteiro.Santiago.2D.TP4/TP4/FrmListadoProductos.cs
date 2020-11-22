using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Data;

namespace TP4
{
    public partial class FrmListadoProductos : Form
    {
        private const string MENSAJE = "Bienvenido, estos son los productos disponibles!"; 
        public event delMostrarMensaje enviarMensaje;

        public FrmListadoProductos()
        {
            InitializeComponent();
        }

        private void FrmListadoProductos_Load(object sender, EventArgs e)
        {
            enviarMensaje.Invoke(MENSAJE);

            AlternarColorFilasDataGrid(dataGridProductos);
            dataGridProductos.DataSource = DataBaseHelper.GetListaItems<Producto>();
        }

        private void AlternarColorFilasDataGrid(DataGridView dataGrid)
        {
            dataGrid.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(
              mensaje,
              "Productos disponibles",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information
            );
        }
    }
}
