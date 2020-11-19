using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace TP4
{
    public partial class FrmListadoProductos : Form
    {
        public FrmListadoProductos()
        {
            InitializeComponent();
        }

        private void FrmListadoProductos_Load(object sender, EventArgs e)
        {
            AlternarColorFilasDataGrid(dataGridProductos);
            dataGridProductos.DataSource = DataBaseHelper.GetListaItems<Producto>();
        }

        private void AlternarColorFilasDataGrid(DataGridView dataGrid)
        {
            dataGrid.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }
    }
}
