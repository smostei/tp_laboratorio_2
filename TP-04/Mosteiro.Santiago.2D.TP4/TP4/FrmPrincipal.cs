using System.Collections.Generic;
using System.Drawing;
using System;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Excepciones;
using Archivos;
using Data;
using System.Threading;

namespace TP4
{
    public delegate void delActualizarTxtBoxAnimacion(int x);
    public delegate void delMostrarMensaje(string mensaje);

    public partial class FrmPrincipal : Form
    {
        private Thread threadAnimacion;
        private List<ProductoItem> listaVentas;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Esta property me va a servir dentro de este form para devolver las ventas realizadas en un string
        /// </summary>
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
            //seteo la locación del titulo en 0x,56y para ir avanzando con la animacion
            tituloVentasLbl.Location = new Point(0, 56);
            threadAnimacion = new Thread(EmpezarAnimacionVentas);
            threadAnimacion.Start();

            //Mientras el hilo de la animación arrancó, en el principal setteamos la lista al datagrid
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

        /// <summary>
        /// Actualiza la lista de ventas que tenemos como atributo en este form con el DataBaseHelper
        /// </summary>
        /// <param name="listaVentas">información a settearle a la lista de ventas</param>
        private void RefrescarListaVentas(List<ProductoItem> listaVentas)
        {
            ventasGridView.DataSource = null;
            ventasGridView.DataSource = listaVentas;
            this.listaVentas = listaVentas;
        }

        /// <summary>
        /// Metodo que sirve para alternar los colores del datagridview
        /// </summary>
        /// <param name="dataGrid">datagrid que va a alternar sus filas con colores</param>
        private void AlternarColorFilasDataGrid(DataGridView dataGrid)
        {
            dataGrid.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        /// <summary>
        /// Metodo que hace un setup del formulario con la data que tenemos en el momento
        /// </summary>
        /// <param name="listaVentas">lista de ventas que necesitamos para establecer el setup</param>
        private void SetupFormPrincipal(List<ProductoItem> listaVentas)
        {
            bool hayVentas = listaVentas.Count > 0;

            if (hayVentas)
            {
                RefrescarListaVentas(listaVentas);
                AlternarColorFilasDataGrid(ventasGridView);
            }

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

            FrmListadoProductos formProductos = new FrmListadoProductos();
            formProductos.enviarMensaje += formProductos.MostrarMensaje;

            formProductos.Show();
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

        /// <summary>
        /// Guarda en un archivo txt las ventas actuales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Guarda en un archivo XML las ventas actuales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
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

        /// <summary>
        /// Metodo que apunta al thread de la animacion, va ser ejecutado cuando este arranque con su metodo Start
        /// </summary>
        private void EmpezarAnimacionVentas()
        {
            int posicionXInicial = 0;

            while (posicionXInicial < 294)
            {
                Thread.Sleep(20);

                delActualizarTxtBoxAnimacion delegadoActualizarTxt = new delActualizarTxtBoxAnimacion(ActualizarEjeXTituloVentas);

                if(tituloVentasLbl.InvokeRequired)
                {
                    tituloVentasLbl.BeginInvoke(delegadoActualizarTxt, posicionXInicial);
                } else
                {
                    ActualizarEjeXTituloVentas(posicionXInicial);
                }

                posicionXInicial++;
            }

        }

        /// <summary>
        /// Metodo que va a ejecutar el delegado para actualizar el eje X del titulo de ventas
        /// </summary>
        /// <param name="x"></param>
        private void ActualizarEjeXTituloVentas(int x)
        {
            tituloVentasLbl.Location = new Point(x, 56);
        }

        /// <summary>
        /// Cuando el formulario se cierre, si tenemos el hilo vivo, vamos a finalizar el proceso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(threadAnimacion.IsAlive)
            {
                threadAnimacion.Abort();
            }
        }
    }
}
