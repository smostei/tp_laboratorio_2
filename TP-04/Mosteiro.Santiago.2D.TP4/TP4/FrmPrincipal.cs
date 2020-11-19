using System.Collections.Generic;
using System.Drawing;
using System;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Excepciones;
using Archivos;
using Data;

namespace TP4
{
    public partial class FrmPrincipal : Form
    {
        private List<ProductoItem> listaVentas;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private string ListaVentas
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                foreach(ProductoItem p in listaVentas)
                {
                    sb.AppendLine(p.ToString());
                }

                return sb.ToString();
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            SetupFormPrincipal(DataBaseHelper.GetListaItems<ProductoItem>());
        }
    
        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (new FrmNuevoProducto().ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(
                        "Producto agregado con exito!",
                        "Nuevo producto"
                    );
                }
                else
                {
                    MostrarMensajeError(
                        "Hubo un error al agregar un produdcto",
                        "Nuevo producto"
                    );
                }
            } 
            catch(ProductoRepetidoException exc)
            {
                Console.WriteLine(exc.Message);
                MostrarMensajeError(
                    "Ya existe un producto con ese nombre",
                    "Error nuevo producto"
                );
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Desea salir?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void RefrescarListaVentas(List<ProductoItem> listaVentas)
        {
            ventasGridView.DataSource = null;
            ventasGridView.DataSource = listaVentas;
            this.listaVentas = listaVentas;
        }

        private void AlternarColorFilasDataGrid(DataGridView dataGrid)
        {
            dataGrid.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        private void SetupFormPrincipal(List<ProductoItem> listaVentas)
        {
            bool hayVentas = listaVentas.Count > 0;

            if (hayVentas)
            {
                RefrescarListaVentas(listaVentas);
                AlternarColorFilasDataGrid(ventasGridView);
            }

            tituloVentasLbl.Visible = hayVentas;
            emptyStateLbl.Visible = !hayVentas;
            ventasXmlButton.Enabled = hayVentas;
            ventasTxtButton.Enabled = hayVentas;
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(new FrmNuevaVenta().ShowDialog() == DialogResult.OK)
            {
                MostrarMensaje("Venta realizada con exito!", "Venta");

                listaVentas = DataBaseHelper.GetListaItems<ProductoItem>();
                SetupFormPrincipal(listaVentas);
            } 
            else
            {
                MostrarMensajeError("Ocurrió un error al realizar la venta", "Error venta");
            }
        }

        private void verProductosDisponiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmListadoProductos().Show();
        }

        private void MostrarMensajeError(string mensaje, string titulo)
        {
            MessageBox.Show(
                mensaje,
                titulo,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
                
        }

        private void MostrarMensaje(string mensaje, string titulo)
        {
            MessageBox.Show(
                mensaje,
                titulo,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

        }

        private void ventasTxtButton_Click(object sender, EventArgs e)
        {
            ArchivoTexto archivo = new ArchivoTexto();

            try
            {
                archivo.Guardar(ListaVentas);
                MostrarMensaje(
                    "Archivo de texto descargado con exito en la ruta del proyecto!",
                    "Descarga finalizada"
                );

            } catch(ArchivosException exc)
            {
                Console.WriteLine(exc.Message);
                MostrarMensajeError(
                    "Ocurrió un error al querer guardar las ventas en archivo de texto",
                    "Error archivo de texto"
                );

            }
        }

        private void ventasXmlButton_Click(object sender, EventArgs e)
        {
            ArchivoXml<List<ProductoItem>> archivo = new ArchivoXml<List<ProductoItem>>();

            try
            {
                archivo.Guardar(listaVentas);
                MostrarMensaje(
                    "Archivo XML descargado con exito en la ruta del proyecto!",
                    "Descarga finalizada"
                );
            }
            catch (ArchivosException exc)
            {
                Console.WriteLine(exc.Message);
                MostrarMensajeError(
                    "Ocurrió un error al querer guardar las ventas en archivo XML",
                    "Error archivo XML"
                );
            }
        }

    }
}
