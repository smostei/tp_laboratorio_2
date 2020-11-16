using System.Drawing;
using System.Windows.Forms;

namespace TP4
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, System.EventArgs e)
        {
            refrescarListaCompras();
            AlternarColorFilasDataGrid(ventasGridView);
        }

        private void productoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            //Ir al form para crear nuevo producto
        }

        private void salirToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            //Salir de la app
        }

        private void refrescarListaCompras()
        {
            ventasGridView.DataSource = null;
            ventasGridView.DataSource = DataBaseHelper.GetListaProductos();
        }

        private void AlternarColorFilasDataGrid(DataGridView dataGrid)
        {
            dataGrid.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }
    }
}
