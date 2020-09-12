using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraTP
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void cerrarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            num1TxtBox.Text = string.Empty;
            num2TxtBox.Text = string.Empty;
            resultadoLabel.Text = string.Empty;
            operadorCmbBox.SelectedIndex = -1;

            parseBinarioButton.Enabled = true;
            parseDecimalButton.Enabled = true;
        }

        private void operarButton_Click(object sender, EventArgs e)
        {
            double resultado = Calculadora.Operar(
                 new Numero(num1TxtBox.Text),
                 new Numero(num2TxtBox.Text),
                 operadorCmbBox.SelectedItem.ToString()
            );

            resultadoLabel.Text = resultado.ToString();

            parseBinarioButton.Enabled = true;
            parseDecimalButton.Enabled = true;
        }

        private void operadorCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            operarButton.Enabled = operadorCmbBox.SelectedIndex != -1;
        }

        private void parseBinarioButton_Click(object sender, EventArgs e)
        {
            parseBinarioButton.Enabled = false;
            parseDecimalButton.Enabled = true;

            Numero num = new Numero(resultadoLabel.Text);
            resultadoLabel.Text = num.DecimalBinario(resultadoLabel.Text);
        }

        private void parseDecimalButton_Click(object sender, EventArgs e)
        {
            parseDecimalButton.Enabled = false;
            parseBinarioButton.Enabled = true;

            Numero num = new Numero(resultadoLabel.Text);
            resultadoLabel.Text = num.BinarioDecimal(resultadoLabel.Text);
        }
    }
}



