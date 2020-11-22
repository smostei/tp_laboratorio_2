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
using Excepciones;
using Data;

namespace TP4
{
    public partial class FrmNuevoProducto : Form
    {
        public FrmNuevoProducto()
        {
            InitializeComponent();
        }

        private void FrmNuevoProducto_Load(object sender, EventArgs e)
        {
            cmbTipoProductos.DataSource = Enum.GetValues(typeof(ProductoItem.TipoProducto));
            cmbTipoProductos.SelectedIndex = -1;
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            float auxPrecio;
            float.TryParse(precioTxtBox.Text, out auxPrecio);

            int auxStock;
            int.TryParse(stockTxtBox.Text, out auxStock);

            if (auxPrecio == 0 || auxStock == 0)
            {
                MessageBox.Show(
                        "Fijate que todos los valores estén bien puestos",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                );

                return;
            }

            Producto producto = new Producto(
                 nombreTxtBox.Text,
                 (ProductoItem.TipoProducto)Enum.Parse(typeof(ProductoItem.TipoProducto), cmbTipoProductos.SelectedValue.ToString()),
                 auxPrecio,
                 auxStock
            );

            try
            {
                if (producto == DataBaseHelper.GetListaItems<Producto>())
                {
                    throw new ProductoRepetidoException("El producto ya existe en la base de datos");
                }
                else
                {
                    DataBaseHelper.InsertarItem(producto);
                    this.DialogResult = DialogResult.OK;
                }
            } catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                this.DialogResult = DialogResult.Cancel;
            }

        }

        /// <summary>
        /// booleano que determina la activacion del botón para agregar el producto a la tabla Productos.
        /// </summary>
        /// <returns></returns>
        private bool activarBotonContinuar()
        {
            return !(
                cmbTipoProductos.SelectedIndex == -1
                || String.IsNullOrWhiteSpace(nombreTxtBox.Text)
                || String.IsNullOrWhiteSpace(precioTxtBox.Text)
                || String.IsNullOrWhiteSpace(stockTxtBox.Text)
            );
        }

        /// <summary>
        /// Este listener se va a triggerear cada vez que cualquiera de las vistas actualice su texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oyenteTextosCambiados(object sender, EventArgs e)
        {
            agregarButton.Enabled = activarBotonContinuar();
        }

        /// <summary>
        /// Este listener se va a triggerear cada vez que cualquiera de las vistas salga de su foco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oyenteFocoSalidaTextos(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();
        }

    }
}
