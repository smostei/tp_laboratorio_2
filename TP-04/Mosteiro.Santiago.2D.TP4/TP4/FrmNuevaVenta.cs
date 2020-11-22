using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Data;

namespace TP4
{
    public partial class FrmNuevaVenta : Form
    {
        public FrmNuevaVenta()
        {
            InitializeComponent();
        }

        private void FrmNuevaVenta_Load(object sender, EventArgs e)
        {
            AlternarColorFilasDataGrid(dataGridProductos);
            dataGridProductos.DataSource = DataBaseHelper.GetListaItems<Producto>(true);
        }

        private void AlternarColorFilasDataGrid(DataGridView dataGrid)
        {
            dataGrid.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        /// <summary>
        /// Cuando se haga doble click en algún elemento del datagrid, se mappeara un objeto de tipo producto a un productoItem,
        /// de esa forma, insertaremos el registro de un productoItem a la tabla ProductosVendidos, y le actualizamos el stock
        /// de ese producto al producto que fue vendido.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Producto p = (Producto)dataGridProductos.CurrentRow.DataBoundItem;

            if(!(p is null))
            {
                try
                {
                    DataBaseHelper.InsertarItem<ProductoItem>(
                        new ProductoItem(
                            p.Nombre,
                            p.Tipo,
                            p.Precio
                        )
                    );

                    DataBaseHelper.ActualizarStockProducto(p.StockDisponible - 1, p.Id);

                    this.DialogResult = DialogResult.OK;
                } 
                catch(Exception exc)
                {
                    Console.WriteLine($"error: {exc.Message}");
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
